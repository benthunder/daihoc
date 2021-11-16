using System;
using System.IO;
using System.Collections.Generic;

using Tuan4_Algo;
namespace Tuan4
{
    class BaiTap
    {
        private AdjacencyMatrix adjacencyMatrix;
        public Dijkstra di;
        public BaiTap(string path, int start = 0)
        {
            string pathDir = System.IO.Directory.GetCurrentDirectory();
            path = pathDir + "/file_input/" + path;

            adjacencyMatrix = new AdjacencyMatrix();
            adjacencyMatrix.readInput(path);
            di = new Dijkstra(adjacencyMatrix.getMatrix(), adjacencyMatrix.getVertexNumber(), start);
            di.runAlgo();
        }

        public void inKQDijsktra()
        {
            List<string> result = this.di.listPath;
            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                string start = Console.ReadLine();
                BaiTap baiTap = new BaiTap("input.txt", Int32.Parse(start));
                baiTap.inKQDijsktra();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }
    }
}