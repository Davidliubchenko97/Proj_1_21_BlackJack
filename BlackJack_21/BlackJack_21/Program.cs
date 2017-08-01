using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_21
{

    struct hand
    {
        public int Cash;
        public int HandPoint;
    }
    struct Cards
    {
        public string Suit;
        public string Rank;
        public int Point;
    }
    class StartGame
    {

        public void Start(Cards[] Card)
        {
            Tass tasyem = new Tass();
            hand yourhand = new hand();
            hand dillerhand = new hand();
            yourhand.Cash = 1000;
            dillerhand.Cash = yourhand.Cash * 100;
            startnewgame:
            yourhand.HandPoint = 0;
            dillerhand.HandPoint = 0;
            tasyem.Tas1(Card);
            int GameCash = 0;
            while (true)
            {
                Console.WriteLine($"На вашем счету {yourhand.Cash}$. Сколько вы поставите? Введите сумму:");
                GameCash = int.Parse(Console.ReadLine());
                if (GameCash <= yourhand.Cash)
                {
                    break;
                }
            }
            int i = 0;
            Console.WriteLine($"Карта диллера: { Card[i].Suit} { Card[i].Rank}");
            dillerhand.HandPoint += Card[i].Point;
            Console.WriteLine($"У него  { dillerhand.HandPoint} очков");
            i++;
            Console.WriteLine("у диллера есть 2скрытая карта");
            dillerhand.HandPoint += Card[i].Point;
            i++;
            for (int p = 0; p < 2; p++)
            {
                Console.WriteLine($"Ваша карта: { Card[i].Suit} { Card[i].Rank}");
                yourhand.HandPoint += Card[i].Point;
                Console.WriteLine($"У вас { yourhand.HandPoint} очков");
                i++;
            }
            if(Card[i-2].Suit==Card[i-1].Suit)
            {
                Console.WriteLine("Сплитуете?(Y/N)");
                char areuwontsplit = char.Parse(Console.ReadLine());
                if (areuwontsplit == 'Y')
                {
                    yourhand.HandPoint = Card[i - 2].Point;
                    hand yourhand2 = new hand();
                    yourhand2.HandPoint = Card[i - 1].Point;
                    Console.WriteLine($"Ваша карта: { Card[i].Suit} { Card[i].Rank}");
                    yourhand.HandPoint += Card[i].Point;
                    Console.WriteLine($"У вас на 1 руке { yourhand.HandPoint} очков");
                    Console.WriteLine($"Ваша карта: { Card[i].Suit} { Card[i].Rank}");
                    yourhand.HandPoint += Card[i].Point;
                    Console.WriteLine($"У вас на 2 руке { yourhand.HandPoint} очков");
                }
                
                    
            }
                

            for (int j = 0; j < 333; j++)
            {
                Console.WriteLine("Вы хотите взять еще карту?(Y/N)");
                char question = char.Parse(Console.ReadLine());
                if (question == 'Y')
                {
                    Console.WriteLine($"Ваша карта: { Card[i].Suit} { Card[i].Rank}");
                    yourhand.HandPoint += Card[i].Point;
                    Console.WriteLine($"У вас { yourhand.HandPoint} очков");
                    i++;
                }
                else if (question == 'N')
                {
                    break;
                }
                if (yourhand.HandPoint > 21)
                {
                    yourhand.Cash -= GameCash;
                    dillerhand.Cash += GameCash;

                    goto startnewgame;
                }
            }
            if (yourhand.HandPoint > 21)
            {
                yourhand.Cash -= GameCash;
                dillerhand.Cash += GameCash;

                goto startnewgame;
            }
            for (int u = 0; u < 10; i++)
            {
                if (dillerhand.HandPoint >= 18 || dillerhand.HandPoint > yourhand.HandPoint)
                    break;
                if (dillerhand.HandPoint < yourhand.HandPoint - 1)
                {
                    Console.WriteLine($"Карта диллера: { Card[i].Suit} { Card[i].Rank}");
                    dillerhand.HandPoint += Card[i].Point;
                    Console.WriteLine($"У него  { dillerhand.HandPoint} очков");
                    i++;
                }
                if (dillerhand.HandPoint > 21)
                {
                    yourhand.Cash = yourhand.Cash + GameCash;
                    dillerhand.Cash -= GameCash;
                    goto startnewgame;
                }
            }
            if (yourhand.HandPoint > dillerhand.HandPoint)
            {
                yourhand.Cash += GameCash;
                dillerhand.Cash -= GameCash;
                goto startnewgame;
            }
            else if (yourhand.HandPoint == dillerhand.HandPoint)
            {
                Console.WriteLine("Ничья!");
                goto startnewgame;
            }
            else
            {
                yourhand.Cash -= GameCash;
                dillerhand.Cash += GameCash;
                goto startnewgame;
            }
        }
    }
    class Tass
    {
        public void Tas1(Cards[] Card)
        {
            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int j1 = rnd.Next(0, 52);
                int j2 = rnd.Next(0, 52);

                var Superfluous_card = Card[j1];
                Card[j1] = Card[j2];
                Card[j2] = Superfluous_card;
            }
        }
    }
    class Program
    {
        static void Main()
        {

            string[] suits = { "Diamonds", "Hearts", "Spades", "Clubs" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            int[] points = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

            Cards[] Card = new Cards[52];
            StartGame start = new StartGame();


            //Создали 52 карты и присвоили соответствующие х-ки
            int k = 0;
            for (int i = 0; i < suits.Length; i++)
            {

                for (int j = 0; j < ranks.Length; j++)
                {
                    Card[k].Suit = suits[i];
                    Card[k].Rank = ranks[j];
                    Card[k].Point = points[j];
                    k++;
                }
            }


            Console.WriteLine("BlackJack");
            Console.WriteLine("Ссыграем? (Y/N)");

            char inputStart = char.Parse(Console.ReadLine());
            if (inputStart == 'Y')
            {

                start.Start(Card);
            }
            else
            {
                Console.WriteLine("Good Luck!");
                return;
            }
        }
    }

}
