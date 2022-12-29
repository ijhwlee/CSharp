using Inje.AIConvergence.Shared;

using static System.Console;

// See https://aka.ms/new-console-template for more information
WriteLine("============ Starting SigningApp =============");
Write("Enter some text to sign: ");
string? data = ReadLine();
string signature = Protector.GenerateSignature(data);

WriteLine($"Signature: {signature}");
WriteLine("Public key used to check signature: ");
WriteLine(Protector.PublicKey);

if (Protector.ValidateSignature(data, signature))
{
  WriteLine("Correct! Signature is valid.");
}
else
{
  WriteLine("Invalid signature.");
}
WriteLine();
WriteLine();
WriteLine("Testing for fake signature");

string fakeSignature = signature.Replace(signature[0], 'X');
if (fakeSignature == signature)
{
  fakeSignature = signature.Replace(signature[0], 'Y');
}

if (Protector.ValidateSignature(data, fakeSignature))
{
  WriteLine("Correct! Fake signature is valied, strange???");
}
else
{
  WriteLine($"Invalid signature: {fakeSignature}");
}