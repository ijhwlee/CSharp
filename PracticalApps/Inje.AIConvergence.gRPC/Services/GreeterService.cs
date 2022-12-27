using Grpc.Core;
using Inje.AIConvergence.gRPC;
using static System.Console;

namespace Inje.AIConvergence.gRPC.Services;

public class GreeterService : Greeter.GreeterBase
{
  private readonly ILogger<GreeterService> _logger;
  public GreeterService(ILogger<GreeterService> logger)
  {
    _logger = logger;
  }

  public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
  {
    WriteLine("[DEBUG-hwlee]GreeterService:SayHello called =========");
    return Task.FromResult(new HelloReply
    {
      Message = "Hello " + request.Name
    });
  }
}