#!/bin/sh
binDir=/data/bin

$binDir/compileParser.sh \
  && fsharpi -r $binDir/FsLexYacc.Runtime.dll Absyn.fs ExprPar.fs ExprLex.fs Parse.fs Expr.fs
