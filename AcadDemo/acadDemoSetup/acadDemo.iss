;;²Î¿¼http://www.manusoft.com/software/freebies/misc.html
;;inno setup°ïÖú https://jrsoftware.org/ishelp/

#define MyAppName "AcadDemo"
#define MyAppVersion "1.0"
#define MyAppPublisher "NiaoGe"
#define MyAppURL "http://www.example.com/"
#define MyAppPublisherKey "NiaoGe"

; MyAppBaseName must be set to the base filename of your main lisp file.
#define MyAppBaseName "AcadDemo"


[Setup]
AppId={#MyAppBaseName}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppPublisherKey}\{#MyAppName}
DefaultGroupName={#MyAppPublisherKey}\{#MyAppName}
OutputBaseFilename={#MyAppBaseName}Setup
Compression=lzma
SolidCompression=yes


[Languages]
Name: "english"; MessagesFile: "compiler:languages\ChineseSimplified.isl"


[Files]
Source: {#MyAppBaseName}.lsp; DestDir: {app}; Flags: touch
Source: {#MyAppBaseName}Cmds.lsp; DestDir: {app}; Flags: touch


;; ----------------------------------------------------------------------------
;; Install the demand-load stub files and set up the demand-load registry
;; entries for all supported host applications. Note that the DestName
;; parameter must rename the stub files to match the main lisp filename.
;; Comment or delete any of these lines for unsupported host applications.

; AutoCAD
Source: "LspLoad\LspLoad.ARX.15.arx";     DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.15.arx;     Flags: ignoreversion; Check: IsAvailable('ARX', '15', 'x86');   AfterInstall: SetupDemandload('ARX', '15', 'x86')
Source: "LspLoad\LspLoad.ARX.16.arx";     DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.16.arx;     Flags: ignoreversion; Check: IsAvailable('ARX', '16', 'x86');   AfterInstall: SetupDemandload('ARX', '16', 'x86')
Source: "LspLoad\LspLoad.ARX.17.arx";     DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.17.arx;     Flags: ignoreversion; Check: IsAvailable('ARX', '17', 'x86');   AfterInstall: SetupDemandload('ARX', '17', 'x86')
Source: "LspLoad\LspLoad.ARX.17.x64.arx"; DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.17.x64.arx; Flags: ignoreversion; Check: IsAvailable('ARX', '17', 'x64');   AfterInstall: SetupDemandload('ARX', '17', 'x64')
Source: "LspLoad\LspLoad.ARX.18.arx";     DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.18.arx;     Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x86');   AfterInstall: SetupDemandload('ARX', '18', 'x86')
Source: "LspLoad\LspLoad.ARX.18.x64.arx"; DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.18.x64.arx; Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x64');   AfterInstall: SetupDemandload('ARX', '18', 'x64')
Source: "LspLoad\LspLoad.ARX.19.arx";     DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.19.arx;     Flags: ignoreversion; Check: IsAvailable('ARX', '19', 'x86');   AfterInstall: SetupDemandload('ARX', '19', 'x86')
Source: "LspLoad\LspLoad.ARX.19.x64.arx"; DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.19.x64.arx; Flags: ignoreversion; Check: IsAvailable('ARX', '19', 'x64');   AfterInstall: SetupDemandload('ARX', '19', 'x64')
Source: "LspLoad\LspLoad.ARX.20.arx";     DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.20.arx;     Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x86');   AfterInstall: SetupDemandload('ARX', '20', 'x86')
Source: "LspLoad\LspLoad.ARX.20.x64.arx"; DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.20.x64.arx; Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x64');   AfterInstall: SetupDemandload('ARX', '20', 'x64')
Source: "LspLoad\LspLoad.ARX.21.arx";     DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.21.arx;     Flags: ignoreversion; Check: IsAvailable('ARX', '21', 'x86');   AfterInstall: SetupDemandload('ARX', '21', 'x86')
Source: "LspLoad\LspLoad.ARX.21.x64.arx"; DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.21.x64.arx; Flags: ignoreversion; Check: IsAvailable('ARX', '21', 'x64');   AfterInstall: SetupDemandload('ARX', '21', 'x64')
Source: "LspLoad\LspLoad.ARX.22.arx";     DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.22.arx;     Flags: ignoreversion; Check: IsAvailable('ARX', '22', 'x86');   AfterInstall: SetupDemandload('ARX', '22', 'x86')
Source: "LspLoad\LspLoad.ARX.22.x64.arx"; DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.22.x64.arx; Flags: ignoreversion; Check: IsAvailable('ARX', '22', 'x64');   AfterInstall: SetupDemandload('ARX', '22', 'x64')
Source: "LspLoad\LspLoad.ARX.23.arx";     DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.23.arx;     Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x86');   AfterInstall: SetupDemandload('ARX', '23', 'x86')
Source: "LspLoad\LspLoad.ARX.23.x64.arx"; DestDir: "{app}"; DestName: {#MyAppBaseName}.ARX.23.x64.arx; Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x64');   AfterInstall: SetupDemandload('ARX', '23', 'x64')
Source:"net45/MN.dll";                      DestDir: "{app}/net45"; DestName: "MN.dll"; Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x64');   AfterInstall: SetupDemandload_net('ARX', '18', 'x64','net45\MN.dll')
Source:"net45/MN.dll";                      DestDir: "{app}/net45"; DestName: "MN.dll"; Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x64');   AfterInstall: SetupDemandload_net('ARX', '20', 'x64','net45\MN.dll')
Source:"net45/MN.dll";                      DestDir: "{app}/net45"; DestName: "MN.dll"; Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x86');   AfterInstall: SetupDemandload_net('ARX', '18', 'x86','net45\MN.dll')
Source:"net45/MN.dll";                      DestDir: "{app}/net45"; DestName: "MN.dll"; Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x86');   AfterInstall: SetupDemandload_net('ARX', '20', 'x86','net45\MN.dll')
Source:"net45/MN.dll";                      DestDir: "{app}/net45"; DestName: "MN.dll"; Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x86');   AfterInstall: SetupDemandload_net('ARX', '23', 'x86','net45\MN.dll')
Source:"net45/MN.dll";                      DestDir: "{app}/net45"; DestName: "MN.dll"; Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x64');   AfterInstall: SetupDemandload_net('ARX', '23', 'x64','net45\MN.dll')

Source:"net45/*.dll";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x64'); 
Source:"net45/*.dll";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x64');  
Source:"net45/*.dll";                      DestDir: "{app}/net45"; Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x86'); 
Source:"net45/*.dll";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x86');  
Source:"net45/*.dll";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x64');  
Source:"net45/*.dll";                      DestDir: "{app}/net45"; Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x86'); 
Source:"net45/*.dll";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x64');

Source:"net45/*.pdb";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x64'); 
Source:"net45/*.pdb";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x64');  
Source:"net45/*.pdb";                      DestDir: "{app}/net45"; Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x86'); 
Source:"net45/*.pdb";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x86');  
Source:"net45/*.pdb";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x64');  
Source:"net45/*.pdb";                      DestDir: "{app}/net45"; Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x86'); 
Source:"net45/*.pdb";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x64');

Source:"net45/*.config";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x64'); 
Source:"net45/*.config";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x64');  
Source:"net45/*.config";                      DestDir: "{app}/net45"; Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x86'); 
Source:"net45/*.config";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x86');  
Source:"net45/*.config";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x64');  
Source:"net45/*.config";                      DestDir: "{app}/net45"; Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x86'); 
Source:"net45/*.config";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x64');

Source:"net45/*.ini";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x64'); 
Source:"net45/*.ini";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x64');  
Source:"net45/*.ini";                      DestDir: "{app}/net45"; Flags: ignoreversion; Check: IsAvailable('ARX', '18', 'x86'); 
Source:"net45/*.ini";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x86');  
Source:"net45/*.ini";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '20', 'x64');  
Source:"net45/*.ini";                      DestDir: "{app}/net45"; Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x86'); 
Source:"net45/*.ini";                      DestDir: "{app}/net45";  Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x64');

Source:"net45/amd64/*";                      DestDir: "{app}/net45/amd64"; Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x86'); 
Source:"net45/amd64/*";                      DestDir: "{app}/net45/amd64";  Flags: ignoreversion; Check: IsAvailable('ARX', '23', 'x64');
Source:"MN.cuix";                      DestDir: "{app}"; DestName: "MN.cuix"; Flags: ignoreversion;   

;Source:"Newtonsoft.Json.dll";             DestDir: "{app}"; DestName: "Newtonsoft.Json.dll"; Flags: ignoreversion; 

[Icons]
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"

     
[Registry]
Root: HKLM; Subkey: Software\{#MyAppPublisherKey}\{#MyAppBaseName}; Flags: uninsdeletekeyifempty; Check: IsAdminLoggedOn()
Root: HKCU; Subkey: Software\{#MyAppPublisherKey}\{#MyAppBaseName}; Flags: uninsdeletekeyifempty; Check: not IsAdminLoggedOn()
Root: HKLM; Subkey: Software\{#MyAppPublisherKey}\{#MyAppBaseName}; ValueType: string; ValueName: InstallPath; ValueData: {app}; Flags: uninsdeletekeyifempty uninsdeletevalue; Check: IsAdminLoggedOn()
Root: HKCU; Subkey: Software\{#MyAppPublisherKey}\{#MyAppBaseName}; ValueType: string; ValueName: InstallPath; ValueData: {app}; Flags: uninsdeletekeyifempty uninsdeletevalue; Check: not IsAdminLoggedOn()

 

[CustomMessages]
NoSupportedHost=The plugin files have been installed, however no supported host application has been configured to load them. Please check the plugin documentation for a list of supported host applications.


[Code]
// ============================================================================
// The code in this section may require modifications in some cases
// ============================================================================

// ----------------------------------------------------------------------------
// PopulateDemandloadKey
//   - Populate a single demand-load registry key for the application.
// ----------------------------------------------------------------------------
procedure PopulateDemandloadKey(const RootKey: Integer; const AppsKey: String; const Loader: String);
begin
  RegWriteDWordValue(RootKey, AppsKey + '\{#MyAppBaseName}', 'LoadCtrls', 2); //2 = load at startup
  RegWriteStringValue(RootKey, AppsKey + '\{#MyAppBaseName}', 'Description', '{#MyAppName}');
  RegWriteStringValue(RootKey, AppsKey + '\{#MyAppBaseName}', 'Loader', ExpandConstant('{app}') + '\' + Loader);
end;

// ----------------------------------------------------------------------------
// PopulateDemandloadKey_net
//   - Populate a single demand-load registry key for the application.
// ----------------------------------------------------------------------------
procedure PopulateDemandloadKey_net(const RootKey: Integer; const AppsKey: String; const Loader: String);
begin
  RegWriteDWordValue(RootKey, AppsKey + '\{#MyAppBaseName}', 'LoadCtrls', 2); //2 = load at startup
  RegWriteDWordValue(RootKey, AppsKey + '\{#MyAppBaseName}', 'Managed', 1); //
  RegWriteStringValue(RootKey, AppsKey + '\{#MyAppBaseName}', 'Description', '{#MyAppName}');
  RegWriteStringValue(RootKey, AppsKey + '\{#MyAppBaseName}', 'Loader', ExpandConstant('{app}') + '\' + Loader);
end;

// ----------------------------------------------------------------------------
// PopulateDemandloadKeyAcadR15
//   - Populate a single demand-load registry key for AutoCAD 2000/2000i/2002.
// ----------------------------------------------------------------------------
procedure PopulateDemandloadKeyAcadR15(const RootKey: Integer; const AppsKey: String; const Loader: String);
begin
  RegWriteDWordValue(RootKey, AppsKey + '\{#MyAppBaseName}', 'LoadCtrls', 2); //2 = load at startup
  RegWriteStringValue(RootKey, AppsKey + '\{#MyAppBaseName}', 'RegPath', '\\HKEY_LOCAL_MACHINE\' + AppsKey + '\{#MyAppBaseName}');
  RegWriteStringValue(RootKey, AppsKey + '\{#MyAppBaseName}\Name', '{#MyAppName}', '{#MyAppName}');
  RegWriteStringValue(RootKey, AppsKey + '\{#MyAppBaseName}\Loader', 'Module', ExpandConstant('{app}') + '\' + Loader);
end;

// ----------------------------------------------------------------------------
// DeleteAllDemandloadKeys
//   - Delete demand-load registry keys for all (reachable) targets.
// ----------------------------------------------------------------------------
procedure DeleteDemandloadKeys(const RootKey: Integer; const HostKey: String); forward;
procedure DeleteAllDemandloadKeys();
begin
  // Comment or delete any lines for unsupported targets
  if IsAdminLoggedOn() then
  begin
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R15.0');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R16.0');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R16.1');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R16.2');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R17.0');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R17.1');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R17.2');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R18.0');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R18.1');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R18.2');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R19.0');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R19.1');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R20.0');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R20.1');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R21.0');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R22.0');
    DeleteDemandloadKeys(HKLM32, 'Software\Autodesk\AutoCAD\R23.0');
  
    if IsWin64() then
    begin
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R17.0');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R17.1');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R17.2');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R18.0');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R18.1');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R18.2');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R19.0');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R19.1');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R20.0');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R20.1');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R21.0');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R22.0');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R23.0');
      DeleteDemandloadKeys(HKLM64, 'Software\Autodesk\AutoCAD\R23.1');
      
    end;
  end;
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R15.0');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R16.0');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R16.1');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R16.2');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R17.0');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R17.1');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R17.2');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R18.0');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R18.1');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R18.2');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R19.0');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R19.1');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R20.0');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R20.1');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R21.0');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R22.0');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R23.0');
  DeleteDemandloadKeys(HKCU, 'Software\Autodesk\AutoCAD\R23.1');
 
