using System;

public class Program
{
    static void Main(string[] args)
    {
        AdministrareJocuri administrareJocuri = new AdministrareJocuri();

        bool meniuActiv = true;

        while (meniuActiv)
        {
            Console.WriteLine("===== MENIU =====");
            Console.WriteLine("1. Adăugare joc");
            Console.WriteLine("2. Salvare jocuri în fișier");
            Console.WriteLine("3. Preluare jocuri din fișier");
            Console.WriteLine("4. Căutare joc");
            Console.WriteLine("5. Afișare jocuri");
            Console.WriteLine("6. Ieșire");

            Console.Write("Selectați o opțiune: ");
            string optiune = Console.ReadLine();

            Console.WriteLine();

            switch (optiune)
            {
                case "1":
                    administrareJocuri.AdaugareJoc();
                    break;
                case "2":
                    Console.Write("Introduceți numele fișierului: ");
                    string numeFisierSalvare = Console.ReadLine();
                    administrareJocuri.SalvareInFisier(numeFisierSalvare);
                    break;
                case "3":
                    Console.Write("Introduceți numele fișierului: ");
                    string numeFisierPreluare = Console.ReadLine();
                    administrareJocuri.PreluareDinFisier(numeFisierPreluare);
                    break;
                case "4":
                    administrareJocuri.CautareJoc();
                    break;
                case "5":
                    administrareJocuri.AfiseazaJocuri();
                    break;
                case "6":
                    meniuActiv = false;
                    break;
                default:
                    Console.WriteLine("Opțiunea introdusă nu este validă.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Program încheiat.");
    }
}
