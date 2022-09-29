## PLC 4.1
We ran the commands in the Readme.txt. The results from running those commands can be 
found in the PLC-ex4.1/result.txt.

## PLC 4.2
We have created each of the different functions in our language. We have typed it in the 
F# interactive terminal and saved the results in the PLC-ex4.2/output.txt.

To get a better overview of the functions created see: PLC-ex4.3-4/PLC-ex4.2.fs

## PLC 4.3
The changed files are:
- PLC-ex4.3-4/Absyn.fs   --> line 12
- PLC-ex4.3-4/Fun.fs     --> line 27, 62-65, 75-76, 80-86, 92-96, 104-105, and 110-116
- PLC-ex4.3-4/FunPar.fsy --> line 30, 60, and 65-66

## PLC 4.4
The changed files and lines are:
- PLC-ex4.3-4/Absyn.fs      --> line 13
- PLC-ex4.3-4/FunPar.fsy    --> line 31 and 65-71

### Example execution
```
> run (fromString "let add x y = x + y in add 1 2 end");;
val it : int = 3

> run (fromString "let addMore x y z = x + y + z in addMore 1 2 3 end");;
val it : int = 6
```

## PLC 4.5
The changed files and lines are:
- PLC-ex4.5/FunLex.fsi --> line 51-52
- PLC-ex4.5/FunPar.fsy --> line 16, line 22, and line 54-55

### How to run
PLC 4.5 needs to use `Absyn.fs` and `Fun.fs` from PLC-ex4.3-4, and Parse.fs from the course Github.

### Example execution
```
> run (fromString "let f x = if x=1 && 2=2 then 1 else 2 in f 1 end");;
val it : int = 1
```

