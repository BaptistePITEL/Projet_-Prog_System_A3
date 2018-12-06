using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
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

        public void makeRestaurant(int nbCarre, int nbRangsParCarre, int nbTablesParRang, int tailleTable, List<string> chefs, string nomMaitreHotel)
        {
            this.restaurantBuilder.buildCarres(nbCarre, nbRangsParCarre, nbTablesParRang,  tailleTable, chefs);
            this.restaurantBuilder.buildMaitreHotel(nomMaitreHotel);
        }
    }
}
