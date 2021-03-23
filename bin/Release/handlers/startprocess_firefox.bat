@echo off
Echo //------------- Run firefox with a specific profile -------------//
START "" /min "C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe" -p "Default" -no-remote "imacros://run/?m=SearchServices_Presearch.iim"