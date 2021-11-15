using System;
using System.IO;
using System.Collections.Generic;

using Tuan4_Algo;
namespace Tuan4
{
    class BaiTap
    {
        private AdjacencyMatrix adjacencyMatrix;

        public BaiTap(string path, int start = 5)
        {
            string pathDir = System.IO.Directory.GetCurrentDirectory();
            path = pathDir + "/file_input/" + path;

            adjacencyMatrix = new AdjacencyMatrix();
            adjacencyMatrix.readInput(path);
            Dijkstra di = new Dijkstra(adjacencyMatrix.getMatrix(), adjacencyMatrix.getVertexNumber(), start);
            di.runAlgo();
        }
        static void Main(string[] args)
        {
            try
            {
                BaiTap baiTap = new BaiTap("input.txt");
                string start = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }
    }
}