﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using VerFarm.Kernel.Data.Entity;

namespace VerFarm.Kernel.Data.Audit
{
    public class AuditTrailFactory
    {
        private DbContext context;

        public AuditTrailFactory(DbContext context)
        {
            this.context = context;
        }

        internal IEnumerable<ChangeLog> GetAudits(DbEntityEntry entry)
        {
            ChangeLog audit = new ChangeLog();
            audit.UserName = "Current User";
            audit.EntityName = GetTableName(entry);
            audit.PrimaryKeyValue = GetKeyValue(entry);
            audit.PropertyName = "";
            audit.DateChanged = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                var newValues = new StringBuilder();
                SetAddedProperties(entry, newValues);
                audit.NewValue = newValues.ToString();
                audit.ActionId = (int)AuditActions.Insert;
            }
            else if (entry.State == EntityState.Deleted)
            {
                var oldValues = new StringBuilder();
                SetDeletedProperties(entry, oldValues);
                audit.OldValue = oldValues.ToString();
                audit.ActionId = (int)AuditActions.Delete;
            }
            else if (entry.State == EntityState.Modified)
            {
                var audits = new List<ChangeLog>();

                DbPropertyValues dbValues = entry.GetDatabaseValues();
                foreach (var propertyName in entry.OriginalValues.PropertyNames)
                {
                    var oldVal = dbValues[propertyName];
                    var newVal = entry.CurrentValues[propertyName];
                    if (oldVal != null && newVal != null && !Equals(oldVal, newVal))
                    {                       
                        if (entry.Property(propertyName).IsModified == false)
                        {
                            continue;
                        }
                        var a = new ChangeLog();
                        a.UserName = "Current User";
                        a.DateChanged = DateTime.Now;
                        a.EntityName = audit.EntityName;
                        a.NewValue = newVal.ToString();
                        a.OldValue = oldVal.ToString();
                        a.PropertyName = propertyName;
                        a.PrimaryKeyValue = GetKeyValue(entry);
                        a.ActionId = (int)AuditActions.Update;
                        audits.Add(a);
                    }
                }
                return audits;
            }
            else
            {
                return new List<ChangeLog>();
            }

            return new List<ChangeLog>() { audit };
        }

        private void SetAddedProperties(DbEntityEntry entry, StringBuilder newData)
        {
            foreach (var propertyName in entry.CurrentValues.PropertyNames)
            {
                var newVal = entry.CurrentValues[propertyName];
                if (newVal != null)
                {
                    newData.AppendFormat("{0}={1} || ", propertyName, newVal);
                }
            }
            if (newData.Length > 0)
                newData = newData.Remove(newData.Length - 3, 3);
        }

        private void SetDeletedProperties(DbEntityEntry entry, StringBuilder oldData)
        {
            DbPropertyValues dbValues = entry.GetDatabaseValues();
            foreach (var propertyName in dbValues.PropertyNames)
            {
                var oldVal = dbValues[propertyName];
                if (oldVal != null)
                {
                    oldData.AppendFormat("{0}={1} || ", propertyName, oldVal);
                }
            }
            if (oldData.Length > 0)
                oldData = oldData.Remove(oldData.Length - 3, 3);
        }

        private void SetModifiedProperties(DbEntityEntry entry, StringBuilder oldData, StringBuilder newData)
        {
            DbPropertyValues dbValues = entry.GetDatabaseValues();
            foreach (var propertyName in entry.OriginalValues.PropertyNames)
            {
                var oldVal = dbValues[propertyName];
                var newVal = entry.CurrentValues[propertyName];
                if (oldVal != null && newVal != null && !Equals(oldVal, newVal))
                {
                    newData.AppendFormat("{0}={1} || ", propertyName, newVal);
                    oldData.AppendFormat("{0}={1} || ", propertyName, oldVal);
                }
            }
            if (oldData.Length > 0)
                oldData = oldData.Remove(oldData.Length - 3, 3);
            if (newData.Length > 0)
                newData = newData.Remove(newData.Length - 3, 3);
        }

        private string GetKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            string id = "0";
            if (objectStateEntry.EntityKey.EntityKeyValues != null)
                id = objectStateEntry.EntityKey.EntityKeyValues[0].Value.ToString();

            return id;
        }

        private string GetTableName(DbEntityEntry dbEntry)
        {
            TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), true).SingleOrDefault() as TableAttribute;
            string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;
            return tableName;
        }

        private EntityObject CloneEntity(EntityObject obj)
        {
            DataContractSerializer dcSer = new DataContractSerializer(obj.GetType());
            MemoryStream memoryStream = new MemoryStream();

            dcSer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;

            EntityObject newObject = (EntityObject)dcSer.ReadObject(memoryStream);
            return newObject;
        }
    }
}
