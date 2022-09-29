let merge a b =

    let rec aux acc = function
        | x :: xs, y :: ys -> 
            match x, y with
            | x, y when x =< y -> aux (x :: acc) (x :: xs) ys
            | 