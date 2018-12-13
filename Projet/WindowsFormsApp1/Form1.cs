using Metier;
using Metier.Builder;
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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Restaurant resto;
        private bool appLancee;
        private int compteurMinute = 1;
        private int compteurHeure = 12;


        public Form1()
        {
            InitializeComponent();
            this.appLancee = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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
            resto.groupeClientArrive(FabriqueGroupeClient.create());

        }

        private void pause_Click(object sender, EventArgs e)
        {
            if(this.appLancee == true)
            {
                if (this.timer1.Enabled == true)
                {
                    this.timer1.Enabled = false;
                    Console.WriteLine("--------------------  RESTAURANT EN PAUSE--------------------");
                }
                else
                {
                    this.timer1.Enabled = true;
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


                restaurantEngineer.makeRestaurant(2, 6, 3, 5, listChef, "Maitre d'hotel", "Chef de cuisine", listServeur);
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
                this.compteurHeure = 12;
                this.compteurMinute = 0;
                this.label2.Text = this.compteurHeure + " H 0" + this.compteurMinute;
                this.timer1.Enabled = false;
                this.appLancee = false;
                this.resto = null;
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
    }
}
