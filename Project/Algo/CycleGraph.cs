namespace Project_Algo
{
    class CycleGraph
    {
        public int k;
        public bool isCycleGraph(int[,] matrix, int vertexNumber, bool isUndirected)
        {
            if (isUndirected)
            {
                int[] vertexDegrees = this.getAllVertexDegrees(matrix, vertexNumber);
                if (matrix[0, vertexNumber - 1] == 0 && matrix[vertexNumber - 1, 0] == 0)
                {
                    return false;
                }

                for (int i = 0; i < vertexDegrees.Length; i++)
                {
                    if (vertexDegrees[i] != 2)
                    {
                        return false;
                    }
                }

                this.k = vertexNumber;
                return true;
            }
            else
            {
                int[,] vertexDegrees = this.getAllInOutVertexDegrees(matrix, vertexNumber);

                if (matrix[0, vertexNumber - 1] == 0 && matrix[vertexNumber - 1, 0] == 0)
                {
                    return false;
                }

                for (int i = 0; i < vertexDegrees.GetLength(0); i++)
                {
                    if (vertexDegrees[i, 0] + vertexDegrees[i, 1] != 2)
                    {
                        return false;
                    }
                }

                this.k = vertexNumber;
                return true;
            }
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


        // 0 : bac vao
        // 1 : bac ra
        public int[,] getAllInOutVertexDegrees(int[,] matrix, int vertexNumber)
        {
            int[,] vertexDegrees = new int[vertexNumber, 2];

            for (int i = 0; i < vertexNumber; i++)
            {
                for (int j = 0; j < vertexNumber; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        if (i == j)
                        {
                            vertexDegrees[i, 0] += matrix[i, j];
                            vertexDegrees[i, 1] += matrix[i, j];
                        }
                        else
                        {
                            vertexDegrees[j, 0] += matrix[i, j];
                            vertexDegrees[i, 1] += matrix[i, j];
                        }
                    }
                }
            }

            return vertexDegrees;
        }
    }
}