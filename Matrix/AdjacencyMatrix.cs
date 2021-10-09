using System;
using System.IO;

namespace Matrix
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

        public bool isUndirectedGraph()
        {
            for (int i = 0; i < this.vertexNumber; i++)
            {
                for (int j = 0; j < this.vertexNumber; j++)
                {
                    if (this.matrix[i, j] != this.matrix[j, i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // canh boi
        public int multipleEdge()
        {
            int multipleEdgeSum = 0;
            if(this.isUndirectedGraph()) {
                for (int i = 0; i < this.vertexNumber; i++)
                {
                    for (int j = i+1; j < this.vertexNumber; j++)
                    {
                        multipleEdgeSum += this.matrix[i, j] > 1? 1 : 0;
                    }
                }
            } else {
                for (int i = 0; i < this.vertexNumber; i++)
                {
                    for (int j = i+1; j < this.vertexNumber; j++)
                    {
                        multipleEdgeSum += this.matrix[i, j] > 1 || this.matrix[j, i] > 1 ? 1 : 0;
                    }
                }
            }
            
            return multipleEdgeSum;
        }

        public bool isGraphHasNoLoops()
        {
            for (int i = 0; i < this.vertexNumber; i++)
            {
                if (this.matrix[i, i] == 1)
                    return false;
            }

            return true;
        }

        public int[] getAllVertexDegrees()
        {
            int[] vertexDegrees = new int[this.vertexNumber];
            for (int i = 0; i < this.vertexNumber; i++)
            {
                int degree = 0;
                for (int j = 0; j < this.vertexNumber; j++)
                {
                    if (this.matrix[i, j] != 0)
                    {
                        degree += this.matrix[i, j];

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
        public int[,] getAllInOutVertexDegrees()
        {
            int[,] vertexDegrees = new int[this.vertexNumber, 2];
            if (this.isUndirectedGraph())
            {
                throw new Exception("Do thi nay khong co bac ra vao");
            }

            for (int i = 0; i < this.vertexNumber; i++)
            {
                for (int j = 0; j < this.vertexNumber; j++)
                {
                    if (this.matrix[i, j] != 0)
                    {
                        if (i == j)
                        {
                            vertexDegrees[i, 0] += this.matrix[i, j];
                            vertexDegrees[i, 1] += this.matrix[i, j];
                        }
                        else
                        {
                            vertexDegrees[j, 0] += this.matrix[i, j];
                            vertexDegrees[i, 1] += this.matrix[i, j];
                        }
                    }
                }
            }

            return vertexDegrees;
        }

        public int countLeafVertices()
        {
            int[] vertexDegrees = this.getAllVertexDegrees();
            int leftVerticesNumber = 0;
            for (int i = 0; i < this.vertexNumber; i++)
            {
                if (vertexDegrees[i] == 1 && this.matrix[i, i] == 0)
                {
                    leftVerticesNumber++;
                }
            }

            return leftVerticesNumber;
        }

        public int countIsolatedVertices()
        {
            // if (this.isUndirectedGraph())
            // {
            //     return 0;
            // }

            int[] vertexDegrees = this.getAllVertexDegrees();
            int isolatedVerticesNumber = 0;
            for (int i = 0; i < this.vertexNumber; i++)
            {
                if (vertexDegrees[i] == 0)
                {
                    isolatedVerticesNumber++;
                }
            }

            return isolatedVerticesNumber;
        }

        public int countLoopVertices()
        {
            if (this.isGraphHasNoLoops())
            {
                return 0;
            }

            int loopVertices = 0;
            for (int i = 0; i < this.vertexNumber; i++)
            {
                if (this.matrix[i, i] == 1)
                {
                    loopVertices++;
                }
            }

            return loopVertices;
        }

        public bool laDoThiCoCanhBoi()
        {
            for (int i = 0; i < this.vertexNumber; i++)
            {
                if (this.matrix[i, i] > 1)
                {
                    return true;
                }
            }

            return false;
        }

    }
}