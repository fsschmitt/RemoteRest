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

        changeOrderState(index);
        if (lbOrders.Items.Count == 0)
        {
            btnNextState.Enabled = false;
        }
        
    }

    String[] btnTexts = { "Accept Order", "Finalize Order", "Remove Order" };
    private void changeOrderState(int index)
    {
        Order o = ((Order)orders[index]);
        
        o.State = (OrderState)(((int)(o.State + 1)) % 3);
        if (Program.debug)
        {
            Console.WriteLine("ORDER SELECTED");
            Console.WriteLine(o);
           
        }
        
        btnNextState.Text = btnTexts[(int)o.State];
        
        if ((int)o.State == 0)
        {
            btnNextState.Enabled = false;
            orders.RemoveAt(index);
            lbOrders.Items.RemoveAt(index);
        }
        else
        {
            Program.cc.OrderManager.changeState(o.Id, o.State);
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

