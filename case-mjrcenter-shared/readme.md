# publish package to myget

Using powershell, navigate to solution root and execute the file .\Push-Packages.ps1 with a version and the selected library you want to update

example:
```powershell
.\Push-Packages.ps1 "1.0.0" -library Data
```