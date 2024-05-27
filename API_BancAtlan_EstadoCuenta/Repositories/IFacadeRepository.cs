namespace API_BancAtlan_EstadoCuenta.Repositories
{
    public interface IFacadeRepository<T>
    {
        Task<T?> Insert(T cliente);
        void Update(int id, T cliente);
        void Delete(T cliente);
        void Delete(int id);
        Task<T> GetById(int id);
        Task<T> FindById(int id);
    }
}
}
