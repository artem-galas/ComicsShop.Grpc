using ComicsShop.Grpc.Entities;

namespace ComicsShop.Grpc.Mappers;

public interface IComicsMapper
{
    ComicsReply MapToComicsReply(Comics entity);
    Comics MapFromComicsReply(ComicsReply reply);
}