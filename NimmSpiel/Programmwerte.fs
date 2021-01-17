module Programmwerte

open Eingabefunktionen

/// Fragt den anfänglichen Punktestand vom Nutzer ab und gibt ihn zurück. Dieser muss in dem Bereich
/// von minimum und maximum liegen
let anfangswert minimum maximum =
    startwertFestlegen minimum maximum "Mit wie vielen Punkten wollen sie spielen?"

/// Fragt vom Nutzer den Bereich ab, mit den Punkte weggenommen werden dürfen.
/// Dieser muss in dem Bereich von minimum und maximum liegen
let schrittwert minimum maximum =
    startwertFestlegen minimum maximum "Wieviele Punkte dürfen maximal je Zug weggenommen werden?"
