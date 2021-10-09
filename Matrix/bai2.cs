using System;
using System.IO;

namespace Matrix
{
    class Bai2
    {
        public static AdjacencyMatrix adjacencyMatrix;

        public void inKQDoThiDayDu()
        {
            if (adjacencyMatrix.isUndirectedGraph() && adjacencyMatrix.isGraphHasNoLoops() && !adjacencyMatrix.laDoThiCoCanhBoi())
            {
                int[] degree = adjacencyMatrix.getAllVertexDegrees();
                int vertexNumber = adjacencyMatrix.getVertexNumber();
                for (int i = 0; i < vertexNumber - 1; i++)
                {
                    if (degree[i] != vertexNumber - 1 || degree[i] != degree[i + 1])
                    {
                        Console.WriteLine("Day khong phai la do thi day du");
                        return;
                    }
                }
                Console.WriteLine("Day la do thi day du K{0}", vertexNumber);
            }
            else
            {
                Console.WriteLine("Day khong phai la do thi day du");
            }
        }

        public void inKQDoThiChinhQuy()
        {
            if (adjacencyMatrix.isUndirectedGraph() && adjacencyMatrix.isGraphHasNoLoops() && !adjacencyMatrix.laDoThiCoCanhBoi())
            {
                int[] degree = adjacencyMatrix.getAllVertexDegrees();
                int vertexNumber = adjacencyMatrix.getVertexNumber();
                int bacChinhQuy = 0;
                for (int i = 0; i < vertexNumber - 1; i++)
                {
                    if (degree[i] != degree[i + 1])
                    {
                        Console.WriteLine("Day khong phai la do thi chinh quy");
                        return;
                    }
                    else
                    {
                        bacChinhQuy = degree[i];
                    }
                }
                Console.WriteLine("Day la do thi {0}-chinh quy", bacChinhQuy);
            }
            else
            {
                Console.WriteLine("Day khong phai la do thi chinh quy");
            }
        }

        public void inKQDoThiVong()
        {
            int[] degree = adjacencyMatrix.getAllVertexDegrees();
            for (int i = 0; i < degree.Length; i++)
            {
                if (degree[i] != 2)
                {
                    Console.WriteLine("Day khong phai la do thi vong");
                    return;
                }
            }
            Console.WriteLine("Day la do thi vong C{0}", adjacencyMatrix.getVertexNumber());
        }

        static void Main(string[] args)
        {
            Bai2 bai2 = new Bai2();
            adjacencyMatrix = new AdjacencyMatrix();
            string pathDir = System.IO.Directory.GetCurrentDirectory();
            string path = pathDir + "/file_input/bai2.txt";
            try
            {
                adjacencyMatrix.readInput(path);
                bai2.inKQDoThiDayDu();
                bai2.inKQDoThiChinhQuy();
                bai2.inKQDoThiVong();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }
    }
}