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
        public int numeroTable;

        public Table(int nb, int nbTable)
        {
            this.nbPlaces = nb;
            this.nbAssiettes = 0;
            enumEtatTable = EnumEtatTable.INITIALE;
            this.numeroTable = nbTable;
        }

        public void log()
        {
            Console.WriteLine(nbPlaces);
        }





    }
}
