using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // loads the config file
            RemotingConfiguration.Configure("RoomClient.exe.config", true);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        RoomClient rc = new RoomClient();
        
        Console.WriteLine("Return to update inventory...");
        Console.ReadLine();

        // creates the remote object

        Order o = new Order();
        Console.WriteLine(o);
        rc.OrderManager.addOrder(o);


    }
}

class RoomClient
{
    IOrderManager om;

    public IOrderManager OrderManager
    {
        get { return om; }
        set { om = value; }
    }
    Repeater orderRepeater;
     void setup()
    {
        om = (IOrderManager)RemoteNew.New(typeof(IOrderManager));
        orderRepeater = new Repeater();
        orderRepeater.orderChanged += new orderChangedDelegate(orderChangedHandler);
        om.orderChangedEvent += new orderChangedDelegate(orderRepeater.orderChangedRepeater);
        Console.WriteLine("Setup was made");
    }
     public RoomClient()
     {
         setup();
     }
    public void orderChangedHandler(Order o)
    {
        switch (o.State)
        {
            case OrderState.Waiting:
                Console.WriteLine("Oh noes, something went terribly wrong in the kitchen.");
                break;
            case OrderState.Ready:
                Console.WriteLine("I'm going to get your food gentlemens!");
                break;
            case OrderState.InProgress:
                 Console.WriteLine("Your food started to cook!");
                break;
        }
        
        
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




