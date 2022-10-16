using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace джессикаабобусаванялошпед
{
    internal class Program
    {
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
                Menu(zametki);
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
                        DopInf();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
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
                if (WhichDay == 0 && WhereStrelka != 3)
                {
                    WhereStrelka++;
                    Console.SetCursorPosition(0, WhereStrelka);
                    Console.Write("->");
                }
                else if (WhichDay == -1 && WhereStrelka != 1)
                {
                    WhereStrelka++;
                    Console.SetCursorPosition(0, WhereStrelka);
                    Console.Write("->");
                }
                else if (WhichDay == 2 && WhereStrelka != 2)
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
        static void DopInf()
        {
            Console.Clear();
            if (WhichDay == 0)
            {
                if (WhereStrelka == 1)
                {
                    Console.WriteLine($"{FirstFirst.name}\n{FirstFirst.data}\n{FirstFirst.description}");
                }
                else if (WhereStrelka == 2)
                {
                    Console.WriteLine($"{SecondFirst.name}\n{SecondFirst.data}\n{SecondFirst.description}");
                }
                else if (WhereStrelka == 3)
                {
                    Console.WriteLine($"{ThirdFirst.name}\n{ThirdFirst.data}\n{ThirdFirst.description}");
                }
            }
            else if (WhichDay == -1)
            {
                if (WhereStrelka == 1)
                {
                    Console.WriteLine($"{FirstMinusSecond.name}\n{FirstMinusSecond.data}\n{FirstMinusSecond.description}");
                }
            }
            else if (WhichDay == 2)
            {
                if (WhereStrelka == 1)
                {
                    Console.WriteLine($"{FirstThird.name}\n{FirstThird.data}\n{FirstThird.description}");
                }
                else if (WhereStrelka == 2)
                {
                    Console.WriteLine($"{SecondThird.name}\n{SecondThird.data}\n{SecondThird.description}");
                }
            }
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
        static void Menu(List<Zametka> zametkas)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Выбрана дата {mydate}");
            int i = 0;
            foreach (Zametka note in zametkas)
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
