using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
using Metier.Salle;
using Metier.Cuisine;


namespace Metier.Builder
{
    public class RestaurantBuilder : GeneralRestaurantBuilder
    {

        private Restaurant restaurant;

        public RestaurantBuilder()
        {
            this.restaurant = new Restaurant();
        }

        public void buildCarres(int nbCarre, int nbRangsParCarre, int nbTablesParRang,int tailleTable, List<string> chefs)
        {
            List<int> list = new List<int> { 2, 4, 6, 8, 10 };

            Random rnd = new Random();
            for (int i = 0; i < nbCarre; i++)
            {
                restaurant.carres.Add(new Carre());
                restaurant.carres[i].chefDeRang = new ChefDeRang(restaurant.carres[i], chefs[i]);
                for (int j = 0; j < nbRangsParCarre; j++)
                {
                    restaurant.carres[i].rangs.Add(new Rang());
                    for (int k = 0; k < nbTablesParRang; k++)
                    {
                        restaurant.carres[i].rangs[j].tables.Add(new Table(list[rnd.Next(0,list.Count-1)]));
                    }
                }
            }
        }

        public void buildMaitreHotel(string nomMaitreHotel)
        {
            restaurant.addMaitreHotel(new MaitreHotel(restaurant,nomMaitreHotel));
        }

        public Restaurant getRestaurant()
        {
            return this.restaurant;
        }
    }
}
