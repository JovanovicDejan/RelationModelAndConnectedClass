namespace RelationModel
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvKupci = new System.Windows.Forms.DataGridView();
            this.dgvFakture = new System.Windows.Forms.DataGridView();
            this.dgvFaktureStavke = new System.Windows.Forms.DataGridView();
            this.btnShowData = new System.Windows.Forms.Button();
            this.btnCreateXML = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKupci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFakture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaktureStavke)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKupci
            // 
            this.dgvKupci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKupci.Location = new System.Drawing.Point(22, 236);
            this.dgvKupci.Name = "dgvKupci";
            this.dgvKupci.Size = new System.Drawing.Size(345, 385);
            this.dgvKupci.TabIndex = 0;
            // 
            // dgvFakture
            // 
            this.dgvFakture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFakture.Location = new System.Drawing.Point(461, 236);
            this.dgvFakture.Name = "dgvFakture";
            this.dgvFakture.Size = new System.Drawing.Size(343, 385);
            this.dgvFakture.TabIndex = 1;
            // 
            // dgvFaktureStavke
            // 
            this.dgvFaktureStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaktureStavke.Location = new System.Drawing.Point(902, 236);
            this.dgvFaktureStavke.Name = "dgvFaktureStavke";
            this.dgvFaktureStavke.Size = new System.Drawing.Size(346, 385);
            this.dgvFaktureStavke.TabIndex = 2;
            // 
            // btnShowData
            // 
            this.btnShowData.Location = new System.Drawing.Point(72, 39);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(161, 52);
            this.btnShowData.TabIndex = 3;
            this.btnShowData.Text = "Show Data";
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // btnCreateXML
            // 
            this.btnCreateXML.Location = new System.Drawing.Point(509, 39);
            this.btnCreateXML.Name = "btnCreateXML";
            this.btnCreateXML.Size = new System.Drawing.Size(206, 52);
            this.btnCreateXML.TabIndex = 4;
            this.btnCreateXML.Text = "Kreiraj XML Fajl";
            this.btnCreateXML.UseVisualStyleBackColor = true;
            this.btnCreateXML.Click += new System.EventHandler(this.btnCreateXML_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 691);
            this.Controls.Add(this.btnCreateXML);
            this.Controls.Add(this.btnShowData);
            this.Controls.Add(this.dgvFaktureStavke);
            this.Controls.Add(this.dgvFakture);
            this.Controls.Add(this.dgvKupci);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKupci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFakture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaktureStavke)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKupci;
        private System.Windows.Forms.DataGridView dgvFakture;
        private System.Windows.Forms.DataGridView dgvFaktureStavke;
        private System.Windows.Forms.Button btnShowData;
        private System.Windows.Forms.Button btnCreateXML;
    }
}

