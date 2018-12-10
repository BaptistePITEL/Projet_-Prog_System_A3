using Metier.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Commande
    {
        public Table table;

        public List<Cuisine.Recette> recettes;
        public StatutCommande statutCommande;

        public Commande(Table t)
        {
            this.table = t;
            this.statutCommande = StatutCommande.ATTENTE;
            this.recettes = new List<Cuisine.Recette>();
        }

       
    }
}
