#!/bin/sh
binDir=/data/bin

mono $binDir/fslex.exe --unicode ExprLex.fsl \
  && mono $binDir/fsyacc.exe --module ExprPar ExprPar.fsy
