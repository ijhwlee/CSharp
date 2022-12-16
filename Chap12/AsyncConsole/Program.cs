// See https://aka.ms/new-console-template for more information
using AIConvergence.Shared;
using static System.Console;

int ret = await HttpClientRequest();

static async Task<int> HttpClientRequest()
{
  WriteLine("=============== HttpClientRequest ==============");
  Write("Enter a URL: ");
  string? url = ReadLine();
  if(url == null || url.Length == 0)
  {
    url = "https://www.apple.com/kr";
  }
  if (url.IsValidURL())
  {
    Uri myUri = new Uri(url);
    string host = myUri.Host;
    HttpClient client = new();
    HttpResponseMessage response = await client.GetAsync(url);
    WriteLine("{1}'s home page has {0:N0} bytes.",
      response.Content.Headers.ContentLength, host);
    return 0;
  }
  else
  {
    WriteLine("{0} is not valid URL.",url);
    return -1;
  }
}
