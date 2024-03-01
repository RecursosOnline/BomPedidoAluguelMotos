var builder = DistributedApplication.CreateBuilder(args);
builder.AddPostgres("db");
builder.AddRabbitMQ("rabbitMQ");
builder.Build().Run();
