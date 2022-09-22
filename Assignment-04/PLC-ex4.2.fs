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
//3
//4