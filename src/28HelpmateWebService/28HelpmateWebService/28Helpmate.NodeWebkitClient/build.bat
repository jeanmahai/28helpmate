@echo off

cd..

::release path
set current_path=C:\Users\Jeanma\Desktop\28SoftWare
::build path
set buildPath=F:\github\nodebob

@echo build path:%buildPath%

@echo delete app\ folder...

rd %buildPath%\app\ /s /q

md %buildPath%\app

@echo deleted

@echo copy source files...

xcopy package.json %buildPath%\app\ 
xcopy *.html %buildPath%\app\ /s /h
xcopy *.htm %buildPath%\app\ /s /h
xcopy *.js %buildPath%\app\ /s /h
xcopy *.css %buildPath%\app\ /s /h
xcopy *.gif %buildPath%\app\ /s /h
xcopy *.png %buildPath%\app\ /s /h
xcopy *.jpg %buildPath%\app\ /s /h
xcopy *.mp3 %buildPath%\app\ /s /h

@echo copy complete

@echo delete release\ folder...

rd %buildPath%\release\ /s /q

md %buildPath%\release

@echo delete complete

@echo begin package...

cd %buildPath%

call %buildPath%\build.bat

rd %current_path%\release /s /q

md %current_path%\release

xcopy %buildPath%\release %current_path%\release /s /h

@echo package complete
