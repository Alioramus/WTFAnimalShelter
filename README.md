# Zaawansowane Interfejsy Graficzne - projekt

## Cele projektu:

* schronisko dla zwierzat
* role w systemie
* dodawanie zwierzat, rozne rodzaje
* opiekun z schroniska, zglasza potrzeby, wizyty weterynarza
* konto opiekuna, weterynarza, administrator (zamawia, umawia wizyty)
* GUI (UWP, WPF) + testy jednostkowe
* Dane w pliku, lub baza danych
* Narzędzia, jak uruchomić, jak zalogować
* .NET / .NET Core która wersja

### Etapy projektowania aplikacji:
1. Definiowanie ról użytkowników systemu: opiekun z schroniska, weterynarz, administrator
2. Implementacja funkcjonalności dodawania zwierząt: klasa Animal, z polami takimi jak imię, gatunek, rasa, opis, itp., oraz odpowiednie metody do dodawania i edytowania zwierząt
3. Implementacja funkcjonalności dotyczącej opiekuna i wizyt weterynarza: klasa Keeper z informacjami o opiekunie, klasa Visit z informacjami o wizycie weterynarza, oraz odpowiednie metody do rejestrowania i przeglądania informacji o opiece i wizytach
4. Implementacja kont użytkowników: klasa User z informacjami o użytkowniku, klasa Auth z metodami do logowania i rejestracji użytkowników
5. Implementacja interfejsu graficznego (GUI) aplikacji w WPF: tworzenie okien i kontrolek, oraz połączenie ich z logiką aplikacji
6. Implementacja testów jednostkowych dla poszczególnych funkcjonalności aplikacji
7. Implementacja zapisu i odczytu danych z pliku lub bazy danych, na przykład za pomocą ADO.NET lub Entity Framework.
8. Dokumentacja narzędzi i instrukcji, jak uruchomić aplikację i zalogować się do niej.

### Jak uruchomić aplikację:
1. Pobierz repozytorium
2. Uruchom plik .sln
3. Uruchom projekt AnimalShelter
4. Zaloguj się do aplikacji lub zarejestruj nowe konto
5. Możesz się zalogować jako administrator, opiekun lub weterynarz

### Użyte technologie i biblioteki:  
* .NET 7.0
* WPF 6.0
* SQLite
* Entity Framework 7.0
* Moq 4.18
* XUnit 2.4
* NLog 5.0
* Autofac 8.0
