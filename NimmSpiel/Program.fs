module Programm

open System

open Hilfsfunktionen
open Eingabefunktionen
open Programmwerte
open Programmlogik

///Einstiegspunkt der Anwendung
[<EntryPoint>]
let main argv =
    /// Anfangswerte festlegen lassen
    let anfangswert' = anfangswert 5 10
    let schrittwert' = schrittwert 1 3

    /// Spieler definieren
    let spieler1 =
        ("Spieler 1", anfangswert', schrittwert')

    let spieler2 =
        ("Spieler 2", anfangswert', schrittwert')

    /// Spiel starten. Kehrt zurück, wenn ein Sieger existiert und das Spiel beendet ist
    let spielergebnis = spiel spieler1 spieler2
    let sieger = first spielergebnis

    System.Console.Clear()
    printfn "Der Gewinner ist %s!" sieger
    printfn "(zum beenden ENTER drücken)"

    let tmp = System.Console.ReadLine()
    0
