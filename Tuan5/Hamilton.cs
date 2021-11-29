using System;
using System.IO;

namespace Tuan5
{
    class Hamilton
    {
        public int vertextNumber;
        public int[,] matrix;
        public int[] degreeVertext;
        public Hamilton(AdjacencyMatrix adjacencyMatrix)
        {
            this.vertextNumber = adjacencyMatrix.getVertexNumber();
            this.matrix = adjacencyMatrix.getMatrix();
            this.degreeVertext = adjacencyMatrix.getAllVertexDegrees(this.matrix, this.vertextNumber);
        }
        public bool isHamilton()
        {
            // b1
            if (this.isDuplicateVertext())
            {
                return false;
            }

            if (this.vertextNumber < 3)
            {
                return false;
            }

            // b2

            // b3
            if (!this.isDirac())
            {
                return false;
            }

            if (!this.isOre())
            {
                return false;
            }


            return true;
        }

        public bool isDirac()
        {
            float checkVertext = this.vertextNumber / 2;

            for (int i = 0; i < this.vertextNumber; i++)
            {
                if (this.degreeVertext[i] < checkVertext)
                {
                    return false;
                }
            }

            return true;
        }

        public bool isOre()
        {
            for (int i = 0; i < this.vertextNumber; i++)
            {
                for (int j = 0; j < this.vertextNumber; j++)
                {
                    if (this.matrix[i, j] > 0)
                    {
                        if (this.degreeVertext[i] + this.degreeVertext[j] < this.vertextNumber)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool isDuplicateVertext()
        {
            for (int i = 0; i < this.vertextNumber; i++)
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