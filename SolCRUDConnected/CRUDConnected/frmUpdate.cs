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
    public partial class frmUpdate : Form
    {
        int klijentid;
        string naziv;
        string kontakt;
        string grad;
        string zemlja;
        public frmUpdate()
        {
            InitializeComponent();
        }

        public frmUpdate(int klijentId, string naziv, string kontakt, string grad, string zemlja)
        {
            this.klijentid = klijentId;
            this.naziv = naziv;
            this.kontakt = kontakt;
            this.grad = grad;
            this.zemlja = zemlja;
            InitializeComponent();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            naziv = txtNaziv.Text;
            kontakt = txtKontakt.Text;
            grad = txtGrad.Text;
            zemlja = txtZemlja.Text;
            if (naziv.Trim() == "")
            {
                MessageBox.Show("Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNaziv.Focus();
                return;
            }
            else if (naziv.Length >= 40)
            {
                MessageBox.Show("Length should be under 40!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNaziv.Focus();
                return;
            }
            else if (kontakt.Trim() == "")
            {
                MessageBox.Show("Contact is required! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKontakt.Focus();
                return;
            }
            else if (kontakt.Length >= 40)
            {
                MessageBox.Show("Length should be under 40!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKontakt.Focus();
                return;
            }
            else if (grad.Trim() == "")
            {
                MessageBox.Show("City is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGrad.Focus();
                return;
            }
            else if (grad.Length >= 15)
            {
                MessageBox.Show("Length should be under 15! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGrad.Focus();
                return;
            }
            else if (zemlja.Trim() == "")
            {
                MessageBox.Show("Country is required! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtZemlja.Focus();
                return;
            }
            else if (zemlja.Length >= 15)
            {
                MessageBox.Show("Length should be under 15", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtZemlja.Focus();
                return;
            }
            else
            {
                try
                {
                    clsDataAccess dataAccess = new clsDataAccess();
                    int Response = dataAccess.ClientUpdate(klijentid, naziv, kontakt, grad,zemlja);

                    if(Response == 0)
                    {
                        MessageBox.Show("successfully updated!", "Update!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }else if(Response == -1) 
                    { 
                        MessageBox.Show("Client doesen't exists! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error: " + Response.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }catch(Exception ex)
                {
                    throw new Exception("Error " + ex.Message);
                }
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

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            this.txtKontakt.Text = this.kontakt;
            this.txtNaziv.Text = this.naziv;
            this.txtGrad.Text = this.grad;
            this.txtZemlja.Text = this.zemlja;
        }
    }
}
