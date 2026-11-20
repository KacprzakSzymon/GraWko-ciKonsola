using System;

namespace GraWKosci
{
    public class Kosc
    {
        // Pole statyczne zliczające instancje klasy
        public static int LiczbaInstancji = 0;

        // Generator liczb losowych (jeden wspólny dla całej klasy, aby zapobiec losowaniu tych samych wartości)
        private static readonly Random random = new Random();

        // Pola ogólnodostępne (publiczne)
        public string[] NazwyPlikow = new string[]
        {
            "kosc0.png",
            "kosc1.png",
            "kosc2.png",
            "kosc3.png",
            "kosc4.png",
            "kosc5.png",
            "kosc6.png"
        };

        public int LiczbaOczek;
        public int IdPlikuGraficznego;
        public bool CzyDostepna;

        // Konstruktor jednoargumentowy
        public Kosc(int wartosc)
        {
            // Walidacja zakresu (1-6)
            if (wartosc < 1 || wartosc > 6)
            {
                wartosc = 0;
            }

            this.LiczbaOczek = wartosc;
            this.IdPlikuGraficznego = wartosc;
            this.CzyDostepna = true;

            LiczbaInstancji++;
        }

        // Konstruktor bezargumentowy
        public Kosc()
        {
            int wylosowana = random.Next(1, 7);

            this.LiczbaOczek = wylosowana;
            this.IdPlikuGraficznego = wylosowana;
            this.CzyDostepna = true;

            LiczbaInstancji++;
        }


        public void Rzuc()
        {
            if (CzyDostepna)
            {
                int wylosowana = random.Next(1, 7);
                this.LiczbaOczek = wylosowana;
                this.IdPlikuGraficznego = wylosowana;
            }
        }


        public void Zablokuj()
        {
            this.CzyDostepna = false;
        }

        public string PobierzWartoscSlownie()
        {
            switch (LiczbaOczek)
            {
                case 1: return "jeden";
                case 2: return "dwa";
                case 3: return "trzy";
                case 4: return "cztery";
                case 5: return "pięć";
                case 6: return "sześć";
                default: return "zero";
            }
        }
    }

    // Przykładowy program konsolowy do przetestowania klasy
    class Program
    {
        static void Main(string[] args)
        {
            Kosc kosc1 = new Kosc();
            Kosc kosc2 = new Kosc();
            Kosc kosc3 = new Kosc();
            Kosc kosc4 = new Kosc();
            Kosc kosc5 = new Kosc();

            Console.WriteLine($"Kość 1: {kosc1.LiczbaOczek} ({kosc1.PobierzWartoscSlownie()}), Plik: {kosc1.NazwyPlikow[kosc1.IdPlikuGraficznego]}");
            Console.WriteLine($"Kość 2: {kosc2.LiczbaOczek} ({kosc2.PobierzWartoscSlownie()}), Plik: {kosc2.NazwyPlikow[kosc2.IdPlikuGraficznego]}");
            Console.WriteLine($"Kość 3: {kosc3.LiczbaOczek} ({kosc3.PobierzWartoscSlownie()}), Plik: {kosc3.NazwyPlikow[kosc3.IdPlikuGraficznego]}");
            Console.WriteLine($"Kość 4: {kosc4.LiczbaOczek} ({kosc4.PobierzWartoscSlownie()}), Plik: {kosc4.NazwyPlikow[kosc4.IdPlikuGraficznego]}");
            Console.WriteLine($"Kość 5: {kosc5.LiczbaOczek} ({kosc5.PobierzWartoscSlownie()}), Plik: {kosc5.NazwyPlikow[kosc5.IdPlikuGraficznego]}");

            Console.WriteLine($"\nŁącznie utworzonych instancji: {Kosc.LiczbaInstancji}");

            // Test blokady
            kosc1.Zablokuj();
            kosc1.Rzuc();
            Console.WriteLine($"\nKość 1 po zablokowaniu i rzucie: {kosc1.LiczbaOczek}");
        }
    }
}

