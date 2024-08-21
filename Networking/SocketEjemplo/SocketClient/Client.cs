using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace SocketClient
{
    internal class Client
    {

        IPAddress ipAddressToConnect;
        int portServerToConnect;


        Socket socketClient;
        public Client()
        {
            ipAddressToConnect = IPAddress.Parse("127.0.0.1");
            portServerToConnect = 3000;
        }

        public void Start() {
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Mando solicitud de conectarme al endpoint del servidor
            socketClient.Connect(new IPEndPoint(ipAddressToConnect,portServerToConnect));
            Console.WriteLine("Connected to the server");

            //Mando mensaje al endpoint del servidor
            string messageToSend = "Hi Server , I'm new client";
            byte[] bytesToSend = Encoding.ASCII.GetBytes(messageToSend);
            socketClient.Send(bytesToSend);
            Console.WriteLine("Message sent.. !!");


            //Recibir el mensaje del servidor
            byte[] bytesToReceive = new byte[1024];
            int serverBytes = socketClient.Receive(bytesToReceive);
            string messageToReceive = Encoding.ASCII.GetString(bytesToReceive,0,serverBytes);

            Console.WriteLine($"Server: {messageToReceive}");

            socketClient.Shutdown(SocketShutdown.Both);
            socketClient.Close();
        }

    }
}
