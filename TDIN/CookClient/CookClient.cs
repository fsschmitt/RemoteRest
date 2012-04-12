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
        if (Program.debug) Console.WriteLine("I'm the cook");
        try
        {
            // loads the config file
            RemotingConfiguration.Configure("CookClient.exe.config", true);
        }
        catch (Exception e) { Console.WriteLine("erro no log " + e.Message); }

        
        mf = new MainForm();
        cc = new CookClient(mf,CookType.Bar);
        Application.Run(mf);

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
    Repeater orderRepeater;
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

        if (Program.debug) Console.WriteLine("Setup was made");
    }
    
    public void newOrderHandler(Order o)
    {
        /*Console.WriteLine(cType + " Received a new order!\n" + o);
        Console.WriteLine("I am cooking!\n");
        om.changeState(o.Id, OrderState.InProgress);
        System.Threading.Thread.Sleep(5000);
        om.changeState(o.Id, OrderState.Ready);
        Console.WriteLine("Done!\n");
        */
        if(Program.debug) Console.WriteLine(cType + " Received a new order!\n" + o);
        
        mf.addNewOrder(o);
       
    }

}
