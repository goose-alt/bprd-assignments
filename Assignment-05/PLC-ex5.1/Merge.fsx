module Merge

let merge a b =

    let rec aux acc a b = 
        match a, b with
        | [], [] -> acc
        | x :: xs, [] -> aux (x :: acc) xs []
        | [], y :: ys -> aux (y :: acc) [] ys
        | x :: xs, y :: ys when x <= y -> aux (x :: acc) xs (y :: ys)
        | x :: xs, y :: ys -> aux (y :: acc) (x::xs) ys
    
    List.rev (aux [] a b);;

let res = merge [3; 5; 12] [2;3;4;7];;
