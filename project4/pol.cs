using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Pol
    {
        public List<string> equations = new List<string>();
        //public List<string>numbers = new List<string>();
        public void addLine (string userInput)
            {
                equations.Add(userInput);
            }

        public void read()
        {
            foreach (string equation in equations)
            {
                putEq(equation);
            }

        }
        
        public void putEq(string equation)
        {
 
            var parts = equation.Split(' ').ToList();
            var last = parts[parts.Count - 1];
            parts.RemoveAt(parts.Count - 1);

            for (int i = 0; i < parts.Count; i++) 
                {

                  if (i == 0)
                    {
                        Console.Write($"{parts[i]}x^{parts.Count()}");
                    }
                    else if (parts[i].Contains('-'))
                    {
                        parts[i] = parts[i].Replace("-","");
                        Console.Write($" - {(parts[i])}x^{parts.Count() - i}");
                    }   
                    else
                    {
                        Console.Write($" + {parts[i]}x^{parts.Count() - i}");
                    }
                }
                
                Console.Write(" "+last);
                return;
        }


        public double GetIntegralTrapeze(double a, double b, int n)
        {
            double h = (b - a) / n;
            double integral = 0;
            integral = h / 2 * (Solve(a) + Solve(b));
                for (int i = 1; i < n; i++)
                {
                    integral += h * Solve(a + i * h);
                }
            return integral;
        }

        public double GetIntegralSimpson(double a, double b, int n)
        {
            double h = (b - a) / n;
            double integral = 0;
            
                integral = Solve(a) + Solve(b);
                for (int i = 1; i < n; i++)
                {
                    int coefficient = i % 2 == 0 ? 2 : 4;
                    integral += coefficient * Solve(a + i * h);
                }
                integral *= h / 3;
                return integral;
            
        }



        public double Solve(double x)
        {
             foreach (string equation in equations)
            {       
            var parts = equation.Split(' ').ToList();
            double answer = double.Parse(parts.Last());

            for (int i = 0; i < parts.Count() - 1; i++)
            {
                answer += double.Parse(parts[i]) * Math.Pow(x, parts.Count() - 1 - i);
            }

            return answer;
            }
            return 0;
        }
    }
}