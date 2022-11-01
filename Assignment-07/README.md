# Assignment 07
## PLC-ex8.1

In this exercise we have added the following two files containing the symbolic bytecode with the associtated Micro-c code:
- plc-ex8.1/ex3.comp.txt
- plc-ex8.1/ex5.comp.txt

All output of the program runs with both the Machine.java and Machinetrace.java can be found at:
- plc-ex8.1/output.txt
- plc-ex8.1/ex3trace.txt

In terms of the nested block, then by looking at the symbolic bytecode, it is not visible that there is a nested block
because the `INCSP 1` duplicates the top value of the stack. However, we can see when the nested block ends when the 
symbolic bytecode performs the `INCSP -1` twice in order to remove the variables and values that is no longer used in the scope of the block statement.

### Ex3 trace explanation 
The program have three main events. 
- Declaring and assigning variable `i`
- While condition `i < n`
- The increment `i = i + 1`

First and foremost, we can see that we declare and assign the variable `i` from line 3 - 9.

Then we want to start the loop. We do so by getting the value for variable `n` on the top of the stack. That happens from line 15-18.
This stores the value 4. Then the program can now begin to compare `i` and `n` with the `LT` operator(line 19). After that the `IFNZRO` decides whether or not if we should continue the loop or stop by checking the value put on the top of the stack by the previous `LT`. 
Examples of this is repeated in the trace file at lines 15-20, 43-48, 71-76, 99-104, and 127-132

Last but not least, the program has to increment `i` by doing the `i = i + 1`. This is being done by getting index of the `i` value. Then we try and get the current stored value of `i`. Afterwards we are putting the value 1 on top of the stack. Then we add the two values and store the result by using the `STI`. 
This happens in the trace at line 27-36, 55-64, 83-92, and 111-120.

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
