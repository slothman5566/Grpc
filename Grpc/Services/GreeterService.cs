using Grpc.Core;
using Grpc;

namespace Grpc.Services;

public class GreeterService : GrpcExample.Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

}
