using System;
using System.IO;

namespace Tuan5
{
    class Euler
    {
        public string getEulerType(AdjacencyMatrix adjacencyMatrix)
        {
            int[] vertextDegree = adjacencyMatrix.getAllVertexDegrees(adjacencyMatrix.getMatrix(), adjacencyMatrix.getVertexNumber());

            int oddVertextNumber = 0;
            int evenVertextNumber = 0;
            string eulerType = "Do thi khong Euler";
            for (int i = 0; i < vertextDegree.Length; i++)
            {
                if (vertextDegree[i] % 2 == 0)
                {
                    evenVertextNumber++;
                }
                else
                {
                    oddVertextNumber++;
                }
            }

            if ((oddVertextNumber < 1 && evenVertextNumber < 1) || oddVertextNumber > 2)
            {
                eulerType = "Do thi khong Euler";
            }
            else if (oddVertextNumber < 1 && evenVertextNumber > 1)
            {
                eulerType = "Do thi Euler";
            }
            else if (oddVertextNumber > 0 && oddVertextNumber <= 2)
            {
                eulerType = "Do thi nua Euler";
            }

            return eulerType;
        }
    }
}