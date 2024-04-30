# Komponensek

A programcsomag komponensei

## Desktop applikáció leírása

A Desktop applikáció egy C# alapú szoftver, melynek kezelőfelületét C# elemek segítségével fejlesztenénk.
Az asztali alkalmazás mögött egy adatbázis is dolgozna, MariaDB alapú. A
Desktop applikáció egy egyszerű kezelőfelülettel rendelkezne. Itt a felhasználó
a termékeket tudja felvinni, illetve módosítani. A belépéshez szükséges User-t
elsőként a WordPress adminisztrációs felületén kell létrehozni. A következő
szinkronizációt követően (weboldal és desktop applikáció) már ugyan ez a User
képes lesz belépni a desktop applikációba is.

## WordPress plugin leírása

A WordPress bővítmény felel közvetlenül az adatok szinkronizálásáért, illetve ez
tartalmazná a cron beállításokat is, amelyek az adatok szinkronizálásának
“automatizációjáért“, pontosabban az időbeni beállításaiért felel.

