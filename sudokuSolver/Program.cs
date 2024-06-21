using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testSudoku
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int[,] s1 = {
            {1,5,3,9,4,8,6,7,2},
            {9,6,4,2,7,5,8,3,1},
            {7,8,2,6,3,1,5,4,9},
            {2,9,6,3,8,7,4,1,5},
            {5,1,8,4,9,2,7,6,3},
            {4,3,7,5,1,6,9,2,8},
            {6,4,9,8,2,3,1,5,7},
            {8,2,1,7,5,4,3,9,6},
            {3,7,5,1,6,9,2,8,4}};
            bool test = Sudoku.CheckAll(s1);
            Console.WriteLine($"Test: {test}");
        }
    }
}