if [ "$#" -ne 2 ]; then
    echo "Usage: $0 <keystore path> <keystore alias>"
    exit 1
fi

echo "make sure you have a device connected (through abd devices)"
./export-android.sh $1 $2

# change if you're not me
platform_tools=/home/toddynho/Android/Sdk/platform-tools

$platform_tools/adb install MarkisaOS-Android.apk
