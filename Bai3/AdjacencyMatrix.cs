using System;
using System.IO;
using System.Collections.Generic;

namespace Bai3
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

        public int[,] findMSTByPrim(int startVertext = 0)
        {
            int[,] mst = new int[this.vertexNumber - 1, 2];
            int[,] markedEdge = new int[this.vertexNumber, this.vertexNumber];
            int[] markedVertext = new int[this.vertexNumber];
            int countMst = 0;
            int[,] matrix = this.getMatrix();
            for (int i = 0; i < this.vertexNumber; i++)
            {
                this.markedVertext[i] = 0;
                for (int j = 0; j < length; j++)
                {
                    this.markedEdge[i, j] = 0;
                }
            }

            List<int> queueVertext = new List<int>();
            markedVertext[startVertext] = 1;
            queueVertext.Add(startVertext);
            int minWeight = -1, minVertext = -1;
            while (countMst < this.vertexNumber - 1)
            {
                minWeight = -1;
                minVertext = -1;
                for (int v = 0; v < this.vertexNumber; v++)
                {
                    for (int i = 0; i < this.vertexNumber - 1; i++)
                    {
                        if (matrix[v, i] > 0 && markedEdge[i, v] != 0 && matrix[v, i] <= minWeight)
                        {
                            minWeight = matrix[v, i];
                            minVertext = i;
                        }
                    }
                }
            }
            return mst;
        }

        private int getEdgeWithMinWeight(int vertext, int[] markedVertext)
        {
            int minVertext = -1;
            int minWeight = -1;
            for (int i = 0; i < this.vertexNumber - 1; i++)
            {
                if ((minWeight == -1 || this.matrix[vertext, i] <= minWeight) && this.matrix[vertext, i] > 0 && vertext != i && markedVertext[i] != 1)
                {
                    minVertext = i;
                    minWeight = this.matrix[vertext, i];
                }
            }

            return minVertext;
        }

    }

}
