using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace SocketServer
{
    internal class Server
    {

        //Direccion ip
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        
        //Puerto de nuestro servidor
        int portNumber = 3000;


        Socket serverSocket;


        public Server()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start() {

            //Asociamos nuestro servidor a un endpoint para que los clientes se conecten a este mismo
            serverSocket.Bind(new IPEndPoint(ipAddress, portNumber));
            //Cantidad de clientes a escuchar
            serverSocket.Listen(5);
            Console.WriteLine("Server Ready to listen clients....");

            //Acepta el cliente que quiere conectarse
            Socket client = serverSocket.Accept();
            Console.WriteLine("Client connected");



            //Recibo el mensaje del cliente en bytes
            byte[] tempMessage = new byte[1024];
            int clientBytes = client.Receive(tempMessage);
            string message = Encoding.ASCII.GetString(tempMessage,0,clientBytes);
            Console.WriteLine($"Client: {message}");

            //Envio un mensaje al cliente 
            string messageFromServer = "Hi cliente, how are you";
            byte[] bytesFromMessage=Encoding.ASCII.GetBytes(messageFromServer);
            client.Send(bytesFromMessage);
            Console.WriteLine("Message sent.. !!");

            client.Shutdown(SocketShutdown.Both);
            client.Close();
            serverSocket.Close();
        }
    }
}
