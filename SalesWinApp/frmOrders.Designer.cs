namespace SalesWinApp
{
    partial class frmOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrders));
            this.lbReport = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.dgvMemberList = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.lbRequiredDate = new System.Windows.Forms.Label();
            this.lbFreight = new System.Windows.Forms.Label();
            this.lbCountry = new System.Windows.Forms.Label();
            this.lbMemberID = new System.Windows.Forms.Label();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.lbOrderID = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.txtRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.txtShippedDate = new System.Windows.Forms.DateTimePicker();
            this.txtFromNum = new System.Windows.Forms.DateTimePicker();
            this.txtToNum = new System.Windows.Forms.DateTimePicker();
            this.btnOrderDDetail = new System.Windows.Forms.Button();
            this.sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbReport
            // 
            this.lbReport.AutoSize = true;
            this.lbReport.Location = new System.Drawing.Point(86, 252);
            this.lbReport.Name = "lbReport";
            this.lbReport.Size = new System.Drawing.Size(92, 20);
            this.lbReport.TabIndex = 100;
            this.lbReport.Text = "Sales Report";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(918, 234);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 40);
            this.btnSearch.TabIndex = 98;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(633, 136);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(250, 27);
            this.txtFreight.TabIndex = 97;
            // 
            // dgvMemberList
            // 
            this.dgvMemberList.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemberList.Location = new System.Drawing.Point(50, 293);
            this.dgvMemberList.Name = "dgvMemberList";
            this.dgvMemberList.ReadOnly = true;
            this.dgvMemberList.RowHeadersWidth = 51;
            this.dgvMemberList.RowTemplate.Height = 29;
            this.dgvMemberList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemberList.Size = new System.Drawing.Size(833, 229);
            this.dgvMemberList.TabIndex = 95;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoad.Location = new System.Drawing.Point(224, 187);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(219, 37);
            this.btnLoad.TabIndex = 94;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNew.Location = new System.Drawing.Point(633, 187);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(111, 37);
            this.btnNew.TabIndex = 93;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDelete.Location = new System.Drawing.Point(782, 187);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 37);
            this.btnDelete.TabIndex = 92;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(206, 93);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(262, 27);
            this.txtMemberID.TabIndex = 90;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(206, 40);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(262, 27);
            this.txtOrderID.TabIndex = 89;
            // 
            // lbRequiredDate
            // 
            this.lbRequiredDate.AutoSize = true;
            this.lbRequiredDate.Location = new System.Drawing.Point(519, 44);
            this.lbRequiredDate.Name = "lbRequiredDate";
            this.lbRequiredDate.Size = new System.Drawing.Size(105, 20);
            this.lbRequiredDate.TabIndex = 87;
            this.lbRequiredDate.Text = "Required Date";
            // 
            // lbFreight
            // 
            this.lbFreight.AutoSize = true;
            this.lbFreight.Location = new System.Drawing.Point(519, 143);
            this.lbFreight.Name = "lbFreight";
            this.lbFreight.Size = new System.Drawing.Size(55, 20);
            this.lbFreight.TabIndex = 86;
            this.lbFreight.Text = "Freight";
            // 
            // lbCountry
            // 
            this.lbCountry.AutoSize = true;
            this.lbCountry.Location = new System.Drawing.Point(519, 96);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(100, 20);
            this.lbCountry.TabIndex = 85;
            this.lbCountry.Text = "Shipped Date";
            // 
            // lbMemberID
            // 
            this.lbMemberID.AutoSize = true;
            this.lbMemberID.Location = new System.Drawing.Point(94, 96);
            this.lbMemberID.Name = "lbMemberID";
            this.lbMemberID.Size = new System.Drawing.Size(84, 20);
            this.lbMemberID.TabIndex = 84;
            this.lbMemberID.Text = "Member ID";
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Location = new System.Drawing.Point(95, 139);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(83, 20);
            this.lbOrderDate.TabIndex = 83;
            this.lbOrderDate.Text = "Order Date";
            // 
            // lbOrderID
            // 
            this.lbOrderID.AutoSize = true;
            this.lbOrderID.Location = new System.Drawing.Point(95, 44);
            this.lbOrderID.Name = "lbOrderID";
            this.lbOrderID.Size = new System.Drawing.Size(66, 20);
            this.lbOrderID.TabIndex = 82;
            this.lbOrderID.Text = "Order ID";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.RosyBrown;
            this.btnClose.Location = new System.Drawing.Point(918, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 34);
            this.btnClose.TabIndex = 103;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(206, 133);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(262, 27);
            this.txtOrderDate.TabIndex = 104;
            // 
            // txtRequiredDate
            // 
            this.txtRequiredDate.Location = new System.Drawing.Point(633, 40);
            this.txtRequiredDate.Name = "txtRequiredDate";
            this.txtRequiredDate.Size = new System.Drawing.Size(250, 27);
            this.txtRequiredDate.TabIndex = 105;
            // 
            // txtShippedDate
            // 
            this.txtShippedDate.Location = new System.Drawing.Point(633, 93);
            this.txtShippedDate.Name = "txtShippedDate";
            this.txtShippedDate.Size = new System.Drawing.Size(250, 27);
            this.txtShippedDate.TabIndex = 106;
            // 
            // txtFromNum
            // 
            this.txtFromNum.Location = new System.Drawing.Point(206, 245);
            this.txtFromNum.Name = "txtFromNum";
            this.txtFromNum.Size = new System.Drawing.Size(262, 27);
            this.txtFromNum.TabIndex = 107;
            // 
            // txtToNum
            // 
            this.txtToNum.Location = new System.Drawing.Point(633, 247);
            this.txtToNum.Name = "txtToNum";
            this.txtToNum.Size = new System.Drawing.Size(250, 27);
            this.txtToNum.TabIndex = 108;
            // 
            // btnOrderDDetail
            // 
            this.btnOrderDDetail.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOrderDDetail.Location = new System.Drawing.Point(918, 469);
            this.btnOrderDDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOrderDDetail.Name = "btnOrderDDetail";
            this.btnOrderDDetail.Size = new System.Drawing.Size(107, 53);
            this.btnOrderDDetail.TabIndex = 104;
            this.btnOrderDDetail.Text = "&OrderDetail";
            this.btnOrderDDetail.UseVisualStyleBackColor = false;
            this.btnOrderDDetail.Click += new System.EventHandler(this.btnOrderDDetail_Click);
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 615);
            this.Controls.Add(this.btnOrderDDetail);
            this.Controls.Add(this.txtToNum);
            this.Controls.Add(this.txtFromNum);
            this.Controls.Add(this.txtShippedDate);
            this.Controls.Add(this.txtRequiredDate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbReport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFreight);
            this.Controls.Add(this.dgvMemberList);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtMemberID);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.lbRequiredDate);
            this.Controls.Add(this.lbFreight);
            this.Controls.Add(this.lbCountry);
            this.Controls.Add(this.lbMemberID);
            this.Controls.Add(this.lbOrderDate);
            this.Controls.Add(this.lbOrderID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Manager";
            this.Load += new System.EventHandler(this.frmOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lbReport;
        private Button btnSearch;
        private TextBox txtFreight;
        private DataGridView dgvMemberList;
        private Button btnLoad;
        private Button btnNew;
        private Button btnDelete;
        private TextBox txtMemberID;
        private TextBox txtOrderID;
        private Label lbRequiredDate;
        private Label lbFreight;
        private Label lbCountry;
        private Label lbMemberID;
        private Label lbOrderDate;
        private Label lbOrderID;
        private Button btnClose;
        private DateTimePicker txtOrderDate;
        private DateTimePicker txtRequiredDate;
        private DateTimePicker txtShippedDate;
        private DateTimePicker txtFromNum;
        private DateTimePicker txtToNum;
        private Button btnOrderDDetail;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
    }
}