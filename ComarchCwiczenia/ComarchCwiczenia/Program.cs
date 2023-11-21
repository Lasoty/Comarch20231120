

namespace ComarchCwiczenia
{
    internal class Program
    {
        /// <summary>
        /// Metoda startowa aplikacji.
        /// </summary>
        /// <param name="args">Argumenty startowe aplikacji.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("KALKULATOR 1.0");
            Console.WriteLine("1. Przedstaw się");
            Console.WriteLine("2. Sortowanie");

            Console.Write("Twój wybór: ");

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                switch (value)
                {
                    case 1:
                        MeetMe();
                        break;
                    case 2:
                        Sort();
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór.");
                        break;
                }
            }
        }

        private static void Sort()
        {
            Console.WriteLine("Podaj elementy tablicy rozdzielone spacją:");
            string input = Console.ReadLine();
            string[] elementy = input.Split(' ');

            int[] tab = new int[10];
            for (int i = 0; i < tab.Length; i++)
            {
                if (!int.TryParse(elementy[i], out tab[i]))
                {
                    Console.WriteLine("Nieprawidłowy format liczb. Wprowadź tylko liczby całkowite.");
                    return;
                }
            }

            // Wyświetlenie nieposortowanej tablicy
            Console.WriteLine("\nNieposortowana tablica:");
            ShowTab(tab);

            // Sortowanie bąbelkowe
            BubbleSort(tab);

            // Wyświetlenie posortowanej tablicy
            Console.WriteLine("\nPosortowana tablica:");
            ShowTab(tab);
        }

        private static void ShowTab(int[] tab)
        {
            foreach (var item in tab)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        static void BubbleSort(int[] tab)
        {
            int n = tab.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                        // Zamiana miejscami gdy element jest większy od następnego
                        int temp = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = temp;
                    }
                }
            }
        }


        private static void MeetMe()
        {
            Console.Write("Podaj imię: ");
            string firstName = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");
            string lastName = Console.ReadLine();

            Console.Write("Ile masz lat: ");
            string sAge = Console.ReadLine();

            int age = 0;
            bool isAgeCorrect = int.TryParse(sAge, out age);

            //Console.WriteLine("Witaj " + firstName + " " + lastName + "! Miło Cię widzieć.");
            Console.WriteLine($"Witaj {firstName} {lastName}! Miło Cię widzieć. Masz {age} lat.");
        }
    }
}
