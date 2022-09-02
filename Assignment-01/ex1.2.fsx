// (i)
// Declare an alternative datatype aexpr for a representation of arithmetic ex- pressions without let-bindings.
// The datatype should have constructors CstI, Var, Add, Mul, Sub, for constants, variables, addition, multiplication, and subtraction.
// Then x ∗ (y + 3) is represented as Mul(Var "x", Add(Var "y", CstI 3)), not as Prim("*", Var "x", Prim("+", Var "y", CstI 3)).


let rec lookup env x = 
    match env with
    | [] -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

type aexpr = 
    | CstI of int
    | Var of string
    | Add of aexpr * aexpr
    | Mul of aexpr * aexpr
    | Sub of aexpr * aexpr 

let rec eval (a: aexpr) (env: (string * int) list) : int =
    match a with
    | CstI i -> i
    | Var x -> lookup env x
    | Add (x, y) -> eval x env + eval y env
    | Mul (x, y) -> eval x env * eval y env
    | Sub (x, y) -> eval x env - eval y env

// (ii)
// Write the representation of the expressions v − (w + z) and 2 ∗ (v − (w + z)) 
let rep1 = Sub(Var "v", Add(Var "w", Var "z"))
let rep2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))
let rep3 = Add(Var "x", Add(Var "y", Add(Var "z", Var "v")))

let rec fmt (a: aexpr) : string =
    match a with
    | CstI i -> i.ToString()
    | Var x -> x
    | Add (x, y) -> $"({fmt x} + {fmt y})"
    | Mul (x, y) -> $"({fmt x} * {fmt y})"
    | Sub (x, y) -> $"({fmt x} - {fmt y})"

let rec basicSimplify (a: aexpr) : aexpr = 
    match a with
    | CstI i -> CstI i
    | Var x -> Var x
    | Add (CstI 0, y) -> simplify y
    | Add (y, CstI 0) -> simplify y
    | Sub (y, CstI 0) -> simplify y
    | Mul (CstI 1, y) -> simplify y
    | Mul (y, CstI 1) -> simplify y
    | Mul (CstI 0, _) -> CstI 0
    | Mul (_, CstI 0) -> CstI 0
    | Sub (x, y) when x = y -> CstI 0
    | Add (x, y) -> Add(simplify x, simplify y)
    | Mul (x, y) -> Mul(simplify x, simplify y)
    | Sub (x, y) -> Sub(simplify x, simplify y)
and simplify (a: aexpr) : aexpr = 
    match a with
    | CstI i -> CstI i
    | Var x -> Var x
    | Add (x, y) -> basicSimplify (Add(basicSimplify x, basicSimplify y))
    | Mul (x, y) -> basicSimplify (Mul(basicSimplify x, basicSimplify y))
    | Sub (x, y) -> basicSimplify (Sub(basicSimplify x, basicSimplify y))

let rec diff (a: aexpr) (var: string) =
    match a with
    | CstI _ -> CstI 0 // d/dx[c] = 0
    | Var x when x = var -> CstI 1 // d/dx[x] = 1
    | Var _ -> CstI 0 // d/dx[v] = 0
    | Add(u, v) -> Add(diff u var, diff v var) // d/dx[u + v] = d/dx[u] + d/dx[v]
    | Sub(CstI 0, v) -> diff v var // d/dx[-v] = -d/dx[v]
    | Sub(u, v) -> Sub(diff u var, diff v var) // d/dx[u - v] = d/dx[u] - d/dx[v]
    | Mul(u, v) -> Mul(u, Add(diff v var, Mul(v, diff u var))) // d/dx[u * v] = u * d/dx[v] + v * d/dx[u] 

    