
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject.Models;

namespace SalesWinApp
{
    public partial class frmProductDetails : Form
    {
       
        public IProductRepository ProductRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Product ProductInfor { get; set; }
        //----------------------------------------------

        public frmProductDetails()
        {
            InitializeComponent();
        }
        private void frmProductDetails_Load(object sender, EventArgs e)
        {
        
            txtProductID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)//update mode
            {
                //Show member to perform updating
                txtProductID.Text = ProductInfor.ProductId.ToString();
                txtProductName.Text = ProductInfor.ProductName;
                txtCategoryID.Text = ProductInfor.CategoryId.ToString();
                txtWeight.Text = ProductInfor.Weight;
                txtUnitPrice.Text = ProductInfor.UnitPrice.ToString();
                txtUnitsInStock.Text = ProductInfor.UnitsInStock.ToString();

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Save changes?","Save Confirmation",MessageBoxButtons.YesNo);
            if (dialogResult==DialogResult.Yes)
            {
                try
                {
                    var product = new Product
                    {
                        ProductId = int.Parse(txtProductID.Text),
                        ProductName = txtProductName.Text,
                        Weight = txtWeight.Text,
                        UnitPrice = int.Parse(txtUnitPrice.Text),
                        UnitsInStock = int.Parse(txtUnitsInStock.Text),
                        CategoryId = int.Parse(txtCategoryID.Text),

                    };
                    if (InsertOrUpdate == false)
                    {
                        ProductRepository.InsertProduct(product);
                    }
                    else
                    {
                        ProductRepository.UpdateProduct(product);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Product" : "Update a Product");
                }  
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void ThrowsErrorProvider(ErrorProvider error,string message,TextBox control)
        {
            if (string.IsNullOrEmpty( control.Text))
            {
                control.Focus();
                error.SetError(control, message);
            }
            else
            {
                error.Clear();
            }
        }
        
        private void txtProductID_Leave(object sender, EventArgs e)
        {
            ThrowsErrorProvider(errProductID, "Blank product ID not allowed", txtProductID);
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            ThrowsErrorProvider(errProductName, "Blank product name not allowed", txtProductName);
        }

        private void txtCategoryID_Leave(object sender, EventArgs e)
        {
            ThrowsErrorProvider(errCategoryID, "Blank category ID not allowed", txtCategoryID);
        }

        private void txtWeight_Leave(object sender, EventArgs e)
        {
            ThrowsErrorProvider(errWeight, "Blank weight not allowed", txtWeight);
        }

        private void txtUnitPrice_Leave(object sender, EventArgs e)
        {
            ThrowsErrorProvider(errUnitPrice, "Blank unit price not allowed", txtUnitPrice);
        }

        private void txtUnitsInStock_Leave(object sender, EventArgs e)
        {
            ThrowsErrorProvider(errUnitsInStock, "Blank unit in stock not allowed", txtUnitsInStock);
        }
    }
}
