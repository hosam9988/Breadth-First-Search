using System;
using System.Collections.Generic;

namespace Graphs
{
    class Edge_
    {
        public string StartVertex;
        public string EndVertex;
        public int weight;
    }
    class Edge
    {
        public string vertex;
        public int weight;
    }
    class Program
    {
        // This is the Graph iam gonna practice my examples on ! xD
        // its an undirected weighted Graph !
        //          10
        //      (Cairo) __ (Alex)
        //   20 |
        //      (Giza)
        //   30 |
        //      (Sa7el)
        static void Main(string[] args)
        {
            List<string> VertexList = new List<string> { "Cairo","Alex","Giza","Sa7el" };
            List<string> SortedVertexList = new List<string>(VertexList);
            SortedVertexList.Sort();
            string Vertex_Cairo = SortedVertexList[SortedVertexList.BinarySearch("Cairo")];
            string Vertex_Alex = SortedVertexList[SortedVertexList.BinarySearch("Alex")];
            string Vertex_Giza = SortedVertexList[SortedVertexList.BinarySearch("Giza")];
            string Vertex_Sa7el = SortedVertexList[SortedVertexList.BinarySearch("Sa7el")];

//Using( Hash Table )
            Dictionary<string, List<Edge>> Cities = new Dictionary<string, List<Edge>>();
            Cities[Vertex_Cairo] = new List<Edge> { new Edge { vertex = Vertex_Alex, weight = 10 }, new Edge { vertex = Vertex_Giza, weight = 20 } };
            Cities[Vertex_Alex]  = new List<Edge> { new Edge { vertex = Vertex_Cairo, weight = 10 } };
            Cities[Vertex_Giza]  = new List<Edge> { new Edge { vertex = Vertex_Cairo, weight = 20 } , new Edge { vertex = Vertex_Sa7el, weight = 30 } };
            Cities[Vertex_Sa7el] = new List<Edge> { new Edge { vertex = Vertex_Giza, weight = 30 } };
    
//Breadth First Search
            //Now we Will search if their is a city called Sa7el in Cairo's Road Network
            //we will use Breadth first search Algorithm
            //Breadth First Search's Time Complexity = O( V + E )

            //now we add Neighbor Cities of Cairo to the Queue 
            //Dequeue first enqueued element ( nearest city to Cairo ) which is Alex or Giza ( Giza for example) and check if its (First letter) is ( S )
            //if its the one we are searching for then we have got it and knew it exists in our road network
            //if not then we will enqueue Giza's Neighbors and search in them after search other nearest cities to Cairo and SO ON untill we reach it or just dont find it
            // With this Algorithm we will find the Nearest City to Cairo which its name begins with the letter (S) ! :D :D :D
            Queue<Edge> SearchingQueue = new Queue<Edge>(Cities[Vertex_Cairo]);
            List<string> searchedVertexes = new List<string>();

            Console.WriteLine("Breadth First Search :D \n");
            while (SearchingQueue.Count >0)
            {
                Edge edge = SearchingQueue.Dequeue();

                if (!searchedVertexes.Contains(edge.vertex))
                {
                    if (edge.vertex[0] == 'S')
                    {
                        Console.WriteLine($"{edge.vertex} Begins with the letter S ! :D");
                        break;
                    }
                    else
                    {
                        Cities[edge.vertex].ForEach(Edge => SearchingQueue.Enqueue(Edge));
                        searchedVertexes.Add(edge.vertex);
                    }
                }               
            }

        }
    }
}
