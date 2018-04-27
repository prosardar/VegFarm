namespace VegFarm.Model
{
    public interface IViewModel
    {
        StateViewModel State { get; set; }

        int DtoId { get; }
    }
}