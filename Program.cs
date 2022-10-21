using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace джессикаабобусаванялошпед
{
    internal class Program
    {
        public static int NewZametki = 0;
        public static int BorderAll = 0;
        public static int BorderFirst = 3;
        public static int BorderThird = 2;
        public static int BorderMinusSecond = 1;
        public static List<Zametka> zametki = new List<Zametka>();
        public static DateTime mydate = new DateTime(2022, 10, 7);
        public static int WhichDay = 0;
        public static int WhereStrelka = 0;
        // Логика в названиях заметок следующая: Первое слово - Порядковый номер заметки в этом дне, второе слово - день относительного начального.
        public static Zametka FirstFirst = new Zametka()
        {
            name = "Поугарать на парах Дзюбы",
            data = new DateTime(2022, 10, 7),
            description = "Приехать на пары, дождаться КС, угарать."
        };
        public static Zametka SecondFirst = new Zametka()
        {
            name = "Сделать практическую номер 4",
            data = new DateTime(2022, 10, 7),
            description = "Открыть классрум, ужаснуться, поплакать, собраться с мыслями, написать код."
        };
        public static Zametka ThirdFirst = new Zametka()
        {
            name = "Ограбить мираторг",
            data = new DateTime(2022, 10, 7),
            description = "Позвонить Дзюбе, найти маски, взять автомат у Ключника, забрать все чокопаи из мираторга."
        };
        public static Zametka FirstThird = new Zametka()
        {
            name = "Приготовить покушать",
            data = new DateTime(2022, 10, 9),
            description = "Проголодаться, открыть холодильник, всплакнуть, пожарить украденные чокопаи."
        };
        public static Zametka SecondThird = new Zametka()
        {
            name = "Покушать",
            data = new DateTime(2022, 10, 9),
            description = "Накрыть на стол, достать пожаренные чокопаи, позвать дядю Толю, выпить за здоровье родителей, покушать."
        };
        public static Zametka FirstMinusSecond = new Zametka()
        {
            name = "Выучить законы по Дискретной Математике(Срок пропущен)",
            data = new DateTime(2022, 10, 6),
            description = "Открыть тетрадь, осознать безысходность, попытаться выучить, ответить на паре."
        };
        static void Main()
        {
            Start();
        }
        static void Start()
        {
            zametki.Add(FirstFirst);
            zametki.Add(SecondFirst);
            zametki.Add(ThirdFirst);
            zametki.Add(FirstThird);
            zametki.Add(SecondThird);
            zametki.Add(FirstMinusSecond);
            while (true)
            {
                Menu();
                ConsoleKeyInfo Choice = Console.ReadKey();
                switch (Choice.Key)
                {
                    case ConsoleKey.RightArrow:
                        IzmData("Вправо");
                        break;
                    case ConsoleKey.LeftArrow:
                        IzmData("Влево");
                        break;
                    case ConsoleKey.DownArrow:
                        Strelochki("Вниз");
                        break;
                    case ConsoleKey.UpArrow:
                        Strelochki("Вверх");
                        break;
                    case ConsoleKey.Enter:
                        List<Zametka> sortedZametki = zametki.Where(note => note.data == mydate).ToList();
                        DopInf(sortedZametki[WhereStrelka-1]);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.Spacebar:
                        NewZametka();
                        break;
                }
            }
        }
        static void Strelochki(string WhichSide)
        {
            Console.Clear();
            if (WhichSide == "Вверх")
            {
                if (WhereStrelka != 0)
                {
                    WhereStrelka--;
                }
                if (WhereStrelka != 0)
                {
                    Console.SetCursorPosition(0, WhereStrelka);
                    Console.Write("->");
                }
            }
            if (WhichSide == "Вниз")
            {
                if (WhichDay == 0 && WhereStrelka != BorderFirst)
                {
                    WhereStrelka++;
                    Console.SetCursorPosition(0, WhereStrelka);
                    Console.Write("->");
                }
                else if (WhichDay == -1 && WhereStrelka != BorderMinusSecond)
                {
                    WhereStrelka++;
                    Console.SetCursorPosition(0, WhereStrelka);
                    Console.Write("->");
                }
                else if (WhichDay == 2 && WhereStrelka != BorderThird)
                {
                    WhereStrelka++;
                    Console.SetCursorPosition(0, WhereStrelka);
                    Console.Write("->");
                }
                else if (WhichDay != 2 && WhichDay != -1 && WhichDay != 0 && BorderAll!= 0)
                {
                    WhereStrelka++;
                    Console.SetCursorPosition(0, WhereStrelka);
                    Console.Write("->");
                }
                else
                {
                    Console.SetCursorPosition(0, WhereStrelka);
                    Console.Write("->");
                }
            }
        }
        static void IzmData(string WhichStrelochka)
        {
            Console.Clear();
            if (WhichStrelochka == "Влево")
            {
                mydate = mydate.AddDays(-1);
                WhichDay--;
                WhereStrelka = 0;
            }
            else if (WhichStrelochka == "Вправо")
            {
                mydate = mydate.AddDays(1);
                WhichDay++;
                WhereStrelka = 0;
            }
        }
        static void NewZametka()
        {
            Console.Clear();
            Console.WriteLine("Введите сначала название заметки, затем описание заметки, после дату в формате ГГГГ, ММ, ДД");
            zametki.Add(new Zametka()
            {
                name = Console.ReadLine(),
                description = Console.ReadLine(),
                data = Convert.ToDateTime(Console.ReadLine())
            });
            Console.Clear();
            BorderFirst = 1000;
            BorderMinusSecond = 1000;
            BorderThird = 1000;
            BorderAll = 1000;

        }
        static void DopInf(Zametka SelectedZametka)
        {
            Console.Clear();
            Console.WriteLine($"{SelectedZametka.name}\n{SelectedZametka.data}\n{SelectedZametka.description}");
            ConsoleKeyInfo i;
            if (WhereStrelka != 0)
            {
                do
                {
                    i = Console.ReadKey();
                } while (i.Key != ConsoleKey.Enter);
            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            WhereStrelka = 0;
        }
        static void Menu()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Выбрана дата {mydate}");
            int i = 0;
            foreach (Zametka note in zametki)
            {
                if (note.data == mydate)
                {
                    i++;
                    Console.SetCursorPosition(2, i);
                    Console.Write($"{i}.{note.name}");
                }
            }
        }
    }
}
