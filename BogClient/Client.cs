using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace BogClient
{
    class Client
    {
        public void Start()
        {
            Console.WriteLine("Waiting for Server");
            TcpClient clientSocket = new TcpClient("localhost", 4646);

            Stream ns = clientSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            string message = "";
            Console.WriteLine("Connected");
            while (message != null || message != "")
            {
                message = Console.ReadLine();
                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();
                Console.WriteLine($"Server: {serverAnswer}");
            }
            ns.Close();

            clientSocket.Close();
        }
    }
}
