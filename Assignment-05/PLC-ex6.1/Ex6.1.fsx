module EX6

open ParseAndRunHigher;;

let e1 = run (fromString "let add x = let f y = x+y in f end in add 2 5 end");;

let e2 = run (fromString "let add x = let f y = x+y in f end in let addtwo = add 2 in addtwo 5 end end");;

let e3 = run (fromString "let add x = let f y = x+y in f end in let addtwo = add 2 in let x = 77 in addtwo 5 end end end");;

let e4 = run (fromString "let add x = let f y = x+y in f end in add 2 end");;