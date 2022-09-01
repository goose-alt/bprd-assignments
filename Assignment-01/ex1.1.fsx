//Exercise 1.1

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | Max of expr * expr
  | Min of expr * expr
  | Equals of expr * expr
  | If of expr * expr * expr

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Max (e1,e2) -> if (eval e1 env) < eval e2 env then eval e2 env else eval e1 env
    | Min (e1,e2) -> if (eval e1 env) < eval e2 env then eval e1 env else eval e2 env
    | Equals (e1,e2) -> if (eval e1 env) = (eval e2 env) then 1 else 0
    | If (e1,e2,e3) -> if (eval e1 env) <> 0 then (eval e2 env) else (eval e3 env)
    | Prim(operand, e1, e2) -> 
                                        let i1 = eval e1 env
                                        let i2 = eval e2 env
                                        match operand with
                                        | "+" -> i1 + i2
                                        | "-" -> i1 - i2
                                        | "*" -> i1 * i2
                                        | _ -> failwith "unknown primitive";;