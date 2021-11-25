// C# program for Bellman-Ford's single source
// shortest path algorithm.
using System;


namespace Tuan4_Algo
{
    class BellmanFord
    {

        // The main function that finds shortest
        // distances from src to all other vertices
        // using Bellman-Ford algorithm. The function
        // also detects negative weight cycle
        // The row graph[i] represents i-th edge with
        // three values u, v and w.
        static void BellmanFord(int[,] graph, int V,
                                int E, int src)
        {
            this.matrix = matrix;
            this.vertextNumber = vertexNumber;
            this.start = start;

            this.initValue();
        }

        private void initValue()
        {
            this.VWeight = new int[this.vertextNumber];
            this.VParent = new int[this.vertextNumber];
            this.VChecked = new bool[this.vertextNumber];

            for (int i = 0; i < this.vertextNumber; i++)
            {
                this.VWeight[i] = int.MaxValue;
                this.VParent[i] = -1;
                this.VChecked[i] = false;
            }
        }

        // Driver code
        public static void Main(String[] args)
        {
            int V = 5; // Number of vertices in graph
            int E = 8; // Number of edges in graph

            // Every edge has three values (u, v, w) where
            // the edge is from vertex u to v. And weight
            // of the edge is w.
            int[,] graph = {{ 0, 1, -1 }, { 0, 2, 4 },
                    { 1, 2, 3 }, { 1, 3, 2 },
                    { 1, 4, 2 }, { 3, 2, 5 },
                    { 3, 1, 1 }, { 4, 3, -3 }};

            BellmanFord(graph, V, E, 0);
        }
    }


}
// This code is contributed by Princi Singh