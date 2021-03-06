using System;
using System.IO;
using System.Collections.Generic;
namespace Tuan2
{
    class BaiTap
    {
        private AdjacencyMatrix adjacencyMatrix;

        private int[] listVisited;
        private List<string> listReturn = new List<string>();
        private int vertexNumber;

        private List<int> queueBFS = new List<int>();

        public int start = 0, goal = 0;

        public List<int> queueLienThong = new List<int>();
        private int[] listParent;

        public BaiTap(string path)
        {
            string pathDir = System.IO.Directory.GetCurrentDirectory();
            path = pathDir + "/file_input/" + path;

            adjacencyMatrix = new AdjacencyMatrix();
            adjacencyMatrix.readInput(path);

            this.initValue();
        }

        public void initValue()
        {
            this.vertexNumber = this.adjacencyMatrix.getVertexNumber();
            this.listVisited = new int[this.vertexNumber];
            this.listParent = new int[this.vertexNumber];

            this.listReturn = new List<string>();
            this.queueBFS = new List<int>();
            // Init value
            for (int i = 0; i < this.vertexNumber; i++)
            {
                this.listVisited[i] = 0;
                this.listParent[i] = -1;
            }
        }

        public int[] getListVisited()
        {
            return this.listVisited;
        }

        public int getVertexNumber(){
            return this.adjacencyMatrix.getVertexNumber();
        }


        public void DFS(int vertex = 0)
        {
            int[,] matrix = this.adjacencyMatrix.getMatrix();
            if (this.listVisited[vertex] != 1)
            {
                this.listReturn.Add(vertex.ToString());
            }
            this.listVisited[vertex] = 1;
            if (vertex == this.goal)
            {
                return;
            }
            
            for (int i = 0; i < this.vertexNumber; i++)
            {
                if (matrix[vertex, i] == 1 && this.listVisited[i] != 1)
                {
                    this.listVisited[i] = 1;
                    this.listReturn.Add(i.ToString());
                    this.listParent[i] = vertex;
                    this.DFS(i);
                }
            }
        }


        public void BFS(int vertex = 0)
        {
            int[,] matrix = this.adjacencyMatrix.getMatrix();

            if (this.listVisited[vertex] != 1)
            {
                this.listReturn.Add(vertex.ToString());
                this.queueBFS.Add(vertex);
            }
            this.listVisited[vertex] = 1;
            while (queueBFS.Count > 0)
            {
                int currentVertext = queueBFS[0];
                queueBFS.RemoveAt(0);
                for (int i = 0; i < this.vertexNumber; i++)
                {
                    if (matrix[currentVertext, i] == 1 && this.listVisited[i] != 1)
                    {
                        this.listParent[i] = currentVertext;
                        this.listVisited[i] = 1;
                        this.queueBFS.Add(i);
                        this.listReturn.Add(i.ToString());
                        if (i == this.goal)
                        {
                            return;
                        }
                    }
                }
            }
        }

        public void xuLyLienThong(int vertex){
            int[,] matrix = this.adjacencyMatrix.getMatrix();
            if (this.listVisited[vertex] != 1)
            {
                this.listReturn.Add(vertex.ToString());
                this.mangLT.Add(vertex);
            }
            this.listVisited[vertex] = 1;

            for (int i = 0; i < this.vertexNumber; i++)
            {
                if (matrix[vertex, i] == 1 && this.listVisited[i] != 1)
                {
                    this.listVisited[i] = 1;
                    this.listReturn.Add(i.ToString());
                    this.listParent[i] = vertex;
                    this.mangLT.Add(i);
                    this.xuLyLienThong(i);
                }
            }
        }

        private List<int> mangLT = new List<int>();
        public IDictionary<int, List<int>> listLT = new Dictionary<int, List<int>>();
        public void timLienThong(){
            int soLienThong = 1;
            for(int i = 0 ; i < this.vertexNumber ; i++){
                if(this.listVisited[i] == 1)
                    continue;
                
                this.mangLT = new List<int>();
                this.xuLyLienThong(i);
                this.listLT.Add(++soLienThong,mangLT);
            }
        }
        public void inLienThong(){
            Console.WriteLine("So Lien Thong: "+this.listLT.Count);
            int i = 1;
            foreach(KeyValuePair<int, List<int>> item in this.listLT){
                Console.Write("Lien thong {0}: ",i++);
                foreach(int v in item.Value){
                    Console.Write("{0} ",v);
                }
                Console.WriteLine();
            }
        }

