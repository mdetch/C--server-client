using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApplication1
{
    class Client
    {
        public static void Main(String[] args)
        {
            TcpClient socketForServer = new TcpClient("127.0.0.1", 10099);
            NetworkStream stream = socketForServer.GetStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(stream);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(stream);
            Console.WriteLine("This is client.");
            Console.Write("type:");
            String str = Console.ReadLine();
            while (str != "exit")
            {
                writer.WriteLine(str);
                writer.Flush();
                Console.Write("type:");
                str = Console.ReadLine();
            }
            if (str == "exit")
            {
                writer.WriteLine(str);
                writer.Flush();
            }
            stream.Close();
        }
    }
}