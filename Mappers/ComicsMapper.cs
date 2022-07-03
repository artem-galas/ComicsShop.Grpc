using ComicsShop.Grpc.Entities;

namespace ComicsShop.Grpc.Mappers;

public class ComicsMapper : IComicsMapper
{
    public ComicsReply MapToComicsReply(Comics entity)
    {
        return new ComicsReply
        {
            Id = entity.Id.ToString(),
            Title = entity.Title,
            Description = entity.Description,
            Image = entity.Image,
            Price = entity.Price ?? 0,
        };
    }

    public Comics MapFromComicsReply(ComicsReply reply)
    {
        return new Comics
        {
            Id = Guid.Parse(reply.Id),
            Title = reply.Description,
            Description = reply.Description,
            Image = reply.Image,
            Price = reply.Price
        };
    }
}