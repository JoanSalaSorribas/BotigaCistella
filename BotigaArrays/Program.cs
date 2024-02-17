using System;


using System;

class Program
{
    static string[] productes = new string[10];
    static int[] estoc = new int[10];
    static double[] preus = new double[10];
    static int numProductes = 0; // Variable que manté el nombre actual de productes

    static void Main(string[] args)
    {
        // Exemple d'ús dels mètodes
        AfegirProducte("Producte1", 5.0);
        AfegirProducte("Producte2", 10.0);
        AfegirProducte("Producte3", 7.5);

        AmpliarTenda(3); // Ampliem la tenda per a 3 productes més

        AfegirProductes(new string[] { "Producte4", "Producte5" }, new double[] { 8.0, 6.0 });

        ModificarPreu("Producte1", 6.0);
        ModificarProducte("Producte2", "Producte2Modificat");
        OrdenarProductes();
        OrdenarPreus();
        MostrarBotiga();
        Console.WriteLine(BotigaToString());
    }

    static void AfegirProducte(string producte, double preu)
    {
        if (numProductes < productes.Length)
        {
            productes[numProductes] = producte;
            preus[numProductes] = preu;
            numProductes++;
        }
        else
        {
            Console.WriteLine("No hi ha prou espai a la tenda. Voleu ampliar-la? (s/n)");
            string resposta = Console.ReadLine();
            if (resposta.ToLower() == "s")
            {
                AmpliarTenda(1);
                AfegirProducte(producte, preu);
            }
        }
    }

    static void AfegirProductes(string[] productesNou, double[] preusNou)
    {
        if (numProductes + productesNou.Length <= productes.Length)
        {
            Array.Copy(productesNou, 0, productes, numProductes, productesNou.Length);
            Array.Copy(preusNou, 0, preus, numProductes, preusNou.Length);
            numProductes += productesNou.Length;
        }
        else
        {
            Console.WriteLine("No hi ha prou espai a la botiga. Voleu ampliar-la? (s/n)");
            string resposta = Console.ReadLine();
            if (resposta.ToLower() == "s")
            {
                AmpliarTenda(productesNou.Length);
                AfegirProductes(productesNou, preusNou);
            }
        }
    }

    static void AmpliarTenda(int num)
    {
        // Creem nous arrays amb la nova mida
        string[] newProductes = new string[productes.Length + num];
        int[] newEstoc = new int[estoc.Length + num];
        double[] newPreus = new double[preus.Length + num];

        // Copiem els valors dels arrays originals als nous arrays
        Array.Copy(productes, newProductes, numProductes);
        Array.Copy(estoc, newEstoc, numProductes);
        Array.Copy(preus, newPreus, numProductes);

        // Assignem els nous arrays als arrays originals per referència
        productes = newProductes;
        estoc = newEstoc;
        preus = newPreus;
    }

    static void ModificarPreu(string producte, double preu)
    {
        for (int i = 0; i < numProductes; i++)
        {
            if (productes[i] == producte)
            {
                preus[i] = preu;
                return;
            }
        }
        Console.WriteLine("Producte no trobat.");
    }

    static void ModificarProducte(string producteAntic, string producteNou)
    {
        for (int i = 0; i < numProductes; i++)
        {
            if (productes[i] == producteAntic)
            {
                productes[i] = producteNou;
                return;
            }
        }
        Console.WriteLine("Producte no trobat.");
    }

    static void OrdenarProductes()
    {
        for (int i = 0; i < numProductes - 1; i++)
        {
            for (int j = 0; j < numProductes - 1 - i; j++)
            {
                if (string.Compare(productes[j], productes[j + 1]) > 0)
                {
                    // Intercanviem els valors de productes
                    string temp = productes[j];
                    productes[j] = productes[j + 1];
                    productes[j + 1] = temp;

                    // Intercanviem els valors de preus
                    double tempPreu = preus[j];
                    preus[j] = preus[j + 1];
                    preus[j + 1] = tempPreu;
                }
            }
        }
    }

    static void OrdenarPreus()
    {
        for (int i = 0; i < numProductes - 1; i++)
        {
            for (int j = 0; j < numProductes - 1 - i; j++)
            {
                if (preus[j] > preus[j + 1])
                {
                    // Intercanviem els valors de preus
                    double temp = preus[j];
                    preus[j] = preus[j + 1];
                    preus[j + 1] = temp;

                    // Intercanviem els valors de productes
                    string tempProducte = productes[j];
                    productes[j] = productes[j + 1];
                    productes[j + 1] = tempProducte;
                }
            }
        }
    }

    static void MostrarBotiga()
    {
        for (int i = 0; i < numProductes; i++)
        {
            Console.WriteLine($"{productes[i]}: {preus[i]} €");
        }
    }

    static string BotigaToString()
    {
        string result = "";
        for (int i = 0; i < numProductes; i++)
        {
            result += $"{productes[i]}: {preus[i]} €\n";
        }
        result += $"Nombre de productes: {numProductes}\n";
        result += $"Espai disponible per emplenar: {productes.Length - numProductes}\n";
        return result;
    }
}

    

