using System;
using System.Collections.Generic;
using System.Text;

namespace Way
{
    public class Graph
    {
        private string[] my_cities = { "A", "B", "C", "D", "E" };
        private string[] all_cities = {"","","","",""};
        private string[] all_cities2 = { "", "", "", "", "", "", "", "", "", "","","" };
        private string[] check_cities = { "", "", "", "", "" };
        private int sum_road = 0;
        private int max_road = 0;
        private int min_road = 1000;
        private string a = "", b = "";
        public int GetSumRoad(List<Tuple<string, string, int>> tupleList)
        {
            int sum = 0;
            foreach (var road in tupleList)
                sum += road.Item3;          
            return sum;
        }
        public void SearchClosest(List<Tuple<string, string, int>> tupleList)
        {
            int min = 1000;
            foreach (var road in tupleList)
            {
                if (min > road.Item3)
                {
                    min = road.Item3;
                }
            }
            foreach (var road in tupleList)
            {
                if (min == road.Item3)
                {
                    Console.WriteLine("the closest cities:" + road.Item1 + " " + road.Item2);
                    break;
                }
            }
        }
        public int GetCities(List<Tuple<string, string, int>> tupleList)
        {
            var Cite = new HashSet<string>();
            foreach (var road in tupleList)
            {
                if (Cite.Add(road.Item1) == true)
                {
                    Console.WriteLine(road.Item1);
                }
                if (Cite.Add(road.Item2) == true)
                {
                    Console.WriteLine(road.Item2);
                }
            }
            return Cite.Count;
        }

        public int SearchFar1(List<Tuple<string, string, int>> tupleList, string city)
        {
            sum_road = 0;
            all_cities[0] = city;
            int p = -1;
            string far_city = city;
            for (int i = 0; i < 5; i++)
            {
                int k = 0;
                int max = 0;
                all_cities[i] = far_city;
                foreach (var road in tupleList)
                {
                    if (city == road.Item1)
                    {
                        p++;
                        for (int j = 0; j < 5; j++)
                        {
                            if (all_cities[j] != road.Item2 && all_cities2[j] != road.Item2)
                            {
                                k++;
                                if (k == 5)
                                {
                                    if (max < road.Item3)
                                    {
                                        max = road.Item3;
                                        far_city = road.Item2;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        all_cities2[p] = road.Item2;
                    }
                    k = 0;
                }
                city = far_city;
                sum_road += max;
            }
            for (int l = 0; l < 5; l++)
            {
                if (check_cities[l] == all_cities[4])
                {
                    sum_road = 0;
                }
            }
            return sum_road;
        }
        public void SearchFar(List<Tuple<string, string, int>> tupleList)
        {
            for (int l = 0; l < 5; l++) 
            {
                if (max_road < sum_road)
                {
                    max_road = sum_road;
                    a = all_cities[0];
                    b = all_cities[4];
                    check_cities[l] = a;
                }
                for (int i = 0; i < 5; all_cities[i++] = "") { }
                for (int i = 0; i < 12; all_cities2[i++] = "") { }
                SearchFar1(tupleList, my_cities[l]);
            }
            Console.WriteLine("самые далекие города (" + a + ", " + b + ") " + max_road);
        }

        public int SearchClose1(List<Tuple<string, string, int>> tupleList, string city, string str)
        {
            sum_road = 0;
            all_cities[0] = city;
            string far_city = city;
            for (int i = 0; i < 5; i++)
            {
                int k = 0;
                int min = 1000;
                all_cities[i] = far_city;
                foreach (var road in tupleList)
                {
                    if (city == road.Item1)
                    {
                        if (str == road.Item2)
                        {
                            if (city == road.Item1 && sum_road==0)
                            {
                                return sum_road = road.Item3;
                            }
                            if (min > road.Item3)
                            {
                                min = road.Item3;
                                far_city = road.Item2;
                                return sum_road += min;
                            }
                        }
                        else
                        {

                            for (int j = 0; j < 5; j++)
                            {
                                if (all_cities[j] != road.Item2)
                                {
                                    k++;
                                    if (k == 5)
                                    {
                                        if (min > road.Item3)
                                        {
                                            min = road.Item3;
                                            far_city = road.Item2;
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            k = 0;
                        }
                    }
                }
                city = far_city;
                if (min != 1000)
                {
                    sum_road += min;
                }
            }
            return sum_road;
        }
        public void SearchClose(List<Tuple<string, string, int>> tupleList, string str, string str1)
        {
            if (min_road > sum_road)
            {
                min_road = sum_road;
                a = all_cities[0];
                b = all_cities[4];
            }
            for (int i = 0; i < 5; all_cities[i++] = "") { }
            for (int i = 0; i < 12; all_cities2[i++] = "") { }
            SearchClose1(tupleList, str , str1);
            Console.WriteLine("путь между двумя городами (" + str + ", " + str1 + ") " + sum_road);
        }
    }
}
