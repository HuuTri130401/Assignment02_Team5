using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMemberDetails : Form
    {
        private const string EmailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Member MemberInformation { get; set; }
        public frmMemberDetails()
        {
            InitializeComponent();
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text)||string.IsNullOrEmpty(txtMemberName.Text)||string.IsNullOrEmpty(txtEmail.Text)||string.IsNullOrEmpty(txtPassword.Text))
            {
                txtMemberID.Focus();
                errMemberID.SetError(txtMemberID, "Blank ID not allowed");
            }
            var dialogResult = MessageBox.Show("Save changes?","Save Confirmation",MessageBoxButtons.YesNo);
            if (dialogResult==DialogResult.Yes)
            {
                try
                {
                    var member = new Member
                    {
                        MemberId = int.Parse(txtMemberID.Text),
                        CompanyName = txtMemberName.Text,
                        City = cboCity.Text,
                        Email = txtEmail.Text,
                        Country = cboCountry.Text,
                        Password = txtPassword.Text,
                    };
                    if (InsertOrUpdate == false)
                    {
                        MemberRepository.InsertMember(member);
                    }
                    else
                    {
                        MemberRepository.UpdateMember(member);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Member" : "Update a Member");
                } 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMemberDetails_Load(object sender, EventArgs e)
        {
            cboCity.SelectedIndex = 0;
            txtMemberID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)//update mode
            {
                //Show member to perform updating
                txtMemberID.Text = MemberInformation.MemberId.ToString();
                txtMemberName.Text = MemberInformation.CompanyName;
                cboCity.Text = MemberInformation.City;
                txtEmail.Text = MemberInformation.Email;
                cboCountry.Text = MemberInformation.Country;
                txtPassword.Text = MemberInformation.Password;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.Focus();
                errEmail.SetError(txtEmail, "Blank username not allowed");
            }
            else if (!Regex.IsMatch(txtEmail.Text, EmailPattern))
            {
                txtEmail.Focus();
                errEmail.SetError(txtEmail, "Wrong email format");
            }
            else
            {
                errEmail.Clear();
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                errPassword.SetError(txtPassword, "Blank password not allowed");
            }
            else
            {
                errPassword.Clear();
            }
        }

        private void txtMemberID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                txtMemberID.Focus();
                errMemberID.SetError(txtMemberID, "Blank ID not allowed");
            }
            else
            {
                errMemberID.Clear();
            }
        }

        private void txtMemberName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberName.Text))
            {
                txtMemberName.Focus();
                errMemberName.SetError(txtMemberName, "Blank name not allowed");
            }
            else
            {
                errMemberName.Clear();
            }
        }
    }
}
