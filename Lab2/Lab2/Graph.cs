using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
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
        public List<int>[] adjacency_list()
        {
            List<int>[] list = new List<int>[VertexCount]; //сюди помістимо результат
            for (int i = 0; i < VertexCount; i++) list[i] = new List<int>();//створюємо всі елементи списку
            foreach (Edge edge in Edges) list[edge.From.Number - 1].Add(edge.To.Number - 1);//додаємо в список зв'язок між вершинами
                                                                                            // -1 бо у нас вершини починаються з 1-ці а елементи списку з 0-ля
            return list;
        }
        //Пошук шляху від однієї вершини до іншої за допомогою алгоритму пошуку в ширину (BFS) Breadth First Search
        public List<int> BFS(int start, int dest)
        {
            start = start - 1; dest = dest - 1;//переходимо до нумерації вершин з 0, для правильної роботи алгоритму
            List<int>[] adj = adjacency_list();//формуємо список суміжності вершин графу
            bool[] visited = new bool[VertexCount]; //створюємо масив відвіданих вершин
            int[] parent = new int[VertexCount]; //створюємо масив вершин "батьків"
            for (int i = 0; i < VertexCount; i++) //задаємо масивам початкові значення
            {
                visited[i] = false;//жодну вершину ми ще не проходили
                parent[i] = -1;//в жодної вершини немає "батька"
            }
            Queue<int> q = new Queue<int>();//створюємо чергу, в яку будемо поміщати вершини які потрібно обійти
            visited[start] = true;//помічаємо початкову вершину відвіданою
            q.Enqueue(start);//додаємо її (початкову вершину) в чергу
            while (q.Count != 0) //поки ще лишилися елементи в черзі
            {
                int u = q.Dequeue();//виймаємо слідуючу вершину з черги і поміщаємо її у u
                foreach (int v in adj[u])//перебираємо всі вершини із списку суміжності графа через змінну v
                {
                    if (!visited[v]) //якщо в цій вершины ми ще не були
                    {
                        visited[v] = true; //помычаэмо її як відвідану
                        parent[v] = u;//додаємо батька (у вершину v ми можемо потрапити з вершини u)
                        q.Enqueue(v);//додаємо вершину в чергу, щоб її також опрацювати
                    }
                    if (v == dest) //якщо вершина є кінцевою
                    {
                        // Знайдено шуканий маршрут
                        List<int> path = new List<int>();//створюємо список, щоб в нього помістити наш маршрут
                        int curr = dest;//оголошуємо змінну для поточної вершини і задаємо їй значення кінцевої вершини
                        while (curr != -1)//поки існує батьківська вершина
                        {
                            path.Add(curr + 1);//переходимо до нашої нумерації вершин з 1
                            curr = parent[curr];//додаємо вершину до шляху
                        }
                        path.Reverse();//змінюємо маршрут на протилежний, бо в нас перша вершина кінцева, а остання перша
                        return path;//повертаємо маршрут
                    }
                }
            }
            // Шуканий маршрут не знайдено
            return null;
        }
    }
}
