using System;
using System.Collections.Generic;
using static BazaZplytami.Baza;

namespace BazaZplytami
{
    public class Baza
    {
        public class Utwor
        {
            public string Nazwa;
            public double CzasTrwania;
            public int Sekundy;
            public List<string> Wykonawcy;
            public string Kompozytor;
            public double Nr;

            public Utwor()
            {
                Wykonawcy = new List<string>(); 
            }
        }

        public class Plyta
        {
            public string Tytul;
            public string Typ;
            public double TotalCzas;
            public List<Utwor> Utwory;
            public List<string> Wszystkie = new List<string>();
            public Plyta()
            {
                Utwory = new List<Utwor>();
            }

            public void WprowadzPlyte()
            {
                do
                {
                    try
                    {
                        Console.Write("Podaj tytuł płyty: ");
                        Tytul = Console.ReadLine();

                        Console.Write("Podaj typ płyty (CD/DVD): ");
                        Typ = Console.ReadLine();
                        if(Typ != "CD" && Typ != "cd" && Typ != "DVD" && Typ != "dvd")
                        {
                            throw new Exception("Nie poprawny typ dysku");
                        }


                        for (int i = 0; i < 30; i++)
                        {
                            Console.WriteLine($"\nWprowadzanie utworu {i + 1}:");
                            Utwor utwor = new Utwor();
                            utwor.Nr = i + 1;

                            Console.Write("Podaj tytul utworu: ");
                            utwor.Nazwa = Console.ReadLine();

                            Console.Write("Podaj czas trwania utworu (w minutach): ");
                            utwor.CzasTrwania = Convert.ToDouble(Console.ReadLine());
                            TotalCzas += utwor.CzasTrwania;

                            Console.Write("Podaj czas trwania utworu (w sekundach): ");
                            utwor.Sekundy = Convert.ToInt32(Console.ReadLine());

                            double sprawdz = utwor.Sekundy / 60;
                            int zostalo = utwor.Sekundy % 60;
                            if(sprawdz > 0)
                            {
                                TotalCzas += sprawdz;
                                utwor.Sekundy = zostalo;
                                utwor.CzasTrwania += sprawdz;
                                if(utwor.Sekundy < 10)
                                {
                                    
                                }
                            }

                            Console.Write("Podaj kompozytora utworu: ");
                            utwor.Kompozytor = Console.ReadLine();
                            Console.Write("Podaj liczbę wykonawców utworu: ");
                            int liczbaWykonawcow = Convert.ToInt32(Console.ReadLine());
                            for (int j = 0; j < liczbaWykonawcow; j++)
                            {
                                Console.Write($"Podaj wykonawcę {j + 1}: ");
                                string lokalna = Console.ReadLine();
                                utwor.Wykonawcy.Add(lokalna);
                                Wszystkie.Add(lokalna);
                            }

                            Utwory.Add(utwor);
                            Console.Write("\nCzy chcesz dodać kolejny utwór? (T/N): ");
                            string odpowiedz = Console.ReadLine();
                            if (odpowiedz.ToLower() != "t")
                            {
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                }
                while (true);
            }
            
            public void WypiszUtworSzczegoly()
            {

                while (true)
                {
                    Console.Write("\nPodaj numer utworu: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    index--;
                    Utwor utwor = Utwory[index];
                    Console.WriteLine($"\nSzczegóły utworu {index + 1}:");
                    if (utwor.Sekundy < 10)
                    {
                        Console.WriteLine($"Tytul:{utwor.Nazwa}, Czas trwania: {utwor.CzasTrwania}:0{utwor.Sekundy}");
                        Console.Write("Wykonawca(-y):");
                        foreach (var wykonawca in utwor.Wykonawcy)
                        {
                            Console.Write($"{wykonawca},");
                        }
                        Console.WriteLine($" Kompozytor: {utwor.Kompozytor}");
                    }
                    else
                    {
                        Console.WriteLine($"Tytul:{utwor.Nazwa}, Czas trwania: {utwor.CzasTrwania}:{utwor.Sekundy}");
                        Console.Write("Wykonawca(-y):");
                        foreach (var wykonawca in utwor.Wykonawcy)
                        {
                            Console.Write($"{wykonawca},");
                        }
                        Console.WriteLine($" Kompozytor: {utwor.Kompozytor}");
                    }

                    Console.Write("\n\n");
                    Console.Write("Chcesz wyswietlic sczegoly konkretnego utworu?(T/N): ");
                    char odpowiedz1 = Console.ReadKey().KeyChar;
                    if (!(odpowiedz1 == 't' || odpowiedz1 == 'T'))
                    {
                        break;
                    }
                }

            }
            public void WypiszPlyteSzczegoly()
            {
                Console.Clear();
                Console.WriteLine($"Tytuł płyty: {Tytul}");
                Console.WriteLine($"Typ płyty: {Typ}");
                Console.WriteLine($"Czas trwania płyty: {TotalCzas} minut");
                Console.WriteLine("\nLista utworów:");
                foreach (var utwor in Utwory)
                {
                    if(utwor.Sekundy < 10)
                    {
                        Console.WriteLine($"{utwor.Nr}. {utwor.Nazwa} {utwor.CzasTrwania}:0{utwor.Sekundy}");
                        Console.Write("\n");
                    }
                    else
                    {
                        Console.WriteLine($"{utwor.Nr}. {utwor.Nazwa} {utwor.CzasTrwania}:{utwor.Sekundy}");
                        Console.Write("\n");
                    }
                }
                Console.WriteLine($"Lista wykonawców na plycie {Tytul}:");
                foreach(var wykonawca in Wszystkie)
                {
                    Console.WriteLine($"- {wykonawca}");
                }


                
                
            }

        }
    }
}
