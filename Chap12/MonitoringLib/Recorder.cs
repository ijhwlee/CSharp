﻿using System;
using System.Diagnostics;
using static System.Console;
using static System.Diagnostics.Process;

namespace AIConvergenc.Shared;

public static class Recorder
{
  static Stopwatch timer = new Stopwatch();
  static long bytesPhysicalbefore = 0;
  static long bytesVirtualBefore = 0;

  public static void Start()
  {
    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();

    bytesPhysicalbefore = GetCurrentProcess().WorkingSet64;
    bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;
    timer.Restart();
  }

  public static void Stop()
  {
    timer.Stop();
    long bytesPhysicalAfter = GetCurrentProcess().WorkingSet64;
    long bytesVirtualAfter = GetCurrentProcess().VirtualMemorySize64;
    WriteLine("{0:N0} physical bytes used.",
      bytesPhysicalAfter - bytesPhysicalbefore);
    WriteLine("{0:N0} virtual bytes used.",
      bytesVirtualAfter - bytesVirtualBefore);
    WriteLine("{0} time span elapsed.", timer.Elapsed);
    WriteLine("{0:N0} total milliseconds elapsed.", timer.ElapsedMilliseconds);
  }
}