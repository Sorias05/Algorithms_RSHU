using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Edge
    {
        //зберігаємо вершину з якої виходить ребро
        public Vertex From { get; set; }
        //вершина до якої доходить ребро
        public Vertex To { get; set; }
        //потужність ребра
        public int Weight { get; set; }
        //дозволяємо ініціалізацію без параметрів
        public Edge() { }
        //ініціалізація ребра з вказанням вершин і потужності
        public Edge(Vertex from, Vertex to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }
        //при виведенні в консоль правильно конвертуємо до рядка
        public override string ToString()
        {
            return From.ToString() + ";" + To.ToString();
        }
    }
}
