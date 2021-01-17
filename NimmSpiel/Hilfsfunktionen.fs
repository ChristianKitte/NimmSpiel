module Hilfsfunktionen

open System

/// Gibt die dritte Stelle eines dreier Tupels wieder
let first (a, _, c) = a

/// Gibt die dritte Stelle eines dreier Tupels wieder
let third (_, _, c) = c

/// Testet den übergebenen Text auf Int32. Handelt es sich um einen gültigen Wert, so
/// wird der Betrag des Wertes zurück gegeben, ansonsten -1
let umwandelnInInteger32 integerString =
    let couldParse, parsedInt =
        System.Int32.TryParse(integerString: string)

    if couldParse then System.Math.Abs(parsedInt) else -1
