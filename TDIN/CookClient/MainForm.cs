using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;


public partial class MainForm : Form
{
    private ArrayList orders = new ArrayList();
    public MainForm()
    {
        InitializeComponent();
        btnNextState.Enabled = false;
    }
    public delegate void addNewOrderDelegate(Order o);

    public void addInitialOrders(ArrayList ordersL)
    {
        if (lbOrders.InvokeRequired)
        {
            this.BeginInvoke(new addNewOrderDelegate(addNewOrder), ordersL);
            return;
        }
        foreach (Order o in ordersL)
        {
            lbOrders.Items.Add(o.Description + " - " + o.State);
        }
        orders.AddRange(ordersL);
    }

    public void addNewOrder(Order o){
        if (lbOrders.InvokeRequired)
        {
            this.BeginInvoke(new addNewOrderDelegate(addNewOrder), o);
            return;
        }
        else
            lbOrders.Items.Add(o.Description + " - " + o.State);
           
            orders.Add(o);
    }

    private void btnNextState_Click(object sender, EventArgs e)
    {
        int index = lbOrders.SelectedIndex;

        Order o = ((Order)orders[index]);


        o.State = (OrderState)(((int)(o.State + 1)) % 3);
        Program.cc.OrderManager.changeState(o.Id, o.State);

        if (lbOrders.Items.Count == 0)
        {
            btnNextState.Enabled = false;
        }
        
    }

    private int getOrderIndex(Order o)
    {
        int index = 0;
        foreach (Order ord in orders)
        {
            if (ord.Id == o.Id)
            {
                break;
            }
            index++;
        }
        return index; 
    }

    String[] btnTexts = { "Accept Order", "Finalize Order"};
    public void changeOrderState(Order o)
    {
        int index = getOrderIndex(o);
        if (lbOrders.InvokeRequired)
        {
            this.BeginInvoke(new addNewOrderDelegate(changeOrderState), o);
            return;
        }

        if (Program.debug)
        {
            Console.WriteLine("My index is: " + index);
            Console.WriteLine("ORDER SELECTED");
            Console.WriteLine(o);
        }

        if (OrderState.Ready == o.State)
        {
            btnNextState.Enabled = false;
            orders.RemoveAt(index);
            lbOrders.Items.RemoveAt(index);
            btnNextState.Text = btnTexts[0];
        }
        else
        {
            btnNextState.Text = btnTexts[(int)o.State];
            lbOrders.Items[index] = o.Description + " - " + o.State;
        }
        
        lbOrders.Refresh();
    }

    private void lbOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        int index = lbOrders.SelectedIndex;
        if (index < 0)
            return;

        if (Program.debug) Console.WriteLine("Index: " + index + ", Count: " + orders.Count);

        Order o = (Order)orders[index];
        btnNextState.Text = btnTexts[(int)o.State];
        btnNextState.Enabled = true;
    }

}

