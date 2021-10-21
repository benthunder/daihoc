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
            int[,] mst = new int[this.vertexNumber - 1, 3];
            int[,] markedEdge = new int[this.vertexNumber, this.vertexNumber];
            int[] markedVertext = new int[this.vertexNumber];
            int countMst = 0;
            int[,] matrix = this.getMatrix();
            for (int i = 0; i < this.vertexNumber; i++)
            {
                markedVertext[i] = 0;
                for (int j = 0; j < this.vertexNumber; j++)
                {
                    markedEdge[i, j] = 0;
                }
            }

            List<int> queueVertext = new List<int>();
            markedVertext[startVertext] = 1;
            queueVertext.Add(startVertext);
            int minWeight = -1;
            int[] minEdge = new int[2];
            while (countMst < this.vertexNumber - 1)
            {
                minWeight = -1;
                minEdge[0] = -1;
                minEdge[1] = -1;

                foreach (int v in queueVertext)
                {
                    for (int i = 0; i < this.vertexNumber; i++)
                    {
                        if (matrix[v, i] != 0 && matrix[i, v] != 0 && i != v && (minWeight == -1 || matrix[v, i] <= minWeight) && markedEdge[v, i] != 1 && markedEdge[i, v] != 1 && markedVertext[i] != 1)
                        {
                            minWeight = matrix[v, i];
                            minEdge[0] = v;
                            minEdge[1] = i;
                        }
                    }
                }
                // Them vao tap hop dinh
                if (minEdge[0] != -1 && minEdge[1] != -1)
                {
                    for (int i = 0; i < minEdge.Length; i++)
                    {
                        if (queueVertext.IndexOf(minEdge[i]) == -1)
                        {
                            queueVertext.Add(minEdge[i]);
                        }
                    }

                    // Them vao tap hop canh
                    markedVertext[minEdge[1]] = 1;
                    markedEdge[minEdge[0], minEdge[1]] = 1;
                    markedEdge[minEdge[1], minEdge[0]] = 1;

                    mst[countMst, 0] = minEdge[0];
                    mst[countMst, 1] = minEdge[1];
                    mst[countMst, 2] = matrix[minEdge[0], minEdge[1]];
                    countMst++;
                }

            }
            return mst;
        }
    }

}
