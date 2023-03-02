using System.Text;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //оголошуємо граф
            Graph graph = new Graph();
            //створюємо вершини 1-8
            Vertex v1 = new Vertex(1);
            Vertex v2 = new Vertex(2);
            Vertex v3 = new Vertex(3);
            Vertex v4 = new Vertex(4);
            Vertex v5 = new Vertex(5);
            Vertex v6 = new Vertex(6);
            Vertex v7 = new Vertex(7);
            Vertex v8 = new Vertex(8);
            //додаємо вершини в граф
            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);
            graph.AddVertex(v8);
            //додаемо ребра в граф (2;1)(1;3)(1;4)(2;6)(2;5)(2;6)(3;5)(3;7)(4;6)(4;7)(5;8)(6;8)(7;8)(3;6)
            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v1, v4);
            graph.AddEdge(v1, v7);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6);
            graph.AddEdge(v3, v5);
            graph.AddEdge(v3, v6);
            graph.AddEdge(v3, v7);
            graph.AddEdge(v4, v6);
            graph.AddEdge(v4, v7);
            graph.AddEdge(v5, v8);
            graph.AddEdge(v6, v8);
            graph.AddEdge(v7, v8);
            //виведемо веришини графа
            Console.WriteLine(" Вершини графа");
            for (int i = 0; i < graph.VertexCount; i++) //перебираємо всі вершини графа по черзі
                Console.Write(graph.Vertex(i) + " ");
            Console.WriteLine();
            //Виведемо ребра графу
            Console.WriteLine();
            Console.WriteLine(" Ребра графа");
            for (int i = 0; i < graph.EdgeCount; i++) //перебираємо ві ребра графу по черзі
                Console.Write(graph.Edge(i) + " ");
            Console.WriteLine();
            //вираховуємо матрицю суміжності
            var matrix = graph.Adjacency_Matrix();
            //виводимо матрицю суміжності в консоль
            Console.WriteLine();
            Console.WriteLine(" Матриця суміжності графа");
            for (int i = 0; i < graph.VertexCount; i++) // i - відповідає за рядок
            {
                for (int j = 0; j < graph.VertexCount; j++) //j - відповідає за стовпець
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            //вираховуємо матрицю інцидентності
            var matrix1 = graph.Incidence_Matrix();
            //виводимо матрицю інцидентності в консоль
            Console.WriteLine();
            Console.WriteLine(" Матриця інцидентності графа (стовпці - вершини, рядки ребра)");
            for (int i = 0; i < graph.VertexCount; i++) // i - відповідає за рядок
            {
                for (int j = 0; j < graph.VertexCount; j++) //j - відповідає за стовпець
                {
                    Console.Write(matrix1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Найкоротший шлях від 2 до 8 вершини");
            List<int> path = graph.BFS(2, 8); //вираховуємо найкоротший маршрут
            if (path != null) // =null маршруту неіснує
            {
                foreach (int p in path) Console.Write(p + " "); //перебираємо всі вершини маршруту і виводимо їх
            }
            else { Console.Write("Шляху не існує"); }
            Console.WriteLine();
            //чекаємо поки користувач натисне любу клавішу на клавіатурі
            Console.ReadKey();
        }
    }
}