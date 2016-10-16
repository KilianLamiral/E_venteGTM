using Fil_rouge_evente.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fil_rouge_evente.Models
{
    public class ModelCreationPdfFacture
    {
        public string NomClient { get; set; }
        public string PrenomClient { get; set; }
        public int ClientId { get; set; }
        public string NumeroRueFacturation { get; set; }
        public string NomRueFacturation { get; set; }
        public string CodePostalFacturation { get; set; }
        public string VilleFacturation { get; set; }
        public string NumeroRueLivraison { get; set; }
        public string NomRueLivraison { get; set; }
        public string CodePostalLivraison { get; set; }
        public string VilleLivraison { get; set; }
        public DateTime DateCommande { get; set; }
        public DateTime DateEcheance { get; set; }
        public int FactureId { get; set; }
        public List<ProduitCommande> ProduitCommande { get; set; }
        public decimal PrixTotalCommande { get; set; }
        public List<Produit> Produit { get; set; }
        public decimal PrixTotalProduit { get; set; }
    }
}