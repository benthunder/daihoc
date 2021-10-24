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


        public void inKQPrim(int startVertext = 0)
        {
            int[,] mst = this.adjacencyMatrix.findMSTByPrim(startVertext);
            int tong = 0;
            Console.WriteLine("Prim", tong);
            for (int i = 0; i < this.adjacencyMatrix.getVertexNumber() - 1; i++)
            {
                Console.WriteLine("{0}-{1}: {2}", mst[i, 0], mst[i, 1], mst[i, 2]);
                tong += mst[i, 2];
            }
            Console.WriteLine("Tong: {0}", tong);
        }

        public void inKQKruskal()
        {
            int[,] mst = this.adjacencyMatrix.findMSTByKruskal();
            int tong = 0;
            Console.WriteLine("Kruskal", tong);
            for (int i = 0; i < this.adjacencyMatrix.getVertexNumber() - 1; i++)
            {
                Console.WriteLine("{0}-{1}: {2}", mst[i, 0], mst[i, 1], mst[i, 2]);
                tong += mst[i, 2];
            }
            Console.WriteLine("Tong: {0}", tong);
        }

        static void Main(string[] args)
        {
            try
            {
                Baitap baitap = new Baitap("input.txt");
                Console.Write("Nhap bat dau: ");
                string batdau = Console.ReadLine();
                baitap.inKQPrim(Int32.Parse(batdau));

                baitap.inKQKruskal();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }

    }
}