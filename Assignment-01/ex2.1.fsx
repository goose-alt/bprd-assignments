//Exercise 2.1

type expr = 
  | CstI of int
  | Var of string
  | Let of (string * expr) list * expr
  | Prim of string * expr * expr;;

  let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Let(ls, ebody) -> eval ebody (bind ls env) 
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim _            -> failwith "unknown primitive"

and bind (lis : (string * expr) list) (env : (string * int) list) =
    match lis with
    | [] -> env
    | (x,e)::li ->
                    let xval = eval e env
                    let env1 = (x, xval) :: env 
                    bind li env1;;     
