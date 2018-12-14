using Metier;
using Metier.Builder;
using Metier.Cuisine;
using Metier.Factory;
using Metier.Salle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Restaurant resto;
        private bool appLancee = false;
        private bool appEnPause;
        private int compteurMinute = 1;
        private int compteurHeure = 12;
        private int tickMax = 0;
        private string stats = "";


        public Form1()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tickMax += 1;
            resto.tick();
            if(this.compteurMinute < 10)
            {
                this.label2.Text = this.compteurHeure + " H 0" + this.compteurMinute;
            }
            else
            {
                this.label2.Text = this.compteurHeure + " H " + this.compteurMinute;
            }
            this.compteurMinute += 1;
            if (this.compteurMinute == 60)
            {
                this.compteurHeure += 1;
                this.compteurMinute = 0;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.appLancee == true)
            {
                resto.groupeClientArrive(FabriqueGroupeClient.create());
            }
            else
            {
                MessageBox.Show("Aucune simulation de lancée");
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            if(this.appLancee == true)
            {
                if (this.timer1.Enabled == true)
                {
                    this.timer1.Enabled = false;
                    this.appEnPause = true;
                    Console.WriteLine("--------------------  RESTAURANT EN PAUSE--------------------");
                }
                else
                {
                    this.timer1.Enabled = true;
                    this.appEnPause = false;
                    Console.WriteLine("--------------------  RESTAURANT RELANCE--------------------");

                }

            }
            else
            {
                MessageBox.Show("Aucune simulation de lancée");
            }
        }


        private void lancerSimulation_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled == false && this.appLancee == false)
            {
                this.tickMax = 0;
                this.resto = null;
                this.compteurHeure = 12;
                this.compteurMinute = 0;
                this.label2.Text = this.compteurHeure + " H 0" + this.compteurMinute;
                RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
                RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
                List<string> listChef = new List<string>();
                listChef.Add("Chef de Rang 1");
                listChef.Add("Chef de Rang 2");

                List<string> listServeur = new List<string>();
                listServeur.Add("Serveur 1");
                listServeur.Add("Serveur 2");
                listServeur.Add("Serveur 3");
                listServeur.Add("Serveur 4");


                restaurantEngineer.makeRestaurant(2, 4, listChef, "Maitre d'hotel", "Chef de cuisine", listServeur);
                resto = restaurantEngineer.getRestaurant();
                Console.WriteLine("--------------------  RESTAURANT OUVERT  --------------------");
                this.timer1.Enabled = true;
                this.appLancee = true;
            }
            else
            {
                MessageBox.Show("Simulation déjà lancée");
            }
            
        }

        private void arreterSimulation_Click(object sender, EventArgs e)
        {
            if (this.appLancee == true)
            {
                this.timer1.Enabled = false;
                this.appLancee = false;
                Console.WriteLine("--------------------  ARRET SIMULATION  --------------------");
            }
            else
            {
                MessageBox.Show("Aucune simulation de lancée");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.timer1.Interval == 2000)
            {
                MessageBox.Show("Vitesse Minimale");
            }
            else
            {
                this.timer1.Interval = this.timer1.Interval * 2;
                if (this.timer1.Interval == 125)
                {
                    this.label1.Text = "X 8";
                }
                if (this.timer1.Interval == 250)
                {
                    this.label1.Text = "X 4";
                }
                if (this.timer1.Interval == 500)
                {
                    this.label1.Text = "X 2";
                }
                if (this.timer1.Interval == 1000)
                {
                    this.label1.Text = "X 1";
                }
                if (this.timer1.Interval == 2000)
                {
                    this.label1.Text = "X 1/2";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.timer1.Interval == 125)
            {
                MessageBox.Show("Vitesse Maximale");
            }
            else
            {
                this.timer1.Interval = this.timer1.Interval / 2;
                if (this.timer1.Interval == 125)
                {
                    this.label1.Text = "X 8";
                }
                if (this.timer1.Interval == 250)
                {
                    this.label1.Text = "X 4";
                }
                if (this.timer1.Interval == 500)
                {
                    this.label1.Text = "X 2";
                }
                if (this.timer1.Interval == 1000)
                {
                    this.label1.Text = "X 1";
                }
                if (this.timer1.Interval == 2000)
                {
                    this.label1.Text = "X 1/2";
                }
            }
            
        }

        private void recupStat_Click(object sender, EventArgs e)
        {
            if (this.appLancee == true)
            {
                if (this.appEnPause == true)
                {
                    MessageBox.Show(calculStatConsole());
                }
                else
                {
                    MessageBox.Show("L'application doit être en pause");
                }
            }
            else
            {
                if(calculStatConsole() != "")
                {
                    MessageBox.Show(calculStatConsole());
                }
                else
                {
                    MessageBox.Show("Aucune simulation n'a été lancée");
                }
            }
        }

        public string calculStatConsole()
        {
            this.stats = "--------------- Pourcentages de travail ---------------\n\n";
            this.stats += "[Coté Salle] :\n";
            this.stats += resto.maitreHotel.nom + " : " + Math.Round((double)resto.maitreHotel.statMaitreHotel / (double)this.tickMax*100) + " %\n";
            foreach (Carre carre in resto.carres)
            {
                this.stats += carre.chefDeRang.nom + " : " + Math.Round((double)carre.chefDeRang.statChefDeRang / (double)this.tickMax*100) + " %\n";
            }
            foreach (Carre carre in resto.carres)
            {
                foreach (Serveur serveur in carre.serveurs)
                {
                    this.stats += serveur.nom + " : " + Math.Round((double)serveur.statServeur / (double)this.tickMax*100,2) + " %\n";
                }
            }
            this.stats += "\n[Coté Cuisine] :\n";
            this.stats += resto.chefDeCuisine.nom + " : " + Math.Round((double)resto.chefDeCuisine.statChefDeCuisine / (double)this.tickMax*100) + " %\n";
            foreach (ChefDePartie chefDePartie in resto.chefDeCuisine.chefParties)
            {
                this.stats += chefDePartie.nom + " : " + Math.Round((double)chefDePartie.statChefDePartie / (double)this.tickMax*100) + "%\n";
            }
            return this.stats;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.appLancee == false)
            {
                if (calculStatConsole() != "")
                {
                    DisplayInExcel();
                }
                else
                {
                    MessageBox.Show("Aucune simulation n'a été lancée");
                }
            }
            else
            {
                MessageBox.Show("Vous devez attendre la fin de la simulation");
            }
        }

        public void DisplayInExcel()
        {

            //Création du package Excel

            ExcelPackage package = new ExcelPackage();

            //Création du Feuille de calcul(Onglet)

            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Mon Onglet");

            //Réglage de la taille et de la police pour l’ensemble de la feuille de calcul

            ws.Cells.Style.Font.Size = 12;

            ws.Cells.Style.Font.Name = "Restaurant";

            //Ajout des données dans le tableau

            ws.Cells[2, 1].Value = "Personel";

            ws.Cells[2, 2].Value = "Nombre de tick par Personnel";

            Random random = new Random();

            int startRow = 3;

            int endRow = 0;

            //boucle permettant de remplir les cellules
            for (int i = startRow; i < 13; i++)
            {
                ws.Cells[i, 1].Value = listePersonnel()[i-3];
                ws.Cells[i, 2].Value = listeTicks()[i-3];
                endRow = i;
            }

            //Autofit des colonnes

            ws.Cells.AutoFitColumns();


            //Création d’un graphique

            ExcelChart chart = ws.Drawings.AddChart("Mon Graphique", eChartType.Pie3D);

            chart.SetPosition(0, 0, 3, 0);

            chart.SetSize(900, 400);

            //Ajout de la série de données

            chart.Series.Add(ws.Cells["B3:B12"], ws.Cells["A3:A12"]);

            //Ajout d’un titre au graphique

            chart.Title.Text = "Répartition par tick";

            String filePath = @"C:\Users\Nutzer\Documents\CESI\Projet Prog.Système\Proj et_Prog_System_A3\Projet\testResto.xls";

            FileInfo fi = new FileInfo(filePath);

            package.SaveAs(fi);
            System.Diagnostics.Process.Start(@"C:\Users\Nutzer\Documents\CESI\Projet Prog.Système\Projet_Prog_System_A3\Projet\testResto.xls");


        }

        public List<int> listeTicks()
        {
            List<int> listeTicks = new List<int>();
            listeTicks.Add(resto.maitreHotel.statMaitreHotel);
            foreach (Carre carre in resto.carres)
            {
                listeTicks.Add(carre.chefDeRang.statChefDeRang);
            }
            foreach (Carre carre in resto.carres)
            {
                foreach (Serveur serveur in carre.serveurs)
                {
                    listeTicks.Add(serveur.statServeur);
                }
            }
            listeTicks.Add(resto.chefDeCuisine.statChefDeCuisine);
            foreach (ChefDePartie chefDePartie in resto.chefDeCuisine.chefParties)
            {
                listeTicks.Add(chefDePartie.statChefDePartie);
            }
            return listeTicks;
        }

        public List<string> listePersonnel()
        {
            List<string> listePersonnel = new List<string>();
            listePersonnel.Add(resto.maitreHotel.nom);
            foreach (Carre carre in resto.carres)
            {
                listePersonnel.Add(carre.chefDeRang.nom);
            }
            foreach (Carre carre in resto.carres)
            {
                foreach (Serveur serveur in carre.serveurs)
                {
                    listePersonnel.Add(serveur.nom);
                }
            }
            listePersonnel.Add(resto.chefDeCuisine.nom);
            foreach (ChefDePartie chefDePartie in resto.chefDeCuisine.chefParties)
            {
                listePersonnel.Add(chefDePartie.nom);
            }
            return listePersonnel;
        }

    }
}
