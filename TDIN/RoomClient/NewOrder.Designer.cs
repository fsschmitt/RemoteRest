
    partial class NewOrder
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
            this.cbDesc = new System.Windows.Forms.ComboBox();
            this.cbDestination = new System.Windows.Forms.ComboBox();
            this.btnAddRequest = new System.Windows.Forms.Button();
            this.txtQt = new System.Windows.Forms.TextBox();
            this.lblQt = new System.Windows.Forms.Label();
            this.gbRequest = new System.Windows.Forms.GroupBox();
            this.lbRequests = new System.Windows.Forms.ListBox();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.lblTable = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbRequest.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbDesc
            // 
            this.cbDesc.Enabled = false;
            this.cbDesc.FormattingEnabled = true;
            this.cbDesc.Location = new System.Drawing.Point(140, 19);
            this.cbDesc.Name = "cbDesc";
            this.cbDesc.Size = new System.Drawing.Size(210, 21);
            this.cbDesc.TabIndex = 0;
            // 
            // cbDestination
            // 
            this.cbDestination.Enabled = false;
            this.cbDestination.FormattingEnabled = true;
            this.cbDestination.Items.AddRange(new object[] {
            "Bar",
            "Kitchen"});
            this.cbDestination.Location = new System.Drawing.Point(13, 19);
            this.cbDestination.Name = "cbDestination";
            this.cbDestination.Size = new System.Drawing.Size(121, 21);
            this.cbDestination.TabIndex = 1;
            this.cbDestination.SelectedIndexChanged += new System.EventHandler(this.cbDestination_SelectedIndexChanged);
            // 
            // btnAddRequest
            // 
            this.btnAddRequest.Enabled = false;
            this.btnAddRequest.Location = new System.Drawing.Point(275, 58);
            this.btnAddRequest.Name = "btnAddRequest";
            this.btnAddRequest.Size = new System.Drawing.Size(75, 23);
            this.btnAddRequest.TabIndex = 2;
            this.btnAddRequest.Text = "Add Request";
            this.btnAddRequest.UseVisualStyleBackColor = true;
            this.btnAddRequest.Click += new System.EventHandler(this.btnAddRequest_Click);
            // 
            // txtQt
            // 
            this.txtQt.Enabled = false;
            this.txtQt.Location = new System.Drawing.Point(140, 61);
            this.txtQt.Name = "txtQt";
            this.txtQt.Size = new System.Drawing.Size(100, 20);
            this.txtQt.TabIndex = 3;
            // 
            // lblQt
            // 
            this.lblQt.AutoSize = true;
            this.lblQt.Location = new System.Drawing.Point(88, 61);
            this.lblQt.Name = "lblQt";
            this.lblQt.Size = new System.Drawing.Size(46, 13);
            this.lblQt.TabIndex = 4;
            this.lblQt.Text = "Quantity";
            // 
            // gbRequest
            // 
            this.gbRequest.Controls.Add(this.lblQt);
            this.gbRequest.Controls.Add(this.txtQt);
            this.gbRequest.Controls.Add(this.btnAddRequest);
            this.gbRequest.Controls.Add(this.cbDesc);
            this.gbRequest.Controls.Add(this.cbDestination);
            this.gbRequest.Location = new System.Drawing.Point(12, 60);
            this.gbRequest.Name = "gbRequest";
            this.gbRequest.Size = new System.Drawing.Size(366, 100);
            this.gbRequest.TabIndex = 5;
            this.gbRequest.TabStop = false;
            this.gbRequest.Text = "Request";
            // 
            // lbRequests
            // 
            this.lbRequests.FormattingEnabled = true;
            this.lbRequests.Location = new System.Drawing.Point(12, 166);
            this.lbRequests.Name = "lbRequests";
            this.lbRequests.Size = new System.Drawing.Size(350, 173);
            this.lbRequests.TabIndex = 6;
            this.lbRequests.SelectedIndexChanged += new System.EventHandler(this.lbRequests_SelectedIndexChanged);
            // 
            // btnFinalize
            // 
            this.btnFinalize.Enabled = false;
            this.btnFinalize.Location = new System.Drawing.Point(277, 348);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(93, 23);
            this.btnFinalize.TabIndex = 7;
            this.btnFinalize.Text = "Finalize Order";
            this.btnFinalize.UseVisualStyleBackColor = true;
            this.btnFinalize.Click += new System.EventHandler(this.btnFinalize_Click);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(22, 24);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(34, 13);
            this.lblTable.TabIndex = 8;
            this.lblTable.Text = "Table";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(62, 21);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(100, 20);
            this.txtTable.TabIndex = 9;
            this.txtTable.TextChanged += new System.EventHandler(this.txtTable_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(12, 349);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete Request";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // NewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 384);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.btnFinalize);
            this.Controls.Add(this.lbRequests);
            this.Controls.Add(this.gbRequest);
            this.Name = "NewOrder";
            this.Text = "NewOrder";
            this.gbRequest.ResumeLayout(false);
            this.gbRequest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDesc;
        private System.Windows.Forms.ComboBox cbDestination;
        private System.Windows.Forms.Button btnAddRequest;
        private System.Windows.Forms.TextBox txtQt;
        private System.Windows.Forms.Label lblQt;
        private System.Windows.Forms.GroupBox gbRequest;
        private System.Windows.Forms.ListBox lbRequests;
        private System.Windows.Forms.Button btnFinalize;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.Button btnDelete;
    }
