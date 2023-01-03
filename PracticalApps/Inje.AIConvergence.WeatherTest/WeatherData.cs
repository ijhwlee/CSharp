using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Inje.AIConvergence.WeatherTest;

//{"response":{"header":{"resultCode":"00","resultMsg":"NORMAL_SERVICE"},"body":{"dataType":"JSON","items":{"item":[{"baseDate":"20230103","baseTime":"0600","category":"PTY","nx":55,"ny":127,"obsrValue":"0"},{"baseDate":"20230103","baseTime":"0600","category":"REH","nx":55,"ny":127,"obsrValue":"84"},{"baseDate":"20230103","baseTime":"0600","category":"RN1","nx":55,"ny":127,"obsrValue":"0"},{"baseDate":"20230103","baseTime":"0600","category":"T1H","nx":55,"ny":127,"obsrValue":"-11.3"},{"baseDate":"20230103","baseTime":"0600","category":"UUU","nx":55,"ny":127,"obsrValue":"-0.4"},{"baseDate":"20230103","baseTime":"0600","category":"VEC","nx":55,"ny":127,"obsrValue":"43"},{"baseDate":"20230103","baseTime":"0600","category":"VVV","nx":55,"ny":127,"obsrValue":"-0.4"},{"baseDate":"20230103","baseTime":"0600","category":"WSD","nx":55,"ny":127,"obsrValue":"0.7"}]},"pageNo":1,"numOfRows":1000,"totalCount":8}}}

public class WeatherData
{
  public Response response { get; set; }
  public override string ToString()
  {
    return response.ToString();
  }
}

public class Response
{
  public Header header { get; set; }
  public Body body { get; set; }
  public override string ToString()
  {
    string msg = string.Empty;
    msg += "Header:\n";
    return msg + header.ToString() + "Body: \n"+((body==null)?"  NO DATA":body.ToString());
  }
}

public class Header
{
  public string resultCode { get; set; }
  public string resultMsg { get; set; }
  public override string ToString()
  {
    string msg = $"  ResultCode: {resultCode}\n";
    msg += $"  ResultMsg: {resultMsg}\n";
    return msg;
  }
}

public class Body
{
  public string dataType { get; set; }
  public Items items { get; set; }
  public int pageNo { get; set; }
  public int numOfRows { get; set; }
  public int totalCount { get; set; }
  public override string ToString()
  {
    string msg = $"  DataType: {dataType}\n";
    msg += $"  PageNo: {pageNo}\n";
    msg += $"  NumOfRows: {numOfRows}\n";
    msg += $"  TotalCount: {totalCount}\n";
    msg += $"  Items: \n";
    return msg + items.ToString();
  }
}

public class Items
{
  public Item[] item { get; set; }
  public override string ToString()
  {
    string msg = string.Empty;
    for(int i=0; i<item.Length; i++)
    {
      msg += item[i].ToString() + "\n";
    }
    return msg;
  }
}

public class Item
{
  public string baseDate { get; set; }
  public string baseTime { get; set; }
  public string fcstDate { get; set; }
  public string fcstTime { get; set; }
  public string category { get; set; }
  public int nx { get; set; }
  public int ny { get; set; }
  public string obsrValue { get; set; }
  public string fcstValue { get; set; }
  public override string ToString()
  {
    string msg = string.Empty;
    if (fcstDate == null)
    {
      msg += $"    BaseDate: {baseDate},";
      msg += $" BaseTime: {baseTime},";
      msg += $" Category: {category},";
      msg += $" Nx: {nx},";
      msg += $" Ny: {ny},";
      msg += $" ObsrValue: {obsrValue}\n";
    }
    else
    {
      msg += $"    FcstDate: {fcstDate},";
      msg += $" FcstTime: {fcstTime},";
      msg += $" Category: {category},";
      msg += $" Nx: {nx},";
      msg += $" Ny: {ny},";
      msg += $" FcstValue: {fcstValue}\n";
    }
    return msg;
  }
}
