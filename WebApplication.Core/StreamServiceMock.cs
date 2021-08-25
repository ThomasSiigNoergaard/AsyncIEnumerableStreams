using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using WebApplication.Core.Models;

namespace WebApplication.Core
{
  public class StreamServiceMock : IStreamService
  {
    public async IAsyncEnumerable<StockPrice> GetAllStockPrices([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
      await Task.Delay(500, cancellationToken);

      yield return new StockPrice { Identifier = "MSFT", Price = 105.2m };

      await Task.Delay(500, cancellationToken);

      yield return new StockPrice { Identifier = "APPL", Price = 244.3m };

      await Task.Delay(500, cancellationToken);

      yield return new StockPrice { Identifier = "AMZN", Price = 95.9m };
    }
  }
}
