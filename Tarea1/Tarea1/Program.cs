using System;
using System.Collections.Generic;

namespace Tarea1
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Bye();
        }

        private static void Bye()
        {
            var azar = new Random();
            int number = 0;
            while(number != 5)
            {
                number = azar.Next(0, 6);
                Console.WriteLine(number);
            }
            
            
        }
    }
}
