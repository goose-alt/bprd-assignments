#!/bin/bash
binDir=/data/bin
currDir=$PWD

$binDir/compileParser.sh C
$binDir/compileLexer.sh C

cd ../../MicroC/
$binDir/compileMachine.sh

cp Parse.fs Machine.fs ParseAndComp.fs $currDir 
cp Machine.class $currDir 
cd $currDir 

fsharpi -r $binDir/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs
