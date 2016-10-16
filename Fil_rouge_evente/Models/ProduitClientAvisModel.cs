using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Models
{
    public class ProduitClientAvisModel
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int ProduitId { get; set; }
        public int Note { get; set; }
        public string Commentaire { get; set; }
    }
}