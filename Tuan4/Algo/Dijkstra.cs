
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
            this.vertextQueue = new List<int>();

            for (int i = 0; i < this.vertextNumber; i++)
            {
                this.VWeight[i] = 0;
                this.VParent[i] = -1;
                this.vertextQueue.Add(i);
            }
        }


        public void runAlgo()
        {
            this.VWeight[this.start] = 0;
            int currentVertext = this.start;
            this.vertextQueue.RemoveAt(this.vertextQueue.IndexOf(this.start));

            foreach (int i in this.vertextQueue)
            {
                nextVertext = this.getMinVerticleChild(currentVertext);
            }
        }
        /**
        *   v -> 2 | => return [2]
        */
        public int getMinVerticleChild(int verticle)
        {
            int minVertex = -1;
            int minVertexWeight = -1;
            for (int i = 0; i < this.vertextNumber; i++)
            {
                if ((this.matrix[verticle, i] != 0 && (minVertexWeight == -1 || minVertexWeight < this.matrix[verticle, i])))
                {
                    minVertexWeight = this.matrix[verticle, i];
                    minVertex = i;
                }

            }

            return minVertex;
        }


        /**
        *   1 -> v | => return [2]
        */
        public int getMinVerticleParent(int verticle)
        {
            int minVertex = -1;
            int minVertexWeight = -1;
            for (int i = 0; i < this.vertextNumber; i++)
            {
                if ((this.matrix[i, verticle] != 0 && (minVertexWeight == -1 || minVertexWeight < this.matrix[i, verticle])))
                {
                    minVertexWeight = this.matrix[i, verticle];
                    minVertex = i;
                }
            }

            return minVertex;
        }
    }
}