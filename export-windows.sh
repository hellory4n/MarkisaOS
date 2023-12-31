read -p "Did you change the target framework to \"net8.0\"? Press Enter to continue..." userInput

# just in case
rm -rf outWindows/*
dotnet publish frambos/frambos.csproj --output outWindows/ --configuration Release -r win-x64 --self-contained true
# since we're exporting the frambos project the executable is called frambos, but the user doesn't know that the engine is called frambos, so they would just think it's another random file
mv outWindows/frambos.exe outWindows/MarkisaOS.exe
# rename it so it looks nicer when extracted
mv outWindows MarkisaOS-Windows
zip -r MarkisaOS-Windows.zip MarkisaOS-Windows
# rename it back
mv MarkisaOS-Windows outWindows

echo ""
echo "=============================================="
echo ""
echo "Successfully exported to Windows!"