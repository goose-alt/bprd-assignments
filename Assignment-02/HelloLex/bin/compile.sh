mono ./bin/fslex.exe --unicode hello.fsl \
  && fsharpc -r ./bin/FsLexYacc.Runtime.dll hello.fs \
  && MONO_PATH=./bin mono hello.exe
