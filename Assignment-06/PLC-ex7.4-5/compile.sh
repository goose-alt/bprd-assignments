#!/bin/bash
binDir=/data/bin
currDir=$PWD

cd ../MicroC/
$binDir/compileLexer.sh C

cp CLex.fs Parse.fs ParseAndRun.fs $currDir 
cd $currDir 

$binDir/compileParser.sh C

fsharpi -r $binDir/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Interp.fs ParseAndRun.fs   
