using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFilterReduce
{
    class Program
    {
        static void Main(string[] args)
        {
            // Map
            // El arreglo que queremos transformar
            var array = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var squaredArray = SquareArray(array); // [4, 9, 16, 25, 36, 49, 64, 81, 100]

            var squaredArray = array.Select(x => x * x).ToArray();

            // Filter
            // El arreglo que queremos filtrar
            var images = new List<string> {
              "hello.jpg",
              "world.jpg",
              "hola.png",
              "mundo.png",
              "cats.jpg",
              "dogs.png"
            };

            //var jpgImages = GetJpgImages(images);

            var jpgImages = images.Where(image => image.EndsWith(".jpg")).ToList(); // ["hello.jpg", "world.jpg", "cats.jpg"]

            // Reduce
            // 

            //var arraySum = Sum(array); // 54

            var arraySum = array.Aggregate((acc, x) => acc + x);

            Console.WriteLine(arraySum);

            Console.Read();
        }

        // Creamos la función que modificará los elementos  
        // del arreglo elevándolo al cuadrado
        static List<int> SquareArray(List<int> arr)
        {
            var result = new List<int>();

            foreach (var x in arr)
            {
                result.Add(x * x);
            }

            return result.ToList();
        }

        public static List<string> GetJpgImages(List<string> images)
        {
            var results = new List<string>();

            foreach (var image in images)
            {
                if (image.EndsWith(".jpg"))
                {
                    results.Add(image);
                }
            }

            return results;
        }

        public static int Sum(List<int> arr)
        {
            var acc = 0;

            foreach (var value in arr)
            {
                acc += value;
            }

            return acc;
        }

    }
}
