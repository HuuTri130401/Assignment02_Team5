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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMemberDetails : Form
    {
        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Member MemberInformation { get; set; }
        public frmMemberDetails()
        {
            InitializeComponent();
        }

        
        private void btnSave_Click(object sender, EventArgs e)
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
    }
}
