using System;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApplication1
{

    class Server
    {

        public static void Main(string[] args)
        {
            TcpListener tcp = new TcpListener(10099);
            tcp.Start();
            Console.WriteLine("This is server.");
            Socket client = tcp.AcceptSocket();
            if (client.Connected)
            {
                NetworkStream stream = new NetworkStream(client);
                System.IO.StreamWriter writer = new System.IO.StreamWriter(stream);
                System.IO.StreamReader reader = new System.IO.StreamReader(stream);

                while (true) 
                {
                    String input = reader.ReadLine();
                    Console.WriteLine("Msg from client : " + input);
                    if (input == "exit")
                    {
                        break;
                    }
                }
                stream.Close();
                reader.Close();
                writer.Close();
            }
            client.Close();
        }
    }
}