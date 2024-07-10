using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAllProject
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }


        byte CounterWrongPassword;
        public void Valdited(TextBox text)
        {
            CancelEventArgs cancelEventArgs = new CancelEventArgs();
            if(string.IsNullOrEmpty(text.Text))
            {
                cancelEventArgs.Cancel = true;
                text.Focus();
                ErrorFillAll.SetError(text,"You should fill");
            }
            else
            {
                cancelEventArgs.Cancel = false;

                ErrorFillAll.SetError(text, "");

            }
        }

        public bool CheckedShowOrNot(CheckBox check)
        {
            return check.Checked;
        }

        public bool CheckLogIn()
        {

            if (txtUserName.Text == txtUserName.Tag.ToString() && txtPassword.Text == txtPassword.Tag.ToString())
                return true;
            else
                return false;

        }
        public void LogIn()
        {
            if (CheckLogIn())
            {
                
                Form frm = new frmEmployeess();
                frm.ShowDialog();
                CounterWrongPassword = 0;
            }
            else
            {
                MessageBox.Show("The User name Or The Password is not correct", "Erroe LogIn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CounterWrongPassword++;
                txtUserName.Clear();
                txtPassword.Clear();
                txtUserName.Focus();
                checkBox1.Checked = false;
                if (CounterWrongPassword == 3)
                {
                    MessageBox.Show("You have completed three wrong attempt You will Wait 3 muintes", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    panel3.Visible = true;
                    lblTime.Visible = true;
                    TimError.Enabled = true;
                }
            }
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {

            LogIn();
        }

        private void txtUserName_Validated(object sender, EventArgs e)
        {
            Valdited((TextBox)sender);
        }

        private void txtPassword_Validated(object sender, EventArgs e)
        {
            Valdited((TextBox)sender);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !CheckedShowOrNot((CheckBox)sender);   
        }
        short CounterSecond;
        short CounterMuinte;
        private void TimError_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeSpane = new TimeSpan(0,3,0);

            CounterSecond++;

            lblTime.Text = CounterMuinte.ToString()+" : "+CounterSecond.ToString();

            if (CounterSecond == 60)
            {
                CounterMuinte++;
                CounterSecond=0;
            }

            if(CounterMuinte== TimeSpane.Minutes)
            {
                panel3.Visible = false;
                lblTime.Visible = false;
                TimError.Enabled = false;
                txtUserName.Focus();
                return;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            lblTime.Visible = false;
            TimError.Enabled = false;
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {


        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
