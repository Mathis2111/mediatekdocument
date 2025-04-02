using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTekDocuments.controller;
using MediaTekDocuments.model;

namespace MediaTekDocuments.view
{
    public partial class FrmAuthentification : Form
    {
        private readonly FrmMediatekController controller;
        private List<Service> lesServices = new List<Service>();
        public FrmAuthentification()
        {
            InitializeComponent();
            controller = new FrmMediatekController();
        }

        private void FrmAuthentification_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Bouton pour valider l'authentification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnValider_Click(object sender, EventArgs e)
        {
            FrmAlerteFinAbonnement frmAlerteFinAbonnement = new FrmAlerteFinAbonnement(controller);
            FrmAuthentification frmAuthentification = new FrmAuthentification();
            lesServices = controller.GetServiceByUserName(txtBoxNom.Text);

            if (lesServices.Count > 0)
            {
                string nomService = lesServices[0].Libelle;

                lblNomService.Text = nomService;

                if (nomService == "Culture")
                {
                    MessageBox.Show("Les droits ne sont pas suffisants pour accéder à cette application", "Refus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (nomService == "Administrateur" || nomService == "Administratif")
                {
                    frmAlerteFinAbonnement.ShowDialog();
                    FrmMediatek frmMediatek = new FrmMediatek();
                    frmMediatek.ShowDialog();
                }
                if (nomService == "Prêts")
                {
                   
                    FrmMediatek frmMediatek = new FrmMediatek();
                    frmMediatek.GérerVisibilitéObjets(false);
                    frmMediatek.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Utilisateur inconnu ou aucun service associé", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
