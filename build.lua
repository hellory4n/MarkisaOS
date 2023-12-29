-- premake5.lua
workspace "MarkisaOS"
   architecture "x64"
   configurations { "Debug", "Release", "Dist" }
   startproject "app"

   -- Workspace-wide build options for MSVC
   filter "system:windows"
      buildoptions { "/EHsc", "/Zc:preprocessor", "/Zc:__cplusplus" }

OutputDir = "%{cfg.system}-%{cfg.architecture}/%{cfg.buildcfg}"

group "engine"
	include "engine/build.lua"
group ""

include "app/build.lua"
