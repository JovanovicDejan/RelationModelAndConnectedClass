using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDConnected
{
    public partial class frmInsert : Form
    {
        public frmInsert()
        {
            InitializeComponent();
        }

        clsDataAccess DataAccess = new clsDataAccess();
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string naziv = txtNaziv.Text;
                string kontakt = txtKontakt.Text;
                string grad = txtGrad.Text;
                string zemlja = txtZemlja.Text;

                //Check if there is a start space or if lenght is over 40
                if(naziv.Trim() == "")  
                {
                    MessageBox.Show("Name is required");
                    txtNaziv.Focus();
                    return;
                }else if(naziv.Length >= 40)
                {
                    MessageBox.Show("Lenght should be under 40");
                    txtNaziv.Focus();
                    return;
                }

                //Check for kontakt
                if(kontakt.Trim() == "") 
                {
                    MessageBox.Show("Kontakt is required");
                    txtKontakt.Focus();
                    return;
                }else if(kontakt.Length >= 40)
                {
                    MessageBox.Show("Lenght should be under 40");
                    txtNaziv.Focus();
                    return;
                }
                
                //Check for grad
                if (grad.Trim() == "") 
                {
                    MessageBox.Show("City is required");
                    txtGrad.Focus();
                    return;
                }
                else if (grad.Length >= 15)
                {
                    MessageBox.Show("Lenght should be under 40");
                    txtNaziv.Focus();
                    return;
                }

                //Check for zemlja
                if (zemlja.Trim() == "") 
                {
                    MessageBox.Show("Country is required");
                    txtZemlja.Focus();
                    return;
                }
                else if (zemlja.Length >= 15)
                {
                    MessageBox.Show("Lenght should be under 40");
                    txtNaziv.Focus();
                    return;
                }

                try
                {
                    clsDataAccess dataAccess = new clsDataAccess();
                    dataAccess.ClientInsert(naziv, kontakt, grad, zemlja);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to close this form? ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            return;
        }
    }
}
