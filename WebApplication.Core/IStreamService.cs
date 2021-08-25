using System.Collections.Generic;
using System.Threading;
using WebApplication.Core.Models;

namespace WebApplication.Core
{
  public interface IStreamService
  {
    IAsyncEnumerable<StockPrice> GetAllStockPrices(CancellationToken cancellationToken = default);
  }
}
