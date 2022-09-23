#!/bin/sh
CURRENT_DIR="$( cd "$( dirname "$0" )" && pwd )"
BIN_DIR=$CURRENT_DIR/../bin

mono $BIN_DIR/fslex.exe --unicode FunLex.fsl \
    && dotnet fsi -r $BIN_DIR/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs Fun.fs ParseAndRun.fs