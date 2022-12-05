using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Consultation_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection
                (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""O:\School\Consultation System\Consultation System\database\consys.mdf"";Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand
                ("SELECT * FROM Accounts WHERE " +
                "Username = '"+ txtUsername.Text +"' AND " +
                "Password = '"+ txtPassword.Text +"'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            string cmbItemValue = txtAccessLevel.SelectedItem.ToString();

            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["AccessLevel"].ToString() == cmbItemValue)
                    {
                        MessageBox.Show("You are logged in as " + dt.Rows[i][2]);
                        if(txtAccessLevel.SelectedIndex == 0)
                        {
                            adminHome adminHome = new adminHome();
                            adminHome.Show();
                            this.Hide();
                        }
                        else if (txtAccessLevel.SelectedIndex == 1)
                        {
                            tutorHome tutorHome = new tutorHome();
                            tutorHome.Show();
                            this.Hide();
                        }
                        else
                        {
                            tuteeHome tuteeHome = new tuteeHome();
                            tuteeHome.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid Username/Password", "Please try again.");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
