//Exercise 2.2

type expr = 
  | CstI of int
  | Var of string
  | Let of (string * expr) list * expr
  | Prim of string * expr * expr;;

let rec mem x vs = 
    match vs with
    | []      -> false
    | v :: vr -> x=v || mem x vr;;

let rec union (xs, ys) = 
    match xs with 
    | []    -> ys
    | x::xr -> if mem x ys then union(xr, ys)
               else x :: union(xr, ys);;

let rec minus (xs, ys) = 
    match xs with 
    | []    -> []
    | x::xr -> if mem x ys then minus(xr, ys)
               else x :: minus (xr, ys);;

let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x  -> [x]
    | Let(ls, ebody) -> 
        union (getVars ls, freevars ebody)
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2)

and getVars list : string list =
    match list with
    | [] -> []
    | (x, e)::li -> union (minus (freevars e, [x]), getVars li);;

freevars (Let([("x1", Prim("+", Var "x1", CstI 7))], Prim("+", Var "x1", CstI 8)));;