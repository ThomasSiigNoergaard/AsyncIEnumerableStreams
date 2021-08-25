using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Core.Models;

namespace WebApplication2.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;

    public IList<StockPrice> StockPrices { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IStreamService streamService)
    {
      _logger = logger;
      StreamService = streamService;
    }

    private IStreamService StreamService { get; }

    public async Task OnGet()
    {
      StockPrices = new List<StockPrice>();

      var cancellationToken = new CancellationToken();
      var asyncEnumerable = StreamService.GetAllStockPrices(cancellationToken);

      await foreach (StockPrice item in asyncEnumerable.WithCancellation(cancellationToken))
      {
        StockPrices.Add(item);
      }
    }
  }
}
