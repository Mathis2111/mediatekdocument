using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Suivi
    {
        /// <summary>
        /// Récupère ou définit l'id du Suivi d'une commande
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Récupère ou définit le libelle du Suivi d'une commande
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Initialisation d'un objet Suivi
        /// </summary>
        /// <param name="id">Id du Suivi d'une commande</param>
        /// <param name="libelle">Libelle du Suivi d'une commande</param>
        public Suivi(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }
    }
}
