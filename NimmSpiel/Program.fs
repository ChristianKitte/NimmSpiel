module Programm

open System
open Eingabe

///Einstiegspunkt der Anwendung
[<EntryPoint>]
let main argv =
    let Anfangswert =
        startwertFestlegen 5 10 "Mit welchen Anfangswert soll das Spiel beginnen?"

    let Schrittwert =
        startwertFestlegen 1 3 "Wie groß soll die Spanne je Zug sein?"

    let dump = Console.ReadLine()
    0
