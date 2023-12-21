./gradlew assembleDist
mkdir out-linux
mkdir out-linux/application
cp lwjgl3/build/lib/MarkisaOS-*.jar out-linux/application
cp scripts/MarkisaOS.sh out-linux
chmod +x out-linux/MarkisaOS.sh
tar -czvf MarkisaOS-Linux.tar.gz out-linux
echo "MarkisaOS has successfully been exported to Linux."
