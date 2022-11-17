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
    public partial class frmOrders : Form
    {
        public bool isAdmin { get; set; }
        IOrderRepository orderRepository = new OrderRepository();
        BindingSource source;
        public frmOrders()
        {
            InitializeComponent();
        }

        //Clear text on TextBoxes
        private void ClearText()
        {
            txtFreight.Text = string.Empty;
            txtMemberID.Text = string.Empty;
            txtOrderDate.Text = string.Empty;
            txtOrderID.Text = string.Empty;
            txtRequiredDate.Text = string.Empty;
            txtShippedDate.Text = string.Empty;
        }

        public void LoadOrdersList()
        {
            var members = orderRepository.GetOrders();

            try
            {
                //The BindingSource component is designed to simplify
                //the process of binding controls to an underlying data source
                source = new BindingSource();
                source.DataSource = members.OrderByDescending(member => member.OrderDate);

                txtMemberID.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtOrderID.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderId");
                txtMemberID.DataBindings.Add("Text", source, "MemberId");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");


                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (isAdmin == false)
                {
                    if (members.Count() == 0)
                    {
                        ClearText();
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                    }
                }
                else
                {
                    if (members.Count() == 0)
                    {
                        ClearText();
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load order list");
            }
        }
        private void frmOrders_Load(object sender, EventArgs e)
        {

        }

        private void txtShippedDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOrdersList();
        }
    }
}
