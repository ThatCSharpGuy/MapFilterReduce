open System.Collections.Generic
open System.Linq

let squareArray arr = 
    let result = new List<int>()
    for x in arr do
        result.Add(x * x)
    result

let getJpgImages images : List<string> = 
    let result = new List<string>()
    for x : string in images do
        if (x.EndsWith(".jpg")) then result.Add(x)
    result

let sum (arr : List<int>) : int = 
    let mutable result : int = 0
    for x in arr do
        result <- result + x
    result

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

    // Map
    // El arreglo que queremos transformar
    let array = new List<int>([| 2; 3; 4; 5; 6; 7; 8; 9; 10 |])
    //let squaredArray = squareArray array
    let squaredArray = array.Select(fun x -> x * x).ToList()

    // Filter
    // El arreglo que queremos filtrar
    let images = new List<string>([| "hello.jpg"; "world.jpg"; "hola.png"; "mundo.png"; "cats.jpg"; "dogs.png" |])
    //let jpgImages = getJpgImages images
    let jpgImages = images.Where(fun image -> image.EndsWith(".jpg")).ToList()

    // Reduce

    //let arraySum = sum(array); // 54
    let arraySum = array.Aggregate(fun acc x -> acc + x)


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
