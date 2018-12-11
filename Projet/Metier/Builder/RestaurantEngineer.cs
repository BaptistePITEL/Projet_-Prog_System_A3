using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Builder
{
    public class RestaurantEngineer
    {
        private RestaurantBuilder restaurantBuilder;

        public RestaurantEngineer(RestaurantBuilder restaurantBuilder)
        {
            this.restaurantBuilder = restaurantBuilder;
        }

        public Restaurant getRestaurant()
        {
            return this.restaurantBuilder.getRestaurant();
        }

        public void makeRestaurant(int nbCarre, int nbRangsParCarre, int nbTablesParRang, int tailleTable, List<string> chefs, string nomMaitreHotel,string nomChefDeCuisine, List<string> serveurs)
        {
            this.restaurantBuilder.buildCarres(nbCarre, nbRangsParCarre, nbTablesParRang,  tailleTable, chefs, serveurs);
            this.restaurantBuilder.buildMaitreHotel(nomMaitreHotel);
            this.restaurantBuilder.buildChefDeCuisine(nomChefDeCuisine);
            this.restaurantBuilder.buildComptoir();
        }
    }
}
