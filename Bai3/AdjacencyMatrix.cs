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

        public List<int[]> findMSTByPrim(int startVertext = 0)
        {
            List<int[]> mst = new List<int[]>();
            int[] markedVertext = new int[this.vertexNumber];

            for (int i = 0; i < this.vertexNumber; i++)
            {
                markedVertext[i] = 0;
            }
            int nextVertext = this.getEdgeWithMinWeight(startVertext, markedVertext);
            int[] tmpEdge = new int[2];

            tmpEdge[0] = startVertext;
            tmpEdge[1] = nextVertext;
            markedVertext[startVertext] = 1;
            markedVertext[nextVertext] = 1;
            mst.Add(tmpEdge);
            Console.WriteLine("{0} {1}", tmpEdge[0], tmpEdge[1]);

            nextVertext = this.getEdgeWithMinWeight(0, markedVertext);
            tmpEdge[0] = startVertext;
            tmpEdge[1] = nextVertext;
            markedVertext[startVertext] = 1;
            markedVertext[nextVertext] = 1;
            mst.Add(tmpEdge);

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
