using MediaTekDocuments.controller;
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
        public Livre NouveauLivre { get; set; }
        private readonly FrmMediatekController controller = new FrmMediatekController();
        private readonly BindingSource bdgGenres = new BindingSource();
        private readonly BindingSource bdgPublics = new BindingSource();
        private readonly BindingSource bdgRayons = new BindingSource();

        public FrmAjoutDocument()
        {
            InitializeComponent();
            ChargerComboBox();
        }

        /// <summary>
        /// Bouton permettant d'ajouter un livre 
        /// </summary>
        /// /// <param name="sender"></param>
        /// /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!cbxGenre.Text.Equals("") && !cbxPublic.Text.Equals("") && !cbxRayon.Text.Equals("") && !txtBoxID.Text.Equals(""))
            {
                string idGenre = ((MediaTekDocuments.model.Categorie)cbxGenre.SelectedItem).Id;
                string idPublic = ((MediaTekDocuments.model.Categorie)cbxPublic.SelectedItem).Id;
                string idRayon = ((MediaTekDocuments.model.Categorie)cbxRayon.SelectedItem).Id;

                lblIdGenre.Text = idGenre;
                lblIdPublic.Text = idPublic;
                lblIdRayon.Text = idRayon;

                NouveauLivre = new Livre(
                    txtBoxID.Text,
                    txtBoxTitre.Text,
                    txtBoxImage.Text,
                    txtBoxISBN.Text,
                    txtBoxAuteur.Text,
                    txtBoxCollection.Text,
                    lblIdGenre.Text,
                    cbxGenre.Text,
                    lblIdPublic.Text,
                    cbxPublic.Text,
                    lblIdRayon.Text,
                    cbxRayon.Text
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Les champs Numéro du document, Genre, Public et Rayon sont obligatoire !", "Erreur");
            }
        }

        /// <summary>
        /// Rempli les comboBox 
        /// </summary>
        /// <param name="lesCategories"></param>
        /// <param name="bdg"></param>
        /// /// <param name="cbx"></param>
        public void RemplirComboCategorie(List<Categorie> lesCategories, BindingSource bdg, ComboBox cbx)
        {
            bdg.DataSource = lesCategories;
            cbx.DataSource = bdg;
            if (cbx.Items.Count > 0)
            {
                cbx.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Charge les comboBox au lancement de la page
        /// </summary>
        private void ChargerComboBox()
        {
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cbxGenre);
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cbxPublic);
            RemplirComboCategorie(controller.GetAllRayons(), bdgRayons, cbxRayon);
        }

        private void cbxGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
