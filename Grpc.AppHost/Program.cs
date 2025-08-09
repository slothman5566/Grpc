var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Grpc>("grpc");

builder.AddProject<Projects.Grpc_Main>("grpc-main");

builder.AddProject<Projects.Grpc_API>("grpc-api");

builder.Build().Run();
