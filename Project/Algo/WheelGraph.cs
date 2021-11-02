using System;
using System.IO;

namespace Project_Algo
{
    class WheelGraph
    {
        public int k;
        public bool isWheelGraph(int[,] matrix, int vertexNumber, bool isUndirected)
        {
            if (!isUndirected)
                return false;

            if (vertexNumber < 2)
                return false;

            if (this.getAllEdges(matrix, vertexNumber, isUndirected) != (vertexNumber - 1) * 2)
                return false;

            int[] vertexDegrees = this.getAllVertexDegrees(matrix, vertexNumber);

            int centerVertex = -1;
            for (int i = 0; i < vertexDegrees.Length; i++)
            {
                if (vertexDegrees[i] == vertexNumber - 1)
                {
                    centerVertex = i;
                    break;
                }
            }
            if (centerVertex == -1)
                return false;


            for (int i = 0; i < vertexDegrees.Length; i++)
            {
                if (i == centerVertex)
                    continue;

                if (vertexDegrees[i] != 3 || matrix[i, centerVertex] != 1 || matrix[centerVertex, i] != 1)
                {
                    return false;
                }
            }

            this.k = vertexNumber;
            return true;
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