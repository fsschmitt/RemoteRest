using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public partial class Initial : Form
{
    public Initial()
    {
        InitializeComponent();
    }

    private void btnBar_Click(object sender, EventArgs e)
    {
        this.Hide();
        Program.startBar();
    }

    private void btnKitchen_Click(object sender, EventArgs e)
    {
        this.Hide();
        Program.startKitchen();
    }

}
