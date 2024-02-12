using System;
using System.Collections.Generic;

class Program
{
    static List<Produkt> koszyk = new List<Produkt>();
    static decimal lacznaCena = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Odzież");
            Console.WriteLine("2. Obuwie");
            Console.WriteLine("3. Okulary");
            Console.WriteLine("4. Kurtki");
            Console.WriteLine("5. Koszyk");
            if (koszyk.Count > 0)
            {
                Console.WriteLine("6. Zapłać kartą");
            }
            Console.WriteLine("7. Strona Główna");

            Console.Write("Wybierz opcję: ");
            string opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    PokazProdukty("Odzież");
                    break;
                case "2":
                    PokazProdukty("Obuwie");
                    break;
                case "3":
                    PokazProdukty("Okulary");
                    break;
                case "4":
                    PokazProdukty("Kurtki");
                    break;
                case "5":
                    PokazKoszyk();
                    break;
                case "6":
                    if (koszyk.Count > 0)
                    {
                        ZaplacKarta();
                    }
                    else
                    {
                        Console.WriteLine("Koszyk jest pusty. Dodaj produkty przed płatnością.");
                        Console.WriteLine("Naciśnij Enter, aby kontynuować...");
                        Console.ReadLine();
                    }
                    break;
                case "7":
                    ResetujKoszyk();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }
    static void PokazProdukty(string kategoria)
    {
        Console.WriteLine($"--- {kategoria} ---");
        List<Produkt> produkty = PobierzProdukty(kategoria);

        foreach (var produkt in produkty)
        {
            Console.WriteLine($"{produkt.Nazwa} - Cena: {produkt.Cena} zł");
        }

        Console.WriteLine("0. Powrót");
        Console.Write("Wybierz produkt (numer) lub naciśnij 0, aby wrócić: ");
        string wybor = Console.ReadLine();

        if (wybor != "0" && int.TryParse(wybor, out int numerProduktu) && numerProduktu >= 1 && numerProduktu <= produkty.Count)
        {
            DodajDoKoszyka(produkty[numerProduktu - 1]);
        }
    }

    static void DodajDoKoszyka(Produkt produkt)
    {
        koszyk.Add(produkt);
        lacznaCena += produkt.Cena;

        Console.WriteLine($"{produkt.Nazwa} został dodany do koszyka.");
        Console.WriteLine($"Łączna cena: {lacznaCena} zł");
        Console.WriteLine("Naciśnij Enter, aby kontynuować...");
        Console.ReadLine();
    }
    static void ZaplacKarta()
    {
        if (koszyk.Count > 0)
        {
            Console.Write("Podaj kwotę do zapłaty kartą: ");
            string? kwotaString = Console.ReadLine();

            if (!string.IsNullOrEmpty(kwotaString) && decimal.TryParse(kwotaString, out decimal kwota) && kwota >= lacznaCena)
            {
                Console.Write("Podaj numer karty kredytowej: ");
                string numerKarty = Console.ReadLine();

                Console.WriteLine("Dziękujemy za zakup w naszym sklepie!");
                Console.WriteLine($"Kwota zapłacona: {kwota} zł");
                Console.WriteLine($"Numer karty: {numerKarty}");
                Console.WriteLine($"Reszta: {kwota - lacznaCena} zł");
                Console.WriteLine("Naciśnij Enter, aby kontynuować...");
                Console.ReadLine();

                ResetujKoszyk();
            }
            else
            {
                Console.WriteLine("Nieprawidłowa kwota. Spróbuj ponownie.");
                Console.WriteLine("Naciśnij Enter, aby kontynuować...");
                Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("Koszyk jest pusty. Dodaj produkty przed płatnością.");
            Console.WriteLine("Naciśnij Enter, aby kontynuować...");
            Console.ReadLine();
        }
    }

    static void PokazKoszyk()
    {
        Console.WriteLine("--- Koszyk ---");

        if (koszyk.Count == 0)
        {
            Console.WriteLine("Koszyk jest pusty.");
        }
        else
        {
            foreach (var produkt in koszyk)
            {
                Console.WriteLine($"{produkt.Nazwa} - Cena: {produkt.Cena} zł");
            }

            Console.WriteLine($"Łączna cena: {lacznaCena} zł");
        }

        Console.WriteLine("Naciśnij Enter, aby kontynuować...");
        Console.ReadLine();
    }

    static void ResetujKoszyk()
    {
        koszyk.Clear();
        lacznaCena = 0;
    }

    static List<Produkt> PobierzProdukty(string kategoria)
    {

        List<Produkt> produkty = new List<Produkt>();

        if (kategoria == "Odzież")
        {
            produkty.Add(new Produkt("Koszulka w kwiatki", 29.99m));
            produkty.Add(new Produkt("Jeansy damskie szare ", 49.99m));
            produkty.Add(new Produkt("Spodnie dresowe ", 30.99m));
            produkty.Add(new Produkt("Spodnie brązwoe Chino ", 59.99m));
            produkty.Add(new Produkt("Bluza męska z kaputem", 35.99m));
            produkty.Add(new Produkt("Szara koszula ", 29.99m));
            produkty.Add(new Produkt("Koszulka sportowa biała", 15.99m));
            produkty.Add(new Produkt("Koszulka sporotwa czarna", 14.99m));
        }
        else if (kategoria == "Obuwie")
        {
            produkty.Add(new Produkt("Buty sportowe BIG STAR", 89.99m));
            produkty.Add(new Produkt("Sandały", 39.99m));
            produkty.Add(new Produkt("Trampki Kappa  ", 49.99m));
            produkty.Add(new Produkt("Buty wojskowe wodoodporne", 79.99m));
            produkty.Add(new Produkt("Sneakersy 4F ", 37.99m));
        }
        else if (kategoria == "Okulary")
        {
            produkty.Add(new Produkt("Okulary przeciwsłoneczne", 59.99m));
            produkty.Add(new Produkt("Okulary korekcyjne", 79.99m));
            produkty.Add(new Produkt("Czarne okulary Red Sunset", 89.99m));
            produkty.Add(new Produkt("Okulary korekcyjne Grant Americano", 99.99m));
            produkty.Add(new Produkt("ICON Reading i102 - Okulary do czytania", 59.99m));
        }
        else if (kategoria == "Kurtki")
        {
            produkty.Add(new Produkt("Kurtka zimowa", 149.99m));
            produkty.Add(new Produkt("Kurtka skórzana", 199.99m));
            produkty.Add(new Produkt("Kurtki puchowa damskia", 219.99m));
            produkty.Add(new Produkt("Pikowana kurtka z kapturem beżowa", 139.99m));
            produkty.Add(new Produkt("Bordowa Pikowana Kurtka", 179.99m));
            produkty.Add(new Produkt("Pikowana kurtka męska niebieska", 159.99m));
            produkty.Add(new Produkt("Pikowana kurtka męska szara", 159.99m));

        }

        return produkty;
    }
}

class Produkt
{
    public string Nazwa { get; set; }
    public decimal Cena { get; set; }

    public Produkt(string nazwa, decimal cena)
    {
        Nazwa = nazwa;
        Cena = cena;
    }

}
