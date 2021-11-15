using System;
using System.IO;


namespace Tuan4
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

        public void printMatrix()
        {
            Console.WriteLine(this.vertexNumber);
            for (int i = 0; i < this.vertexNumber; i++)
            {
                for (int j = 0; j < this.vertexNumber; j++)
                {
                    Console.Write(this.matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}