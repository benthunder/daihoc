using System;
using System.IO;

namespace Project_Algo
{
    class StartGraph
    {
        public int k;
        public bool isStartGraph(int[,] matrix, int vertexNumber, bool isUndirected)
        {
            if (!isUndirected)
                return false;


            int[] vertexDegrees = this.getAllVertexDegrees(matrix, vertexNumber);
            if (vertexNumber == 1 && vertexDegrees[0] == 1){
                return false;
            }

            if (vertexNumber == 2 && vertexDegrees[0] == 1 && vertexDegrees[1] == 1 && matrix[0, 1] == 1 && matrix[1, 0] == 1){
                this.k = 2;
                return true;
            }

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

                if (vertexDegrees[i] != 1 || matrix[i, centerVertex] != 1 || matrix[centerVertex, i] != 1)
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
    }
}