
using System;
using System.IO;
using System.Collections.Generic;


namespace Tuan4_Algo
{
    class Dijkstra
    {
        public int[,] matrix;
        public int vertextNumber;
        public int start;

        public int[] VWeight, VParent;
        public bool[] VChecked;

        public List<int> vertextQueue;

        public Dijkstra(int[,] matrix, int vertexNumber, int start)
        {
            this.matrix = matrix;
            this.vertextNumber = vertexNumber;
            this.start = start;

            this.initValue();

        }

        private void initValue()
        {
            this.VWeight = new int[this.vertextNumber];
            this.VParent = new int[this.vertextNumber];
            this.VChecked = new bool[this.vertextNumber];

            for (int i = 0; i < this.vertextNumber; i++)
            {
                this.VWeight[i] = int.MaxValue;
                this.VParent[i] = -1;
                this.VChecked[i] = false;
            }
        }

        int minDistance()
        {
            // Initialize min value 
            int min = int.MaxValue, min_index = -1;
            for (int v = 0; v < this.vertextNumber; v++)
            {
                if (this.VChecked[v] == false && this.VWeight[v] <= min)
                {
                    min = this.VWeight[v];
                    min_index = v;
                }
            }
            return min_index;
        }

        void printPaths()
        {
            Console.Write("Vertex this.VWeightance from Source {0}\n", this.start);
            for (int i = 0; i < this.vertextNumber; i++)
            {
                Console.Write(i + " \t\t " + this.VWeight[i] + "\n");
            }
        }
        /**
        *   v -> 2 | => return [2]
        */
        public void runAlgo()
        {
            this.VWeight[this.start] = 0;
            for (int count = 0; count < this.vertextNumber - 1; count++)
            {
                int minDistIndx = this.minDistance();
                this.VChecked[minDistIndx] = true;
                for (int indx = 0; indx < this.vertextNumber; indx++)
                {
                    if (!this.VChecked[indx] && this.matrix[minDistIndx, indx] != 0 && this.VWeight[minDistIndx] != int.MaxValue && this.VWeight[minDistIndx] + this.matrix[minDistIndx, indx] < this.VWeight[indx])
                    {
                        this.VWeight[indx] = this.VWeight[minDistIndx] + this.matrix[minDistIndx, indx];
                    }
                }
            }
            this.printPaths();
        }
    }
}