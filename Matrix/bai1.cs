using System;
using System.IO;

namespace Matrix
{
    class Bai1
    {
        public static AdjacencyMatrix adjacencyMatrix;



        public void inKetKQCoHuong()
        {
            if (adjacencyMatrix.isUndirectedGraph())
            {
                Console.WriteLine("Do thi vo huong");
            }
            else
            {
                Console.WriteLine("Do thi co huong");
            }
        }

        public void inLoaiDoThi()
        {
            string loaiDoThi = "";
            if (adjacencyMatrix.isUndirectedGraph() && adjacencyMatrix.isGraphHasNoLoops() && !adjacencyMatrix.laDoThiCoCanhBoi())
            {
                loaiDoThi = "Don do thi";
            }

            if (adjacencyMatrix.isUndirectedGraph() && adjacencyMatrix.isGraphHasNoLoops() && adjacencyMatrix.laDoThiCoCanhBoi())
            {
                loaiDoThi = "Da do thi";
            }

            if (adjacencyMatrix.isUndirectedGraph() && !adjacencyMatrix.isGraphHasNoLoops())
            {
                loaiDoThi = "Gia do thi";
            }

            if (!adjacencyMatrix.isUndirectedGraph() && !adjacencyMatrix.isGraphHasNoLoops() && !adjacencyMatrix.laDoThiCoCanhBoi())
            {
                loaiDoThi = "Do thi co huong";
            }

            if (!adjacencyMatrix.isUndirectedGraph() && !adjacencyMatrix.isGraphHasNoLoops() && adjacencyMatrix.laDoThiCoCanhBoi())
            {
                loaiDoThi = "Da do thi co huong";
            }

            Console.WriteLine(loaiDoThi);
        }

        public void inSoDinhDoThi()
        {
            Console.WriteLine("So dinh cua do thi: {0}", adjacencyMatrix.getVertexNumber());
        }

        public void inSoDinhCoLap()
        {
            Console.WriteLine("So dinh co lap: {0}", adjacencyMatrix.countIsolatedVertices());
        }

        public void inSoCanhKhuyen()
        {
            Console.WriteLine("So canh khuyen: {0}", adjacencyMatrix.countLoopVertices());
        }

        public void inSoDinhTreo()
        {
            Console.WriteLine("So dinh treo: {0}", adjacencyMatrix.countLeafVertices());
        }

        public void inBacDoThi()
        {
            if (adjacencyMatrix.isUndirectedGraph())
            {
                Console.WriteLine("Bac cua tung dinh:");
                int[] degree = adjacencyMatrix.getAllVertexDegrees();
                for (int i = 0; i < adjacencyMatrix.getVertexNumber(); i++)
                {
                    Console.Write("{0}({1})", i, degree[i]);
                    Console.Write(" ");
                }
            }
            else
            {
                Console.WriteLine("(Bac vao - Bac ra) cua tung dinh:");
                int[,] degree = adjacencyMatrix.getAllInOutVertexDegrees();
                for (int i = 0; i < adjacencyMatrix.getVertexNumber(); i++)
                {
                    Console.Write("{0}({1}-{2})", i, degree[i, 0], degree[i, 1]);
                    Console.Write(" ");
                }
            }

            Console.WriteLine("");
        }

        public void inSoCanh()
        {
            int soDinh = adjacencyMatrix.getVertexNumber();
            int[,] matran = adjacencyMatrix.getMatrix();
            int soCanh = 0;
            for (int i = 0; i < soDinh; i++)
            {
                for (int j = 0; j < soDinh; j++)
                {
                    if (matran[i, j] != 0)
                    {
                        soCanh += matran[i, j];
                    }
                }
            }
            if (adjacencyMatrix.isUndirectedGraph())
            {
                soCanh = soCanh + adjacencyMatrix.countLoopVertices();
                soCanh = soCanh / 2;
            }

            Console.WriteLine("So canh cua do thi: {0}", soCanh);
        }

        public void inCanhBoi()
        {
            Console.WriteLine("So cap dinh xuat hien canh boi: {0}", adjacencyMatrix.multipleEdge());
        }


        static void Main(string[] args)
        {
            Bai1 bai1 = new Bai1();
            adjacencyMatrix = new AdjacencyMatrix();
            string pathDir = System.IO.Directory.GetCurrentDirectory();
            string path = pathDir + "/file_input/bai1.txt";
            try
            {
                adjacencyMatrix.readInput(path);
                adjacencyMatrix.printMatrix();
                bai1.inKetKQCoHuong();
                bai1.inSoDinhDoThi();
                bai1.inSoCanh();
                bai1.inCanhBoi();
                bai1.inSoCanhKhuyen();
                bai1.inSoDinhTreo();
                bai1.inSoDinhCoLap();
                bai1.inBacDoThi();
                bai1.inLoaiDoThi();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }
    }
}