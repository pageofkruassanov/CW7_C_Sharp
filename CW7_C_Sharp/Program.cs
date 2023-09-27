using CW6_C_Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW7_C_Sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix2D<double> firstMatrix = new Matrix2D<double>(5, 5);
            Matrix2D < double> secondMatrix = new Matrix2D<double> (5, 5);
            firstMatrix.SetRandomNumbers(10, 100);
            secondMatrix.SetRandomNumbers(10, 100);
            Matrix2D<double> result = new Matrix2D<double>(5, 5);
            result = firstMatrix + secondMatrix;
            Console.WriteLine(firstMatrix.ToString());
            Console.WriteLine(secondMatrix.ToString());
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }
}
