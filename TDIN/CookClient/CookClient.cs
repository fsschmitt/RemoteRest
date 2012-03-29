using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("I'm the cook");
        try
        {
            // loads the config file
            RemotingConfiguration.Configure("CookClient.exe.config", true);
        }
        catch (Exception e) { Console.WriteLine("erro no log " + e.Message); }

        // creates the remote object
        IOrderManager om = (IOrderManager)RemoteNew.New(typeof(IOrderManager));

        // creats the logger
        CookClient c = new CookClient();
        // and assigns the handler to the event
        c.setup(om);

        Console.WriteLine("Return to exit...");
        Console.ReadLine();
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

class CookClient
{
    int ID;
    CookType cType; 
    newOrderRepeater orderRepeater;
    public void setup(IOrderManager om)
    {

        orderRepeater = new newOrderRepeater();
        orderRepeater.newOrder += new newOrderDelegate(newOrderHandler);
        om.newOrderEvent += new newOrderDelegate(orderRepeater.Repeater);
        Console.WriteLine("Setup was made");
    }
    public void newOrderHandler(Order o)
    {
        Console.WriteLine("Received a new order!\n" + o);
    }

}