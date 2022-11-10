#!/bin/bash
binDir=/data/bin
currDir=$PWD

$currDir/compileLexer.sh C
$currDir/compileParser.sh C

cd ../../MicroC/
$binDir/compileMachine.sh

cp Parse.fs Machine.fs ParseAndComp.fs $currDir 
cp Machine.class $currDir 
cd $currDir 

fsharpi -r $binDir/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs   
