using System;
using System.Collections;
using System.Linq;
using System.Text;

[Serializable]
public class Order : ICloneable
{
    String id;
    //static int ID = 0;
    public Order()
    {
               
    }

    private string GenerateId()
    {
        long i = 1;
        foreach (byte b in Guid.NewGuid().ToByteArray())
        {
            i *= ((int)b + 1);
        }
        return string.Format("{0:x}", i - DateTime.Now.Ticks);
    }

    public Order(int qt, String desc,int tableID, double price, CookType cookDestination)
    {
        //id = "t"+tableID+"o"+ID++;
        id = GenerateId();
        Description = desc;
        this.tableID = tableID;
        this.price = price;
        this.cookDestination = cookDestination;
        this.State = OrderState.Waiting;
        this.qt = qt;


    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

  
    public String Id
    {
        get { return id; }
        set { id = value; }
    }
    OrderState state;

    public OrderState State
    {
        get { return state; }
        set { state = value; }
    }
    String desc;

    public String Description
    {
        get { return desc; }
        set { desc = value; }
    }
    int qt;

    public int Qt
    {
        get { return qt; }
        set { qt = value; }
    }
    int tableID;

    public int TableID
    {
        get { return tableID; }
        set { tableID = value; }
    }
    CookType cookDestination;

    public CookType CookDestination
    {
        get { return cookDestination; }
        set { cookDestination = value; }
    }
    double price;

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public override string ToString()
    {
        return "Order id: " + id + "\nDescription: " + desc + "\nState : " + state + "\nQuantity: " + qt + "\nPrice :" + price + "\nTable : " + tableID + "\nDestination: " + cookDestination + "\n";
    }
}

public enum CookType
{
     Bar, Kitchen
}

public enum OrderState
{
    Waiting, InProgress, Ready
}

public interface IOrderManager
{
    event newOrderBarDelegate newOrderBarEvent;
    event newOrderKitchenDelegate newOrderKitchenEvent;
    event orderChangedDelegate orderChangedEvent;
    void addOrder(Order o);
    void changeState(String orderID, OrderState newState);
    ArrayList getAllOrders();
    ArrayList getAllDestination(CookType ct);
    ArrayList getOrdersFromTable(int id);
    Order getOrderFromID(string id);
}
public delegate void newOrderBarDelegate(Order o);
public delegate void orderChangedDelegate(Order o);
public delegate void newOrderKitchenDelegate(Order o);


public class Repeater : MarshalByRefObject
{
    public event newOrderBarDelegate newOrderBar;
    public event newOrderKitchenDelegate newOrderKitchen;
    public event orderChangedDelegate orderChanged;
    public override object InitializeLifetimeService()
    {
        return null;
    }

    public void newOrderBarRepeater(Order o)
    {
        if (newOrderBar != null)
            newOrderBar(o);
    }
    public void newOrderKitchenRepeater(Order o)
    {
        if (newOrderKitchen != null)
            newOrderKitchen(o);
    }
    public void orderChangedRepeater(Order o)
    {
        if (orderChanged != null)
            orderChanged(o);
    }

}
