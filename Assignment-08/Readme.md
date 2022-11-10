# Assignment 08

## PLC 9.1

## PLC 9.3
Changes in QueueWithMistake.java: line 112-114

The memory mistake is that the dummy node keeps pointing to the node which is first popped, which keeps pointing to
the next popped node, and so on. So the queue keeps growing even when nodes are popped. This can be solved by setting
first.next to null.