using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Metier.Salle
{
    public class Table
    {
        public int nbPlaces, nbAssiettes;
        public GroupeClient grclient;
        public EnumEtatTable enumEtatTable;
        public Rang rang { get; set; }

        public Table(int nb )
        {
            this.nbPlaces = nb;
            this.nbAssiettes = 0;
            enumEtatTable = EnumEtatTable.INITIALE;
        }

        public void log()
        {
            Console.WriteLine(nbPlaces);
        }





    }
}
