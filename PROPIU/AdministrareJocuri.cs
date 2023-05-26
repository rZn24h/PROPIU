using System;
using System.Collections.Generic;
using System.IO;

public class AdministrareJocuri
{
    private List<Joc> jocuri;

    public AdministrareJocuri()
    {
        jocuri = new List<Joc>();
    }

    public void AdaugareJoc()
    {
        Console.WriteLine("Introduceți detaliile jocului:");

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Nume: ");
        string nume = Console.ReadLine();

        Console.Write("Preț: ");
        double pret = double.Parse(Console.ReadLine());

        Joc joc = new Joc(id, nume, pret);
        jocuri.Add(joc);

        Console.WriteLine("Joc adăugat cu succes!");
    }

    public void SalvareInFisier(string numeFisier)
    {
        using (StreamWriter writer = new StreamWriter(numeFisier))
        {
            foreach (Joc joc in jocuri)
            {
                writer.WriteLine($"{joc.ID},{joc.Nume},{joc.Pret}");
            }
        }

        Console.WriteLine("Datele au fost salvate în fișierul text.");
    }

    public void PreluareDinFisier(string numeFisier)
    {
        jocuri.Clear();

        if (File.Exists(numeFisier))
        {
            using (StreamReader reader = new StreamReader(numeFisier))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tokens = line.Split(',');

                    if (tokens.Length == 3 && int.TryParse(tokens[0], out int id) && double.TryParse(tokens[2], out double pret))
                    {
                        Joc joc = new Joc(id, tokens[1], pret);
                        jocuri.Add(joc);
                    }
                }
            }

            Console.WriteLine("Datele au fost preluate din fișierul text.");
        }
        else
        {
            Console.WriteLine("Fișierul specificat nu există.");
        }
    }

    public void CautareJoc()
    {
        Console.WriteLine("Introduceți criteriile de căutare:");

        Console.Write("Nume: ");
        string numeCautat = Console.ReadLine();

        List<Joc> rezultate = jocuri.FindAll(joc => joc.Nume.Equals(numeCautat, StringComparison.OrdinalIgnoreCase));

        if (rezultate.Count > 0)
        {
            Console.WriteLine($"Rezultatele căutării pentru jocul cu numele '{numeCautat}':");
            foreach (Joc joc in rezultate)
            {
                Console.WriteLine($"ID: {joc.ID}, Nume: {joc.Nume}, Preț: {joc.Pret}");
            }
        }
        else
        {
            Console.WriteLine("Nu s-au găsit jocuri conform criteriilor de căutare.");
        }
    }

    public void AfiseazaJocuri()
    {
        Console.WriteLine("Lista jocurilor disponibile:");
        foreach (Joc joc in jocuri)
        {
            Console.WriteLine($"ID: {joc.ID}, Nume: {joc.Nume}, Preț: {joc.Pret}");
        }
    }
}

public class Joc
{
    public int ID { get; set; }
    public string Nume { get; set; }
    public double Pret { get; set; }

    public Joc(int id, string nume, double pret)
    {
        ID = id;
        Nume = nume;
        Pret = pret;
    }
}
