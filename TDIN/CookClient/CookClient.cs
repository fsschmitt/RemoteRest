using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Windows.Forms;

class Program
{
    public static CookClient cc;
    public static MainForm mf;
    public static bool debug = true;

    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        bool commandLine = false;
        string value = "";
        switch (args.Length)
        {
            case 0:
                break;
            case 1:
                if (args[0] != "1" && args[0] != "2")
                {
                    Console.WriteLine(args[0]);
                    Console.WriteLine("Usage: CookClient.exe [1|2] \n1: Bar \n2: Kitchen");
                    return;
                }
                else
                {
                    value = args[0];
                    commandLine = true;
                }
                break;
            default:
                Console.WriteLine("Usage: CookClient.exe [1|2] \n1: Bar \n2: Kitchen");
                return;
        }
            

        
        if (Program.debug) Console.WriteLine("I'm the cook");
        try
        {
            // loads the config file
            RemotingConfiguration.Configure("CookClient.exe.config", true);
        }
        catch (Exception e) { Console.WriteLine("erro no log " + e.Message); }
        mf = new MainForm();
        if (!commandLine)
            Application.Run(new Initial());
        else
        {
            if(value=="1")
                cc = new CookClient(mf, CookType.Bar);
            else
                cc = new CookClient(mf, CookType.Kitchen);
            Application.Run(mf);
        }
        

        /*
        // creats the logger
        CookClient cBar = new CookClient(om,CookType.Bar);

        // and assigns the handler to the event
        cBar.setup();

        CookClient cKitchen = new CookClient(om, CookType.Kitchen);

        cKitchen.setup();


        Console.WriteLine("Return to exit...");
        Console.ReadLine();
        */
    }

    public static void startBar()
    {
        cc = new CookClient(mf, CookType.Bar);
    }

    public static void startKitchen()
    {
        cc = new CookClient(mf, CookType.Kitchen);
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
    CookType cType; 
    Repeater orderRepeater;
    Repeater orderChangedRepeater;
    IOrderManager om;
    MainForm mf;
    public CookClient(MainForm mf,CookType type)
    {
        this.mf = mf;
        this.cType = type;
        setup();
    }

    public IOrderManager OrderManager
    {
        get { return om; }
        set { om = value; }
    }

    public void setup()
    {

        // creates the remote object
        om = (IOrderManager)RemoteNew.New(typeof(IOrderManager));
        orderRepeater = new Repeater();
        switch (cType)
        {
            case CookType.Kitchen:
                orderRepeater.newOrderKitchen += new newOrderKitchenDelegate(newOrderHandler);
                om.newOrderKitchenEvent += new newOrderKitchenDelegate(orderRepeater.newOrderKitchenRepeater);
                break;
            case CookType.Bar:
                orderRepeater.newOrderBar += new newOrderBarDelegate(newOrderHandler);
                om.newOrderBarEvent += new newOrderBarDelegate(orderRepeater.newOrderBarRepeater);
                break;
            default:
                if (Program.debug) Console.WriteLine("OOPS");
                break;

        }

        orderChangedRepeater = new Repeater();
        orderChangedRepeater.orderChanged += new orderChangedDelegate(orderChangedHandler);
        om.orderChangedEvent += new orderChangedDelegate(orderChangedRepeater.orderChangedRepeater);

        mf.addInitialOrders(om.getAllDestination(cType));
        if (Program.debug) Console.WriteLine("Setup was made");
        
        
        switch (cType)
        {
            case CookType.Bar:
                mf.Text = "CookClient - Bar";
                break;
            case CookType.Kitchen:
                mf.Text = "CookClient - Kitchen";
                break;
            default:
                mf.Text = "CookClient";
                break;
        }
        mf.Show();
        
    }
    

    public void newOrderHandler(Order o)
    {
        if(Program.debug) Console.WriteLine(cType + " Received a new order!\n" + o);
        mf.addNewOrder(o);
    }

    public void orderChangedHandler(Order o)
    {
        if (Program.debug) Console.WriteLine("Order number: " + o.Id + " changed to: " + o.State);
        mf.changeOrderState(o);
    }

}
