binDir=/data/bin

mono fslex.exe --unicode FunLex.fsl \
  && fsharpi $binDir/FsLexYacc.Runtime.dll ../Absyn.fs ../FunPar.fs ../FunLex.fs ../Parse.fs ../Fun.fs ../ParseAndRun.fs \
  && MONO_PATH=$binDir mono FunLex.exe
