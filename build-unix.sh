#!/bin/bash

# Probably should add parameters so the user can choose between the two,
# however I have no idea how to do that and I'm too lazy to learn.

mcs SPPI.cs -out:SPPI
mcs SPPI.cs -out:SPPI.exe
