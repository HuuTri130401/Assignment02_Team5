using BusinessObject.Models;
using DataAcces.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmOrderDetails : Form
    {
        public frmOrderDetails()
        {
            InitializeComponent();
        }
        public bool IsAdmin { get; set; }
        public IOrderRepository OrderRepo { get; set; }
        public bool InsertOrUpdate { get; set; } //False?Insert:Update
        public Order OrderInfor { get; set; }
        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            txtOrderID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)//update mode
            {
                //Show order to perform updating
                txtOrderID.Text = OrderInfor.OrderId.ToString();
                dtOrderDate.Text = DateTime.Now.ToString();
                txtMemberID.Text = OrderInfor.MemberId.ToString();
                dtRequiredDate.Text = OrderInfor.RequiredDate.ToString();
                dtShippedDate.Text = OrderInfor.ShippedDate.ToString();
                txtFreight.Text = OrderInfor.Freight.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var order = new Order
                {
                    OrderId = int.Parse(txtOrderID.Text),
                    OrderDate = DateTime.Parse(dtOrderDate.Text),
                    ShippedDate = DateTime.Parse(dtShippedDate.Text),
                    RequiredDate = DateTime.Parse(dtRequiredDate.Text),
                    Freight = decimal.Parse(txtFreight.Text),
                    MemberId = int.Parse(txtMemberID.Text),

                };
                if (InsertOrUpdate == false)
                {
                    OrderRepo.InsertOrder(order);
                }
                else
                {
                    OrderRepo.UpdateOrder(order);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new order" : "Update a order detail");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }//end frmOrderDetails
}//end name space
