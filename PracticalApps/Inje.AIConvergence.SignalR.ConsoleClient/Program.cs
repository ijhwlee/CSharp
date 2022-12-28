using Microsoft.AspNetCore.SignalR.Client;
using Inje.AIConvergence.Chat.Models;
using static System.Console;

// See https://aka.ms/new-console-template for more information
WriteLine("Start SignalR Console Client...");
Write("Enter a username: ");
string? userName = ReadLine();
Write("Enter your groups: ");
string? groups = ReadLine();

HubConnection hubConnection = new HubConnectionBuilder()
  .WithUrl("https://localhost:5001/chat")
  .Build();
hubConnection.On<MessageModel>("ReceiveMessage", message =>
{
  WriteLine($"{message.From} says {message.Body} (sent to {message.To})");
});
await hubConnection.StartAsync();
WriteLine("Successfully started.");
RegisterModel register = new()
{
  UserName = userName,
  Groups = groups
};
await hubConnection.InvokeAsync("Register", register);
WriteLine("Successfully registered.");
WriteLine("Listening... (press ENTER to stop.)");
ReadLine();