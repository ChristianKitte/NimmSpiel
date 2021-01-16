module Programm

open System
open Eingabefunktionen
open Programmwerte
open Programmlogik

///Einstiegspunkt der Anwendung
[<EntryPoint>]
let main argv =
    let anfangswert' = anfangswert
    let schrittwert' = schrittwert

    let spieler1 =
        ("Spieler 1", anfangswert', schrittwert')

    let spieler2 =
        ("Spieler 2", anfangswert', schrittwert')

    let rec spiel spieler1 spieler2 =
        let standSpieler1 = zugSpieler spieler1

        let wertSpieler1 =
            match standSpieler1 with
            | (a, b, c) -> b

        if wertSpieler1 <= 0 then
            standSpieler1
        else
            let spieler2 =
                ("Spieler 2", wertSpieler1, schrittwert')

            let standSpieler2 = zugSpieler spieler2

            let wertSpieler2 =
                match standSpieler2 with
                | (a, b, c) -> b

            if (wertSpieler2) <= 0 then
                standSpieler2
            else
                let spieler1 =
                    ("Spieler 1", wertSpieler2, schrittwert')

                spiel spieler1 standSpieler2



    let result = spiel spieler1 spieler2
    let dump = Console.ReadLine()
    0
