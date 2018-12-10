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
<<<<<<< HEAD
        public bool etat;

        public Recette(string categorie, string titre,float tempsPrepa, float tempsCuisson, float tempsRepos, Table table)
=======

        public Recette(string categorie, string titre,float tempsPrepa, float tempsCuisson, float tempsRepos)
>>>>>>> 4edef53407020649206c33f6d70fce782ea7cdd1
        { 
            this.categorie = categorie;
            this.titre = titre;
            this.tempsPrepa = tempsPrepa;
            this.tempsCuisson = tempsCuisson;
            this.tempsRepos = tempsRepos;
            this.etat = false;
            this.table = table;
        }
    }
}
