@echo off

where java > nul 2>nul
if %errorlevel% equ 0 (
    echo Java is installed.
    java -jar "MarkisaOS-v0.12.0.jar"
) else (
    msg * "MarkisaOS requires Java 17 or higher."
)
