namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmOrders_Click(object sender, EventArgs e)
        {
            frmOrders frmOrders = new frmOrders();
            frmOrders.ShowDialog();
        }
    }
}