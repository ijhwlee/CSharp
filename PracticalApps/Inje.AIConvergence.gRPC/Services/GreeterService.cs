using Grpc.Core;
using Inje.AIConvergence.gRPC;

namespace Inje.AIConvergence.gRPC.Services;

public class GreeterService : GrpcGreeterClient
{
  private readonly ILogger<GreeterService> _logger;
  public GreeterService(ILogger<GreeterService> logger)
  {
    _logger = logger;
  }

  public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
  {
    return Task.FromResult(new HelloReply
    {
      Message = "Hello " + request.Name
    });
  }
}