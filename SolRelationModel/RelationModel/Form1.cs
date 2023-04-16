using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelationModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable Kupci, Fakture, FaktureStavke;
        DataSet fakturisanje;


        private void btnShowData_Click(object sender, EventArgs e)
        {


            //Create table Kupci
            Kupci = new DataTable("Kupci");

            //Create columns for table Kupci
            DataColumn kupacID = new DataColumn("KupacID")
            {
                DataType = typeof(int),
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                AllowDBNull = false,
            };

            //Primarykey
            Kupci.PrimaryKey = new DataColumn[] { Kupci.Columns["KupacID"] };

            DataColumn nazivKupca = new DataColumn("NazivKupca")
            {
                DataType = typeof(string),
                MaxLength = 50,
                AllowDBNull = false
            };

            DataColumn adresa = new DataColumn("Adresa")
            {
                DataType = typeof(string),
                MaxLength = 200,
                AllowDBNull = true
            };

            Kupci.Columns.Add(kupacID);
            Kupci.Columns.Add(nazivKupca);
            Kupci.Columns.Add(adresa);

            //Create Table Fakture
            Fakture = new DataTable("Fakture");

            //Create columns for table Fakture
            DataColumn fakturaID = new DataColumn("FakturaID")
            {
                DataType = typeof(int),
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                AllowDBNull = false
            };

            //Primarykey
            Fakture.PrimaryKey = new DataColumn[] { Fakture.Columns["FakturaID"] };

            DataColumn fkKupacID = new DataColumn("KupacID")
            {
                DataType = typeof(int),
                AllowDBNull = false
            };

            DataColumn datum = new DataColumn("Datum")
            {
                DataType = typeof(DateTime),
                AllowDBNull = false,
                DefaultValue = DateTime.Now
            };

            Fakture.Columns.Add(fakturaID);
            Fakture.Columns.Add(fkKupacID);
            Fakture.Columns.Add(datum);

            //Create Table FaktureStavke
            FaktureStavke = new DataTable("FaktureStavke");


            //Create columns for table FaktureStavke

            DataColumn fkFakturaID = new DataColumn("FakturaID")
            {
                DataType = typeof(int),
                AllowDBNull = false,
                Unique = false
            };

            DataColumn nazivStavke = new DataColumn("NazivStavke")
            {
                DataType = typeof(string),
                MaxLength = 40,
                AllowDBNull = false
            };

            DataColumn cenaStavke = new DataColumn("CenaStavke")
            {
                DataType = typeof(decimal),
                AllowDBNull = false

            };

            //Primarykey
            FaktureStavke.PrimaryKey = new DataColumn[] { FaktureStavke.Columns["FakturaID"], FaktureStavke.Columns["NazivStavke"] };


            //Add columns
            FaktureStavke.Columns.Add(fkFakturaID);
            FaktureStavke.Columns.Add(nazivStavke);
            FaktureStavke.Columns.Add(cenaStavke);
            //DataSet

            //Create dataset for table
            fakturisanje = new DataSet("Fakturisanje");
            fakturisanje.Tables.Add(Kupci);
            fakturisanje.Tables.Add(Fakture);
            fakturisanje.Tables.Add(FaktureStavke);

            //Relations
            DataRelation drFakturisanje = new DataRelation("RelacijaKupciUplate", Kupci.Columns["KupacID"], Fakture.Columns["KupacID"], true);

            DataRelation drFaktureStavke = new DataRelation("drFaktureStavke", Fakture.Columns["FakturaID"], FaktureStavke.Columns["FakturaID"], true);
            
            fakturisanje.Relations.Add(drFakturisanje);
            fakturisanje.Relations.Add(drFaktureStavke);

            //ForeignKey
            ForeignKeyConstraint fkFakturisanje = (ForeignKeyConstraint)Fakture.Constraints["RelacijaKupciUplate"];
            fkFakturisanje.UpdateRule = Rule.None;
            fkFakturisanje.DeleteRule = Rule.None;

            ForeignKeyConstraint fkFaktureStavke = (ForeignKeyConstraint)FaktureStavke.Constraints["drFaktureStavke"];
            fkFaktureStavke.UpdateRule = Rule.None;
            fkFaktureStavke.DeleteRule = Rule.None;

            Kupci.Rows.Add(1, "test", "Test");
            Kupci.Rows.Add(2, "test1", "Test1");
            Kupci.Rows.Add(3, "test2", "Test2");
            Kupci.Rows.Add(4, "test3", "Test3");
            Kupci.Rows.Add(5, "test4", "Test4");


            Fakture.Rows.Add(1, 1);
            Fakture.Rows.Add(2, 2);
            Fakture.Rows.Add(3, 3);
            Fakture.Rows.Add(4, 4);

            FaktureStavke.Rows.Add(1, "Stavka 1", 100);
            FaktureStavke.Rows.Add(2, "Stavka 1", 100);
            FaktureStavke.Rows.Add(3, "Stavka 1", 100);
            FaktureStavke.Rows.Add(4, "Stavka 1", 100);

            dgvKupci.DataSource = Kupci;
            dgvFakture.DataSource = Fakture;
            dgvFaktureStavke.DataSource = FaktureStavke;

        }
        private void btnCreateXML_Click(object sender, EventArgs e)
        {
            
            try
            {
                fakturisanje.WriteXml(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Fakturisano.xsd", XmlWriteMode.WriteSchema);
                MessageBox.Show("Saved");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
