using Metier.Cuisine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Salle
{
    class Serveur : Personnel
    {
        public Carre carre;
        public Restaurant restaurant;

<<<<<<< HEAD
        public Serveur(Carre carre, Restaurant r, string nom) : base(nom)
=======
        public Serveur(Carre carre, Restaurant r, string nom ) : base(nom)
>>>>>>> 4edef53407020649206c33f6d70fce782ea7cdd1
        {
            this.carre = carre;
            this.restaurant = r;
        }

<<<<<<< HEAD
        public override Restaurant getRestaurant()
        {
            return restaurant;
=======
        public void ServirPlat()
        {
            int quitter = 0;
            foreach(Recette r in restaurant.recettesAServir)
            {
                foreach(Rang rang in this.carre.rangs){
                    if (rang.tables.Contains(r.table))
                    {
                        int i = restaurant.recettesAServir.IndexOf(r);
                        restaurant.recettesAServir.RemoveAt(i);
                        //GERER ARRIVAGE A LA TABLE
                        quitter = 1;
                        break;
                    }
                }
                if (quitter == 1)
                {
                    break;
                }
            }
>>>>>>> 4edef53407020649206c33f6d70fce782ea7cdd1
        }

        public void ServirPlat()
        {
            int quitter = 0;
            foreach (Recette r in restaurant.recettesAServir)
            {
                foreach (Rang rang in this.carre.rangs)
                {
                    if (rang.tables.Contains(r.table))
                    {
                        int i = restaurant.recettesAServir.IndexOf(r);
                        restaurant.recettesAServir.RemoveAt(i);
                        //GERER ARRIVAGE A LA TABLE
                        quitter = 1;
                        break;
                    }
                }
                if (quitter == 1)
                {
                    break;
                }
            }
        }


        public override void tick()
        {
            throw new NotImplementedException();
        }
    }
}
