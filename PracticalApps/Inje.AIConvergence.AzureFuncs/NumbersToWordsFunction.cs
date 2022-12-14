using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Inje.AIConvergence.Shared;
using System.Threading.Tasks;
using System.Numerics;

namespace Inje.AIConvergence.AzureFuncs;

public class NumbersToWordsFunction
{
  private readonly ILogger _logger;

  public NumbersToWordsFunction(ILoggerFactory loggerFactory)
  {
    _logger = loggerFactory.CreateLogger<NumbersToWordsFunction>();
  }

  [Function(nameof(NumbersToWordsFunction))]
  public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
  {
    _logger.LogInformation("C# HTTP trigger function processed a request.");

    var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
    string? amount = query["amount"];
    string? system = query["system"]?.ToLower();
    _logger.LogInformation($"Request query = {query}, amount = {amount}, system = {system}");
    string message = string.Empty;
    var response = req.CreateResponse(HttpStatusCode.OK);
    if (BigInteger.TryParse(amount, out BigInteger number))
    {
      if (system != null && system.Equals("kor"))
      {
        _logger.LogInformation($"Call SetNumberSystem set Korean");
        NumbersToWords.SetNumberSystem(NumbersToWords.NumberSystem.Kor);
      }
      else
      {
        _logger.LogInformation($"Call SetNumberSystem set English");
        NumbersToWords.SetNumberSystem(NumbersToWords.NumberSystem.Eng);
      }
      message = number.ToWords();
    }
    else
    {
      response = req.CreateResponse(HttpStatusCode.BadRequest);
      message = $"Failed to parse: {amount}";
    }
    response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

    //response.WriteString("Welcome to Azure Functions!");
    response.WriteString(message);

    return response;
  }
}
