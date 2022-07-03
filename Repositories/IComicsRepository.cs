using ComicsShop.Grpc.Entities;

namespace ComicsShop.Grpc.Repositories;

public interface IComicsRepository
{
    Task<Comics> GetById(Guid id);
    Task<IEnumerable<Comics>> GetAll();

    Task<Guid> UpdateById(Guid id, Comics comics);
    Task<Guid> Create(Comics comics);

    Task DeleteById(Guid id);
}