
using System;
using System.IO;
using System.Collections.Generic;

namespace Project_Algo
{
    class PartiteGraph
    {
        public int k;

        public int[,] matrix;
        
        public bool isPartiteGraph(int[,] matrix, int vertexNumber, bool isUndirected)
        {
            if (!isUndirected)
                return false;

            this.matrix = matrix;
            int[] vertexDegrees = this.getAllVertexDegrees(matrix, vertexNumber);

            
            return true;
        }

        private bool vertextConnected(int v1, int v2)
        {
            return (this.matrix[v1, v2] == 1 && this.matrix[v2, v1] == 1);
        }

        public int[] getAllVertexDegrees(int[,] matrix, int vertexNumber)
        {
            int[] vertexDegrees = new int[vertexNumber];
            for (int i = 0; i < vertexNumber; i++)
            {
                int degree = 0;
                for (int j = 0; j < vertexNumber; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        degree += matrix[i, j];

                        if (i == j)
                        {
                            degree++;
                        }
                    }
                    vertexDegrees[i] = degree;
                }
            }

            return vertexDegrees;
        }

        private int getAllEdges(int[,] matrix, int vertexNumber, bool isUndirected)
        {
            int edgeNumber = 0;
            for (int i = 0; i < vertexNumber; i++)
            {
                for (int j = 0; j < vertexNumber; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        edgeNumber++;
                    }
                }
            }

            if (isUndirected)
            {
                edgeNumber = edgeNumber / 2;
            }
            return edgeNumber;
        }

    }
}