#!/bin/bash

# This checks if the number of arguments is correct
# If the number of arguments is incorrect ( $# != 2) print error message and exit
if [[ $# != 2 ]]
then
  echo "backup.sh target_directory_name destination_directory_name"
  exit
fi

# This checks if argument 1 and argument 2 are valid directory paths
if [[ ! -d $1 ]] || [[ ! -d $2 ]]
then
  echo "Invalid directory path provided"
  exit
fi

# [number 1]
targetDirectory=$1
destinationDirectory=$2

# [number 2]
echo "$1"
echo "$2"

# [number 3]
currentTS=$(date +%Y%m%d )

# [number 4]
backupFileName=""backup-[$currentTS].tar.gz

# We're going to:
  # 1: Go into the target directory
  # 2: Create the backup file
  # 3: Move the backup file to the destination directory

# To make things easier, we will define some useful variables...

# [number 5]
origAbsPath=`/home/project`

# [number 6]
cd origAbsPath # <-
destDirAbsPath=`/home/project`

# [number 7]
cd origAbsPath # <-
cd destDirAbsPath # <-

# [number 8]
yesterdayTS=$(($currentTS - 24*60*60))

declare -a toBackup

for file in $(ls) # [number 9]
do
  # [number 10]
  last_modified = `date -r $file +%s`
  if ((`date -r $file +%s` > $yesterdayTS))
  then
    # [number 11]
    toBackup+=($file)
  fi
done

# [number 12]
tar -czvf $backupFileName ${toBackup[@]}
# [number 13]
mv $backupFileName destDirAbsPath