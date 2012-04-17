using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Windows.Forms;

class Program
{
   public static RoomClient rc;
   public static MainForm mf;
   public static void Main(string[] args)
    {
       try
        {
            // loads the config file
            RemotingConfiguration.Configure("RoomClient.exe.config", true);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }

       Application.EnableVisualStyles();
       Application.SetCompatibleTextRenderingDefault(false);
        
        rc = new RoomClient();
        mf = new MainForm();
        Application.Run(mf);


    }
}

class RoomClient
{
    IOrderManager om;
    Hashtable tables;

    public Hashtable Tables
    {
        get { return tables; }
        set { tables = value; }
    }

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
        setupTables(om.getAllOrders());
        Console.WriteLine("Setup was made");
    }

     private void setupTables(ArrayList orders)
     {
         foreach(Order o in orders)
         {
             if (tables.ContainsKey(o.TableID))
             {
                 ((Table)tables[o.TableID]).addOrder(o);
             }
             else
             {
                 Console.WriteLine("New table: " + o.TableID);
                 Table newTable = new Table(o.TableID);
                 newTable.addOrder(o);
                 tables.Add(o.TableID, newTable);
             }
         }
     }

    public RoomClient()
    {
        tables = new Hashtable();
        setup();
    }
    delegate void updateViewDelegate();
    public void orderChangedHandler(Order o)
    {

        
        int index = -1;
        foreach (Order ord in ((Table)tables[o.TableID]).Orders)
        {

            if (ord.Id == o.Id)
            {
                index++;
                break;
            }
            index++;
            
        }

        if (index != -1)
        {
            ((Table)tables[o.TableID]).Orders[index] = o;
            Program.mf.updateTable(o.TableID);
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




