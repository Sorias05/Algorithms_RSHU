using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Graph
    {
        //Списки для зберігання вершин та ребер
        List<Vertex> Vertexes = new List<Vertex>();
        List<Edge> Edges = new List<Edge>();
        //повертаємо кількість вершин графа
        public int VertexCount => Vertexes.Count;
        //повертаємо кількість ребер графа
        public int EdgeCount => Edges.Count;
        //додаємо вершину
        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }
        //додаємо ребро
        public void AddEdge(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            Edges.Add(edge);
        }
        //Матриця суміжності
        public int[,] Adjacency_Matrix()
        {
            var matrix = new int[Vertexes.Count, Vertexes.Count];
            foreach (var edge in Edges)
            {
                var row = edge.From.Number;
                var column = edge.To.Number;
                matrix[row - 1, column - 1] = edge.Weight;// -1 бо в масиві елементи починаються із 0 а вершини графу з 1
            }
            return matrix;
        }
        //матриця інцидентності
        public int[,] Incidence_Matrix()
        {
            var matrix = new int[Vertexes.Count, Edges.Count];
            for (int i = 0; i < Edges.Count; i++)
            {
                matrix[Edges[i].From.Number - 1, i] = 1;// -1 бо в масиві елементи починаються із 0 а вершини графу з 1
                matrix[Edges[i].To.Number - 1, i] = 1;
            }
            return matrix;
        }
        //повертаємо вершину за його індексом
        public Vertex Vertex(int i)
        {
            return Vertexes[i];
        }
        //повертаємо ребро за його індексом
        public Edge Edge(int i)
        {
            return Edges[i];
        }
    }
}
