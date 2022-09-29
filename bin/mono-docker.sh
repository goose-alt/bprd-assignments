#!/bin/bash

docker run \
  -v $PWD:/data \
  -it mono:latest bash
