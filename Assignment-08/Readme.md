# Assignment 08

## PLC 9.1
Explanations of the .NET Common Language Infrastructure bytecode can be found in `PLC-ex9.1/Selsort.il`

Explanations of the JVM byte code can be found in `PLC-ex9.1/Selsort.jvmbytecode`

## PLC 9.3
Changes in QueueWithMistake.java: line 112-114

The memory mistake is that the dummy node keeps pointing to the node which is first popped, which keeps pointing to
the next popped node, and so on. So the queue keeps growing even when nodes are popped. This can be solved by setting
first.next to null.
