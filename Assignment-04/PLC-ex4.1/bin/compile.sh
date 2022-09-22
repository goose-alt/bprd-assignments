mono fslex.exe --unicode FunLex.fsl \
  && fsharpi ./FsLexYacc.Runtime.dll ../Absyn.fs ../FunPar.fs ../FunLex.fs ../Parse.fs ../Fun.fs ../ParseAndRun.fs \
  && MONO_PATH=./bin mono FunLex.exe
