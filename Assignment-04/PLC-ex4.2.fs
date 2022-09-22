//1
> let e1 = fromString "let sum n = if 0<n then n + sum (n-1) else n in sum 1000 end";;
val e1: Absyn.expr =
  Letfun
    ("sum", "n",
     If
       (Prim ("<", CstI 0, Var "n"),
        Prim ("+", Var "n", Call (Var "sum", Prim ("-", Var "n", CstI 1))),
        Var "n"), Call (Var "sum", CstI 1000))

> run e1;;                                                                            
val it: int = 500500

//2
> let e2 = fromString "let power n = if 0<n then 3 * power (n-1) else 1 in power 8 end";;
val e2: Absyn.expr =
  Letfun
    ("power", "n",
     If
       (Prim ("<", CstI 0, Var "n"),
        Prim ("*", CstI 3, Call (Var "power", Prim ("-", Var "n", CstI 1))),
        CstI 1), Call (Var "power", CstI 8))

> run e2;;
val it: int = 6561

//3
let e3 = fromString "let plus n = if 0<n then e2 n + plus n-1 else 1 in plus 11 end";;
let e3 = fromString "let power n = if 0 < n then 3 * power (n-1) else 1 in let plus m = if 0 < m then (power m) + (plus (m-1)) else 1 in plus 11 end end";;

//4