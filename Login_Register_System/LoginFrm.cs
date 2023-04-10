using Microsoft.Data.SqlClient;
using Tacda_Q6;

namespace Login_Register_System
{
    public partial class LoginFrm : Form
    {
        private SqlCommand cmd;
        private SqlConnection cn;
        private SqlDataReader dr;

        public LoginFrm()
        {
            InitializeComponent();
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\EOUSER\SOURCE\REPOS\TACDA_Q6\LOGIN_REGISTER_SYSTEM\LOGIN_REGISTER_SYSTEM\PROFILE_DB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            cn.Open();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void loginLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\EOUSER\SOURCE\REPOS\TACDA_Q6\LOGIN_REGISTER_SYSTEM\LOGIN_REGISTER_SYSTEM\PROFILE_DB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            cn.Open();
            if (txtpassword.Text != string.Empty || txtusername.Text != string.Empty)
            {
                cmd = new SqlCommand("select * from Profile_Table where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("You are now logged in " + txtusername.Text + "!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtusername.Clear();
                    txtpassword.Clear();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

        }



        private void txtfname_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnkLogin_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterFrm registration = new RegisterFrm();
            registration.ShowDialog();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}