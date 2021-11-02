
using System;
using System.IO;
using System.Collections.Generic;


namespace Project_Algo
{
    class BarbellGraph
    {
        public int k;

        public int[,] matrix;
        public bool isBarbellGraph(int[,] matrix, int vertexNumber, bool isUndirected)
        {
            if (!isUndirected)
                return false;

            if (vertexNumber % 2 != 0)
                return false;

            this.matrix = matrix;
            int[] vertexDegrees = this.getAllVertexDegrees(matrix, vertexNumber);

            int leftCenterVertex = -1;
            for (int i = 0; i < vertexDegrees.Length; i++)
            {
                if (vertexDegrees[i] == vertexNumber / 2)
                {
                    leftCenterVertex = i;
                    break;
                }
            }
            if (leftCenterVertex == -1)
                return false;


            int rightCenterVertext = -1;
            for (int i = 0; i < vertexDegrees.Length; i++)
            {
                if (vertexDegrees[i] == vertexNumber / 2 && i != leftCenterVertex)
                {
                    rightCenterVertext = i;
                    break;
                }
            }

            if (rightCenterVertext == -1)
                return false;

            if (!this.vertextConnected(leftCenterVertex, rightCenterVertext))
                return false;

            List<int> listVertextLeft = new List<int>();
            List<int> listVertextRight = new List<int>();

            for (int i = 0; i < vertexDegrees.Length; i++)
            {
                if (i == leftCenterVertex || i == rightCenterVertext)
                    continue;

                if (this.vertextConnected(i, leftCenterVertex) && this.vertextConnected(i, rightCenterVertext))
                    return false;

                if (vertexDegrees[i] != (vertexNumber / 2) - 1)
                {
                    return false;
                }

                if (this.vertextConnected(i, leftCenterVertex))
                {
                    listVertextLeft.Add(i);
                }

                if (this.vertextConnected(i, rightCenterVertext))
                {
                    listVertextRight.Add(i);
                }
            }

            if (listVertextLeft.Count + 1 != (vertexNumber / 2) || listVertextRight.Count + 1 != (vertexNumber / 2))
                return false;

            this.k = vertexNumber / 2;
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