open System.Collections.Generic
open System.Linq

let squareArray arr =
    let result = new List<int>();
    for x in arr do
        result.Add(x*x)
    result

let getJpgImages images : List<string> =
    let result = new List<string>()
    for x:string in images do
        if (x.EndsWith( ".jpg")) then 
            result.Add(x)
    result

let sum (arr : List<int>) : int =
    let mutable result:int = 0
    for x in arr do
        result <- result + x
    result

[<EntryPoint>]
let main argv = 
    // Map
    // El arreglo que queremos transformar
    let array = new List<int>( [| 2; 3; 4; 5; 6; 7; 8; 9; 10|]);

    //let squaredArray = squareArray array

    let squaredArray = array.Select(fun x -> x*x).ToList();
    
    // Filter
    // El arreglo que queremos filtrar
    let images = new List<string>([|
                                    "hello.jpg"
                                    "world.jpg"
                                    "hola.png"
                                    "mundo.png"
                                    "cats.jpg"
                                    "dogs.png"
                                |])

    //let jpgImages = getJpgImages images

    let jpgImages = images.Where(fun image -> image.EndsWith(".jpg")).ToList()

    // Reduce
    // 

    //let arraySum = sum(array); // 54

    let arraySum = array.Aggregate( fun acc x -> acc + x)

    printf "%d" arraySum
//    let arraySum = array.Aggregate( fun acc x -> acc + x)

    System.Console.ReadKey() |> ignore

    0 // devolver un código de salida entero


