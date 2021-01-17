module Programmlogik

open Eingabefunktionen
open Hilfsfunktionen

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
