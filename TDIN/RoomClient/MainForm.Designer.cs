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
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnCloseTable = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvTables = new System.Windows.Forms.TreeView();
            this.gbTables = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.gbTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Location = new System.Drawing.Point(28, 23);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(75, 23);
            this.btnNewOrder.TabIndex = 0;
            this.btnNewOrder.Text = "New Order";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnCloseTable
            // 
            this.btnCloseTable.Enabled = false;
            this.btnCloseTable.Location = new System.Drawing.Point(28, 52);
            this.btnCloseTable.Name = "btnCloseTable";
            this.btnCloseTable.Size = new System.Drawing.Size(75, 23);
            this.btnCloseTable.TabIndex = 1;
            this.btnCloseTable.Text = "Close Table";
            this.btnCloseTable.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCloseTable);
            this.panel1.Controls.Add(this.btnNewOrder);
            this.panel1.Location = new System.Drawing.Point(8, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 94);
            this.panel1.TabIndex = 3;
            // 
            // tvTables
            // 
            this.tvTables.Location = new System.Drawing.Point(6, 19);
            this.tvTables.Name = "tvTables";
            this.tvTables.Size = new System.Drawing.Size(389, 276);
            this.tvTables.TabIndex = 4;
            // 
            // gbTables
            // 
            this.gbTables.Controls.Add(this.tvTables);
            this.gbTables.Location = new System.Drawing.Point(155, 12);
            this.gbTables.Name = "gbTables";
            this.gbTables.Size = new System.Drawing.Size(401, 301);
            this.gbTables.TabIndex = 5;
            this.gbTables.TabStop = false;
            this.gbTables.Text = "Tables";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbTables);
            this.Name = "MainForm";
            this.Text = "RoomClient";
            this.panel1.ResumeLayout(false);
            this.gbTables.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnCloseTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvTables;
        private System.Windows.Forms.GroupBox gbTables;

    }
