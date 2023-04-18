using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDConnected
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dgKlijenti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgKlijenti.MultiSelect = false;;
            dgKlijenti.ReadOnly = true;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var set = clsDataAccess.selectAll();
                dgKlijenti.DataSource = set.Tables[0];

                Cursor.Current = Cursors.Default;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmInsert fInsert = new frmInsert();
            fInsert.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                frmUpdate frmUpdate = new frmUpdate
                    (
                        Convert.ToInt32(dgKlijenti.SelectedRows[0].Cells[0].Value),
                        dgKlijenti.SelectedRows[0].Cells[1].Value.ToString(),
                        dgKlijenti.SelectedRows[0].Cells[2].Value.ToString(),
                        dgKlijenti.SelectedRows[0].Cells[3].Value.ToString(),
                        dgKlijenti.SelectedRows[0].Cells[4].Value.ToString()
                    );
                frmUpdate.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           DialogResult dialogResult = MessageBox.Show("Do you want to delete this client?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                try
                {
                    clsDataAccess dataAccess = new clsDataAccess();

                    int Response = dataAccess.ClientDelete(Convert.ToInt32(dgKlijenti.SelectedRows[0].Cells[0].Value));

                    if(Response == 0)
                    {
                        MessageBox.Show("Client successfully deleted! ", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }else if(Response == -1)
                    {
                        MessageBox.Show("Client doesen't exists! ", "Information !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }else if(dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgKlijenti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgKlijenti.MultiSelect = false;
            dgKlijenti.ReadOnly = true;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var resp = clsDataAccess.selectAll();
                dgKlijenti.DataSource = resp.Tables[0];

                Cursor.Current = Cursors.Default;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit this app?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
