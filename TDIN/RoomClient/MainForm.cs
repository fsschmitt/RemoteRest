using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


    public partial class MainForm : Form
    {
        ImageList myImageList = new ImageList();
        public MainForm()
        {
            InitializeComponent();
            myImageList.Images.Add(global::RoomClientNs.Properties.Resources.green);
            myImageList.Images.Add(global::RoomClientNs.Properties.Resources.yellow);
            myImageList.Images.Add(global::RoomClientNs.Properties.Resources.red);
            tvTables.ImageList = myImageList;
        }



        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            NewOrder no = new NewOrder();
            no.Show();
        }

        public delegate void addInitialTablesDelegate();
        public void addInitialTables()
        {
            if (tvTables.InvokeRequired)
            {
                this.BeginInvoke(new addInitialTablesDelegate(addInitialTables));
                return;
            }

            ICollection myTables = Program.rc.Tables.Values;
            foreach (Table t in myTables)
            {
                TreeNode[] orders = getTreeNodes(t);
                tvTables.Nodes.Add(new TreeNode("Table: " + t.Id, orders));
            }
        }

        public delegate void addNewTableDelegate(Table t);
        public void addNewTable(Table t)
        {
            if (tvTables.InvokeRequired)
            {
                this.BeginInvoke(new addNewTableDelegate(addNewTable), t);
                return;
            }
            TreeNode[] orders = getTreeNodes(t);
            tvTables.Nodes.Add(new TreeNode("Table: " + t.Id, orders));
            
        }

        private static TreeNode[] getTreeNodes(Table t)
        {
            TreeNode[] orders = new TreeNode[t.Orders.Count];
            int i = 0;
            foreach (Order o in t.Orders)
            {
                switch (o.State)
                {
                    case OrderState.Waiting:
                        orders[i] = new TreeNode(o.Description, 2, 2);
                        break;
                    case OrderState.InProgress:
                        orders[i] = new TreeNode(o.Description, 1, 1);
                        break;
                    case OrderState.Ready:
                        orders[i] = new TreeNode(o.Description, 0, 0);
                        break;
                }
                i++;
            }
            return orders;
        }
        public int findTableInTreeView(int tableID)
        {
            int i = 0;
            foreach (TreeNode t in tvTables.Nodes)
            {
                if (t.Text == "Table: " + tableID)
                    return i;
                i++;
            }
            return -1;
            
        }
        public delegate void removeTableDelegate(int id);
        private void removeTable(int tableID)
        {
            if (tvTables.InvokeRequired)
            {
                this.BeginInvoke(new removeTableDelegate(removeTable), tableID);
                return;
            }
            tvTables.Nodes.RemoveAt(findTableInTreeView(tableID));
        }

        public delegate void updateTableDelegate(int id);
        public void updateTable(int tableID)
        {
            if (tvTables.InvokeRequired)
            {
                this.BeginInvoke(new updateTableDelegate(updateTable), tableID);
                return;
            }
            TreeNode[] orders = getTreeNodes((Table)Program.rc.Tables[tableID]);
            int index = findTableInTreeView(tableID);
            Console.WriteLine("INDEX = " + index);
            if(index!=-1){
                tvTables.Nodes[index].Nodes.Clear();
                tvTables.Nodes[index].Nodes.AddRange(orders);
            }else{
                Console.WriteLine("COUNT: " + tvTables.Nodes.Count);
                foreach (TreeNode t in tvTables.Nodes)
                {
                    Console.WriteLine("Key:" + t.Text);
                }
            }
        }

        private double getTableTotal(int tableID)
        {
            Table t = (Table)Program.rc.Tables[tableID];
            double sum = 0;
            foreach (Order o in t.Orders)
                sum += o.Price;
            return sum;
        }
        private int getIdFromText(String text)
        {
            return Convert.ToInt32((text.Substring(text.IndexOf(' ')+1)));
        }
        private void btnCloseTable_Click(object sender, EventArgs e)
        {
            int index = getIdFromText(tvTables.SelectedNode.Text);
            bool canClose = true;
            foreach (Order o in ((Table)Program.rc.Tables[index]).Orders)
            {
                if (o.State != OrderState.Ready)
                {
                    canClose = false;
                    break;
                }
            }
            if (canClose)
            {

                if (MessageBox.Show("Table total : " + getTableTotal(index) + "€", "Confirm close table", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Program.rc.Tables.Remove(index);
                    removeTable(index);
                    btnCloseTable.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Must wait for all orders to be attended.");
            }
           
        }

        

       
        private void tvTables_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvTables.SelectedNode.Text.Contains("Table: "))
            {
                btnCloseTable.Enabled = true;
            }
            else
            {
                btnCloseTable.Enabled = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            addInitialTables();
        }

        
    }

