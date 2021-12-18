using System;
using System.IO;
using System.Collections.Generic;
namespace Tuan6
{
    class Baitap
    {
        private AdjacencyMatrix adjacencyMatrix;
        private GreedyFeed greedyFeed;
        public Baitap(string path)
        {
            string pathDir = System.IO.Directory.GetCurrentDirectory();
            path = pathDir + "/file_input/" + path;

            this.adjacencyMatrix = new AdjacencyMatrix();
            this.adjacencyMatrix.readInput(path);

            this.greedyFeed = new GreedyFeed(this.adjacencyMatrix);
        }

        public void inKQGreedyFeed()
        {
            int[] listColorVertex = this.greedyFeed.getAllVertexColor();
            Console.WriteLine(this.greedyFeed.getMaxColor());
            for (int i = 0; i < adjacencyMatrix.getVertexNumber(); i++)
            {
                Console.Write("{0}({1}) ", i, listColorVertex[i]);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Baitap baitap = new Baitap("input.txt");
                baitap.inKQGreedyFeed();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }

    }
}