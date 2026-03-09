open System

/// проверка на наличие необходимого числа
let rec recNum num required_number = 
    if num < 10 then
        if num = required_number then
            1
        else
            0
    else
        if num % 10 = required_number then
            1
        else
            recNum (num/10) required_number

/// Перебор элементов в seq
let findNum numbers required_number = 
    seq {
        for num in numbers do
            yield recNum (abs(num)) required_number
    }

[<EntryPoint>]
let main args = 
    printf "Введите кол-во эл списка: "
    let countEl = int(Console.ReadLine())
    if countEl > 0 then
        printfn "Введите эл списка: "
        let numbers = [
            for i in 0..countEl-1 -> 
                int(Console.ReadLine())
        ]
        printf "Какое число необходимо найти: "
        let requiredNumber = int(Console.ReadLine())
        let numbersSeq = numbers |> Seq.ofList
        let listNum = findNum numbersSeq requiredNumber
        let sum = 
            Seq.fold 
                (fun acc x -> acc + x) 
                0 
                listNum
        printfn "Кол-во чисел с %i: %i" requiredNumber sum
    else
        printfn "Некорректный ввод"
    0