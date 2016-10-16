using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Models
{
    public class ProduitModel
    {
        public int ProduitId
        {
            get;
            set;
        }


        public string Nom
        {
            get;
            set;
        }
        public decimal Prix
        {
            get;
            set;
        }
        public int Stock
        {
            get;
            set;
        }

        public string NomCategorie
        {
            get;
            set;
        }
        public int CategorieId
        {
            get;
            set;
        }
        public string NomCatalogue
        {
            get;
            set;
        }
        public int CatalogueId
        {
            get;
            set;
        }
    }
}