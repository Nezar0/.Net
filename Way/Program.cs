using System;
using System.Collections.Generic;

namespace Way
{
    class Program
    {
        static void Main(string[] args)
        {

            var tupleList = new List<Tuple<string, string, int>>
            {
                new Tuple<string,string, int>( "A","B",5 ),
                new Tuple<string,string, int>( "B","E",9 ),
                new Tuple<string,string, int>( "E","C",8 ),
                new Tuple<string,string, int>( "C","D",7 ),
                new Tuple<string,string, int>( "E","D",6 ),
                new Tuple<string,string, int>( "A","D",9 ),

                new Tuple<string,string, int>( "B","A",5 ),
                new Tuple<string,string, int>( "E","B",9 ),
                new Tuple<string,string, int>( "C","E",8 ),
                new Tuple<string,string, int>( "D","C",7 ),
                new Tuple<string,string, int>( "D","E",6 ),
                new Tuple<string,string, int>( "D","A",9 )
            };
            Graph graph = new Graph();
            Console.WriteLine(graph.GetSumRoad(tupleList));
            //ListAllCities cities = new ListAllCities();
            Console.WriteLine(graph.GetCities(tupleList));
            //FindTheClosestCities find = new FindTheClosestCities();
            graph.SearchClosest(tupleList);
            graph.SearchFar(tupleList);
            Console.WriteLine("Найти кротчайший путь между двумя городами");
           graph.SearchClose(tupleList,Console.ReadLine(), Console.ReadLine());
        }
    }
}
