using System;
using System.IO;
using System.Collections.Generic;
namespace Tuan5
{
    class Baitap
    {
        private AdjacencyMatrix adjacencyMatrix;
        private Euler euler;
        public Baitap(string path)
        {
            string pathDir = System.IO.Directory.GetCurrentDirectory();
            path = pathDir + "/file_input/" + path;

            this.adjacencyMatrix = new AdjacencyMatrix();
            this.adjacencyMatrix.readInput(path);

            this.euler = new Euler();
        }

        public void inKQEuler()
        {
            string eulerType = this.euler.getEulerType(this.adjacencyMatrix);
            Console.WriteLine(eulerType);
        }

        static void Main(string[] args)
        {
            try
            {
                Baitap baitap = new Baitap("input.txt");
                baitap.inKQEuler();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }

    }
}