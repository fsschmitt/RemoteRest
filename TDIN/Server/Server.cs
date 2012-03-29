using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;


class Server
{
    static void Main(string[] args)
    {
        Console.WriteLine("I'm the server!");
        try
        {
            // loads the config file
            RemotingConfiguration.Configure("Server.exe.config", true);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }


        Console.WriteLine("Return to exit...");
        Console.ReadLine();
    }
}


