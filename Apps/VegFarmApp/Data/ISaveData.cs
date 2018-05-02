namespace VegFarm.Data
{
    internal interface ISaveForm
    {
        bool IsLoaded { get; set; }
        void SaveData();
        void UpdateData();
        void InitData();
        void ShowAndBringToFront();
    }
}