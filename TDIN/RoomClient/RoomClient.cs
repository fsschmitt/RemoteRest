using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Windows.Forms;

class Program
{
   public static RoomClient rc;
   public static void Main(string[] args)
    {
       try
        {
            // loads the config file
            RemotingConfiguration.Configure("RoomClient.exe.config", true);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
      
        rc = new RoomClient();
       
       /* rc.OrderManager.addOrder(o);

        Order o1 = new Order();

        o1.CookDestination = CookType.Kitchen;
        o1.Description = "Order 2";
         System.Threading.Thread.Sleep(5000);

        rc.OrderManager.addOrder(o1);

        */
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());


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




