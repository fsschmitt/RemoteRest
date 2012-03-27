using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
class Order
{
    int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    Utils.OrderState state;

    internal Utils.OrderState State
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
    Utils.CookType cookDestination;

    internal Utils.CookType CookDestination
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
}

