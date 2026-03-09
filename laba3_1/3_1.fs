open System

/// Нахождение минимальных цифр
let rec minNum num min =
    if num < 10 then
        if num < min then num else min
    else
        if num % 10 < min then
            minNum (num / 10) (num % 10)
        else
            minNum (num / 10) min

let findMinNum numbers =
    numbers |> Seq.map (fun x -> minNum x 10)

[<EntryPoint>]
let main argv =
    printf "Введите кол-во эл списка: "
    let countEl = int (Console.ReadLine())
    
    if countEl > 0 then
        printfn "Введите эл списка: "
        let numbersList = [ for i in 0 .. countEl - 1 -> int(Console.ReadLine()) ]
        let numbersSeq = numbersList |> Seq.ofList
        let minDigits = findMinNum numbersSeq
        printfn "Исходные числа: %A" numbersList
        printfn "Минимальные цифры: %A" (minDigits |> Seq.toList)
    else
        printfn "Некорректный ввод"
    
    0
