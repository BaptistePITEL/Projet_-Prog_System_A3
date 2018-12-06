using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RestoBuilder
{
    private Restaurant restaurant { get; set; } = new Restaurant();
    private Carre lastCarre { get; set; }
    private Rang lastRang { get; set; }

    //Crée Restaurant + Maitre d'hotel
    public RestoBuilder()
    {
        this.restaurant.maitreHotel = new MaitreHotel(this.restaurant, "Didier");
    }

    //Ajoute un carre
    public RestoBuilder AddCarre()
    {
        Carre newCarre = new Carre();
        newCarre.chefDeRang = new ChefDeRang(newCarre, "Jacques");
        this.restaurant.carres.Add(newCarre);
        this.lastCarre = newCarre;
        return this;
    }

    //Ajoute un rang dans le carre spécifier 
    public RestoBuilder AddRangInCarreDonnee(int carre)
    {
        Rang newRang = new Rang();
        this.restaurant.carres[carre].rangs.Add(newRang);
        this.lastRang = newRang;
        return this;
    }

    //Ajoute un rang dans le dernier carre ajouter
    public RestoBuilder AddRangInCarre()
    {
        Rang newRang = new Rang();
        this.lastCarre.rangs.Add(newRang);
        this.lastRang = newRang;
        return this;
    }

    //Ajoute une table de "place" places dans le rang du carre spécifier
    public RestoBuilder AddTableInRangInCarreDonneDePlace(int rang, int carre, int place)
    {
        this.restaurant.carres[carre].rangs[rang].tables.Add(new Table(place));
        return this;
    }

    //Ajoute une table de "place" places dans le dernier rang ajouter
    public RestoBuilder AddTableInRangDePlace(int place)
    {
        this.lastRang.tables.Add(new Table(place));
        return this;
    }

    //Récupère le restaurant final
    public Restaurant GetRestaurant()
    {
        return this.restaurant;
    }
}
