﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Builder
{
    public interface GeneralRestaurantBuilder
    {
        void buildMaitreHotel(string nomMaitreHotel);

        void buildCarres(int nbCarre, int nbRangsParCarre, List<string> chefs, List<string> serveurs);

        void buildChefDeCuisine(string nomChefdeCuisine);

        void buildComptoir();

        Restaurant getRestaurant();
    }
}
