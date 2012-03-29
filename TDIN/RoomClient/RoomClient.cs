using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

class RoomClient
{
    static void Main(string[] args)
    {
        try
        {
            // loads the config file
            RemotingConfiguration.Configure("RoomClient.exe.config", true);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }

        Console.WriteLine("Return to update inventory...");
        Console.ReadLine();

        // creates the remote object
        IOrderManager om = (IOrderManager)RemoteNew.New(typeof(IOrderManager));
        Order o = new Order();
        Console.WriteLine(o);
        om.addOrder(o);


    }
}
/* Mechanism for instanciating a remote object through its interface, using the config file */

class RemoteNew
{
    private static Hashtable types = null;

    private static void InitTypeTable()
    {
        types = new Hashtable();
        foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            types.Add(entry.ObjectType, entry);
    }

    public static object New(Type type)
    {
        if (types == null)
            InitTypeTable();
        WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)types[type];
        if (entry == null)
            throw new RemotingException("Type not found!");
        return RemotingServices.Connect(type, entry.ObjectUrl);
    }
}




