using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAllProject
{
    public partial class frmEmployeess : Form
    {
        public frmEmployeess()
        {
            InitializeComponent();
        }
        public void SaveItemsInListView()
        { 

           ListViewItem Item = new ListViewItem(txtFirsstNAme.Text);

            Item.SubItems.Add(txtLasstNAme.Text);
            Item.SubItems.Add(txtBirthday.Text);
            Item.SubItems.Add(txtDepartment.Text); 

            listView1.Items.Add(Item);

            txtFirsstNAme.Clear();
            txtLasstNAme.Clear();
            txtBirthday.Clear();
            txtDepartment.Clear();
        }

        public void Delete()
        {
            for(int i= listView1.Items.Count-1; i>=0;i--)
            {
                listView1.Items.Remove(listView1.Items[i]);
            }
        }

        public bool ValditionAll(TextBox First, TextBox Laast, TextBox Birth, TextBox Dep)
        {

            CancelEventArgs e = new CancelEventArgs();

            if (string.IsNullOrWhiteSpace(First.Text))
            {
                e.Cancel = true;
                First.Focus();
                errorProvider1.SetError(First, First.Tag.ToString() + " Should have Value");
                return false;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(First, "");
                
            }

            if (string.IsNullOrWhiteSpace(Laast.Text))
            {
                e.Cancel = true;
                Laast.Focus();
                errorProvider1.SetError(Laast, Laast.Tag.ToString() + " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Laast, "");
            }

            if (string.IsNullOrWhiteSpace(Birth.Text))
            {
                e.Cancel = true;
                Birth.Focus();
                errorProvider1.SetError(Birth, Birth.Tag.ToString() + " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Birth, "");
            }

            if (string.IsNullOrWhiteSpace(Dep.Text))
            {
                e.Cancel = true;
                Dep.Focus();
                errorProvider1.SetError(Dep, Dep.Tag.ToString() + " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Dep, "");
            }

            return true;

        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            txtFirsstNAme.Clear();
            txtLasstNAme.Clear();
            txtBirthday.Clear();
            txtDepartment.Clear();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValditionAll(txtFirsstNAme,txtLasstNAme,txtBirthday,txtDepartment))
            { SaveItemsInListView(); }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

    
    }
}
