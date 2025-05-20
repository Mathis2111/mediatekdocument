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
    public partial class FrmAjoutDvd : Form
    {
        public Dvd NouveauDvd { get; set; }
        private readonly FrmMediatekController controller = new FrmMediatekController();
        private readonly BindingSource bdgGenres = new BindingSource();
        private readonly BindingSource bdgPublics = new BindingSource();
        private readonly BindingSource bdgRayons = new BindingSource();
        public FrmAjoutDvd()
        {
            InitializeComponent();
            ChargerComboBox();
        }

        private void btnValiderAjoutDvd_Click(object sender, EventArgs e)
        {
            if (!cbxGenreDvd.Text.Equals("") && !cbxPublicDvd.Text.Equals("") && !cbxRayonDvd.Text.Equals("") && !txbAjoutDvdNumero.Text.Equals("") && !txbAjoutDvdDuree.Text.Equals(""))
            {
                string idGenre = ((MediaTekDocuments.model.Categorie)cbxGenreDvd.SelectedItem).Id;
                string idPublic = ((MediaTekDocuments.model.Categorie)cbxPublicDvd.SelectedItem).Id;
                string idRayon = ((MediaTekDocuments.model.Categorie)cbxRayonDvd.SelectedItem).Id;

                lblIdGenreDvd.Text = idGenre;
                lblIdPublicDvd.Text = idPublic;
                lblIdRayonDvd.Text = idRayon;

                NouveauDvd = new Dvd(
                    txbAjoutDvdNumero.Text,
                    txbAjoutDvdTitre.Text,
                    txbAjoutDvdImage.Text,
                    int.Parse(txbAjoutDvdDuree.Text),
                    txbAjoutDvdRealisateur.Text,
                    txbAjoutDvdSynopsis.Text,
                    lblIdGenreDvd.Text,
                    cbxGenreDvd.Text,
                    lblIdPublicDvd.Text,
                    cbxPublicDvd.Text,
                    lblIdRayonDvd.Text,
                    cbxRayonDvd.Text
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Les champs Numéro du document, Genre, Public, Rayon et Durée sont obligatoire !", "Erreur");
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
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cbxGenreDvd);
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cbxPublicDvd);
            RemplirComboCategorie(controller.GetAllRayons(), bdgRayons, cbxRayonDvd);
        }
    }
}
