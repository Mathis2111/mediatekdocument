
namespace MediaTekDocuments.view
{
    partial class FrmAjoutDocument
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
            this.components = new System.ComponentModel.Container();
            this.CTXMAjoutDocument = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAjouter = new System.Windows.Forms.Button();
            this.grpNouveauLivre = new System.Windows.Forms.GroupBox();
            this.cbxRayon = new System.Windows.Forms.ComboBox();
            this.cbxPublic = new System.Windows.Forms.ComboBox();
            this.cbxGenre = new System.Windows.Forms.ComboBox();
            this.txtBoxImage = new System.Windows.Forms.TextBox();
            this.txtBoxCollection = new System.Windows.Forms.TextBox();
            this.txtBoxAuteur = new System.Windows.Forms.TextBox();
            this.txtBoxTitre = new System.Windows.Forms.TextBox();
            this.txtBoxISBN = new System.Windows.Forms.TextBox();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.pcbLivresImage = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIdGenre = new System.Windows.Forms.Label();
            this.lblIdPublic = new System.Windows.Forms.Label();
            this.lblIdRayon = new System.Windows.Forms.Label();
            this.grpNouveauLivre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLivresImage)).BeginInit();
            this.SuspendLayout();
            // 
            // CTXMAjoutDocument
            // 
            this.CTXMAjoutDocument.Name = "CTXMAjoutDocument";
            this.CTXMAjoutDocument.Size = new System.Drawing.Size(61, 4);
            this.CTXMAjoutDocument.Text = "AjoutDocument";
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(769, 263);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 23);
            this.btnAjouter.TabIndex = 34;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // grpNouveauLivre
            // 
            this.grpNouveauLivre.Controls.Add(this.lblIdRayon);
            this.grpNouveauLivre.Controls.Add(this.lblIdPublic);
            this.grpNouveauLivre.Controls.Add(this.lblIdGenre);
            this.grpNouveauLivre.Controls.Add(this.cbxRayon);
            this.grpNouveauLivre.Controls.Add(this.cbxPublic);
            this.grpNouveauLivre.Controls.Add(this.cbxGenre);
            this.grpNouveauLivre.Controls.Add(this.txtBoxImage);
            this.grpNouveauLivre.Controls.Add(this.txtBoxCollection);
            this.grpNouveauLivre.Controls.Add(this.txtBoxAuteur);
            this.grpNouveauLivre.Controls.Add(this.txtBoxTitre);
            this.grpNouveauLivre.Controls.Add(this.txtBoxISBN);
            this.grpNouveauLivre.Controls.Add(this.txtBoxID);
            this.grpNouveauLivre.Controls.Add(this.label59);
            this.grpNouveauLivre.Controls.Add(this.btnAjouter);
            this.grpNouveauLivre.Controls.Add(this.label22);
            this.grpNouveauLivre.Controls.Add(this.pcbLivresImage);
            this.grpNouveauLivre.Controls.Add(this.label19);
            this.grpNouveauLivre.Controls.Add(this.label1);
            this.grpNouveauLivre.Controls.Add(this.label10);
            this.grpNouveauLivre.Controls.Add(this.label7);
            this.grpNouveauLivre.Controls.Add(this.label11);
            this.grpNouveauLivre.Controls.Add(this.label8);
            this.grpNouveauLivre.Controls.Add(this.label12);
            this.grpNouveauLivre.Controls.Add(this.label9);
            this.grpNouveauLivre.Location = new System.Drawing.Point(12, 12);
            this.grpNouveauLivre.Name = "grpNouveauLivre";
            this.grpNouveauLivre.Size = new System.Drawing.Size(858, 292);
            this.grpNouveauLivre.TabIndex = 35;
            this.grpNouveauLivre.TabStop = false;
            this.grpNouveauLivre.Text = "Nouveau Livre";
            // 
            // cbxRayon
            // 
            this.cbxRayon.FormattingEnabled = true;
            this.cbxRayon.Location = new System.Drawing.Point(150, 170);
            this.cbxRayon.Name = "cbxRayon";
            this.cbxRayon.Size = new System.Drawing.Size(207, 21);
            this.cbxRayon.TabIndex = 46;
            // 
            // cbxPublic
            // 
            this.cbxPublic.FormattingEnabled = true;
            this.cbxPublic.Location = new System.Drawing.Point(150, 145);
            this.cbxPublic.Name = "cbxPublic";
            this.cbxPublic.Size = new System.Drawing.Size(207, 21);
            this.cbxPublic.TabIndex = 45;
            // 
            // cbxGenre
            // 
            this.cbxGenre.FormattingEnabled = true;
            this.cbxGenre.Location = new System.Drawing.Point(150, 120);
            this.cbxGenre.Name = "cbxGenre";
            this.cbxGenre.Size = new System.Drawing.Size(207, 21);
            this.cbxGenre.TabIndex = 44;
            this.cbxGenre.SelectedIndexChanged += new System.EventHandler(this.cbxGenre_SelectedIndexChanged);
            // 
            // txtBoxImage
            // 
            this.txtBoxImage.Location = new System.Drawing.Point(150, 198);
            this.txtBoxImage.Name = "txtBoxImage";
            this.txtBoxImage.Size = new System.Drawing.Size(390, 20);
            this.txtBoxImage.TabIndex = 43;
            // 
            // txtBoxCollection
            // 
            this.txtBoxCollection.Location = new System.Drawing.Point(150, 94);
            this.txtBoxCollection.Name = "txtBoxCollection";
            this.txtBoxCollection.Size = new System.Drawing.Size(391, 20);
            this.txtBoxCollection.TabIndex = 39;
            // 
            // txtBoxAuteur
            // 
            this.txtBoxAuteur.Location = new System.Drawing.Point(150, 71);
            this.txtBoxAuteur.Name = "txtBoxAuteur";
            this.txtBoxAuteur.Size = new System.Drawing.Size(207, 20);
            this.txtBoxAuteur.TabIndex = 38;
            // 
            // txtBoxTitre
            // 
            this.txtBoxTitre.Location = new System.Drawing.Point(150, 45);
            this.txtBoxTitre.Name = "txtBoxTitre";
            this.txtBoxTitre.Size = new System.Drawing.Size(391, 20);
            this.txtBoxTitre.TabIndex = 37;
            // 
            // txtBoxISBN
            // 
            this.txtBoxISBN.Location = new System.Drawing.Point(440, 17);
            this.txtBoxISBN.Name = "txtBoxISBN";
            this.txtBoxISBN.Size = new System.Drawing.Size(100, 20);
            this.txtBoxISBN.TabIndex = 36;
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(150, 17);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(99, 20);
            this.txtBoxID.TabIndex = 35;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(557, 11);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(49, 13);
            this.label59.TabIndex = 33;
            this.label59.Text = "Image :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(6, 120);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 13);
            this.label22.TabIndex = 22;
            this.label22.Text = "Genre :";
            // 
            // pcbLivresImage
            // 
            this.pcbLivresImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbLivresImage.Location = new System.Drawing.Point(560, 27);
            this.pcbLivresImage.Name = "pcbLivresImage";
            this.pcbLivresImage.Size = new System.Drawing.Size(284, 210);
            this.pcbLivresImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLivresImage.TabIndex = 21;
            this.pcbLivresImage.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 145);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Public :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Rayon :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Titre :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Numéro de document :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Auteur(e) :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Chemin de l\'image :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Collection :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(357, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Code ISBN :";
            // 
            // lblIdGenre
            // 
            this.lblIdGenre.AutoSize = true;
            this.lblIdGenre.Location = new System.Drawing.Point(389, 127);
            this.lblIdGenre.Name = "lblIdGenre";
            this.lblIdGenre.Size = new System.Drawing.Size(0, 13);
            this.lblIdGenre.TabIndex = 47;
            // 
            // lblIdPublic
            // 
            this.lblIdPublic.AutoSize = true;
            this.lblIdPublic.Location = new System.Drawing.Point(392, 152);
            this.lblIdPublic.Name = "lblIdPublic";
            this.lblIdPublic.Size = new System.Drawing.Size(0, 13);
            this.lblIdPublic.TabIndex = 48;
            // 
            // lblIdRayon
            // 
            this.lblIdRayon.AutoSize = true;
            this.lblIdRayon.Location = new System.Drawing.Point(389, 173);
            this.lblIdRayon.Name = "lblIdRayon";
            this.lblIdRayon.Size = new System.Drawing.Size(0, 13);
            this.lblIdRayon.TabIndex = 49;
            // 
            // FrmAjoutDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 317);
            this.Controls.Add(this.grpNouveauLivre);
            this.Name = "FrmAjoutDocument";
            this.Text = "FrmAjoutDocument";
            this.grpNouveauLivre.ResumeLayout(false);
            this.grpNouveauLivre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLivresImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CTXMAjoutDocument;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.GroupBox grpNouveauLivre;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pcbLivresImage;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxImage;
        private System.Windows.Forms.TextBox txtBoxCollection;
        private System.Windows.Forms.TextBox txtBoxAuteur;
        private System.Windows.Forms.TextBox txtBoxTitre;
        private System.Windows.Forms.TextBox txtBoxISBN;
        private System.Windows.Forms.ComboBox cbxRayon;
        private System.Windows.Forms.ComboBox cbxPublic;
        private System.Windows.Forms.ComboBox cbxGenre;
        private System.Windows.Forms.Label lblIdGenre;
        private System.Windows.Forms.Label lblIdRayon;
        private System.Windows.Forms.Label lblIdPublic;
    }
}