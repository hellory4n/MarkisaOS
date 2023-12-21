./gradlew assembleDist
mkdir out-windows
mkdir out-windows/application
cp lwjgl3/build/lib/MarkisaOS-*.jar out-windows/application
cp scripts/MarkisaOS.cmd out-windows
zip -r MarkisaOS-Windows.zip out-windows
echo "MarkisaOS has successfully been exported to Windows."
