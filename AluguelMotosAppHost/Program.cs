using Projects;

var builder = DistributedApplication.CreateBuilder(args);
var databaseName = "AluguelMotos";
var postgresql = builder.AddPostgresContainer("postgresql")
    .WithEnvironment("POSTGRES_DB",databaseName)
    .WithVolumeMount("../AluguelMotos.API/data/postgres", "/docker-entrypoint-initdb.d", VolumeMountType.Bind)
    .AddDatabase(databaseName);
var rabbitmq = builder.AddRabbitMQ("rabbitMQ");
var api = builder.AddProject<Projects.AluguelMotos_API>("api")
    .WithReference(postgresql)
    .WithReference(rabbitmq);
builder.Build().Run();
