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

    public partial class NewOrder : Form
    {
        private ArrayList orders = new ArrayList();
        private double[] pricesKitchen = {4.95,6.95,5.95, 9.95,3.95,4.95, 4.95,3.95,3.95,3.95,5.95,6.95,3.95,3.95,3.95,4.95,3.95,4.95,7.95,3.95,4.95,4.95,4.95,4.95,3.95,3.95,4.95,4.95,9.95,5.95,5.95,6.95, 5.95 };
        private String[] foodKitchen = {
            "Aji - Spanish Mackerel",
            "Ama-Ebi - sweet shrimp" ,
            "Anago - sea eel",
            "Awabi - abalone",
            "Ebi - shrimp",
            "Hamachi - Yellow Tail",
            "Hirame - Halibut",
            "Hokkigai - Surf Clam",
            "Hotate - scallop",
            "Ika - squid",
            "Ikura - Salmon roe",
            "Iku-Tama - Salmon roe with Quail eggs",
            "Inari - fried bean curd pouch stuffed with Sushi rice",
            "Kani - real crab meat",
            "Katsuo - Bonito (Skipjack Tuna)",
            "Kazunoko - Herring roe",
            "Kodako - baby octopus",
            "Maguro - Tuna",
            "Mirugai - Long Neck Clam",
            "Saba - Mackerel",
            "Sake - Salmon",
            "Smoked Sake - smoked Salmon",
            "Shiro Maguro - White Tuna",
            "Suzuki - Striped Bass",
            "Tamago - cooked egg",
            "Tobiko - Flying Fish roe",
            "Tobi-Tama - Flying Fish roe with Quail eggs",
            "Tako - octopus",
            "Toro - Tuna belly",
            "Unagi - fresh water eel",
            "Uni - Sea Urchin",
            "Uni Tama - Sea Urchin with Quail eggs",
            "Waru – Escolar, fatty white tuna"};
        private double[] pricesBar = {0.5, 2.0, 1.5,  1.5, 1.5, 7.0 };
        private String[] foodBar = { "Water", "Beer", "Cola", "Sprite", "Fanta", "Rose" };

        private double[][] prices = new double[2][];
        private String[][] foods = new String[2][];
        
        public NewOrder()
        {

            prices[0] = pricesBar;
            prices[1] = pricesKitchen;

            foods[0] = foodBar;
            foods[1] = foodKitchen;

           
            InitializeComponent();
            cbDestination.SelectedIndex = 0;
            txtQt.Text = "1";
            
        }

        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            int qt = Convert.ToInt32(txtQt.Text);
            String desc = cbDesc.SelectedItem.ToString();
            int tableID = Convert.ToInt32(txtTable.Text);
            double price = prices[cbDestination.SelectedIndex][cbDesc.SelectedIndex];
            CookType cookDestination = (CookType)Enum.ToObject(typeof(CookType), cbDestination.SelectedIndex);
            Order o = new Order(qt, desc,tableID, price, cookDestination);
            lbRequests.Items.Add(o.TableID + " - " + o.CookDestination + ": "+ o.Description + " - " + o.Qt);
            txtTable.Enabled = false;
            btnFinalize.Enabled = true;
            orders.Add(o);
        }

        public void cbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDesc.Items.Clear();
            cbDesc.Items.AddRange(foods[cbDestination.SelectedIndex]);
            cbDesc.SelectedIndex = 0;

        }

        private void lbRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lbRequests.SelectedIndex;
            orders.RemoveAt(index);
            lbRequests.Items.RemoveAt(index);
            btnDelete.Enabled = false;
            if (lbRequests.Items.Count == 0)
                btnFinalize.Enabled = false;
        }

        private void txtTable_TextChanged(object sender, EventArgs e)
        {
            if (txtTable.Text != "")
            {
                txtQt.Enabled = true;
                cbDesc.Enabled = true;
                cbDestination.Enabled = true;
                btnAddRequest.Enabled = true;

            }
            else
            {
                txtQt.Enabled = false;
                cbDesc.Enabled = false;
                cbDestination.Enabled = false;
                btnAddRequest.Enabled = false;
            }
        }

        delegate void updateViewDelegate(Table t);
        delegate void updateTableDelegate(int index);
        private void btnFinalize_Click(object sender, EventArgs e)
        {
            int tableID = Convert.ToInt32(txtTable.Text);
            foreach (Order o in orders)
                Program.rc.OrderManager.addOrder(o);

            this.Close();
        }

        


        
    }

