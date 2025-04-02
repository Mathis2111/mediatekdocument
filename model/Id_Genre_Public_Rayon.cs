using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Id_Genre_Public_Rayon (récupère l'ID d'un genre, public et rayon)
    /// </summary>
    public class Id_Genre_Public_Rayon
    {
        public string TypeId { get; }
        public Id_Genre_Public_Rayon(string id)
        {
            this.TypeId = id;
        }
    }
}
