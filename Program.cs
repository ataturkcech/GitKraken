namespace test1703
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Celkem zastavek");
            int pocetZastavek = int.Parse(Console.ReadLine());
            Console.WriteLine("Spoj je mezi: (např. 1 2,2 3)");
            string spojeni = Console.ReadLine();
            string[] pary = spojeni.Split(',');
            Console.WriteLine("Start");
            string start = Console.ReadLine();
            Console.WriteLine("Cil");
            string cil = Console.ReadLine();

            Dictionary<string, List<string>> graf = new Dictionary<string, List<string>>();
            foreach (var par in pary)
            {
                string[] zastavky = par.Trim().Split(' ');
                if (zastavky.Length == 2)
                {
                    string z1 = zastavky[0].Trim();
                    string z2 = zastavky[1].Trim();
                    if (!graf.ContainsKey(z1)) graf[z1] = new List<string>();
                    if (!graf.ContainsKey(z2)) graf[z2] = new List<string>();
                    graf[z1].Add(z2);
                    graf[z2].Add(z1);
                }
            }

            HashSet<string> navstivene = new HashSet<string>();
            Queue<string> fronta = new Queue<string>();
            fronta.Enqueue(start);
            bool nalezeno = false;
            foreach (string z in graf.Keys)
                            {
                if (z == cil)
                {
                    nalezeno = true;
                    break;
                }
            }
            if (nalezeno)
            {
                Console.WriteLine("Cesta:");
                while (fronta.Count > 0)
                {
                    string aktualni = fronta.Dequeue();
                    {
                        navstivene.Add(aktualni);
                        Console.WriteLine(aktualni);
                        foreach (string soused in graf[aktualni])
                        {
                            if (!navstivene.Contains(soused))
                            {
                                fronta.Enqueue(soused);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Nejde");
            }
        }
    }
}
