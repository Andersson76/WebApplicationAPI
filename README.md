# 🏆 Tournament Manager

## 📌 Beskrivning

Denna applikation är en enkel fullstack lösning där användaren kan skapa, visa och ta bort turneringar.

Frontend är byggd med HTML, CSS och JavaScript och kommunicerar med ett .NET Web API som hanterar logik och lagrar data i en SQLite databas.

---

## 🚀 Hur man kör projektet

1. Klona projektet:
```bash
git clone https://github.com/Andersson76/WebApplicationAPI.git

Navigera till projektmappen:

```bash
cd WebApplication1

Installera beroenden:

```bash
dotnet restore

Kör applikationen:

```bash
dotnet run

Öppna i webbläsaren:

https://localhost:7190

## 🔌 API Endpoints

| Method | Endpoint | Beskrivning |
|--------|----------|------------|
| GET | /api/tournaments | Hämtar alla turneringar |
| GET | /api/tournaments/{id} | Hämtar en specifik turnering |
| POST | /api/tournaments | Skapar en ny turnering |
| PUT | /api/tournaments/{id} | Uppdaterar en turnering |
| DELETE | /api/tournaments/{id} | Tar bort en turnering |

## 🔄 Kommunikation mellan frontend och API

Frontend använder JavaScript och `fetch()` för att kommunicera med API:et.

- När användaren klickar på **Create** skickas en POST-request till `/api/tournaments`
- API:et tar emot datan och skickar den vidare till en service
- Servicen sparar datan i databasen via Entity Framework Core
- Frontend gör sedan en GET-request för att hämta alla turneringar
- Resultatet visas dynamiskt i en lista i UI:t

## 🧠 Reflektion

Det som gick bra var att bygga upp backend strukturen med controllers, services och DTOs, samt att koppla databasen med Entity Framework Core.

Projektet gav en tydlig förståelse för hur hela flödet fungerar i en fullstack applikation, från användarinteraktion i webbläsaren till lagring i databasen och tillbaka till UI:t.
