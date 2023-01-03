using System;
using System.Net;
using System.Net.Http;
using System.IO;
using static System.Console;
using System.Net.Http.Json;
using Inje.AIConvergence.WeatherTest;

// See https://aka.ms/new-console-template for more information
WriteLine("================ Weather Request Test ===============");
weatherRequest();

static async void weatherRequest()
{
  //HttpClient client = HttpClient.CreateClient(name: "Minimal.WebApi"); 
  HttpClient client = new HttpClient();
  //string url = "http://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getUltraSrtNcst"; // URL
  string url = "http://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getVilageFcst"; // URL
  url += "?ServiceKey=" + "JEsbNK3wkBKTZNdvuQE1P4lS3p6M9vJPdWDCQfKbXK7iSdL6%2F%2F3S5fgY%2F8WVeI2EAKI%2Brk8aiZC7VsUJhakHTA%3D%3D"; // Service Key
  url += "&pageNo=1";
  url += "&numOfRows=1000";
  url += "&dataType=JSON";
  url += "&base_date=20230103";
  url += "&base_time=0500";
  url += "&nx=95";
  url += "&ny=77";
  HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: url);
  HttpResponseMessage response = client.Send(request);
  //HttpResponseMessage response = await client.SendAsync(request);
  //string results = await response.Content.ReadAsStringAsync();
  WeatherData? results = await response.Content.ReadFromJsonAsync<WeatherData>();

  Console.WriteLine(results);


}

