#!/bin/bash
binDir=/data/bin
currDir=$PWD

mono $binDir/fslex.exe --unicode $currDir/CLex.fsl
mono $binDir/fsyacc.exe --module CPar $currDir/CPar.fsy

cd ../MicroC/
$binDir/compileMachine.sh

cp Absyn.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs $currDir 
cp Machine.class $currDir 
cd $currDir 

 fsharpi -r $binDir/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs   
