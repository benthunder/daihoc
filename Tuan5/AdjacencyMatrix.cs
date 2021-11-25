using System;
using System.IO;


namespace Tuan5
{
    class AdjacencyMatrix
    {
        private int[,] matrix;
        private int vertexNumber;

        public void readInput(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new Exception("This file does not exist.");
            }

            string[] lines = File.ReadAllLines(filename);
            this.vertexNumber = Int32.Parse(lines[0]);
            this.matrix = new int[this.vertexNumber, this.vertexNumber];
            for (int i = 0; i < this.vertexNumber; ++i)
            {
                string[] tokens = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < this.vertexNumber; ++j)
                {
                    this.matrix[i, j] = Int32.Parse(tokens[j]);
                }
            }
        }

        public int getVertexNumber()
        {
            return this.vertexNumber;
        }

        public int[,] getMatrix()
        {
            return this.matrix;
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