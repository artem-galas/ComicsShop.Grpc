# ComicsShop.Grpc

GRPC implementation of ComicsShop api

## Technologies:
- C# .NET 6
- Docker
- myslq
- SqlKata as lightweight query builder

## Development

Application is running into **Docker** container

```bash
$ docker-compose up --build
```

## Methods

For more info please follow [Proto Schema](./Protos/comics.proto)

- rpc GetList
- rpc GetById
- rpc Update
- rpc Delete
- rpc Create