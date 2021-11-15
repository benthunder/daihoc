using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using Project_Algo;
namespace Project
{
    class Graph
    {
        public int VertexNumber { get; set; }
        public int[,] Martrix { get; set; }
        public bool IsUndirected { get; set; }

        private bool isUndirectedGraph()
        {
            for (int i = 0; i < this.VertexNumber; i++)
            {
                for (int j = 0; j < this.VertexNumber; j++)
                {
                    if (this.Martrix[i, j] != this.Martrix[j, i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void readInput(List<string> inputString, int VertexNumber)
        {
            this.VertexNumber = VertexNumber;
            this.Martrix = new int[this.VertexNumber, this.VertexNumber];
            for (int i = 0; i < this.VertexNumber; i++)
            {
                for (int j = 0; j < this.VertexNumber; j++)
                {
                    this.Martrix[i, j] = 0;
                }

                string[] tokens = inputString[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (Int32.Parse(tokens[0]) == 0)
                {
                    continue;
                }

                for (int j = 1; j <= Int32.Parse(tokens[0]); j++)
                {
                    this.Martrix[i, Int32.Parse(tokens[j])] = 1;
                }
            }

            this.IsUndirected = this.isUndirectedGraph();
        }

        public void printResult()
        {
            EmptyGraph emptyGraph = new EmptyGraph();
            if (emptyGraph.isEmptyGraph(this.Martrix, this.VertexNumber))
            {
                Console.WriteLine("1. Đồ thị trống : k = {0}", emptyGraph.k);
            }
            else
            {
                Console.WriteLine("1. Đồ thị trống : Không");
            }

            CycleGraph cycleGraph = new CycleGraph();
            if (cycleGraph.isCycleGraph(this.Martrix, this.VertexNumber, this.IsUndirected))
            {
                Console.WriteLine("2. Đồ thị vòng : k = {0}", cycleGraph.k);
            }
            else
            {
                Console.WriteLine("2. Đồ thị vòng : Không");
            }

            ButterflyGraph butterflyGraph = new ButterflyGraph();
            if (butterflyGraph.isButterflyGraph(this.Martrix, this.VertexNumber, this.IsUndirected))
            {
                Console.WriteLine("3. Đồ thị con bướm : có");
            }
            else
            {
                Console.WriteLine("3. Đồ thị con bướm : Không");
            }

            MothGraph mothGraph = new MothGraph();
            if (mothGraph.isMothGraph(this.Martrix, this.VertexNumber, this.IsUndirected))
            {
                Console.WriteLine("4. Đồ thị con ngài : có");
            }
            else
            {
                Console.WriteLine("4. Đồ thị con ngài : Không");
            }

            StartGraph startGraph = new StartGraph();
            if (startGraph.isStartGraph(this.Martrix, this.VertexNumber, this.IsUndirected))
            {
                Console.WriteLine("5. Đồ thị hình sao : k = {0}", startGraph.k);
            }
            else
            {
                Console.WriteLine("5. Đồ thị hình sao : Không");
            }

            WheelGraph wheelGraph = new WheelGraph();
            if (wheelGraph.isWheelGraph(this.Martrix, this.VertexNumber, this.IsUndirected))
            {
                Console.WriteLine("6. Đồ thị bánh xe : k = {0}", wheelGraph.k);
            }
            else
            {
                Console.WriteLine("6. Đồ thị bánh xe : Không");
            }

            BarbellGraph barbellGraph = new BarbellGraph();
            if (barbellGraph.isBarbellGraph(this.Martrix, this.VertexNumber, this.IsUndirected))
            {
                Console.WriteLine("7. Đồ thị Barbell : k = {0}", barbellGraph.k);
            }
            else
            {
                Console.WriteLine("7. Đồ thị Barbell : Không");
            }

            FriendshipGraph friendshipGraph = new FriendshipGraph();
            if (friendshipGraph.isFriendshipGraph(this.Martrix, this.VertexNumber, this.IsUndirected))
            {
                Console.WriteLine("8. Đồ thị tình bạn : k = {0}", friendshipGraph.k);
            }
            else
            {
                Console.WriteLine("8. Đồ thị tình bạn : Không");
            }

            PartiteGraph partiteGraph = new PartiteGraph();
            if (partiteGraph.isPartiteGraph(this.Martrix, this.VertexNumber, this.IsUndirected))
            {
                List<string> kGraph = partiteGraph.listK;
                Console.Write("9. Đồ thị k-phân (k>1): k = {0} {1}", kGraph.Count, string.Join(",", kGraph));
            }
            else
            {
                Console.Write("9. Đồ thị k-phân (k>1): Không");
            }
            Console.WriteLine();
        }

        public void printInput()
        {
            Console.WriteLine(this.VertexNumber);
            for (int i = 0; i < this.VertexNumber; i++)
            {
                for (int j = 0; j < this.VertexNumber; j++)
                {
                    Console.Write(this.Martrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

    }

}