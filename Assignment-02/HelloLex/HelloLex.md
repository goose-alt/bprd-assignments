# HelloLex
## Question 1
The rule is just `[0-9]`, which in most cases is the same as `\d`.

## Question 2
Running `mono fslex.exe hello.fsl` generates a `.fs` file.

Depending on how you draw the graph, there is probably only 3 states. The start and final state, and the 10 edges between those nodes. The final state is the fail state, essentially everything that is not those.

## Question 3
```
# mono ../../bin/fslex.exe --unicode hello.fsl
compiling to dfas (can take a while...)
3 states
writing output
# fsharpc -r ../../bin/FsLexYacc.Runtime.dll hello.fs
Microsoft (R) F# Compiler version 11.0.0.0 for F# 5.0
Copyright (c) Microsoft Corporation. All Rights Reserved.
# mono hello.exe
Hello World from FsLex!

Please pass a digit:
2
The lexer recognizes 2
```

## Question 4
Add to `hello.fsl`:
```
| ['0'-'9']+      { LexBuffer<char>.LexemeString lexbuf }
```

## Question 5
Add to `hello.fsl`:
```
| ['+''-']?(['0'-'9']*['.'])?['0'-'9']+ { LexBuffer<char>.LexemeString lexbuf }
```

## Note
`hello.fsl` contains a slightly simplified version of the code show above

### Compilation
To make life easier i have added 2 scripts to `./bin`, both assume that `PWD` is in `Assignment-02/HelloLex`.

First is `./bin/mono-docker.sh` which is just a docker image that contains mono and fsharpc, this eliminates having to install those.

The second script is `./bin/compile.sh` which contains the entire compile and run sequence necessary to compile and run `hello.fsl`
