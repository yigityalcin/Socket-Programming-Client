using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp2
{
    //CLIENT
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte[1024];

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipA = ipHostInfo.AddressList[0];
            IPEndPoint REndP = new IPEndPoint(ipA, 11000);

            Socket sender = new Socket(ipA.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            sender.Connect(REndP);

            Console.WriteLine("Socket is connected to {0}", sender.RemoteEndPoint.ToString());

            byte[] msg = Encoding.ASCII.GetBytes("This is a test <EOF>");

            int bS = sender.Send(msg);
            int bytesRec = sender.Receive(bytes);
            Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();




        }
    }
}
