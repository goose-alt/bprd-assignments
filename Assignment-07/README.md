# Assignment 07
## PLC-ex8.1

In this exercise we have added the following two files containing the symbolic bytecode with the associtated Micro-c code:
- plc-ex8.1/ex3.comp.txt
- plc-ex8.1/ex5.comp.txt

All output of the program runs with both the Machine.java and Machinetrace.java can be found at:
- plc-ex8.1/output.txt

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
