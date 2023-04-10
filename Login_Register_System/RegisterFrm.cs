using Login_Register_System;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tacda_Q6
{
    public partial class RegisterFrm : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;

        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void RegisterFrm_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\EOUSER\SOURCE\REPOS\TACDA_Q6\LOGIN_REGISTER_SYSTEM\LOGIN_REGISTER_SYSTEM\PROFILE_DB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            cn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\EOUSER\SOURCE\REPOS\TACDA_Q6\LOGIN_REGISTER_SYSTEM\LOGIN_REGISTER_SYSTEM\PROFILE_DB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            cn.Open();
            String interest = "";
            if (txtconpassword.Text != String.Empty || txtpassword.Text != String.Empty || txtusername.Text != String.Empty)
            {
                if (txtpassword.Text == txtconpassword.Text)
                {
                    cmd = new SqlCommand("select * from Profile_Table where username='" + txtusername.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into Profile_Table values (@fname, @lname, @username, @password, @sex, @bday, @brgy, @municipal, @province, @interests)", cn);
                        cmd.Parameters.AddWithValue("fname", txtfname.Text);
                        cmd.Parameters.AddWithValue("lname", txtlname.Text);
                        cmd.Parameters.AddWithValue("username", txtusername.Text);
                        cmd.Parameters.AddWithValue("password", txtpassword.Text);
                        if (rbmale.Checked)
                        {
                            cmd.Parameters.AddWithValue("sex", "Male");
                        }   
                        else if (rbfemale.Checked)
                        {
                            cmd.Parameters.AddWithValue("sex", "Female");
                        }
                        else if (rbna.Checked)
                        {
                            cmd.Parameters.AddWithValue("sex", "Prefer not to say");
                        }
                        cmd.Parameters.AddWithValue("bday", bdayMonth.SelectedItem + " " + bdayDay.Text + ", " + bdayYear.Text);
                        cmd.Parameters.AddWithValue("brgy", txtbrgy.Text);
                        cmd.Parameters.AddWithValue("municipal", txtmunicipal.Text);
                        cmd.Parameters.AddWithValue("province", lbprov.SelectedItem);
                        if (chSports.Checked)
                        {
                            interest = interest + chSports.Text + ", ";
                        }
                        if (chMusic.Checked)
                        {
                            interest = interest + chMusic.Text + ", ";
                        }
                        if (chArts.Checked)
                        {
                            interest = interest + chArts.Text + ", ";
                        }
                        if (chMovies.Checked)
                        {
                            interest = interest + chMovies.Text + ", ";
                        }
                        if (chGames.Checked)
                        {
                            interest = interest + chGames.Text + ", ";
                        }
                        cmd.Parameters.AddWithValue("interests", interest);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Your Account is created. Please login now", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bdayMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginFrm login = new LoginFrm();
            login.ShowDialog();
        }

        private void txtfname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginLabel_Click(object sender, EventArgs e)
        {

        }

        private void txtlname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
