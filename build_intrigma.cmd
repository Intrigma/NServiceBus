md build
md build\merge
md build\output
md build\tools
md build\tools\GridUI
md build\tools\ReturnToSourceQueue
md build\XsdGenerator

call clean.bat

msbuild /p:Configuration=Release
