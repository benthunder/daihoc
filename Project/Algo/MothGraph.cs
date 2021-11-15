namespace Project_Algo
{
    class MothGraph
    {
        public bool isMothGraph(int[,] matrix, int vertexNumber, bool isUndirected)
        {
            if (!isUndirected)
                return false;

            if (vertexNumber != 6)
                return false;

            int headVertex = -1;
            int tailVertex = -1;
            int leftSwing = -1;
            int rightSwing = -1;
            int headLeftAnten = -1;
            int headRightAnten = -1;

            int[] vertexDegrees = this.getAllVertexDegrees(matrix, vertexNumber);
            for (int i = 0; i < vertexDegrees.Length; i++)
            {
                if (vertexDegrees[i] == 5)
                {
                    headVertex = i;
                }

                if (vertexDegrees[i] == 3)
                {
                    tailVertex = i;
                }

                if (vertexDegrees[i] == 2)
                {
                    if (leftSwing == -1 && rightSwing == -1)
                    {
                        leftSwing = i;
                    }
                    else if (leftSwing != -1 && i != leftSwing && rightSwing == -1)
                    {
                        rightSwing = i;
                    }
                }

                if (vertexDegrees[i] == 1)
                {
                    if (headLeftAnten == -1 && headRightAnten == -1)
                    {
                        headLeftAnten = i;
                    }
                    else if (headLeftAnten != -1 && i != headLeftAnten && headRightAnten == -1)
                    {
                        headRightAnten = i;
                    }
                }

            }

            if (headVertex == -1 || tailVertex == -1 || headLeftAnten == -1 || headRightAnten == -1 || rightSwing == -1 || leftSwing == -1)
            {
                return false;
            }

            if (matrix[headVertex, tailVertex] != 1)
            {
                return false;
            }

            if (matrix[rightSwing, tailVertex] != 1 || matrix[leftSwing, tailVertex] != 1)
            {
                return false;
            }

            if (matrix[rightSwing, headVertex] != 1 || matrix[leftSwing, headVertex] != 1)
            {
                return false;
            }

            if (matrix[headLeftAnten, headVertex] != 1 || matrix[headLeftAnten, headVertex] != 1)
            {
                return false;
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