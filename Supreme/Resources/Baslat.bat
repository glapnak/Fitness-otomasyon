@echo off
@echo Resources kismindan Baslat.bat a iki kere tiklayin ve DESKTOP-UMFQTVC\GYM adli yeri kendi server isminizi I:\BigCon\Gym\Supreme\GYMVT.MDF yeride GYMVT.MDF adli dosyanin dosya konum linkini yapistirin ve son olarak I:\BigCon\Gym\Supreme\SQLQuery5.sql adli yere supreme adli klasorun icindeki SQLQUERY5 adli dosyanin dosya konumunu yapistirin
sqlcmd -E -S DESKTOP-UMFQTVC\GYM -d I:\BigCon\Gym\Supreme\GYMVT.MDF -i I:\BigCon\Gym\Supreme\SQLQuery5.sql
PAUSE