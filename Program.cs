using System;
using System.Collections.Generic;

class Program
{
    List<Produkt> koszyk = new List<Produkt>();
    decimal lacznaCena = 0;

    void Start()
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

    void PokazProdukty(string kategoria)
    {
        Console.WriteLine($"--- {kategoria} ---");
        List<Produkt> produkty = Produkt.PobierzProdukty(kategoria);

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

    void DodajDoKoszyka(Produkt produkt)
    {
        koszyk.Add(produkt);
        lacznaCena += produkt.Cena;

        Console.WriteLine($"{produkt.Nazwa} został dodany do koszyka.");
        Console.WriteLine($"Łączna cena: {lacznaCena} zł");
        Console.WriteLine("Naciśnij Enter, aby kontynuować...");
        Console.ReadLine();
    }

    void ZaplacKarta()
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

    void PokazKoszyk()
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

    void ResetujKoszyk()
    {
        koszyk.Clear();
        lacznaCena = 0;
    }

    static void Main()
    {
        Program program = new Program();
        program.Start();
    }
}
