using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class Order
{
    int id;

    public Order()
    {
        id = 0;
        state = OrderState.Waiting;
        desc = "default order";
        tableID = 0;
        qt = 10;
        cookDestination = CookType.Bar;
        price = 10;

    }
    public int Id
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

    internal CookType CookDestination
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
    Kitchen, Bar
}

public enum OrderState
{
    Waiting, InProgress, Ready
}

public interface IOrderManager
{
    event newOrderDelegate newOrderEvent;
    void addOrder(Order o);
    void changeState(int orderID, OrderState newState);
}
public delegate void newOrderDelegate(Order o);

public class newOrderRepeater : MarshalByRefObject
{
    public event newOrderDelegate newOrder;

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public void Repeater(Order o)
    {
        if (newOrder != null)
            newOrder(o);
    }
}