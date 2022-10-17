# Assignment 06
## PLC-ex7.1
Run `compile.sh` in the docker container

`cleanup.sh` is provided to remove all files created by the compilation process.

## PLC-ex7.4
Placed in folder `PLC-ex7.4-5`

Changed in `Absyn.fs`: Line 26 and 27

Changed in `Interp.fs`: Line 197-206

## PLC-ex7.5
Placed in folder `PLC-ex7.4-5`

Changes in `CPar.fsy`: Line 136 and 137

We reuse the `PLUS` token from the lexer to create the parser, therefore no changes to `CLex.fsl`

See output of using the `test.c` file in `output.txt`:
```
$ ./compile.sh
> open ParseAndRun;;
> run (fromFile "test.c") [];;
0 1 0 val it : Interp.store = map [(0, 0)]
```
