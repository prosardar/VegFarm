﻿using DevExpress.XtraBars.Ribbon;
using System.Windows.Forms;
using VegFarm.Data;

namespace VegFarm.Forms
{
    public class CommunicationWithMainForm
    {
        public Form MainForm { get; set; }

        public RibbonControl RibbonControl { get; set; }

        public DataManager DataManager { get; set; }


        public CommunicationWithMainForm(Form mainForm)
        {
            MainForm = mainForm;
            DataManager = new DataManager();

            var ribbonForm = mainForm as IMainRibbonForm;
            RibbonControl = ribbonForm.GetRibbonControl();
        }
    }
}