        public void inKetQua()
        {
            foreach (string vertext in this.listReturn)
            {
                Console.Write(vertext + " ");
                if (Int32.Parse(vertext) == this.goal) break;
            }
            Console.WriteLine();
        }

        public void inDuongDi()
        {
            List<int> listPath = new List<int>();
            if (this.listParent[this.goal] == -1)
            {
                Console.WriteLine("Khong co duong di");
                return;
            }
            else
            {
                int cur = this.goal;
                while (cur != this.start && cur != -1)
                {
                    listPath.Add(cur);
                    cur = this.listParent[cur];
                }

                if (cur == this.start)
                {
                    listPath.Add(cur);
                }
            }

            if (listPath.Count < 1)
            {
                Console.WriteLine("Khong co duong di");
                return;
            }

            if (listPath[listPath.Count - 1] != this.start)
            {
                Console.WriteLine("Khong co duong di");
                return;
            }

            for (int i = 0; i < listPath.Count; i++)
            {
                Console.Write(listPath[i]);
                if (listPath.Count - 1 != i)
                {
                    Console.Write("<-");
                }
            }
            Console.WriteLine();
        }
        public void inKetQua(int start, int goal)
        {
            this.listReturn.Reverse();
            foreach (string vertext in this.listReturn)
            {
                Console.Write(vertext + " ");
                if (Int32.Parse(vertext) == goal) break;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            try
            {
                BaiTap baiTap = new BaiTap("input.txt");
                // adjacencyMatrix.printMatrix();
                string batdau = Console.ReadLine();
                string ketthuc = Console.ReadLine();

                baiTap.initValue();
                baiTap.start = Int32.Parse(batdau);
                baiTap.goal = Int32.Parse(ketthuc);

                if (Int32.Parse(batdau) < Int32.Parse(ketthuc))
                {
                    baiTap.initValue();
                    for (int i = Int32.Parse(batdau); i  Int32.Parse(ketthuc); i++)
                    {
                        if (baiTap.getListVisited()[i] != 1)
                        {
                            baiTap.DFS(i);
                        }
                    }
                    Console.WriteLine("DFS Duyet: ");
                    baiTap.inKetQua();

                    Console.WriteLine("DFS Duong Di: ");
                    baiTap.inDuongDi();
                }
                else
                {
                    for (int i = Int32.Parse(batdau); i >= Int32.Parse(ketthuc); i--)
                    {
                        if (baiTap.getListVisited()[i] != 1)
                        {
                            baiTap.DFS(i);
                        }
                    }
                    Console.WriteLine("DFS Duyet: ");
                    baiTap.inKetQua();

                    Console.WriteLine("DFS Duong Di: ");
                    baiTap.inDuongDi();
                }



                if (Int32.Parse(batdau) < Int32.Parse(ketthuc))
                {
                    baiTap.initValue();
                    for (int i = Int32.Parse(batdau); i <= Int32.Parse(ketthuc); i++)
                    {
                        if (baiTap.getListVisited()[Int32.Parse(ketthuc)] == 1)
                        {
                            break;
                        }

                        if (baiTap.getListVisited()[i] != 1)
                        {
                            baiTap.BFS(i);
                        }
                    }
                    Console.WriteLine("BFS Duyet: ");
                    baiTap.inKetQua();

                    Console.WriteLine("BFS Duong di: ");
                    baiTap.inDuongDi();
                }
                else
                {
                    baiTap.initValue();
                    for (int i = Int32.Parse(batdau); i >= Int32.Parse(ketthuc); i--)
                    {
                        if (baiTap.getListVisited()[Int32.Parse(ketthuc)] == 1)
                        {
                            break;
                        }

                        if (baiTap.getListVisited()[i] != 1)
                        {
                            baiTap.BFS(i);
                        }
                    }
                    Console.WriteLine("BFS Duyet: ");
                    baiTap.inKetQua();


                    Console.WriteLine("BFS Duong di: ");
                    baiTap.inDuongDi();
                }

                baiTap.initValue();
                Console.WriteLine("Tim Lien Thong: ");
                baiTap.timLienThong();
                baiTap.inLienThong();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }
    }
}