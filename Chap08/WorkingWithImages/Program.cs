// See https://aka.ms/new-console-template for more information
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Reflection;
using static System.Console;

ImageProcessing();

static void ImageProcessing()
{
  WriteLine("============== Image Processing =================");
  string? projectPath = GetProjectPath();
  if (projectPath == null)
    projectPath = Environment.CurrentDirectory;
  string imagesFolder = Path.Combine(projectPath, "images");
  IEnumerable<string> images = Directory.EnumerateFiles(imagesFolder);
  foreach(string imagePath in images)
  {
    if (imagePath.Contains("-thumbnail")) continue;
    WriteLine($"  Generating thumbnale image for {imagePath}");
    string thumbnailPath = Path.Combine(
      projectPath, "images",
      Path.GetFileNameWithoutExtension(imagePath) 
      + "-thumbnail" + Path.GetExtension(imagePath));

    using (Image image = Image.Load(imagePath))
    {
      image.Mutate(x => x.Resize(image.Width/10, image.Height/10));
      image.Mutate(x => x.Grayscale());
      image.Save(thumbnailPath);
    }
  }
  WriteLine("Image processing complete. View the images folder.");
  return;
}

static string? GetProjectPath()
{
  string? appName = Assembly.GetExecutingAssembly().GetName().Name;
  var dir = new DirectoryInfo(Environment.CurrentDirectory);
  while (dir?.Name != appName)
  {
    dir = Directory.GetParent(dir==null?".": dir.FullName);
  }
  return dir?.FullName;
}