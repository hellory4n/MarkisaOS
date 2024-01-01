if [ "$#" -ne 2 ]; then
    echo "Usage: $0 <keystore path> <keystore alias>"
    exit 1
fi

read -p "Did you change the target framework to \"net8.0-android\"? Press Enter to continue..." userInput

dotnet build frambos.android/frambos.android.csproj -c Release -f net8.0-android -bl

# now we need to sign it and shit
# change if you're not me
build_tools=/home/toddynho/Android/Sdk/build-tools/34.0.0

cp frambos.android/bin/Release/net8.0-android/com.hellory4n.markisa-Signed.apk temp.apk
$build_tools/zipalign -p -f -v 4 temp.apk MarkisaOS-Android.apk
$build_tools/apksigner sign --ks $1 MarkisaOS-Android.apk
rm temp.apk

echo ""
echo "=============================================="
echo ""
echo "Successfully exported to Android!"