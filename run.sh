./thirdparty/premake/premake5 --file=build.lua gmake2
make

# only run the executable if make didn't give an error
if [ $? -eq 0 ]; then
    ./bin/linux-x86_64/Debug/app/app
fi