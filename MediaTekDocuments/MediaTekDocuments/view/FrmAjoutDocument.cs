using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    /// <summary>
    /// Classe d'affichage
    /// </summary>
    public partial class FrmAjoutDocument : Form
    {
        public Livre NouveauLivre { get; private set; }

        public FrmAjoutDocument()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxID.Text) ||
                string.IsNullOrWhiteSpace(txtBoxTitre.Text) ||
                string.IsNullOrWhiteSpace(txtBoxImage.Text) ||
                string.IsNullOrWhiteSpace(txtBoxISBN.Text) ||
                string.IsNullOrWhiteSpace(txtBoxAuteur.Text) ||
                string.IsNullOrWhiteSpace(txtBoxCollection.Text) ||
                string.IsNullOrWhiteSpace(txtBoxGenre.Text) ||
                string.IsNullOrWhiteSpace(txtBoxPublic.Text) ||
                string.IsNullOrWhiteSpace(txtBoxRayon.Text))
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NouveauLivre = new Livre (
                txtBoxID.Text,
                txtBoxTitre.Text,
                txtBoxImage.Text,
                txtBoxISBN.Text,
                txtBoxAuteur.Text,
                txtBoxCollection.Text,
                txtBoxGenre.Text,
                txtBoxGenre.Text,
                txtBoxPublic.Text,
                txtBoxPublic.Text,
                txtBoxRayon.Text,
                txtBoxRayon.Text
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
