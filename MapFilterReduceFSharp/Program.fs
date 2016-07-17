open System.Collections.Generic
open System.Linq

let squareArray arr = 
    let result = new List<int>()
    for x in arr do
        result.Add(x * x)
    result.ToArray()

let getJpgImages images : string array = 
    let result = new List<string>()
    for x : string in images do
        if (x.EndsWith(".jpg")) then result.Add(x)
    result.ToArray()

let sum arr : int = 
    let mutable result : int = 0
    for x in arr do
        result <- result + x
    result

// Suponiendo que tenemos la siguiente estructura de ciudades
type City = 
    struct
        val Name : string
        val Population : int
        new(name : string, population : int) = 
            { Population = population
              Name = name }
    end

// Como tenemos las ciudades con poca población, vamos a escribir una función
// que nos ayude a escalar la población
let scale(city : City ) : City =
    new City ( city.Name, city.Population * 1000)

[<EntryPoint>]
let main argv = 

    System.Console.WriteLine("Map");
    // Map
    // El arreglo que queremos transformar
    let array = [| 2; 3; 4; 5; 6; 7; 8; 9; 10 |]
    //let squaredArray = squareArray array  // [4, 9, 16, 25, 36, 49, 64, 81, 100]
    let squaredArray = 
        array
        |> Array.map(fun x -> x * x)  // [4, 9, 16, 25, 36, 49, 64, 81, 100]

    for n in squaredArray do
        System.Console.Write(n.ToString() + " ")


    System.Console.WriteLine("\nFilter");
    // Filter
    // El arreglo que queremos filtrar
    let images = [| 
        "hello.jpg"
        "world.jpg" 
        "hola.png" 
        "mundo.png"
        "cats.jpg" 
        "dogs.png" |]
    //let jpgImages = getJpgImages images // ["hello.jpg", "world.jpg", "cats.jpg"]
    let jpgImages = 
        images
        |> Array.filter(fun image -> image.EndsWith(".jpg")) // ["hello.jpg", "world.jpg", "cats.jpg"]

    for images in jpgImages do
        System.Console.Write(images + " ")

    System.Console.WriteLine("\nReduce");
    // Reduce
    //let arraySum = sum(array); // 54

    let arraySum = 
        array
        |> Array.reduce(fun acc x -> acc + x) // 54

    System.Console.Write(arraySum)

    System.Console.WriteLine("\nCombinación");
    // Combinación
    // Vamos a definir varios ejemplos de ciudades, y meterlos en un arreglo
    let paris = new City("Paris", 2243)
    let madrid = new City("Madrid", 3216)
    let amsterdam = new City("Amsterdam", 811)
    let berlin = new City("Berlin", 3397)

    let cities = [|paris;madrid;amsterdam;berlin|]

    let citiesFilter = 
        cities
        |> Array.filter(fun city -> city.Population > 1000)
        |> Array.map(scale)
        |> Array.fold(fun result c -> result + sprintf "\n%s: %d" c.Name c.Population ) "City population"

    System.Console.WriteLine(citiesFilter)

    System.Console.ReadKey() |> ignore

    0 // devolver un código de salida entero
