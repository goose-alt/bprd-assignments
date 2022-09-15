module PLC

open Expr
open Parse

let compString (s: string) : sinstr list =
  scomp (fromString s) []
