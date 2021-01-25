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
    let anfangswert' = anfangswert 5 20
    let schrittwert' = schrittwert 3 6

    /// Spieler definieren
    let spieler1 =
        ("Spieler 1", anfangswert', schrittwert')

    let spieler2 =
        ("Spieler 2", anfangswert', schrittwert')

    /// Spiel starten. Kehrt zurück, wenn das Spiel beendet ist
    let spielergebnis = spiel spieler1 spieler2
    let finalerPunktestand = second spielergebnis
    let sieger = first spielergebnis

    System.Console.Clear()

    if finalerPunktestand < 0 then
        printfn "Der Spieler %s ist unter Null gekommen und hat verloren!" sieger
    else
        printfn "Der Gewinner ist %s!" sieger

    printfn "(zum beenden ENTER drücken)"
    let tmp = System.Console.ReadLine()

    0
