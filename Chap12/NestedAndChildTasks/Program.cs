﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

RunningNestedTasks();

static void RunningNestedTasks()
{
  WriteLine("============= RunningNestedTasks ==================");
  var outer = Task.Factory.StartNew(OuterMethod);
  outer.Wait();
  WriteLine("Console app is stopping.");
}
static void OuterMethod()
{
  WriteLine("Outer method starting...");
  var inner = Task.Factory.StartNew(InnerMethod, TaskCreationOptions.AttachedToParent);
  WriteLine("Outer method finished.");
}

  static void InnerMethod()
{
  WriteLine("Inner method starting...");
  Thread.Sleep(2000);
  WriteLine("Inner method finished.");
}