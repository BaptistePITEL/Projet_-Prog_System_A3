using Metier.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Cuisine
{
    public class Recette
    {
        public string categorie, titre;
        public Table table;
        public float tempsPrepa, tempsCuisson, tempsRepos;

        public Recette(string categorie, string titre,float tempsPrepa, float tempsCuisson, float tempsRepos)
        { 
            this.categorie = categorie;
            this.titre = titre;
            this.tempsPrepa = tempsPrepa;
            this.tempsCuisson = tempsCuisson;
            this.tempsRepos = tempsRepos;
        }
    }
}
