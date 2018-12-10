using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Commande
    {
        public int numTable;

        public List<Cuisine.Recette> recettes;
        public StatutCommande statutCommande;

        public Commande(int numTable)
        {
            this.numTable = numTable;
            this.statutCommande = StatutCommande.ATTENTE;
            this.recettes = new List<Cuisine.Recette>();
        }

       
    }
}
