using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Vertex
    {
        //зберігає номер вершини
        public int Number { get; set; }
        //при виведенні в консоль правильно конвертуємо до рядка
        public override string ToString()
        {
            return Number.ToString();
        }
        //дозволяємо ініціалізувати пусту вершину
        public Vertex() { }
        //ініціалізація вершини з її номером
        public Vertex(int number)
        {
            Number = number;
        }
    }
}
