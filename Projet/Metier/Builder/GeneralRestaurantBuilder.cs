using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Builder
{
    public interface GeneralRestaurantBuilder
    {
        void buildMaitreHotel(string nomMaitreHotel);

        void buildCarres(int nbCarre, int nbRangsParCarre, int nbTablesParRang, int tailleTable, List<string> chefs);

        void buildChefDeCuisine(string nomChefdeCuisine);

        Restaurant getRestaurant();
    }
}
