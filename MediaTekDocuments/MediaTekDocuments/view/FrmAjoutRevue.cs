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
    public partial class FrmAjoutRevue : Form
    {
        public Revue NouvelleRevue { get; set; }
        private readonly FrmMediatekController controller = new FrmMediatekController();
        private readonly BindingSource bdgGenres = new BindingSource();
        private readonly BindingSource bdgPublics = new BindingSource();
        private readonly BindingSource bdgRayons = new BindingSource();
        public FrmAjoutRevue()
        {
            InitializeComponent();
            ChargerComboBox();
        }

        private void btnValiderAjoutRevue_Click(object sender, EventArgs e)
        {
            if (!cbxGenreRevue.Text.Equals("") && !cbxPublicRevue.Text.Equals("") && !cbxRayonRevue.Text.Equals("") && !txbAjoutRevuesNumero.Text.Equals("") && !txbAjoutRevuesPeriodicite.Text.Equals("") && !txbAjoutRevuesDateMiseADispo.Text.Equals(""))
            {
                string idGenre = ((MediaTekDocuments.model.Categorie)cbxGenreRevue.SelectedItem).Id;
                string idPublic = ((MediaTekDocuments.model.Categorie)cbxPublicRevue.SelectedItem).Id;
                string idRayon = ((MediaTekDocuments.model.Categorie)cbxRayonRevue.SelectedItem).Id;

                lblIdGenre.Text = idGenre;
                lblIdPublic.Text = idPublic;
                lblIdRayon.Text = idRayon;

                NouvelleRevue = new Revue(
                    txbAjoutRevuesNumero.Text,
                    txbAjoutRevuesTitre.Text,
                    txbAjoutRevuesImage.Text,
                    lblIdGenre.Text,
                    cbxGenreRevue.Text,
                    lblIdPublic.Text,
                    cbxPublicRevue.Text,
                    lblIdRayon.Text,
                    cbxRayonRevue.Text,
                    txbAjoutRevuesPeriodicite.Text,
                    int.Parse(txbAjoutRevuesDateMiseADispo.Text)
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Les champs Numéro du document, Genre, Public, Rayon, Délai mise à dispo et Periodicité sont obligatoire !", "Erreur");
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
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cbxGenreRevue);
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cbxPublicRevue);
            RemplirComboCategorie(controller.GetAllRayons(), bdgRayons, cbxRayonRevue);
        }
    }
}
