#!/bin/bash

pdfcrop $1.pdf
pdftoppm $1-crop.pdf | pnmtopng > $1.png

rm $1-crop.pdf
