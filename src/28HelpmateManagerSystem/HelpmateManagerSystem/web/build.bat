@echo off

cd..

set current_path=C:\Users\jm96\Desktop

@echo ���APP...

set buildPath=D:\jean.h.ma\Downloads\github\node-webkit-v0.6.1-win-ia32\build

@echo ������·��:%buildPath%

@echo ɾ��app\�е������ļ����ļ���....

rd %buildPath%\app\ /s /q

md %buildPath%\app

@echo ɾ�����

@echo ���ƴ���ļ���app...

xcopy package.json %buildPath%\app\ 
xcopy *.html %buildPath%\app\ /s /h
xcopy *.htm %buildPath%\app\ /s /h
xcopy *.js %buildPath%\app\ /s /h
xcopy *.css %buildPath%\app\ /s /h

@echo �������

@echo ɾ��release/�е������ļ����ļ���

rd %buildPath%\release\ /s /q

md %buildPath%\release

@echo ɾ�����

@echo ��ʼ���...

cd %buildPath%

call %buildPath%\build.bat

rd %current_path%\release /s /q

md %current_path%\release

xcopy %buildPath%\release %current_path%\release /s /h

@echo ������
