
## PLC 3.5-7
PLC 3.5-7 can be found in the folder PLC-ex3.5-7.

### 3.5
3.5 has been compiled using 2 scripts in the `bin` folder. First is `compileParser.sh` which compiles with fslex and fsyacc. And `compileAndRunParser.sh` runs that script and runs it in fsharpi

### 3.6
`compString` is located in `PLC-3.6.fs`

### 3.7
Change in `Absyn.fs` line 12

Change in `ExprLex.fsl` line 22-24

Change in `ExprPar.fsy` line 14 and line 36

Change in `Expr.fs` line 42, line 59 and line 87   

*note*: line 42 and 59 are just to make it compile, line 87 is where the expression is actually used. line 59 has not been tested and is probably wrong.
