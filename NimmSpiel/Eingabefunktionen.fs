module Eingabefunktionen

open System
open Hilfsfunktionen

/// Die zwei Übergabewerte definieren eine untere und obere Grenze. Es wird ein Wert aus der
/// Konsole eingelesen ausgewertet. Die Funktion gibt 0 für den Fall Zurück, dass die Eingabe
/// nicht in dem festgelegten Bereich ist oder einen gültigen Wert. Es wird ein Hinweis
/// für den gültigen Bereich angezeigt
let startwertHolen untereGrenze obereGrenze (infoText: string) =
    //Console.Clear()
    printfn "%s" infoText
    printfn "Bitte geben Sie eine Zahl zwischen %i und %i ein..." untereGrenze obereGrenze

    let mutable tmpWert = 0
    let eingabeString = Console.ReadLine()

    let eingabeNumber = umwandelnInInteger32 (eingabeString)

    if eingabeNumber > 0 then
        if eingabeNumber < untereGrenze
        then printfn "Der Wert muss größer %i sein!" untereGrenze
        elif eingabeNumber > obereGrenze
        then printfn "Der Wert muss kleiner %i sein!" obereGrenze
        else tmpWert <- eingabeNumber

    tmpWert

/// Die zwei Übergabewerte definieren eine untere und obere Grenze. Die Funktion gibt
/// einen Wert wieder, der in dem definierten Bereich liegt.
let rec startwertFestlegen untereGrenze obereGrenze (infoText: string) =
    let iniVal =
        (startwertHolen untereGrenze obereGrenze infoText)

    if iniVal > 0
    then iniVal
    else startwertFestlegen untereGrenze obereGrenze infoText
