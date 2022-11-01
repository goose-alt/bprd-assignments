# Assignment 07
## PLC-ex8.1
## PLC-ex8.3
All contained in `PLC-ex8.3` folder.

Changed files are the following:
- `CLex.fsl` line 53 and 54.
- `CPar.fsy` line 18, 136 and 137
- `Absyn.fs` line 26 and 27
- `Comp.fs` line 209-212
- `test.c` entire file, simply a test of the program.

### Example output:
```
$ ./compile.sh
...compilation output

> open ParseAndComp;;
> compileToFile (fromFile "test.c") "test";;
...instruction output
> #quit;;

$ java Machine test
0 1 0
Ran 0.001 seconds
```

## PLC-ex8.4
## PLC-ex8.5
## PLC-ex8.6
All contained in `PLC-ex8.6` folder.

Changed files are the following:
- `CLex.fsl` line 31,32 and 78.
- `CPar.fsy` line 19, 22, 92-94 and 108
- `Absyn.fs` line 38
- `Comp.fs` line 147-157 
- `test.c` entire file, simply a test of the program.


```

$ ./compile.sh
...compilation output

> open ParseAndComp;;
> compileToFile (fromFile "test.c") "test";;
...instruction output
> #quit;;

$ java Machine test 1
31 4
Ran 0.001 seconds
```
