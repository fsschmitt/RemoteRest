using System;
using System.Collections;
using System.Linq;
using System.Text;


public class OrderManager:MarshalByRefObject, IOrderManager
{
    Hashtable orders;
    public event newOrderDelegate newOrderEvent;

    public OrderManager()
    {
        orders = new Hashtable();
    }
    public void addOrder(Order o)
    {
        
        orders.Add(o.Id, o);
        if (newOrderEvent != null)
            newOrderEvent(o);
        else
            Console.WriteLine("No one is listening!");
    }
    public void changeState(int orderID, OrderState newState)
    {
        if(orders.ContainsKey(orderID))
            ((Order)orders[orderID]).State= newState;
    }

}

