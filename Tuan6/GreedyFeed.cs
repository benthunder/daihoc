using System;
using System.IO;
using System.Collections.Generic;

namespace Tuan6
{
    class GreedyFeed
    {
        private AdjacencyMatrix adjacencyMatrix;
        private int vertextNumber;

        private int[,] maxtrix;

        private int[] colorVertext;

        private int maxColor;
        private List<int> colorMaked = new List<int>();
        public GreedyFeed(AdjacencyMatrix adjacencyMatrix)
        {
            this.adjacencyMatrix = adjacencyMatrix;
            this.vertextNumber = adjacencyMatrix.getVertexNumber();
            this.maxtrix = adjacencyMatrix.getMatrix();

            this.colorVertext = new int[this.vertextNumber];
            for (int i = 0; i < this.vertextNumber; i++)
            {
                this.colorVertext[i] = -1;
            }
        }

        public int[] getAllVertexColor()
        {
            int color = -1;
            int maxColor = -1;
            List<int> listColorConnectedVertext;

            for (int i = 0; i < this.vertextNumber; i++)
            {
                color = 0;
                listColorConnectedVertext = this.getAllColorConnectdVertex(i);
                foreach (int c in colorMaked)
                {
                    if (listColorConnectedVertext.IndexOf(c) == -1)
                    {
                        color = c;
                        break;
                    }
                }

                if (maxColor < color)
                {
                    maxColor = color;
                }


                if (color == 0)
                {
                    maxColor++;
                    this.colorVertext[i] = maxColor;
                }
                else
                {
                    this.colorVertext[i] = color;
                }

                if (this.colorMaked.IndexOf(this.colorVertext[i]) == -1)
                {
                    this.colorMaked.Add(this.colorVertext[i]);
                    this.colorMaked.Sort();
                }

            }
            
            this.maxColor = maxColor;
            return this.colorVertext;
        }


        public int getMaxColor()
        {
            return this.maxColor;
        }

        private List<int> getAllColorConnectdVertex(int vertext)
        {
            List<int> listColor = new List<int>();
            for (int i = 0; i < this.vertextNumber; i++)
            {
                if (this.maxtrix[vertext, i] == 1)
                {
                    listColor.Add(this.colorVertext[i]);
                }
            }
            return listColor;
        }


    }
}