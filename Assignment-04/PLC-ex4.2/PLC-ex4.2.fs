//1
open Parse;;
open ParseAndRun;;

let e1 = fromString "let sum n = if 0<n then n + sum (n-1) else n in sum 1000 end";;
run e1;;                                                                            

//2
let e2 = fromString "let power n = if 0<n then 3 * power (n-1) else 1 in power 8 end";;
run e2;;

//3
let e3 = fromString "let power x = if 0 < x then 3 * power (x-1) else 1 in let plus n = if 0<n then power n + plus (n-1) else 1 in plus 6 end end";;
run e3;;

// 4
let e4 = fromString "let power x = x * x * x * x * x * x * x * x in let plus n = if 0<n then power n + plus (n-1) else 0 in plus 10 end end";;
run e4;;