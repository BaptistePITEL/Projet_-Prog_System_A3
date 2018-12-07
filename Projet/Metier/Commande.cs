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
<<<<<<< HEAD
        public List<Cuisine.Recette> recettes;
        public StatutCommande statutCommande;

        public Commande(int numTable)
        {
            this.numTable = numTable;
            this.statutCommande = StatutCommande.ATTENTE;
            this.recettes = new List<Cuisine.Recette>();
        }
=======
        public List<Cuisine.Recette> listRecettes;
        //public Statut statutCommande;
>>>>>>> 7ba5f6fdb273af4a66433cb12a1d7ede5df77e55
    }
}
