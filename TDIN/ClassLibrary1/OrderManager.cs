using System;
using System.Collections;
using System.Linq;
using System.Text;


public class OrderManager
{
    Hashtable orders = new Hashtable();

    public void addOrder(Order o)
    {
        orders.Add(o.Id, o);
    }
    public void changeState(int orderID, Utils.OrderState newState)
    {
        if(orders.ContainsKey(orderID))
            ((Order)orders[orderID]).State = newState;
    }

}

