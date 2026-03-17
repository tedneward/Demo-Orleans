#!/bin/bash

# This script is used to determine the public IP address of the machine it is run on.
ifconfig | grep inet
