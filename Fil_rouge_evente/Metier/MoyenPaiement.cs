using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Classe MoyenPaiement permettant à l'utilisateur de choisir le moyen de paiement au moment de valider sa commande. Possède 4 classe filles : CarteBancaire, Cheque, Facture, virement
namespace Fil_rouge_evente.Metier
{
    public class MoyenPaiement
    {
        public int MoyenPaiementId { get; set; }
        public bool Actif { get; set; }
        public enum typePaiement { CarteBancaire, Cheque, Facture, Virement};
        public typePaiement TypePaiement { get; set; }

        public int UtilisateurId { get; set; }
        public virtual Client client { get; set; }
    }
}