using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Table
    {
        public int nbPlaces;
        public GroupeClient grclient;
        public bool ontCarte;
        public bool ontPrisCommande;


        // etatTable : 
        //   0 : n'ont pas les cartes
        //   1 : ont reçu les cartes
        //   2 : ont commandé
        //   3 : ont reçu 

        public int etatTable;

        public Table(int nb )
        {
            this.nbPlaces = nb;
            this.etatTable = 0;
            this.ontCarte = false;
            this.ontPrisCommande = false;
        }

        public void log()
        {
            Console.WriteLine(nbPlaces);
        }




    }
}
