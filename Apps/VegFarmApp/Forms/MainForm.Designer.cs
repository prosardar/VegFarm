namespace VegFarm.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.ExitBarItem = new DevExpress.XtraBars.BarButtonItem();
            this.OrgStructureBarItem = new DevExpress.XtraBars.BarButtonItem();
            this.SaveBarItem = new DevExpress.XtraBars.BarButtonItem();
            this.RefreshBarItem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonDropDownControl = this.applicationMenu;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.OrgStructureBarItem,
            this.SaveBarItem,
            this.RefreshBarItem,
            this.ExitBarItem});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 1;
            this.ribbonControl.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.Size = new System.Drawing.Size(1038, 143);
            this.ribbonControl.StatusBar = this.ribbonStatusBar1;
            // 
            // applicationMenu
            // 
            this.applicationMenu.ItemLinks.Add(this.ExitBarItem);
            this.applicationMenu.MenuAppearance.HeaderItemAppearance.Options.UseTextOptions = true;
            this.applicationMenu.MenuAppearance.HeaderItemAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.applicationMenu.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesText;
            this.applicationMenu.Name = "applicationMenu";
            this.applicationMenu.Ribbon = this.ribbonControl;
            // 
            // ExitBarItem
            // 
            this.ExitBarItem.Caption = "Выход";
            this.ExitBarItem.Glyph = ((System.Drawing.Image)(resources.GetObject("ExitBarItem.Glyph")));
            this.ExitBarItem.Id = 5;
            this.ExitBarItem.Name = "ExitBarItem";
            this.ExitBarItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExitBarItem_ItemClick);
            // 
            // OrgStructureBarItem
            // 
            this.OrgStructureBarItem.Caption = "Орг структура";
            this.OrgStructureBarItem.Glyph = ((System.Drawing.Image)(resources.GetObject("OrgStructureBarItem.Glyph")));
            this.OrgStructureBarItem.Id = 2;
            this.OrgStructureBarItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("OrgStructureBarItem.LargeGlyph")));
            this.OrgStructureBarItem.Name = "OrgStructureBarItem";
            this.OrgStructureBarItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OrgStructureBarItem_ItemClick);
            // 
            // SaveBarItem
            // 
            this.SaveBarItem.Caption = "Сохранить";
            this.SaveBarItem.Glyph = ((System.Drawing.Image)(resources.GetObject("SaveBarItem.Glyph")));
            this.SaveBarItem.Id = 3;
            this.SaveBarItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("SaveBarItem.LargeGlyph")));
            this.SaveBarItem.Name = "SaveBarItem";
            this.SaveBarItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveBarItem_ItemClick);
            // 
            // RefreshBarItem
            // 
            this.RefreshBarItem.Caption = "Обновить";
            this.RefreshBarItem.Glyph = ((System.Drawing.Image)(resources.GetObject("RefreshBarItem.Glyph")));
            this.RefreshBarItem.Id = 4;
            this.RefreshBarItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("RefreshBarItem.LargeGlyph")));
            this.RefreshBarItem.Name = "RefreshBarItem";
            this.RefreshBarItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RefreshBarItem_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Главная";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.RefreshBarItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.SaveBarItem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Основные действия";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.OrgStructureBarItem);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Предприятие";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 485);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1038, 31);
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabbedMdiManager.CloseTabOnMiddleClick = DevExpress.XtraTabbedMdi.CloseTabOnMiddleClick.OnMouseDown;
            this.xtraTabbedMdiManager.HeaderButtons = DevExpress.XtraTab.TabButtons.Close;
            this.xtraTabbedMdiManager.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Location = new System.Drawing.Point(0, 143);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 201;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(201, 342);
            this.navBarControl1.TabIndex = 3;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "navBarGroup1";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "navBarGroup2";
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // MainForm
            // 
            this.AllowMdiBar = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 516);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Рабочее место";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem OrgStructureBarItem;
        private DevExpress.XtraBars.BarButtonItem SaveBarItem;
        private DevExpress.XtraBars.BarButtonItem RefreshBarItem;
        private DevExpress.XtraBars.BarButtonItem ExitBarItem;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
    }
}

