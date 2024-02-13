using System.Collections.Generic;

class Produkt
{
    public string Nazwa { get; set; }
    public decimal Cena { get; set; }

    public Produkt(string nazwa, decimal cena)
    {
        Nazwa = nazwa;
        Cena = cena;
    }

    public static List<Produkt> PobierzProdukty(string kategoria)
    {
        List<Produkt> produkty = new List<Produkt>();

        if (kategoria == "Odzież")
        {
            produkty.Add(new Produkt("1.Koszulka w kwiatki", 29.99m));
            produkty.Add(new Produkt("2.Jeansy damskie szare ", 49.99m));
            produkty.Add(new Produkt("3.Spodnie dresowe ", 30.99m));
            produkty.Add(new Produkt("4.Spodnie brązwoe Chino ", 59.99m));
            produkty.Add(new Produkt("5.Bluza męska z kaputem", 35.99m));
            produkty.Add(new Produkt("6.Szara koszula ", 29.99m));
            produkty.Add(new Produkt("7.Koszulka sportowa biała", 15.99m));
            produkty.Add(new Produkt("8.Koszulka sporotwa czarna", 14.99m));
            produkty.Add(new Produkt("9.Czerwona sukienka", 79.99m));
            produkty.Add(new Produkt("10.Garnitur męski", 149.99m));
            produkty.Add(new Produkt("11.Czarna kurtka skórzana", 199.99m));
            produkty.Add(new Produkt("12.Dżinsowa kurtka damska", 129.99m));
            produkty.Add(new Produkt("13.Czarno-białe sneakersy", 79.99m));
        }
        else if (kategoria == "Obuwie")
        {
            produkty.Add(new Produkt("1.Buty sportowe BIG STAR", 89.99m));
            produkty.Add(new Produkt("2.Sandały", 39.99m));
            produkty.Add(new Produkt("3.Trampki Kappa  ", 49.99m));
            produkty.Add(new Produkt("4.Buty wojskowe wodoodporne", 79.99m));
            produkty.Add(new Produkt("5.Sneakersy 4F ", 37.99m));
            produkty.Add(new Produkt("6.Botki damskie", 89.99m));
            produkty.Add(new Produkt("7.Kapcie dziecięce", 19.99m));
            produkty.Add(new Produkt("8.Białe tenisówki", 59.99m));
            produkty.Add(new Produkt("9.Eleganckie mokasyny", 69.99m));
            produkty.Add(new Produkt("10.Skórzane kozaki", 129.99m));
        }
        else if (kategoria == "Okulary")
        {
            produkty.Add(new Produkt("1.Okulary przeciwsłoneczne", 59.99m));
            produkty.Add(new Produkt("2.Okulary korekcyjne", 79.99m));
            produkty.Add(new Produkt("3.Czarne okulary Red Sunset", 89.99m));
            produkty.Add(new Produkt("4.Okulary korekcyjne Grant Americano", 99.99m));
            produkty.Add(new Produkt("5.ICON Reading i102 - Okulary do czytania", 59.99m));
            produkty.Add(new Produkt("6.Sportowe okulary narciarskie", 119.99m));
            produkty.Add(new Produkt("7.Przyciemniane okulary pilotki", 69.99m));
            produkty.Add(new Produkt("8.Okulary przeciwmgielne do jazdy rowerem", 49.99m));
            produkty.Add(new Produkt("9.Czerwone okulary retro", 79.99m));
            produkty.Add(new Produkt("10.Okulary komputerowe anty-świecące", 89.99m));
        }
        else if (kategoria == "Kurtki")
        {
            produkty.Add(new Produkt("1.Kurtka zimowa", 149.99m));
            produkty.Add(new Produkt("2.Kurtka skórzana", 199.99m));
            produkty.Add(new Produkt("3.Kurtki puchowa damskia", 219.99m));
            produkty.Add(new Produkt("4.Pikowana kurtka z kapturem beżowa", 139.99m));
            produkty.Add(new Produkt("5.Bordowa Pikowana Kurtka", 179.99m));
            produkty.Add(new Produkt("6.Pikowana kurtka męska niebieska", 159.99m));
            produkty.Add(new Produkt("7.Pikowana kurtka męska szara", 159.99m));
            produkty.Add(new Produkt("8.Kurtka jeansowa", 89.99m));
            produkty.Add(new Produkt("9.Kurtka przeciwdeszczowa", 59.99m));
            produkty.Add(new Produkt("10.Kurtka sportowa", 109.99m));
            produkty.Add(new Produkt("11.Płaszcz damski", 179.99m));
            produkty.Add(new Produkt("12.Kurtka turystyczna", 129.99m));
        }

        return produkty;
    }
}
