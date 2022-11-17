using BusinessObject.Models;
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

namespace SalesWinApp
{
    public partial class frmMembers : Form
    {
        public bool IsAdmin { get; set; }
        private IMemberRepository _memberRepository = new MemberRepository();
        //Create a data source
        BindingSource _source;
        public frmMembers()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMemberDetails frmMemberDetails = new frmMemberDetails
            {
                Text = "Add member",
                InsertOrUpdate = false,
                MemberRepository = _memberRepository
            };
            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                //Set focus member inserted
                _source.Position = _source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var member = GetMemberObject();
                _memberRepository.DeleteMember(member.MemberId);
                LoadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a member");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadOneMember();
        }

        private void LoadOneMember()
        {
            Member member = new Member();
            var members = _memberRepository.GetMembers();
            try
            {
                foreach (var i in members)
                {
                    //The BindingSource omponent is designed to simplify
                    //the process of binding controls to an underlying data source
                    if (i.CompanyName.Equals(txtSearch.Text))
                    {
                        _source = new BindingSource();


                        _source.DataSource = _memberRepository.GetMemberByID(i.MemberId);

                        txtMemberID.DataBindings.Clear();
                        txtMemberName.DataBindings.Clear();
                        txtPassword.DataBindings.Clear();
                        txtEmail.DataBindings.Clear();
                        cboCountry.DataBindings.Clear();
                        cboCity.DataBindings.Clear();

                        txtMemberID.DataBindings.Add("Text", _source, "MemberId");
                        txtMemberName.DataBindings.Add("Text", _source, "CompanyName");
                        txtPassword.DataBindings.Add("Text", _source, "Password");
                        txtEmail.DataBindings.Add("Text", _source, "Email");
                        cboCountry.DataBindings.Add("Text", _source, "Country");
                        cboCity.DataBindings.Add("Text", _source, "City");


                        dgvMemberList.DataSource = null;
                        dgvMemberList.DataSource = _source;
                        break;
                    }
                    else if (i.MemberId.ToString().Equals(txtSearch.Text))
                    {
                        _source = new BindingSource();


                        _source.DataSource = _memberRepository.GetMemberByID(i.MemberId);

                        txtMemberID.DataBindings.Clear();
                        txtMemberName.DataBindings.Clear();
                        txtPassword.DataBindings.Clear();
                        txtEmail.DataBindings.Clear();
                        cboCountry.DataBindings.Clear();
                        cboCity.DataBindings.Clear();

                        txtMemberID.DataBindings.Add("Text", _source, "MemberId");
                        txtMemberName.DataBindings.Add("Text", _source, "CompanyName");
                        txtPassword.DataBindings.Add("Text", _source, "Password");
                        txtEmail.DataBindings.Add("Text", _source, "Email");
                        cboCountry.DataBindings.Add("Text", _source, "Country");
                        cboCity.DataBindings.Add("Text", _source, "City");


                        dgvMemberList.DataSource = null;
                        dgvMemberList.DataSource = _source;
                        break;
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            if (IsAdmin == false)
            {
                btnDelete.Enabled = false;
                btnNew.Enabled = false;

                cboCity.Enabled = false;
                cboCountry.Enabled = false;
                txtEmail.Enabled = false;
                txtMemberID.Enabled = false;
                txtMemberName.Enabled = false;
                txtPassword.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                cboSearchCity.Enabled = false;
                cboSearchCountry.Enabled = false;
                dgvMemberList.CellDoubleClick += null;
            }
            else
            {
                btnDelete.Enabled = false;
                
                //Register this event to open the frmMemberDetail form that performs updating
                dgvMemberList.CellDoubleClick += DgvMemberList_CellDoubleClick;
            }
        }

        private void DgvMemberList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            frmMemberDetails frmMemberDetails = new frmMemberDetails
            {
                Text = "Update member",
                InsertOrUpdate = true,
                MemberInformation = GetMemberObject(),
                MemberRepository = _memberRepository
            };
            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                //Set focus member updated
                _source.Position = _source.Count - 1;
            }
        }
        private void LoadMemberList()
        {
            var members = _memberRepository.GetMembers();

            try
            {
                //The BindingSource component is designed to simplify
                //the process of binding controls to an underlying data source
                _source = new BindingSource();
                _source.DataSource = members.OrderByDescending(member => member.CompanyName);
                txtMemberID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                cboCountry.DataBindings.Clear();
                cboCity.DataBindings.Clear();

                txtMemberID.DataBindings.Add("Text", _source, "MemberId");
                txtMemberName.DataBindings.Add("Text", _source, "CompanyName");
                txtPassword.DataBindings.Add("Text", _source, "Password");
                txtEmail.DataBindings.Add("Text", _source, "Email");
                cboCountry.DataBindings.Add("Text", _source, "Country");
                cboCity.DataBindings.Add("Text", _source, "City");


                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = _source;
                if (IsAdmin == false)
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
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private Member GetMemberObject()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    CompanyName = txtMemberName.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text,
                    Country = cboCountry.Text,
                    City = cboCity.Text,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");
            }
            return member;
        }

        private void ClearText()
        {
            txtMemberID.Text = string.Empty;
            txtMemberName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cboCountry.Text = string.Empty;
            cboCity.Text = string.Empty;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FilterMember();
        }

        private void FilterMember()
        {
            Member member = new Member();
            List<Member> filterList = _memberRepository.GetMemberByCityAndCountry(cboSearchCity.Text, cboSearchCountry.Text);
            
            try
            {

               
                if (filterList.Count == 0)
                {
                    MessageBox.Show("No member matched", "No result");
                }
                else if (filterList.Count != 0)
                {
                    _source = new BindingSource();
                    _source.DataSource = filterList.OrderByDescending(member => member.CompanyName);
                    txtMemberID.DataBindings.Clear();
                    txtMemberName.DataBindings.Clear();
                    txtPassword.DataBindings.Clear();
                    txtEmail.DataBindings.Clear();
                    cboCountry.DataBindings.Clear();
                    cboCity.DataBindings.Clear();

                    txtMemberID.DataBindings.Add("Text", _source, "MemberId");
                    txtMemberName.DataBindings.Add("Text", _source, "CompanyName");
                    txtPassword.DataBindings.Add("Text", _source, "Password");
                    txtEmail.DataBindings.Add("Text", _source, "Email");
                    cboCountry.DataBindings.Add("Text", _source, "Country");
                    cboCity.DataBindings.Add("Text", _source, "City");


                    dgvMemberList.DataSource = null;
                    dgvMemberList.DataSource = _source;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
