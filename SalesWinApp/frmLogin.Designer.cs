namespace SalesWinApp
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.frmOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // frmOrders
            // 
            this.frmOrders.Location = new System.Drawing.Point(334, 305);
            this.frmOrders.Name = "frmOrders";
            this.frmOrders.Size = new System.Drawing.Size(198, 63);
            this.frmOrders.TabIndex = 0;
            this.frmOrders.Text = "frmOrders";
            this.frmOrders.UseVisualStyleBackColor = true;
            this.frmOrders.Click += new System.EventHandler(this.frmOrders_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.frmOrders);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button frmOrders;
    }
}