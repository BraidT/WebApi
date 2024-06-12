### Eesmärk
Ülesande eesmärgiks on kontrollida kandidaadi teadmiseid C# keelest, objekt-orienteeritud programmeerimise üldtunnustatud arendusmustrite/võtete tundmise ja kasutamise oskuseid ning oskust enda loodava tarkvara dokumenteerimiseks ja kvaliteedi kontrollimiseks.

### Töö Sisuks
1. **Äriülesande Realiseerimine**: Kasutades domeenipõhise disaini (Domain-Driven Design) printsiipe ja kihilist arhitektuuri koos sobivate arendusmustritega (nõrgad seosed kihtide vahel, dependency injection, inversion of control).
2. **Visuaalne Kasutajaliides**: Kasutajaliidese loomine, järgides kaustas „UI materjal“ olevaid juhiseid.
3. **Andmebaas ja Andmebaasi Diagramm**: Loo andmebaas ja selle diagramm, kasutades sobivat abstraktsiooni (Microsoft SQL Server, SQLite, PostgreSQL, Oracle vms).
4. **Automatiseeritud Testid**: Koosta automaattestid tarkvara toimimise kontrollimiseks vastavalt etteantud nõuetele. Testimisraamistik vabal valikul.
5. **Dokumentatsioon**: Koosta minimaalne vajalik dokumentatsioon rakenduse paigaldamise kirjeldamiseks, üldise ettekujutuse saamiseks rakenduse arhitektuurist ning rakenduse koodi mõistmiseks.

### Mittefunktsionaalsed Nõuded
- **Keele ja Raamistiku Kasutamine**: Veebirakendus peab olema realiseeritud C# programmeerimiskeeles, kasutades uusimat .NET raamistikku.
- **Arendusvahend**: Kasuta uusimat Visual Studio versiooni. [Lae alla siit](https://visualstudio.microsoft.com/downloads/)
- **Koodi Kompileerimine**: Rakenduse kood peab olema vigadeta kompileeruv ning eelneva seadistuseta Visual Studiost avatav ning käivitatav.
- **Kasutajaliides**: Peab vastama HTML5 standardile. Soovitatav on kasutada raamistikku nagu Bootstrap.
- **Versioonihaldus**: Kasuta avalikult kättesaadavat Git repositooriumi (GitHub, GitLab või Bitbucket). Töö käik peab olema hindaja poolt versioonihaldusest selgelt jälgitav.

### Äriülesanne
**Külaliste registreerimissüsteem**
- **Üritused**: Võimaldab lisada, muuta ja vaadata toimunud ning tulevasi üritusi. Tulevasi üritusi saab ka kustutada.
- **Osavõtjad**: Iga üritusega saab seostada osavõtjaid, kes võivad olla eraisikud või juriidilised isikud (ettevõtted). Osavõtjate andmeid saab vaadata, muuta ning kustutada. Samuti saab osavõtjaid lisada teistele üritustele.
- **Nimekirjad**: Iga ürituse puhul peab saama näha täielikku nimekirja külalistest.

### Funktsionaalsed Nõuded
Rakendus peab koosnema järgmistest vaadetest:
1. **Avaleht**: Sisaldab loetelu toimunud ja tulevikus toimuvatest üritustest. Kuvatakse ürituse nimi, aeg, koht, osavõtjate arv, lingid osavõtja lisamiseks ja ürituse kustutamiseks.
2. **Ürituse Lisamise Vaade**: Vorm tulevaste ürituste lisamiseks, kus sisestatakse ürituse nimi, toimumisaeg, koht ja lisainfo. Peale lisamist toimub suunamine avalehele.
3. **Üritusest Osavõtvate Isikute Vaade**: Näitab kõiki üritusest osavõtvaid isikuid koos nende detailidega. Sisaldab ka kustutamisvõimalust ja nupu tagasi avalehele liikumiseks.
4. **Osavõtja Lisamise Vaade**: Vorm osavõtjate lisamiseks, kus saab valida, kas lisada füüsiline või juriidiline isik ja sisestada vastavad andmed.
5. **Osavõtja Detailandmete Vaatamise/Muutmise Vaade**: Võimaldab vaadata ja muuta osavõtja andmeid.


---

### Paigaldamise Juhend
1. **Klooni Repositoorium**:
    ```sh
    git clone <repository-url>
    ```
2. **Ava Projekt Visual Studios**:
    - Veendu, et kasutad uusimat Visual Studio versiooni.
    - Ava lahendusfail (`.sln`).

3. **Andmebaasi Seadistamine**:
    - Loo andmebaas vastavalt andmebaasi diagrammile.
    - Konfigureeri ühendusstring (`connection string`) vastavalt andmebaasi seadele.

4. **Rakenduse Käivitamine**:
    - Kompileeri ja käivita projekt Visual Studios.

5. **Testide Käivitamine**:
    - Käivita automaattestid, et veenduda rakenduse toimimises.

### Arhitektuuri Ülevaade
- **Kihtide Rollid**:
    - **Esitluskiht (Presentation Layer)**: Kasutajaliidese vaated ja interaktsioonid.
    - **Äriloogika kiht (Business Logic Layer)**: Ärilogika ja domeenimudelid.
    - **Andmekiht (Data Layer)**: Andmebaasi haldus ja andmete salvestamine.

### Kulunud Aeg
- Kirjelda ülesande lahendamiseks kulunud aega.

---

### Märksõnad
- **Domeenipõhine Disain**
- **Kihiline Arhitektuur**
- **Dependency Injection**
- **Inversion of Control**
- **Automatiseeritud Testimine**
- **Visual Studio**
- **C#**
- **.NET**