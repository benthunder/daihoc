namespace Project_Algo
{
    class ButterflyGraph
    {
        public bool isButterflyGraph(int[,] matrix, int vertexNumber, bool isUndirected)
        {
            if (!isUndirected)
                return false;

            if (vertexNumber != 5)
                return false;

            int centerVertex = -1;
            int[] vertexDegrees = this.getAllVertexDegrees(matrix, vertexNumber);
            for (int i = 0; i < vertexDegrees.Length; i++)
            {
                if (vertexDegrees[i] == 4)
                {
                    centerVertex = i;
                }
            }

            if (centerVertex == -1)
            {
                return false;
            }

            for (int i = 0; i < vertexDegrees.Length; i++)
            {
                if (i == centerVertex) continue;

                if (vertexDegrees[i] != 2 || matrix[i, centerVertex] != 1)
                {
                    return false;
                }
            }

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