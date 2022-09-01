type expr = 
   | CstI of int
   | Var of string
   | Let of (string * expr) list * expr
   | Prim of string * expr * expr;;

type texpr =                            (* target expressions *)
  | TCstI of int
  | TVar of int                         (* index into runtime environment *)
  | TLet of texpr * texpr               (* erhs and ebody                 *)
  | TPrim of string * texpr * texpr;;


(* Map variable name to variable index at compile-time *)

let rec getindex vs x = 
    match vs with 
    | []    -> failwith "Variable not found"
    | y::yr -> if x=y then 0 else 1 + getindex yr x;;

(* Compiling from expr to texpr *)

let rec tcomp (e : expr) (cenv : string list) : texpr =
  match e with
  | CstI i -> TCstI i
  | Var x  -> TVar (getindex cenv x)
  | Let(erhs, ebody) -> bind erhs cenv ebody
  | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv)
and bind erhs cenv ebody = 
  match erhs with
  | [] -> failwith "Missing 'let' expression" // There needs to be at least one let expression in order to compute the next expression
  | (x, xExpr ) :: [] -> x :: cenv 
                                        |> fun cenv1 -> TLet(tcomp xExpr cenv, tcomp ebody cenv1)
  | (x, xExpr) :: xs -> x :: cenv 
                                                              |> fun cenv1 -> TLet(tcomp xExpr cenv, bind xs cenv1 ebody);;

