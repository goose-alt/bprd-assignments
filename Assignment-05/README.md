# Assignment 05
## PLC-ex5.7
Solution is in file `TypeInference.fs` line 56,110,139,153,183,189,230.

It compiles, but is rather hard to check. Due to the wording of the assignment we have decided not to implement the list type on the parser which means there is no way to test the type inference on the language.

## PLC-ex6.5
### 1)
```
inferType (fromString "let f x = 1 in f f end");;
val it : string = "int"

inferType (fromString "let f g = g g in f end");;
# Failed with circularity. g in this case references itself, making an infinite type

inferType (fromString @"let f x =
  let g y = y
  in g false end
in f 42 end");;
val it : string = "bool"

inferType (fromString @"let f x =
  let g y = if true then y else x
  in g false end
in f 42 end");;
# Failed with incombatability. x is anything in the if statement, while y is set to bool in the line below. When x is then set to int in the outer scope, it creates a conflict as all branches of an if statement must return the same type. So having it return bool and int is no good.

inferType (fromString @"let f x =
  let g y = if true then y else x
  in g false end
in f true end");;
val it : string = "bool"
```

### 2)
```
// bool -> bool
> inferType (fromString "let f x = if x then true else false in f end");;
val it : string = "(bool -> bool)"

// int -> int
> inferType (fromString "let f x = x + 1 in f end");;
val it : string = "(int -> int)"

// int -> int -> int
> inferType (fromString @"
  let f x = 
    let g y =
      x + y
    in g end
  in f end
");;
val it : string = "(int -> (int -> int))"

// 'a -> 'b -> 'a
> inferType (fromString @"
  let f x = 
    let g y =
      x
    in g end
  in f end
");;
val it : string = "('h -> ('g -> 'h))"

// 'a -> 'b -> 'b
> inferType (fromString @"
  let f x = 
    let g y =
      y
    in g end
  in f end
");;
val it : string = "('g -> ('h -> 'h))"

// (’a -> ’b) -> (’b -> ’c) -> (’a -> ’c)
> inferType(fromString @"
  let tw g = 
    let app f =
      let t x = f (g x) in t end
    in app end 
  in tw end
");;
val it : string = "(('l -> 'k) -> (('k -> 'm) -> ('l -> 'm)))"

// ’a -> ’b 
> infertype(fromstring @"
  let f =
    let x = x in 1 end
  in f end
");;
val it : string = "('i -> 'j)"

// TODO: 'a
```

