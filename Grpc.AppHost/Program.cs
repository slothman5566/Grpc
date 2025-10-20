var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Grpc_Server>("grpc-server");

builder.AddProject<Projects.Grpc_Client>("grpc-client");

builder.Build().Run();
