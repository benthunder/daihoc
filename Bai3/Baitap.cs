using System;
using System.IO;
using System.Collections.Generic;
namespace Bai3
{
    class Baitap
    {
        private AdjacencyMatrix adjacencyMatrix;
        public Baitap(string path)
        {
            string pathDir = System.IO.Directory.GetCurrentDirectory();
            path = pathDir + "/file_input/" + path;

            adjacencyMatrix = new AdjacencyMatrix();
            adjacencyMatrix.readInput(path);
        }


        public void inKQPrim()
        {
            List<int[]> mst = this.adjacencyMatrix.findMSTByPrim();
            foreach (int[] item in mst)
            {
                Console.WriteLine(item[1]);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Baitap baitap = new Baitap("input.txt");
                baitap.inKQPrim();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }

    }
}