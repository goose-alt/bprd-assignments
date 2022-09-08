//PLC Exercise 2.4 and 2.5
type sinstr =
  | SCstI of int                        (* push integer           *)
  | SVar of int                         (* push variable from env *)
  | SAdd                                (* pop args, push sum     *)
  | SSub                                (* pop args, push diff.   *)
  | SMul                                (* pop args, push product *)
  | SPop                                (* pop value/unbind var   *)
  | SSwap;;                             (* exchange top and next  *)

let sinstrToInt  = function 
    | SCstI x -> [0; x]
    | SVar x -> [1; x]
    | SAdd -> [2]
    | SSub -> [3]
    | SMul -> [4]
    | SPop -> [5]
    | SSwap -> [6]

let assemble instrs = 
    let accumulator xs = function
        | x :: y :: [] -> x :: y :: xs
        | x :: [] -> x :: xs
        | _ -> failwith "No corresponding instruction form"

    List.foldBack (fun instr acc -> sinstrToInt instr |> accumulator acc) instrs []

let intsToFile (inss : int list) (fname : string) = 
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text);;