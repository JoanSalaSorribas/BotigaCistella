using System;
using System.Text;

class Botiga
{
    static string[] productes = new string[10];
    static double[] preus = new double[10];
    static int numProductes = 0;
    static Cistella cistella;

    static void Main(string[] args)
    {
        Console.Write("Introdueix els diners inicials dels que disposes: ");
        double dinersInicial = double.Parse(Console.ReadLine());
        cistella = new Cistella(10, dinersInicial);

        bool sortir = false;
        while (!sortir)
        {
            Console.WriteLine("\n1. Afegir producte");
            Console.WriteLine("2. Mostrar productes");
            Console.WriteLine("3. Mostrar productes ordenats per preu");
            Console.WriteLine("4. Comprar producte");
            Console.WriteLine("5. Modificar nom de producte");
            Console.WriteLine("6. Modificar preu de producte");
            Console.WriteLine("7. Mostrar cistella");
            Console.WriteLine("8. Sortir");
            Console.Write("Tria una opció: ");
            string opcio = Console.ReadLine();

            switch (opcio)
            {
                case "1":
                    AfegirProducte();
                    break;
                case "2":
                    MostrarBotiga();
                    break;
                case "3":
                    OrdenarProductes();
                    MostrarBotiga();
                    break;
                case "4":
                    ComprarProducte();
                    break;
                case "5":
                    ModificarNomProducte();
                    break;
                case "6":
                    ModificarPreuProducte();
                    break;
                case "7":
                    cistella.MostraCistella();
                    break;
                case "8":
                    sortir = true;
                    break;
                default:
                    Console.WriteLine("Opció no vàlida.");
                    break;
            }
        }
    }

    static void AfegirProducte()
    {
        if (numProductes >= productes.Length)
        {
            Console.WriteLine("No hi ha espai per a més productes.");
            return;
        }

        Console.Write("Introdueix el nom del producte: ");
        string nom = Console.ReadLine();
        Console.Write("Introdueix el preu del producte: ");
        double preu = double.Parse(Console.ReadLine());

        productes[numProductes] = nom;
        preus[numProductes] = preu;
        numProductes++;
    }

    static void MostrarBotiga()
    {
        for (int i = 0; i < numProductes; i++)
        {

            Console.WriteLine($"{i + 1}. {productes[i]} {preus[i]} $");
        }
    }

    static void OrdenarProductes()
    {
        Array.Sort(preus, productes, 0, numProductes);
    }

    static void ComprarProducte()
    {
        MostrarBotiga();
        Console.Write("Selecciona el producte que vols comprar (número): ");
        int seleccion = int.Parse(Console.ReadLine()) - 1;
        if (seleccion >= 0 && seleccion < numProductes)
        {
            Console.Write("Quantitat: ");
            int quantitat = int.Parse(Console.ReadLine());
            if (cistella.ComprarProducte(productes[seleccion], quantitat, preus[seleccion]))
            {
                Console.WriteLine("Producte afegit a la cistella.");
            }
            else
            {
                Console.WriteLine("No s'ha pogut afegir el producte a la cistella.");
            }
        }
        else
        {
            Console.WriteLine("Selecció no vàlida.");
        }
    }

    static void ModificarNomProducte()
    {
        MostrarBotiga();
        Console.Write("Introdueix el número del producte a modificar: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < numProductes)
        {
            Console.Write("Nou nom: ");
            string nouNom = Console.ReadLine();
            productes[index] = nouNom;
            Console.WriteLine("Producte modificat.");
        }
        else
        {
            Console.WriteLine("Número de producte no vàlid.");
        }
    }

    static void ModificarPreuProducte()
    {
        MostrarBotiga();
        Console.Write("Introdueix el número del producte a modificar: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < numProductes)
        {
            Console.Write("Nou preu: ");
            double nouPreu = double.Parse(Console.ReadLine());
            preus[index] = nouPreu;
            Console.WriteLine("Preu modificat.");
        }
        else
        {
            Console.WriteLine("Número de producte no vàlid.");
        }
    }
}

class Cistella
{
    string[] productes;
    int[] quantitats;
    double[] preus;
    int numProductes;
    double diners;

    public Cistella(int mida, double dinersInicial)
    {
        productes = new string[mida];
        quantitats = new int[mida];
        preus = new double[mida];
        numProductes = 0;
        diners = dinersInicial;
    }

    public bool ComprarProducte(string producte, int quantitat, double preu)
    {
        if (diners - (preu * quantitat) < 0)
        {
            Console.WriteLine("No tens prou diners.");
            return false;
        }

        for (int i = 0; i < numProductes; i++)
        {
            if (productes[i] == producte)
            {
                quantitats[i] += quantitat;
                diners -= preu * quantitat;
                return true;
            }
        }

        if (numProductes < productes.Length)
        {
            productes[numProductes] = producte;
            quantitats[numProductes] = quantitat;
            preus[numProductes] = preu;
            numProductes++;
            diners -= preu * quantitat;
            return true;
        }

        Console.WriteLine("La cistella està plena.");
        return false;
    }

    public void MostraCistella()
    {
        if (numProductes == 0)
        {
            Console.WriteLine("La cistella està buida.");
            return;
        }

        Console.WriteLine("Contingut de la cistella:");
        for (int i = 0; i < numProductes; i++)
        {
            Console.WriteLine($"{productes[i]} x{quantitats[i]} - {preus[i]}€/u");
        }
        Console.WriteLine($"Diners restants: {diners}€");
    }
}
