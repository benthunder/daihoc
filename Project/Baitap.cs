using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Project
{
    class Baitap
    {
        public List<Graph> ListGraph = new List<Graph>();
        public Baitap(string path)
        {
            string pathDir = System.IO.Directory.GetCurrentDirectory();
            path = pathDir + "/file_input/" + path;

            if (!File.Exists(path))
            {
                throw new Exception("This file does not exist.");
            }

            string[] lines = File.ReadAllLines(path);
            Graph graph;
            List<string> lineInput;
            int vertexNumber = 0;
            int i = 0;
            while (i < lines.Length)
            {
                lineInput = new List<string>();
                vertexNumber = Int32.Parse(lines[i]);
                for (int j = 1; j <= vertexNumber; j++)
                {
                    lineInput.Add(lines[i + j]);
                }

                graph = new Graph();
                graph.readInput(lineInput, vertexNumber);
                this.ListGraph.Add(graph);
                i = i + vertexNumber + 1;
            }

        }

        public void inMaTran()
        {
            foreach (Graph g in this.ListGraph)
            {
                g.printResult();
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Baitap baitap = new Baitap("input.txt");
                baitap.inMaTran();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}