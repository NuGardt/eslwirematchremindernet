;
; Copyright (C) 2012 NuGardt Software
; http://www.nugardt.com
;
; This Program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2, or (at your option) any later version.
;
; This Program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
;
; You should have received a copy of the GNU General Public License along with NuGardt ESL Wire Plugin Match Reminder; see the file COPYING. If not, write to the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.
; http://www.gnu.org/copyleft/gpl.html
;
; The name of the installer
;

Name "NuGardt ESL Wire Plugin Match Reminder"

SetCompressor /solid lzma
XPStyle on
SetDateSave on
SetDatablockOptimize on
CRCCheck on
Icon "Resources\ICO_MatchReminder.ico"
LicenseData "COPYING.txt"
!define /date DATE "%Y.%m.%d"


; The file to write
OutFile "ESLWirePluginMatchReminder-${Date}.exe"

; The default installation directory
InstallDir $PROGRAMFILES64\EslWire

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\ESL Wire_is1" "InstallLocation"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------

; Pages

Page license
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "Match reminder (required)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR\plugins
  SetOverwrite "on"

  MessageBox MB_OK|MB_ICONEXCLAMATION "If ESL Wire is running, please close it first." /SD IDOK

  ; Put file there
  File "COPYING.txt"
  File "Readme.txt"
  File "bin\Release\com.NuGardt.ESLWirePlugin.MatchReminder.dll"
  
  ; Write the installation path into the registry
  WriteRegStr HKLM Software\NuGardt\ESLWirePluginMatchReminder "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ESLWirePluginMatchReminder" "DisplayName" "NuGardt ESL Wire Plugin Match Reminder (remove only)"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ESLWirePluginMatchReminder" "UninstallString" '"$INSTDIR\uninstall_ESLWirePluginMatchReminder.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ESLWirePluginMatchReminder" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ESLWirePluginMatchReminder" "NoRepair" 1
  WriteUninstaller "plugins\uninstall_ESLWirePluginMatchReminder.exe"
  
SectionEnd

;--------------------------------

; Uninstaller

UninstallText "Please exit ESL Wire before uninstalling."
UninstallIcon "Resources\ICO_MatchReminder.ico"

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ESLWirePluginMatchReminder"

  ; Remove files and uninstaller
  Delete "$INSTDIR\COPYING.txt"
  Delete "$INSTDIR\Readme.txt"
  Delete "$INSTDIR\com.NuGardt.ESLWirePlugin.MatchReminder.dll"
  Delete "$INSTDIR\uninstall_ESLWirePluginMatchReminder.exe"
SectionEnd
