using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;

namespace ДЗ_1
{

    class Program
    {
        static string list777 = "";

        static void Main(string[] args)
        {

            Console.WriteLine();
            #region пп. 1-3 Создать коллекции List, ArrayList и LinkedList.

            var stopWatch = new Stopwatch();
            TimeSpan ts = stopWatch.Elapsed;

            string TimeSpanList = string.Format("{0:00}", ts.Milliseconds);

            //List
            stopWatch.Start();
            var list = new List<int>();
            for (var i = 1; i <= 1000000; i++)
            {
                list.Add(i);
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            TimeSpanList = string.Format("{0:00}", ts.Milliseconds);
            Console.WriteLine($"Записано в list: {list.Count}. Время " + TimeSpanList + " (мс).");

            //ArrayList 
            var arraylist = new ArrayList();

            stopWatch.Start();
            for (int i = 1; i <= 1000000; i++)
            {
                arraylist.Add(i);
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            TimeSpanList = string.Format("{0:00}", ts.Milliseconds);
            Console.WriteLine($"Записано в arraylist: {arraylist.Count} . Время {TimeSpanList} (мс).");

            //LinkedList     
            var linkedlist = new LinkedList<int>();
            stopWatch.Start();
            for (int i = 1; i <= 1000000; i++)
            {
                if (i == 496753)
                {
                    linkedlist.AddLast(i + 1000000);//добавлено 300 для проверки поиска элемента по индексу 496753
                }
                else
                {
                    linkedlist.AddLast(i);
                }

            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            TimeSpanList = string.Format("{0:00}", ts.Milliseconds);
            Console.WriteLine($"Записано в linkedList: {linkedlist.Count} . Время {TimeSpanList} (мс).");
            Console.WriteLine();
            #endregion 


            #region пп. 4. Найти 496753
            int myInt = 496753;

            stopWatch.Start();

            //List
            int myIndex;

            myIndex = list.IndexOf(myInt);

            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            TimeSpanList = string.Format("{0:00}", ts.Milliseconds);

            Console.WriteLine($"Найден индекс {myIndex} в list. Время {TimeSpanList} (мс).");

            //ArrayList 
            stopWatch.Start();

            myIndex = arraylist.IndexOf(myInt);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            TimeSpanList = String.Format("{0:00}", ts.Milliseconds);
            Console.WriteLine($"Найден индекс {myIndex} в arrayList: {TimeSpanList} (мс).");

            //LinkedList    
            try
            {
                stopWatch.Start();
                //var myIntFind = linkedlist.Find(myInt);//ищет элемент а не индекс
                var j = 0; var i = 0;

                //497053
                var currentNode = linkedlist.First;
                do
                {
                    i++;
                    j = currentNode.Value;
                    currentNode = currentNode.Next;

                    if (i == myInt)
                    {
                        break;
                    }
                }
                while (currentNode != null);


                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                TimeSpanList = string.Format("{0:00}", ts.Milliseconds);
                Console.WriteLine($"Найден {myInt} в linkedList: {TimeSpanList} (мс).");
            }
            catch
            {
                Console.WriteLine($"Не найден индекс 496753 в linkedList: {TimeSpanList} (мс).");
            }

            #endregion

            #region пп. 5. Вывести на экран каждый элемент коллекции, который без остатка делится на 777
            stopWatch.Start();
            Console.WriteLine();
            Console.WriteLine("list деление на 777:");
            Console.WriteLine();


            int iN;

            foreach (var i in list)
            {
                iN = i;

                if (iN % 777 == 0)
                {
                    Division777(iN.ToString());

                }
            }

            Console.WriteLine(list777);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            TimeSpanList = string.Format("{0:00}", ts.Milliseconds);
            Console.WriteLine($"Время {TimeSpanList} (мс).");

            Console.WriteLine();

            stopWatch.Start();
            Console.WriteLine("arraylist деление на 777:");
            Console.WriteLine();
            list777 = "";

            foreach (var l in arraylist)
            {
                iN = int.Parse(l.ToString());

                if (iN % 777 == 0)
                {
                    Division777(l.ToString());
                }
            }

            Console.WriteLine(list777);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            TimeSpanList = string.Format("{0:00}", ts.Milliseconds);
            Console.WriteLine($"Время {TimeSpanList} (мс).");

            stopWatch.Start();
            Console.WriteLine();
            Console.WriteLine("linkedlist деление на 777:");
            Console.WriteLine();
            list777 = "";

            foreach (var l in linkedlist)
            {
                iN = l;

                if (iN % 777 == 0)
                {
                    Division777(l.ToString());
                }
            }

            Console.WriteLine(list777);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            TimeSpanList = string.Format("{0:00}", ts.Milliseconds);
            Console.WriteLine($"Время {TimeSpanList} (мс).");

            Console.WriteLine("Выполнение п.5 ~час");
            #endregion
        }

        static void Division777(string l)
        {
            if (list777 == "")
            {
                list777 = l;
            }
            else
            {
                list777 = list777 + ", " + l;
            }
        }



    }
}
