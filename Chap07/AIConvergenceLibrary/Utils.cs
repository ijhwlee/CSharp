using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using static System.Environment;

namespace AIConvergence.Shared
{
  //
  // Summary:
  //     Exposes static methods for checking if the program is launched from Visual Studio, get the correct project path
  //     if it is launched from Visual Studio or CurrentDirectory
  public static class Utils
  {
    //
    // Summary:
    //     Checks if the program is launched from Visual Studio
    //
    // Parameters:
    //   None
    //
    // Exceptions:
    public static bool IsLaunchedFromVS()
    {
      var dir = new DirectoryInfo(Environment.CurrentDirectory);
      bool launchedFromVS = (dir.FullName.Contains("Debug\\net") || dir.FullName.Contains("Release\\net"));
      return launchedFromVS;
    }
    //
    // Summary:
    //     Returns a correct project path or current directory
    //
    // Parameters:
    //   appName:
    //     application name obtained from Assembly
    //
    // Exceptions:
    public static string GetProjectPath(string appName)
    {
      var dir = new DirectoryInfo(Environment.CurrentDirectory);
      if (IsLaunchedFromVS())
      {
        while (dir.Name != appName)
        {
          dir = Directory.GetParent(dir == null ? "." : dir.FullName);
        }
        return dir.FullName;
      }
      return Environment.CurrentDirectory;
    }
  }
}
