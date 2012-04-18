using System;
using System.Collections;
using System.Linq;
using System.Text;

    public class Table
    {
        int id;
        ArrayList orders;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        public ArrayList Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public Table(int id)
        {
            this.id = id;
            orders = new ArrayList();
        }

        public void addOrder(Order o)
        {
            orders.Add(o);
        }

        public void removeOrder(Order o)
        {
            int i = 0;
            foreach (Order ord in orders)
            {
                if (ord.Id == o.Id)
                {
                    break;
                }
                i++;
            }
            orders.RemoveAt(i);
        }

        public void addOrders(ArrayList newOrders)
        {
            orders.AddRange(newOrders);
        }

        public double getTotal()
        {
            double sum = 0.0;
            foreach (Order o in orders)
            {
                sum += o.Price;
            }
            return sum;
        }



    }
