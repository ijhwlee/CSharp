// See https://aka.ms/new-console-template for more information
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using AIConvergence.Shared;
using System.Reflection;
using System.IO.Compression;

WorkWithText();
WorkWithXml();
WorkWithCompression(true);

static void WorkWithText()
{
  WriteLine("============ WorkWithText ================");
  string? appName = Assembly.GetExecutingAssembly().GetName().Name;
  string ProjectPath = Utils.GetProjectPath(appName);
  //WriteLine($"ProjectPath : {ProjectPath}");
  string textFile = Combine(ProjectPath, "streams.txt");
  StreamWriter text = File.CreateText(textFile);
  foreach(string item in Viper.Callsigns)
  {
    text.WriteLine(item);
  }
  text.Close();

  WriteLine("{0} contains {1:N0} bytes.",
    arg0: textFile,
    arg1: new FileInfo(textFile).Length);

  WriteLine(File.ReadAllText(textFile));
}

static void WorkWithXml()
{
  WriteLine("============ WorkWithXml ================");
  FileStream? xmlFileStream = null;
  XmlWriter? xml = null;
  try
  {
    string? appName = Assembly.GetExecutingAssembly().GetName().Name;
    string ProjectPath = Utils.GetProjectPath(appName);
    string xmlFile = Combine(ProjectPath, "streams.xml");

    xmlFileStream = File.Create(xmlFile);
    xml = XmlWriter.Create(xmlFileStream,
      new XmlWriterSettings { Indent = true });
    xml.WriteStartDocument();
    xml.WriteStartElement("callsigns");
    foreach (string item in Viper.Callsigns)
    {
      xml.WriteElementString("callsign", item);
    }
    xml.WriteEndElement();
    xml.Close();
    xmlFileStream.Close();

    WriteLine("{0} contains {1:N0} bytes.",
      arg0: xmlFile,
      arg1: new FileInfo(xmlFile).Length);

    WriteLine(File.ReadAllText(xmlFile));
  }
  catch (Exception ex)
  {
    WriteLine($"{ex.GetType()} says {ex.Message}");
  }
  finally
  {
    if(xml != null)
    {
      xml.Dispose();
      WriteLine("The XML writer's unmanaged resources have been disposed.");
      if(xmlFileStream!=null)
      {
        xmlFileStream.Dispose();
        WriteLine("The file stream's unmanaged resources have been disposed.");
      }
    }
  }
}

static void WorkWithCompression(bool useBrotli = true)
{
  WriteLine("============ WorkWithCompression ================");
  string fileExt = useBrotli?"brotli":"gzip";
  string? appName = Assembly.GetExecutingAssembly().GetName().Name;
  string ProjectPath = Utils.GetProjectPath(appName);
  string filePath = Combine(ProjectPath, $"streams.{fileExt}");
  FileStream file = File.Create(filePath);

  Stream compressor;
  if (useBrotli)
  {
    compressor = new BrotliStream(file, CompressionMode.Compress);
  }
  else
  {
    compressor = new GZipStream(file, CompressionMode.Compress);
  }
  using (compressor)
  {
    using (XmlWriter xml = XmlWriter.Create(compressor))
    {
      xml.WriteStartDocument();
      xml.WriteStartElement("callsigns");
      foreach (string item in Viper.Callsigns)
      {
        xml.WriteElementString("callsign", item);
      }
    }
  }
  WriteLine("{0} contains {1:N0} bytes.",
    arg0: filePath,
    arg1: new FileInfo(filePath).Length);

  WriteLine($"The compressed contents:");
  WriteLine(File.ReadAllText(filePath));

  WriteLine("Reading the compressed XML file:");
  file = File.Open(filePath, FileMode.Open);

  Stream decompressor;
  if (useBrotli)
  {
    decompressor = new BrotliStream(file, CompressionMode.Decompress);
  }
  else
  {
    decompressor = new GZipStream(file, CompressionMode.Decompress);
  }

  using (decompressor)
  {
    using (XmlReader reader = XmlReader.Create(decompressor))
    {
      while (reader.Read())
      {
        if ((reader.NodeType == XmlNodeType.Element)
          && (reader.Name == "callsign"))
        {
          reader.Read();
          WriteLine($"{reader.Value}");
        }
      }
    }
  }
}

static class Viper
{
  public static string[] Callsigns = new[]
  {
    "Husker", "Starbuck", "Apollo", "Boomer",
    "Bulldog", "Athena", "Helo", "Racetrack",
    "아침이슬", "새벽별", "석양"
  };
}