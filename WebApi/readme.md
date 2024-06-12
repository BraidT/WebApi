### Eesm�rk
�lesande eesm�rgiks on kontrollida kandidaadi teadmiseid C# keelest, objekt-orienteeritud programmeerimise �ldtunnustatud arendusmustrite/v�tete tundmise ja kasutamise oskuseid ning oskust enda loodava tarkvara dokumenteerimiseks ja kvaliteedi kontrollimiseks.

### T�� Sisuks
1. **�ri�lesande Realiseerimine**: Kasutades domeenip�hise disaini (Domain-Driven Design) printsiipe ja kihilist arhitektuuri koos sobivate arendusmustritega (n�rgad seosed kihtide vahel, dependency injection, inversion of control).
2. **Visuaalne Kasutajaliides**: Kasutajaliidese loomine, j�rgides kaustas �UI materjal� olevaid juhiseid.
3. **Andmebaas ja Andmebaasi Diagramm**: Loo andmebaas ja selle diagramm, kasutades sobivat abstraktsiooni (Microsoft SQL Server, SQLite, PostgreSQL, Oracle vms).
4. **Automatiseeritud Testid**: Koosta automaattestid tarkvara toimimise kontrollimiseks vastavalt etteantud n�uetele. Testimisraamistik vabal valikul.
5. **Dokumentatsioon**: Koosta minimaalne vajalik dokumentatsioon rakenduse paigaldamise kirjeldamiseks, �ldise ettekujutuse saamiseks rakenduse arhitektuurist ning rakenduse koodi m�istmiseks.

### Mittefunktsionaalsed N�uded
- **Keele ja Raamistiku Kasutamine**: Veebirakendus peab olema realiseeritud C# programmeerimiskeeles, kasutades uusimat .NET raamistikku.
- **Arendusvahend**: Kasuta uusimat Visual Studio versiooni. [Lae alla siit](https://visualstudio.microsoft.com/downloads/)
- **Koodi Kompileerimine**: Rakenduse kood peab olema vigadeta kompileeruv ning eelneva seadistuseta Visual Studiost avatav ning k�ivitatav.
- **Kasutajaliides**: Peab vastama HTML5 standardile. Soovitatav on kasutada raamistikku nagu Bootstrap.
- **Versioonihaldus**: Kasuta avalikult k�ttesaadavat Git repositooriumi (GitHub, GitLab v�i Bitbucket). T�� k�ik peab olema hindaja poolt versioonihaldusest selgelt j�lgitav.

### �ri�lesanne
**K�laliste registreerimiss�steem**
- **�ritused**: V�imaldab lisada, muuta ja vaadata toimunud ning tulevasi �ritusi. Tulevasi �ritusi saab ka kustutada.
- **Osav�tjad**: Iga �ritusega saab seostada osav�tjaid, kes v�ivad olla eraisikud v�i juriidilised isikud (ettev�tted). Osav�tjate andmeid saab vaadata, muuta ning kustutada. Samuti saab osav�tjaid lisada teistele �ritustele.
- **Nimekirjad**: Iga �rituse puhul peab saama n�ha t�ielikku nimekirja k�lalistest.

### Funktsionaalsed N�uded
Rakendus peab koosnema j�rgmistest vaadetest:
1. **Avaleht**: Sisaldab loetelu toimunud ja tulevikus toimuvatest �ritustest. Kuvatakse �rituse nimi, aeg, koht, osav�tjate arv, lingid osav�tja lisamiseks ja �rituse kustutamiseks.
2. **�rituse Lisamise Vaade**: Vorm tulevaste �rituste lisamiseks, kus sisestatakse �rituse nimi, toimumisaeg, koht ja lisainfo. Peale lisamist toimub suunamine avalehele.
3. **�ritusest Osav�tvate Isikute Vaade**: N�itab k�iki �ritusest osav�tvaid isikuid koos nende detailidega. Sisaldab ka kustutamisv�imalust ja nupu tagasi avalehele liikumiseks.
4. **Osav�tja Lisamise Vaade**: Vorm osav�tjate lisamiseks, kus saab valida, kas lisada f��siline v�i juriidiline isik ja sisestada vastavad andmed.
5. **Osav�tja Detailandmete Vaatamise/Muutmise Vaade**: V�imaldab vaadata ja muuta osav�tja andmeid.


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
    - Konfigureeri �hendusstring (`connection string`) vastavalt andmebaasi seadele.

4. **Rakenduse K�ivitamine**:
    - Kompileeri ja k�ivita projekt Visual Studios.

5. **Testide K�ivitamine**:
    - K�ivita automaattestid, et veenduda rakenduse toimimises.

### Arhitektuuri �levaade
- **Kihtide Rollid**:
    - **Esitluskiht (Presentation Layer)**: Kasutajaliidese vaated ja interaktsioonid.
    - **�riloogika kiht (Business Logic Layer)**: �rilogika ja domeenimudelid.
    - **Andmekiht (Data Layer)**: Andmebaasi haldus ja andmete salvestamine.

### Kulunud Aeg
- Kirjelda �lesande lahendamiseks kulunud aega.

---

### M�rks�nad
- **Domeenip�hine Disain**
- **Kihiline Arhitektuur**
- **Dependency Injection**
- **Inversion of Control**
- **Automatiseeritud Testimine**
- **Visual Studio**
- **C#**
- **.NET**