(*
open System

///module Hilfsfunktionen
/// Gibt die dritte Stelle eines dreier Tupels wieder
let first (a, _, _) = a

/// Gibt die zweite Stelle eines dreier Tupels wieder
let second (_, b, _) = b

/// Gibt die dritte Stelle eines dreier Tupels wieder
let third (_, _, c) = c

/// Testet den übergebenen Text auf Int32. Handelt es sich um einen gültigen Wert, so
/// wird der Betrag des Wertes zurück gegeben, ansonsten -1
let umwandelnInInteger32 integerString =
    let couldParse, parsedInt =
        System.Int32.TryParse(integerString: string)

    if couldParse then System.Math.Abs(parsedInt) else -1

/// module Eingabefunktionen
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


///module Programmwerte
/// Fragt den anfänglichen Punktestand vom Nutzer ab und gibt ihn zurück. Dieser muss in dem Bereich
/// von minimum und maximum liegen
let anfangswert minimum maximum =
    startwertFestlegen minimum maximum "Mit wie vielen Punkten wollen sie spielen?"

/// Fragt vom Nutzer den Bereich ab, mit den Punkte weggenommen werden dürfen.
/// Dieser muss in dem Bereich von minimum und maximum liegen
let schrittwert minimum maximum =
    startwertFestlegen minimum maximum "Wieviele Punkte dürfen maximal je Zug weggenommen werden?"

/// module Programmlogik
/// Fragt für den übergebenen Spieler ab, wieviele Punkte weggenommen werden sollen und
/// liefert einen dreier Tupel zurück in der Bedeutung: (spieler, aktuelle punkte, aktuell
/// eingestellte Schrittweite)
let zugSpieler (spieler, aktuellerWert, schrittwert) =
    let anzeige =
        sprintf
            "%s : %i Punkte sind noch verfügbar. Wieviel Punkte wollen sie wegnehmen? (%i bis %i)"
            spieler
            aktuellerWert
            1
            schrittwert

    let schritt = startwertFestlegen 1 schrittwert anzeige

    (spieler, aktuellerWert - schritt, schrittwert)

/// Führt das eigentliche Spiel aus. Hierbei werden die Züge der Beiden Spieler der Reihe nach
/// abgearbeitet. Erreicht ein Spieler 0 oder weniger, so hat dieser Spieler gewonne und die Funktion
/// verlassen. Gewinnt keiner der Beiden Spieler bei einem Durchgang, so wird die Funktion rekursiv
/// neu aufgerufen.
let rec spiel spieler1 spieler2 =
    /// Zug Spieler 1 ausführen
    let standSpieler1 = zugSpieler spieler1

    let wertSpieler1 =
        match standSpieler1 with
        | (a, b, c) -> b

    if wertSpieler1 <= 0 then
        /// Rückkehr mit Spieler 1 als Gewinner
        standSpieler1
    else
        /// Spieler 2 aktualisieren und Zug Spieler 2 ausführen
        let spieler2 =
            ("Spieler 2", wertSpieler1, (third spieler2))

        let standSpieler2 = zugSpieler spieler2

        let wertSpieler2 =
            match standSpieler2 with
            | (a, b, c) -> b

        if (wertSpieler2) <= 0 then
            /// Rückkehr mit Spieler 2 als Gewinner
            standSpieler2
        else
            /// Spieler 1 aktualisieren und nächster Durchgang
            let spieler1 =
                ("Spieler 1", wertSpieler2, (third spieler1))

            spiel spieler1 standSpieler2

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

    if finalerPunktestand < 0
    then printfn "Der Spieler %s ist unter Null gekommen und hat verloren!" sieger
    else printfn "Der Gewinner ist %s!" sieger

    printfn "(zum beenden ENTER drücken)"
    let tmp = System.Console.ReadLine()

    0
    *)
