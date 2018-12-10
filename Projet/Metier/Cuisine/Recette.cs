using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Cuisine
{
    public class Recette
    {
        public string categorie, titre, recette;
        public int nbPers, numTable;
        public float tempsPrepa, tempsCuisson, tempsRepos;

        public Recette(string categorie, string titre, string recette, int nbPers, float tempsPrepa, float tempsCuisson, float tempsRepos)
        {
            this.categorie = categorie;
            this.titre = titre;
            this.recette = recette;
            this.nbPers = nbPers;
            this.numTable = 0;
            this.tempsPrepa = tempsPrepa;
            this.tempsCuisson = tempsCuisson;
            this.tempsRepos = tempsRepos;
        }
    }
}
