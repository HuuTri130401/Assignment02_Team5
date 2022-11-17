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
    public partial class frmMain : Form
    {
        public bool isAdmin { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        //private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (!CheckExistForm("frmMembers"))
        //    {
        //        frmMembers frm = new frmMembers() { IsAdmin = this.isAdmin };

        //        frm.Show();
        //    }
        //    else ActiveChildForm("frmMembers");
        //}



        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmProducts"))
            {
                frmProducts frm = new frmProducts() { IsAdmin = this.isAdmin };

                frm.Show();
            }
            else ActiveChildForm("frmProducts");
        }

        private void orderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmOrders"))
            {
                frmOrders frm = new frmOrders() { IsAdmin = this.isAdmin };
                frm.Show();
            }
            else ActiveChildForm("frmOrders");
        }
    }

    //private void orderToolStripMenuItem_Click(object sender, EventArgs e)
    //{
    //    if (!CheckExistForm("frmOrders"))
    //    {
    //        frmOrders frm = new frmOrders() { IsAdmin = this.isAdmin };

    //        frm.Show();
    //    }
    //    else ActiveChildForm("frmOrders");
    //}
}
