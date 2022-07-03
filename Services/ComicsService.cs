using ComicsShop.Grpc.Mappers;
using ComicsShop.Grpc.Repositories;
using ComicsShop.Grpc.Entities;
using Grpc.Core;

namespace ComicsShop.Grpc.Services;

public class ComicsService : ComicsServiceRpc.ComicsServiceRpcBase
{
    private readonly IComicsRepository _repository;
    private readonly IComicsMapper _mapper;

    public ComicsService(IComicsRepository repository, IComicsMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override async Task<ComicsListReply> GetList(ComicsListRequest request, ServerCallContext context)
    {
        var comics = await _repository.GetAll();
        var reply = new ComicsListReply();

        comics.ToList().ForEach(c =>
        {
            reply.Comics.Add(_mapper.MapToComicsReply(c));
        });

        return reply;
    }

    public override async Task<ComicsReply> GetById(ComicsIdRequest request, ServerCallContext context)
    {
        var comics = await _repository.GetById(Guid.Parse(request.Id));

        return _mapper.MapToComicsReply(comics);
    }

    public override async Task<ComicsReply> Update(ComicsUpdateRequest request, ServerCallContext context)
    {
        var newComicsId = await _repository.UpdateById(Guid.Parse(request.Id), new Comics()
        {
            Description = request.Description,
            Image = request.Image,
            Price = request.Price,
            Title = request.Title,
        });

        var comics = await _repository.GetById(newComicsId);

        return _mapper.MapToComicsReply(comics);
    }

    public override async Task<EmptyReply> Delete(ComicsIdRequest request, ServerCallContext context)
    {
        await _repository.DeleteById(Guid.Parse(request.Id));

        return new EmptyReply();
    }

    public override async Task<ComicsReply> Create(CreateComicsRequest request, ServerCallContext context)
    {
        var newComicsId = await _repository.Create(new Comics()
        {
            Description = request.Description,
            Image = request.Image,
            Price = request.Price,
            Title = request.Title,
        });

        var newComics = await _repository.GetById(newComicsId);

        return _mapper.MapToComicsReply(newComics);
    }
}