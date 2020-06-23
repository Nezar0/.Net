using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("patterns.dll"); // Загружаем сборку
            Console.WriteLine(asm.FullName); // Выводим полное имя сборки
            Type[] types = asm.GetTypes();// Берем типы, определенные в сборке и кладем в массив
            foreach (Type t in types)
            {
                Console.WriteLine(t.Name + " С методами: "); // Выводим типы
                MethodInfo[] Mmas = t.GetMethods();// Берем методы у конкретного типа и записываем в массив
                foreach (MethodInfo m in Mmas)
                    Console.Write(" — — — " + m.ReturnType.Name + " — > " + m.Name + "\n");// Выводим тип метода и его имя
            }
            Console.ReadLine();
        }
    }
}
