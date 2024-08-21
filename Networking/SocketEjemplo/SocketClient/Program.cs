// See https://aka.ms/new-console-template for more informatio}
using SocketClient;

Console.WriteLine("Hello, World!");

Client clientSocket = new Client();
clientSocket.Start();

Console.ReadKey();