end;

// ----------------------------------------------------------------------------
// CurUninstallStepChanged
//   - Standard Inno Setup event handler
// ----------------------------------------------------------------------------
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
begin
  if CurUninstallStep = usPostUninstall then
  begin
    DeleteAllDemandloadKeys();
  end;
end;

// ----------------------------------------------------------------------------
// CurStepChanged
//   - Standard Inno Setup event handler
// ----------------------------------------------------------------------------
var FoundSupportedHost: Boolean; //this will be False if no supported host was found
procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    if not FoundSupportedHost then
      SuppressibleMsgBox(ExpandConstant('{cm:NoSupportedHost}'), mbInformation, MB_OK, IDOK);
  end;
end;
// ============================================================================

  
[Code]
// ============================================================================
// The code in this section should never require any changes
// ============================================================================

// ----------------------------------------------------------------------------
// IsAvailable
//   - Check whether the requested host/version/architecture is installed
//     on this system and return True if it is available.
// ----------------------------------------------------------------------------
function IsAvailable(const Host: String; const Ver: String; const Arch: String): Boolean;
var ProductKey: String;
begin
  Result := False;
  case Host of
    'ARX' :
      case Ver of
        '15' :
          case Arch of
            'x86':
              if IsAdminLoggedOn() then
                if RegQueryStringValue(HKLM32, 'Software\Autodesk\AutoCAD\R15.0', 'CurVer', ProductKey) then
                  if RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R15.0\' + ProductKey + '\Applications')) then
                    begin FoundSupportedHost := True; Result := True; end;
          end;
        '16' :
          case Arch of
            'x86':
              if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R16.0', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R16.0\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end
              else if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R16.1', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R16.1\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end
              else if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R16.2', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R16.2\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end;
          end;
        '17' :
          case Arch of
            'x86':
              if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R17.0', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R17.0\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end
              else if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R17.1', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R17.1\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end
              else if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R17.2', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R17.2\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end;
            'x64':
              if IsWin64() then
                if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R17.0', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R17.0\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end
                else if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R17.1', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R17.1\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end
                else if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R17.2', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R17.2\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end;
          end;
        '18' :
          case Arch of
            'x86':
              if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R18.0', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R18.0\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end
              else if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R18.1', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R18.1\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end
              else if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R18.2', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R18.2\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end;
            'x64':
              if IsWin64() then
                if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R18.0', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R18.0\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end
                else if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R18.1', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R18.1\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end
                else if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R18.2', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R18.2\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end;
          end;
        '19' :
          case Arch of
            'x86':
              if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R19.0', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R19.0\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end
              else if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R19.1', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R19.1\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end;
            'x64':
              if IsWin64() then
                if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R19.0', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R19.0\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end
                else if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R19.1', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R19.1\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end;
          end;
        '20' :
          case Arch of
            'x86':
              if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R20.0', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R20.0\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end
              else if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R20.1', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R20.1\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end;
            'x64':
              if IsWin64() then
                if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R20.0', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R20.0\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end
                else if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R20.1', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R20.1\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end;
          end;
        '21' :
          case Arch of
            'x86':
              if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R21.0', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R21.0\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end;
            'x64':
              if IsWin64() then
                if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R21.0', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R21.0\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end;
          end;
        '22' :
          case Arch of
            'x86':
              if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R22.0', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R22.0\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end;
            'x64':
              if IsWin64() then
                if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R22.0', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R22.0\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end;
          end;
        '23' :
          case Arch of
            'x86':
              if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R23.0', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R23.0\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end
              else if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R23.1', 'CurVer', ProductKey) and
                  RegKeyExists(HKLM32, ('Software\Autodesk\AutoCAD\R23.1\' + ProductKey + '\Applications')) then
                begin FoundSupportedHost := True; Result := True; end;
            'x64':
              if IsWin64() then
                if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R23.0', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R23.0\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end
                else if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R23.1', 'CurVer', ProductKey) and
                    RegKeyExists(HKLM64, ('Software\Autodesk\AutoCAD\R23.1\' + ProductKey + '\Applications')) then
                  begin FoundSupportedHost := True; Result := True; end;
          end;
      end;
    end;
  end;


// ----------------------------------------------------------------------------
// GetPreferredRoot32
//   - Return the preferred registry root for x86 registry access
// ----------------------------------------------------------------------------
function GetPreferredRoot32(): Integer;
begin
  if IsAdminLoggedOn() then
    Result := HKLM32
  else
    Result := HKCU32;
end;

// ----------------------------------------------------------------------------
// GetPreferredRoot64
//   - Return the preferred registry root for x64 registry access
// ----------------------------------------------------------------------------
function GetPreferredRoot64(): Integer;
begin
  if IsAdminLoggedOn() then
    Result := HKLM64
  else
    Result := HKCU64;
end;

// ----------------------------------------------------------------------------
// SetupDemandload
//   - Setup the demand-load registry key for the requested
//     host/version/architecture.
// ----------------------------------------------------------------------------
procedure SetupDemandload(const Host: String; const Ver: String; const Arch: String);
var ProductKey: String;
begin
  case Host of
    'ARX' :
      case Ver of
        '15' :
          case Arch of
            'x86':
              if IsAdminLoggedOn() then
                if RegQueryStringValue(HKLM32, 'Software\Autodesk\AutoCAD\R15.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKeyAcadR15(HKLM32, ('Software\Autodesk\AutoCAD\R15.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.15.arx');
          end;
        '16' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R16.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R16.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.16.arx');
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R16.1', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R16.1\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.16.arx');
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R16.2', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R16.2\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.16.arx');
              end;
          end;
        '17' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R17.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R17.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.17.arx');
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R17.1', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R17.1\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.17.arx');
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R17.2', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R17.2\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.17.arx');
              end;
            'x64':
              if IsWin64() then
                begin
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R17.0', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R17.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.17.x64.arx');
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R17.1', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R17.1\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.17.x64.arx');
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R17.2', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R17.2\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.17.x64.arx');
                end;
          end;
        '18' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R18.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R18.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.18.arx');
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R18.1', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R18.1\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.18.arx');
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R18.2', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R18.2\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.18.arx');
              end;
            'x64':
              if IsWin64() then
                begin
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R18.0', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R18.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.18.x64.arx');
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R18.1', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R18.1\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.18.x64.arx');
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R18.2', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R18.2\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.18.x64.arx');
                end;
          end;
        '19' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R19.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R19.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.19.arx');
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R19.1', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R19.1\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.19.arx');
              end;
            'x64':
              if IsWin64() then
                begin
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R19.0', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R19.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.19.x64.arx');
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R19.1', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R19.1\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.19.x64.arx');
                end;
          end;
        '20' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R20.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R20.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.20.arx');
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R20.1', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R20.1\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.20.arx');
              end;
            'x64':
              if IsWin64() then
                begin
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R20.0', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R20.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.20.x64.arx');
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R20.1', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R20.1\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.20.x64.arx');
                end;
          end;
        '21' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R21.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R21.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.21.arx');
              end;
            'x64':
              if IsWin64() then
                begin
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R21.0', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R21.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.21.x64.arx');
                end;
          end;
        '22' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R22.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R22.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.22.arx');
              end;
            'x64':
              if IsWin64() then
                begin
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R22.0', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R22.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.22.x64.arx');
                end;
          end;
        '23' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R23.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R23.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.23.arx');
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R23.1', 'CurVer', ProductKey) then
                  PopulateDemandloadKey(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R23.1\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.23.arx');
              end;
            'x64':
              if IsWin64() then
                begin
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R23.0', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R23.0\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.23.x64.arx');
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R23.1', 'CurVer', ProductKey) then
                    PopulateDemandloadKey(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R23.1\' + ProductKey + '\Applications'), '{#MyAppBaseName}.ARX.23.x64.arx');
                end;
          end;
      end;
  end;
end;


procedure SetupDemandload_net(const Host: String; const Ver: String; const Arch: String;const Dll:String);
var ProductKey: String;
begin
  case Host of
    'ARX' :
      case Ver of
        
        '18' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R18.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey_net(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R18.0\' + ProductKey + '\Applications'), Dll);
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R18.1', 'CurVer', ProductKey) then
                  PopulateDemandloadKey_net(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R18.1\' + ProductKey + '\Applications'), Dll);
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R18.2', 'CurVer', ProductKey) then
                  PopulateDemandloadKey_net(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R18.2\' + ProductKey + '\Applications'), Dll);
              end;
            'x64':
              if IsWin64() then
                begin
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R18.0', 'CurVer', ProductKey) then
                    PopulateDemandloadKey_net(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R18.0\' + ProductKey + '\Applications'), Dll);
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R18.1', 'CurVer', ProductKey) then
                    PopulateDemandloadKey_net(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R18.1\' + ProductKey + '\Applications'), Dll);
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R18.2', 'CurVer', ProductKey) then
                    PopulateDemandloadKey_net(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R18.2\' + ProductKey + '\Applications'), Dll);
                end;
          end;
        '19' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R19.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey_net(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R19.0\' + ProductKey + '\Applications'), Dll);
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R19.1', 'CurVer', ProductKey) then
                  PopulateDemandloadKey_net(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R19.1\' + ProductKey + '\Applications'), Dll);
              end;
            'x64':
              if IsWin64() then
                begin
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R19.0', 'CurVer', ProductKey) then
                    PopulateDemandloadKey_net(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R19.0\' + ProductKey + '\Applications'), Dll);
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R19.1', 'CurVer', ProductKey) then
                    PopulateDemandloadKey_net(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R19.1\' + ProductKey + '\Applications'), Dll);
                end;
          end;
        '20' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R20.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey_net(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R20.0\' + ProductKey + '\Applications'),Dll);
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R20.1', 'CurVer', ProductKey) then
                  PopulateDemandloadKey_net(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R20.1\' + ProductKey + '\Applications'), Dll);
              end;
            'x64':
              if IsWin64() then
                begin
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R20.0', 'CurVer', ProductKey) then
                    PopulateDemandloadKey_net(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R20.0\' + ProductKey + '\Applications'), Dll);
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R20.1', 'CurVer', ProductKey) then
                    PopulateDemandloadKey_net(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R20.1\' + ProductKey + '\Applications'), Dll);
                end;
          end;

        '23' :
          case Arch of
            'x86':
              begin
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R23.0', 'CurVer', ProductKey) then
                  PopulateDemandloadKey_net(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R23.0\' + ProductKey + '\Applications'),Dll);
                if RegQueryStringValue(HKCU32, 'Software\Autodesk\AutoCAD\R23.1', 'CurVer', ProductKey) then
                  PopulateDemandloadKey_net(GetPreferredRoot32(), ('Software\Autodesk\AutoCAD\R23.1\' + ProductKey + '\Applications'), Dll);
              end;
            'x64':
              if IsWin64() then
                begin
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R23.0', 'CurVer', ProductKey) then
                    PopulateDemandloadKey_net(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R23.0\' + ProductKey + '\Applications'), Dll);
                  if RegQueryStringValue(HKCU64, 'Software\Autodesk\AutoCAD\R23.1', 'CurVer', ProductKey) then
                    PopulateDemandloadKey_net(GetPreferredRoot64(), ('Software\Autodesk\AutoCAD\R23.1\' + ProductKey + '\Applications'), Dll);
                end;
          end;
        
      end;
  end;
end;
// ----------------------------------------------------------------------------
// DeleteDemandloadKeys
//   - Delete all demand-load registry keys found under all subkeys of the
//     host key.
// ----------------------------------------------------------------------------
procedure DeleteDemandloadKeys(const RootKey: Integer; const HostKey: String);
var
  Subkeys: TArrayOfString;
  Index: Integer;
begin
  if (Length('{#MyAppBaseName}') > 0) and (RegGetSubkeyNames(RootKey, HostKey, Subkeys)) then
  begin
    for Index := 0 to GetArrayLength(Subkeys)-1 do
      RegDeleteKeyIncludingSubkeys(RootKey, (HostKey + '\' + Subkeys[Index] + '\Applications\{#MyAppBaseName}'));
  end;
end;
// ============================================================================
