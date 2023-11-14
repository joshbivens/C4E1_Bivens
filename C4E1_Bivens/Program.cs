using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    class Program
    {
        delegate void DispStrDelegate(string param);

        static void Capitalize(string text)
        {
            Console.WriteLine("Your input capatilized --> " + text.ToUpper());
        }

        static void LowerCased(string text)
        {
            Console.WriteLine("Your input lower cased --> " + text.ToLower());
        }

        static void RunMyDelegate(DispStrDelegate del, string textParam)
        {
            del(textParam);
        }

        static void Main(string[] args)
        {
            //Get a line of text to convert
            Console.WriteLine("Please enter some text: ");
            String text = Console.ReadLine();

            //Instantiate three delegate objects            
            DispStrDelegate saying1 = new DispStrDelegate(Capitalize);
            DispStrDelegate saying2 = new DispStrDelegate(LowerCased);
            DispStrDelegate saying3 = new DispStrDelegate(Console.WriteLine);

            //Call them one after the other
            saying1(text);
            saying2(text);
            saying3(text);

            //Get another text line
            Console.Write("Please enter some text: ");
            text = Console.ReadLine();

            //Make a new delegate object and concatenate delegates
            DispStrDelegate sayings = new DispStrDelegate(Capitalize);
            sayings += new DispStrDelegate(LowerCased);
            sayings += new DispStrDelegate(Console.WriteLine);

            //Call the one delegate and run all three methods
            Console.WriteLine("Running multi cast directly: ");
            sayings(text);

            //Pass delegate as a method argument
            Console.WriteLine("Running by passing delegate to another method: ");
            RunMyDelegate(sayings, text);

            Console.WriteLine("Running by passing in a lambda expression: ");
            RunMyDelegate((t) => { Console.WriteLine("Lambda: " + t); }, text);

            Console.WriteLine("Lambda without parenthesis: ");
            RunMyDelegate(t => { Console.WriteLine("Lambda2: " + t); }, text);

            sayings += t => { Console.WriteLine("Lambda3: " + t); };
            Console.WriteLine("Three Delegates and a lambda: ");
            RunMyDelegate(sayings, text);
        }
    }
}