using System.Text;
using Lab1;

internal class Program
{
    static void Main(string[] args)
    {
        //на всякий випадок міняємо кодування на таке, що підтримує кирилицю, в нових версіях VisualStudio непотрібно
        Console.OutputEncoding = Encoding.UTF8;
        //оголошуємо граф
        Graph graph = new Graph();
        //створюємо вершини 1-7
        Vertex v1 = new Vertex(1);
        Vertex v2 = new Vertex(2);
        Vertex v3 = new Vertex(3);
        Vertex v4 = new Vertex(4);
        Vertex v5 = new Vertex(5);
        Vertex v6 = new Vertex(6);
        Vertex v7 = new Vertex(7);
        Vertex v8 = new Vertex(8);
        Vertex v9 = new Vertex(9);
        //додаємо вершини в граф
        graph.AddVertex(v1);
        graph.AddVertex(v2);
        graph.AddVertex(v3);
        graph.AddVertex(v4);
        graph.AddVertex(v5);
        graph.AddVertex(v6);
        graph.AddVertex(v7);
        graph.AddVertex(v8);
        graph.AddVertex(v9);
        //додаемо ребра в раф (1;2)(1;3)(3;4)(2;5)(2;6)(6;5)(5;6)
        graph.AddEdge(v1, v2);
        graph.AddEdge(v1, v3);
        graph.AddEdge(v1, v4);
        graph.AddEdge(v1, v5);
        graph.AddEdge(v2, v3);
        graph.AddEdge(v2, v5);
        graph.AddEdge(v3, v7);
        graph.AddEdge(v3, v8);
        graph.AddEdge(v4, v5);
        graph.AddEdge(v4, v9);
        graph.AddEdge(v5, v7);
        graph.AddEdge(v5, v8);
        graph.AddEdge(v6, v7);
        graph.AddEdge(v6, v9);
        graph.AddEdge(v7, v9);
        graph.AddEdge(v8, v9);
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
        //чекаємо поки користувач натисне любу клавішу на клавіатурі
        Console.ReadKey();
    }
}