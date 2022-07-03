using ComicsShop.Grpc.Mappers;
using ComicsShop.Grpc.Services;
using ComicsShop.Grpc.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddScoped<IComicsMapper, ComicsMapper>();
builder.Services.AddDbConnection();
builder.Services.AddComicsRepository();

var app = builder.Build();

app.MapGrpcService<ComicsService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.Run();
