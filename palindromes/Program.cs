using System;

namespace palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int c =Int32.Parse(Console.ReadLine());
            Console.WriteLine(c.Palidrom());
            Console.WriteLine();
        }
    }
    public static class PalidromeSearch
    {
        public static bool Palidrom(this int number)
        {
            bool ok = true;
            int temp = number; 
            int b = 0; 

            while (temp != 0)
            {
                b = b * 10 + temp % 10;
                temp /= 10;
            }

            if (number == b)
                ok = true;
            else
                ok = false;
            return ok;
        }
    }
}
