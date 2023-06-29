namespace Api.ProductsManagement.Data.Repository.Contract
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }
}