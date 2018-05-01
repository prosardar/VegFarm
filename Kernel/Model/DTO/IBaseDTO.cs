namespace VerFarm.Kernel.Model.DTO
{
    public interface IBaseDTO
    {
        int Id { get; set; }

        bool IsError { get; set; }

        string Message { get; set; }

        void SetError(string message, params object[] args);
    }
}