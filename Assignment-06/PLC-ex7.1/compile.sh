#!/bin/bash
binDir=/data/bin

cd ../MicroC/
$binDir/compileLexer.sh C
$binDir/compileParser.sh C

cp Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs ../PLC-ex7.1
cd ../PLC-ex7.1

 fsharpi -r $binDir/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs   
