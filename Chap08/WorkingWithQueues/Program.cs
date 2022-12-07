// See https://aka.ms/new-console-template for more information
using static System.Console;

WorkingWithQueues();
WorkingWithPriorityQueues();

static void WorkingWithQueues()
{

  WriteLine("========== Working with Queues ===============");

  Queue<string> coffee = new();
  coffee.Enqueue("Damir");
  coffee.Enqueue("Andrea");
  coffee.Enqueue("Ronald");
  coffee.Enqueue("Amin");
  coffee.Enqueue("Irina");

  Output("Initial queue from front to back", coffee);

  string served = coffee.Dequeue();
  WriteLine($"Served: {served}");

  Output("Current queue from front to back", coffee);

  WriteLine($"{coffee.Peek()} is next in line.");

  Output("Current queue from front to back", coffee);

}
static void OutputPQ<TElement, TPriority>(string title,
  IEnumerable<(TElement Element, TPriority Priority)> collection)
{
  WriteLine(title);
  foreach((TElement, TPriority) item in collection)
  {
    WriteLine($"  {item.Item1}: {item.Item2}");
  }
}

static void WorkingWithPriorityQueues()
{
  PriorityQueue<string, int> vaccine = new();
  vaccine.Enqueue("Pamela", 1);
  vaccine.Enqueue("Rebecca", 3);
  vaccine.Enqueue("Juliet", 2);
  vaccine.Enqueue("Ian", 1);

  WriteLine("========== Working with Priority Queues ===============");

  OutputPQ("Current queue for vaccine:", vaccine.UnorderedItems);

  WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
  WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

  OutputPQ("Current queue for vaccine:", vaccine.UnorderedItems);

  WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

  vaccine.Enqueue("Mark", 2);
  WriteLine($"{vaccine.Peek()} will be next to be vaccinated.");

  OutputPQ("Current queue for vaccine:", vaccine.UnorderedItems);

}
static void Output(string title, IEnumerable<string> output)
{
  WriteLine(title);
  foreach(string item in output)
  {
    WriteLine($"  {item}");
  }
}
