if command -v java &> /dev/null; then
    echo "Java is installed."
    java -jar ./application/MarkisaOS-v0.12.0.jar
else
    if command -v zenity &> /dev/null; then
        zenity --error --title="MarkisaOS" --text="MarkisaOS requires Java 17 or later."
    elif command -v kdialog &> /dev/null; then
        kdialog --error "MarkisaOS requires Java 17 or later."
    elif command -v notify-send &> /dev/null; then
        notify-send "MarkisaOS" "MarkisaOS requires Java 17 or later."
    elif command -v xmessage &> /dev/null; then
        xmessage "MarkisaOS requires Java 17 or later."
    else
        echo "MarkisaOS requires Java 17 or later."
    fi
fi
