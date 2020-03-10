using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BogServer
{
    class Server
    {
        public void start()
        {

            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, 4646);

            serverSocket.Start();
            Console.WriteLine("Server Started");


            while (true)
            {
                Task.Run(() =>
                {
                    TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                    DoClient(connectionSocket);
                });
                
                
            }
            //connectionSocket.Close();
            //serverSocket.Stop();
        }

        public void DoClient(TcpClient socket)
        {
            Stream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            string message = sr.ReadLine();
            string answer = "";
            while (message != null || message != "")
            {
                Console.WriteLine($"Client: {message}");
                answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();
            }
            ns.Close();
        }
    }
}
