
partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.btnNextState = new System.Windows.Forms.Button();
        this.lbOrders = new System.Windows.Forms.ListBox();
        this.groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.SuspendLayout();
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.pictureBox1);
        this.groupBox1.Controls.Add(this.btnNextState);
        this.groupBox1.Controls.Add(this.lbOrders);
        this.groupBox1.Location = new System.Drawing.Point(12, 12);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(500, 388);
        this.groupBox1.TabIndex = 0;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Orders";
        // 
        // pictureBox1
        // 
        this.pictureBox1.Image = global::CookClientNs.Properties.Resources.sushi_cook;
        this.pictureBox1.Location = new System.Drawing.Point(400, 324);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(75, 50);
        this.pictureBox1.TabIndex = 4;
        this.pictureBox1.TabStop = false;
        // 
        // btnNextState
        // 
        this.btnNextState.Location = new System.Drawing.Point(374, 19);
        this.btnNextState.Name = "btnNextState";
        this.btnNextState.Size = new System.Drawing.Size(120, 21);
        this.btnNextState.TabIndex = 3;
        this.btnNextState.Text = "Accept Order";
        this.btnNextState.UseVisualStyleBackColor = true;
        this.btnNextState.Click += new System.EventHandler(this.btnNextState_Click);
        // 
        // lbOrders
        // 
        this.lbOrders.FormattingEnabled = true;
        this.lbOrders.Location = new System.Drawing.Point(6, 19);
        this.lbOrders.Name = "lbOrders";
        this.lbOrders.Size = new System.Drawing.Size(361, 355);
        this.lbOrders.TabIndex = 0;
        this.lbOrders.SelectedIndexChanged += new System.EventHandler(this.lbOrders_SelectedIndexChanged);
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(524, 412);
        this.Controls.Add(this.groupBox1);
        this.Name = "MainForm";
        this.Text = "CookClient";
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
        this.groupBox1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnNextState;
    private System.Windows.Forms.ListBox lbOrders;
    private System.Windows.Forms.PictureBox pictureBox1;
}
