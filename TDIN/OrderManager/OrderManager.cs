using System;
using System.Collections;
using System.Linq;
using System.Text;


public class OrderManager:MarshalByRefObject, IOrderManager
{
    Hashtable orders;
    public event newOrderKitchenDelegate newOrderKitchenEvent;
    public event newOrderBarDelegate newOrderBarEvent;
    public event orderChangedDelegate orderChangedEvent;

    public OrderManager()
    {
        orders = new Hashtable();
    }
    public void addOrder(Order o)
    {
        
        orders.Add(o.Id, o);
        switch (o.CookDestination)
        {
            case CookType.Bar:
                if (newOrderBarEvent != null)
                     newOrderBarEvent(o);
                else
                    Console.WriteLine("No one in the Bar is listening!");
                break;
            case CookType.Kitchen:
                if (newOrderKitchenEvent != null)
                     newOrderKitchenEvent(o);
                else
                    Console.WriteLine("No one in the Kitchen is listening!");
                break;
            default:
                Console.WriteLine("OOPS");
                break;
        }
        
       
    }
    public void changeState(int orderID, OrderState newState)
    {
        if(orders.ContainsKey(orderID))
            ((Order)orders[orderID]).State= newState;
        if (orderChangedEvent != null)
            orderChangedEvent((Order)orders[orderID]);
    }

}

