

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
            bool closeApp = false;
            do
            {
                ShowMenu();

                Console.Write("Twój wybór: ");

                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    Calculator calculator = new Calculator();

                    int x = 0;
                    int y = 0;

                    switch (value)
                    {
                        case 1:
                            MeetMe();
                            break;
                        case 2:
                            Sort();
                            break;
                        case 3:
                            GetXY(out x, out y);
                            int addResult = calculator.Add(x, y);
                            Console.Write($"Wynik dodawania {x} i {y} to {addResult}");
                            break;
                        case 4:
                            GetXY(out x, out y);
                            int subResult = calculator.Subtract(x, y);
                            Console.Write($"Wynik odejmowania {x} i {y} to {subResult}");
                            break;
                        case 5:
                            GetXY(out x, out y);
                            int multiResult = calculator.Multiply(x, y);
                            Console.Write($"Wynik mnożenia {x} i {y} to {multiResult}");
                            break;
                        case 6:
                            GetXY(out x, out y);
                            try
                            {
                                float divResult = calculator.Divide(x, y);
                                Console.Write($"Wynik dzielenia {x} i {y} to {divResult}");
                            }
                            catch (Exception ex)
                            {
                                ShowError(ex.Message);
                                //throw;
                            }
                            break;
                        case 7:
                            GetXY(out x, out y);
                            try
                            {
                                int modResult = calculator.Modulo(x, y);
                                Console.Write($"Wynik reszty z dzielenia {x} i {y} to {modResult}");
                            }
                            catch (DivideByZeroException ex)
                            {
                                ShowError("Pamiętaj cholero! Nie dziel przez 0!.");                                
                            }
                            catch (Exception ex)
                            {
                                ShowError("Wystąpił nieprzewidziany wyjątek.");
                            }
                            break;
                        default:
                            Console.WriteLine("Nieprawidłowy wybór.");
                            break;
                    }
                }
                Console.ReadKey();

                Console.Clear();
                Console.Write("Czy chcesz zamknąć aplikację? [N | t]");
                closeApp = Console.ReadKey().Key == ConsoleKey.T;
            } while (!closeApp);
        }

        private static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private static void GetXY(out int x, out int y)
        {
            Console.Write("Podaj x: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Podaj y: ");
            y = int.Parse(Console.ReadLine());
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("KALKULATOR 1.0");
            Console.WriteLine("1. Przedstaw się");
            Console.WriteLine("2. Sortowanie");
            Console.WriteLine("3. Dodawanie");
            Console.WriteLine("4. Odejmowanie");
            Console.WriteLine("5. Mnożenie");
            Console.WriteLine("6. Dzielenie");
            Console.WriteLine("7. Reszta z dzielenia");
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
