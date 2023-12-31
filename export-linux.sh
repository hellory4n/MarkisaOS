read -p "Did you change the target framework to \"net8.0\"? Press Enter to continue..." userInput

# just in case
rm -rf outLinux/*
dotnet publish frambos/frambos.csproj --output outLinux/ --configuration Release -r linux-x64 --self-contained true
# since we're exporting the frambos project the executable is called frambos, but the user doesn't know that the engine is called frambos, so they would just think it's another random file
mv outLinux/frambos outLinux/MarkisaOS
# rename it so it looks nicer when extracted
mv outLinux MarkisaOS-Linux
tar -czvf MarkisaOS-Linux.tar.gz MarkisaOS-Linux
# rename it back
mv MarkisaOS-Linux outLinux

echo ""
echo "=============================================="
echo ""
echo "Successfully exported to Linux!"