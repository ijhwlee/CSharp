using Grpc.Core;
using Inje.AIConvergence.Shared;

namespace Inje.AIConvergence.gRPC.Services;

public class ShipperService : Shipper.ShipperBase
{
  private readonly ILogger<ShipperService> _logger;
  private readonly NorthwindContext db;
  public ShipperService(ILogger<ShipperService> logger, NorthwindContext db)
  {
    _logger = logger;
    this.db = db;
  }

  public override async Task<ShipperReply> GetShipper(ShipperRequest request, ServerCallContext context)
  {
    return ToShipperReply(await db.Shippers.FindAsync(request.ShipperId));
  }
  private ShipperReply ToShipperReply(Inje.AIConvergence.Shared.Shipper? shipper)
  {
    return new ShipperReply
    {
      ShipperId = shipper?.ShipperId ?? 0,
      CompanyName = shipper?.CompanyName ?? string.Empty,
      Phone = shipper?.Phone ?? string.Empty
    };
  }
}
