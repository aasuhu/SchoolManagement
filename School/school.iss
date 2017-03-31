; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "School Manager"
#define MyAppVersion "1.0"
#define MyAppPublisher "Adil Lahib, Inc."
#define MyAppExeName "School.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{B5A02089-932B-442E-8D0B-7EE119A68CE0}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
OutputDir=C:\Users\Adil\OneDrive\Projects\OutPuts
OutputBaseFilename=setup
SetupIconFile=C:\Users\Adil\OneDrive\Projects\Visual Studio Projects\School\School\1455474268_School.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\Adil\OneDrive\Projects\Visual Studio Projects\School\School\bin\Debug\School.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Adil\OneDrive\Projects\Visual Studio Projects\School\School\bin\Debug\School.application"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Adil\OneDrive\Projects\Visual Studio Projects\School\School\bin\Debug\School.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Adil\OneDrive\Projects\Visual Studio Projects\School\School\bin\Debug\DB\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\Adil\OneDrive\Projects\Visual Studio Projects\School\School\1455474268_School.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Adil\OneDrive\Projects\Visual Studio Projects\School\School\App.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Adil\OneDrive\Projects\Visual Studio Projects\School\School\Orange.jpg"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Adil\OneDrive\Projects\Visual Studio Projects\School\School\School.dbml"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

