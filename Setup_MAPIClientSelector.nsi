; example1.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply 
; prompts the user asking them where to install, and drops a copy of example1.nsi
; there. 

;--------------------------------

Unicode true

!define APP "MAPIClientSelector"

!system 'MySign "bin\DEBUG\${APP}.exe"'
!finalize 'MySign "%1"'

; The name of the installer
Name "${APP}"

; The file to write
OutFile "Setup_${APP}.exe"

; The default installation directory
InstallDir "$APPDATA\${APP}"

; Request application privileges for Windows Vista
RequestExecutionLevel user

XPStyle on

LoadLanguageFile "${NSISDIR}\Contrib\Language files\Japanese-MeiryoUI.nlf"

;--------------------------------

; Pages

Page directory
Page instfiles

;--------------------------------

; The stuff to install
Section "" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File /r /x "*.vshost.*" "bin\DEBUG\*.*"
  
  Exec "$INSTDIR\${APP}.exe"
  
  IfErrors +2
    SetAutoClose true
  
SectionEnd ; end the section
