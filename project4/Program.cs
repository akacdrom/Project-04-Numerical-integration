using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            double a,b;
            Pol pol = new Pol();
            
            Console.Clear();

            Console.WriteLine("Please write the coefficients of polynomial function:");

            
                Console.Write($"f(x): ");
                userInput = Console.ReadLine();
                pol.addLine(userInput);

            Console.Clear();
            Console.WriteLine("The function you've entered:");
            pol.read();
            Console.WriteLine("\nPlease write the boundaries of integration: ");
            Console.Write("a = "); a=double.Parse(Console.ReadLine());
            Console.Write("b = "); b=double.Parse(Console.ReadLine());
            Console.WriteLine("\nIntegration by trapezoidal method: " + pol.GetIntegralTrapeze(a, b, 100));
            Console.WriteLine("Integration by Simpson's method: " + pol.GetIntegralSimpson(a, b, 100));
            

            
            Console.ReadLine();
        }
    }
}