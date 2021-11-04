
using System;
using System.IO;
using System.Collections.Generic;

namespace Project_Algo
{
    class PartiteGraph
    {
        public List<dynamic> k;

        public int[,] matrix;

        public List<string> listK = new List<string>();

        public PartiteGraph()
        {
            this.k = new List<dynamic>();
        }
        public bool isPartiteGraph(int[,] matrix, int vertexNumber, bool isUndirected)
        {
            if (!isUndirected)
                return false;

            EmptyGraph emptyGraph = new EmptyGraph();
            if (emptyGraph.isEmptyGraph(matrix, vertexNumber))
            {
                return false;
            }

            this.matrix = matrix;
            int[] checkedVertices = new int[vertexNumber];

            for (int i = 0; i < vertexNumber; i++)
            {
                checkedVertices[i] = 0;
            }

            List<int> queueTraversal = new List<int>();

            for (int i = 0; i < vertexNumber; i++)
            {
                if (checkedVertices[i] == 1)
                {
                    continue;
                }
                checkedVertices[i] = 1;
                queueTraversal.Clear();
                queueTraversal.Add(i);
                for (int j = 0; j < vertexNumber; j++)
                {
                    if (!this.vertextConnected(i, j) && i != j && checkedVertices[j] == 0)
                    {
                        if (!this.inJoinSet(queueTraversal, j, matrix))
                        {
                            queueTraversal.Add(j);
                            checkedVertices[j] = 1;
                        }
                    }
                }
                listK.Add("{" + string.Join(",", queueTraversal) + "}");
            }

            if (listK.Count <= 1)
                return false;

            return true;
        }

        private bool inJoinSet(List<int> queue, int vertext, int[,] matrix)
        {
            foreach (int v in queue)
            {
                if (matrix[v, vertext] == 1)
                {
                    return true;
                }
            }
            return false;
        }

        private bool vertextConnected(int v1, int v2)
        {
            return (this.matrix[v1, v2] == 1 && this.matrix[v2, v1] == 1);
        }

    }
}