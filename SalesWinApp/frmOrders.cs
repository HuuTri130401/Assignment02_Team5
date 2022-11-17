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
    public partial class frmOrders : Form
    {
        public bool IsAdmin { get; set; }
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
            var orders = orderRepository.GetOrders();

            try
            {
                //The BindingSource component is designed to simplify
                //the process of binding controls to an underlying data source
                source = new BindingSource();
                source.DataSource = orders.OrderByDescending(order => order.OrderDate);

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
                if (IsAdmin == false)
                {
                    if (orders.Count() == 0)
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
                    if (orders.Count() == 0)
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
            //
            btnDelete.Enabled = false;
            dgvMemberList.CellDoubleClick += dgvOrderList_CellDoubleClick;
        }

        private void dgvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmOrderDetails frm = new frmOrderDetails
            {
                Text = "Update order",
                InsertOrUpdate = true,
                OrderInfor = GetOrderObject(),
                OrderRepo = orderRepository
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadOrdersList();
                //Set focus order updated
                source.Position = source.Count - 1;
            }
        }


        private void txtShippedDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOrdersList();
        }

        private Order? GetOrderObject()
        {
            Order? order = null;
            try
            {
                order = new Order
                {
                    OrderId = int.Parse(txtOrderID.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    Freight = decimal.Parse(txtFreight.Text),
                    MemberId = int.Parse(txtMemberID.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order");
            }
            return order;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Do you want to delete this order?","Delete Confirmation",MessageBoxButtons.YesNo);
            if (dialogResult==DialogResult.Yes)
            {
                try
                {
                    var order = GetOrderObject();
                    orderRepository.DeleteOrder(order.OrderId);
                    LoadOrdersList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete an order");
                } 
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //}

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmOrderDetails frm = new frmOrderDetails
            {
                //isAdmin = this.isAdmin,
                Text = "Add Order",
                InsertOrUpdate = false,
                OrderRepo = orderRepository
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadOrdersList();
                source.Position = source.Count - 1;
            }
        }

        private void FindOrderBetween()
        {
            List<Order> findList = new List<Order>();
            try
            {
                findList = orderRepository.GetOrderByOrderdDate(DateTime.Parse(txtFromNum.Text), DateTime.Parse(txtToNum.Text));
                if (findList.Count != 0)
                {
                    source = new BindingSource();
                    source.DataSource = findList.OrderByDescending(order => order.OrderDate);
                    txtFreight.DataBindings.Clear();
                    txtMemberID.DataBindings.Clear();
                    txtOrderDate.DataBindings.Clear();
                    txtOrderID.DataBindings.Clear();
                    txtRequiredDate.DataBindings.Clear();
                    txtShippedDate.DataBindings.Clear();

                    txtFreight.DataBindings.Add("Text", source, "Freight");
                    txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                    txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                    txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                    txtOrderID.DataBindings.Add("Text", source, "OrderId");
                    txtMemberID.DataBindings.Add("Text", source, "MemberId");

                    dgvMemberList.DataSource = null;
                    dgvMemberList.DataSource = source;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Order List");
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindOrderBetween();
        }
    }
}
