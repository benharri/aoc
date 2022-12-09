#!/bin/sh

. ./session_cookie.txt

if [ -z "$session" ]; then
  printf "missing session cookie\n"
fi

if [ -z "$1" ]; then
  year=$(date +"%Y")
else
  year="$1"
fi

if [ -z "$2" ]; then
  day=$(date +"%_d")
else
  day="$2"
fi

mkdir -p "$(printf "AOC%s/input%s" "$year" "$year")"

puzzleName=$(curl -s https://adventofcode.com/"$year"/day/"$day" | sed -nr 's/.*--- Day [[:digit:]]+: (.*) ---.*/\1/p')

curl -s https://adventofcode.com/"$year"/day/"$day"/input \
  --cookie "session=$session" \
  -o "$(printf "AOC%s/input%s/day%02d.in" "$year" "$year" "$day")"
  
touch "$(printf "AOC%s/input%s/test%02d.in" "$year" "$year" "$day")"

class=$(printf "AOC%s/Day%02d.cs" "$year" "$day")
longDay=$(printf "%02d" "$day")

if [ ! -f "$class" ]; then
  sed -e "s/Q/$day/g" -e "s/XX/$longDay/g" -e "s/YYYY/$year/g" -e "s/Puzzle Name/$puzzleName/g" DayXX.cs.txt >"$class"
fi
