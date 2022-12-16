// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

RunningTasksInSingleThread();
RunningTasksInMultiThread();
RunningAfterThread();

static void RunningAfterThread()
{
  WriteLine("=========== RunningAfterThread =============");
  var timer = Stopwatch.StartNew();
  WriteLine("Passing the result of one task as an input into another.");
  var taskCallWebServiceAndTheStoredProcedure =
    Task.Factory.StartNew(CallWebService)
      .ContinueWith(previousTask => CallStoredProcedure(previousTask.Result));
  WriteLine($"Result: {taskCallWebServiceAndTheStoredProcedure.Result}");
}

static decimal CallWebService()
{
  WriteLine("Starting call to call web services...");
  Thread.Sleep((new Random()).Next(2000, 4000));
  WriteLine("Finished cal to web service.");
  return 89.94M;
}
static string CallStoredProcedure(decimal amount)
{
  WriteLine("Starting call to call stored procedure...");
  Thread.Sleep((new Random()).Next(2000, 4000));
  WriteLine("Finished cal to call stored procedure.");
  return $"12 products cost more than {amount:$#,##0.00}";
}
static void RunningTasksInMultiThread()
{
  WriteLine("=========== RunningTasksInMultiThread =============");
  var timer = Stopwatch.StartNew();
  WriteLine("Running methods asynchronously on multiple threads.");
  Task taskA = new Task(MethodA);
  Task taskB = new Task(MethodB);
  Task taskC = new Task(MethodC);
  Task[] tasks = { taskA, taskB, taskC };
  taskA.Start();
  taskB.Start();
  taskC.Start();
  Task.WaitAll(tasks);
  WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
}
static void RunningTasksInSingleThread()
{
  WriteLine("=========== RunningTasksInSingleThread =============");
  var timer = Stopwatch.StartNew();
  WriteLine("Running methods synchronously on one thread.");
  MethodA();
  MethodB();
  MethodC();
  WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
}
static void MethodA()
{
  WriteLine("Starting Method A...");
  Thread.Sleep(3000);
  WriteLine("Finished Method A.");
}

static void MethodB()
{
  WriteLine("Starting Method B...");
  Thread.Sleep(2000);
  WriteLine("Finished Method B.");
}

static void MethodC()
{
  WriteLine("Starting Method C...");
  Thread.Sleep(1000);
  WriteLine("Finished Method C.");
}