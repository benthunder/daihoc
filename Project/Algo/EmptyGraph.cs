namespace Project_Algo
{
    class EmptyGraph
    {

        public int k;
        public bool isEmptyGraph(int[,] matrix, int vertexNumber)
        {
            for (int i = 0; i < vertexNumber; i++)
            {
                for (int j = 0; j < vertexNumber; j++)
                {
                    if (i != j && matrix[i, j] == 1) return false;
                }
            }

            this.k = vertexNumber;
            return true;
        }
    }
}