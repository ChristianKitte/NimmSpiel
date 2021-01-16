module Programmlogik

open Eingabefunktionen

let zugSpieler (spieler: string, aktuellerWert, schrittwert) =
    let schritt =
        startwertFestlegen 1 schrittwert "Wieviel Punkte wollen sie wegnehmen?"

    (spieler, aktuellerWert - schritt, schrittwert)
