using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
using Metier.Cuisine;

namespace Metier
{
    public class Comptoir
    {
        public Queue<Commande> commandeAPrepare;
        public Queue<Recette> entreesAServir;
        public Queue<Recette> platsAServir;
        public Queue<Recette> dessertsAServir;

        public  Comptoir()
        {
            this.commandeAPrepare = new Queue<Commande>();
            this.entreesAServir = new Queue<Recette>();
            this.platsAServir = new Queue<Recette>();
            this.dessertsAServir = new Queue<Recette>();
        }

       
    }
}
