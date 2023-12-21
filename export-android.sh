if [ "$#" -ne 2 ]; then
    echo "Usage: $0 <keystore path> <keystore alias>"
    exit 1
fi

# change this if you're not me
build_tools=/home/toddynho/Android/Sdk/build-tools/33.0.2

./gradlew assembleRelease
cp android/build/outputs/apk/release/android-release-unsigned.apk temp.apk
$build_tools/zipalign -p -f -v 4 temp.apk MarkisaOS-Android.apk
$build_tools/apksigner sign --ks $1 MarkisaOS-Android.apk
rm temp.apk
