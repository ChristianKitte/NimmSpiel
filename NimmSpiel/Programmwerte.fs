module Programmwerte

open Eingabefunktionen

let anfangswert =
    startwertFestlegen 5 10 "Mit wie vielen Punkten wollen sie spielen?"

let schrittwert =
    startwertFestlegen 1 3 "Wieviele Punkte dürfen maximal je Zug weggenommen werden?"
