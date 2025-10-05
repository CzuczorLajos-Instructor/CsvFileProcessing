# CSV fájl feldolgozása (asztalok)

Írj konzolos C# programot, amely egy CSV fájlból olvasott adatokat
dolgozza fel! Az IDE projekt neve **CsvFileProcessing**.

Az Asztalok.csv fájl olyan asztalok adatait tartalmazza, amelyeket egy
bútormanufaktúra egyedi megrendelésekre gyártott le az elmúlt években.
Ennek a fájlnak készíts külön mappát Data névvel a projekt fő
mappájában!

Ahogy az a fájlban látható, a manufaktúrában az asztalok sokféle
méretben készültek, illetve, hogy egy-egy nevet (női keresztnevet)
rendeltek az asztalok mindegyikéhez. A fájl fejléce szerint a fájl
egy-egy sorában az adatok sorrendje a következő:

-   hozzárendelt név
-   hossz
-   szélesség
-   ár

A program az alábbiakat végezze el, ill. az alábbi kérdésekre adjon
választ!

1.  Ha vannak a fájlban nem értelmezhető, azaz hibás adatsorok, a
    program listázza ki azokat! Definiálnád pontosan, hogy mi számít
    hibának, és ennek megfelelően valósítsd meg a programnak ezt a
    funkcióját!

2.  Hány asztal adatai szerepelnek a fájlban?

3.  Hány olyan asztal van, amelynek a hosszúsága kisebb, mint a
    szélessége?

4.  Mekkora a legkisebb felületű asztallap felülete (területe) és
    mekkora a legnagyobbé?

5.  Hány asztal \[lapjának\] felülete haladja meg a legnagyobb asztal
    felületének ***80%***-át?

6.  Mennyi azoknak az asztaloknak az összesített ára, amelyekhez rövid
    ***I*** vagy hosszú ***Í*** betűvel kezdődő nevek tartoznak?

7.  Mennyi a teljes felülete azoknak az asztaloknak, amelyekhez ***a***
    betűre végződő keresztnevek tartoznak ***és*** az áruk meghaladja az
    ***50*** ezer egységet?

8.  Hány olyan asztal van, amelyeknek a hosszúság--szélesség aránya
    meghaladja a ***2,5***-et?

9.  Mennyi az asztalok átlagára?

Mielőtt elkezded megírni a programot, egyrészt gondold végig, milyen
adatstruktúra szolgálná legjobban a fenti lekérdezések megvalósítását!

Másrészt nézz utána annak is, hogy a .NET platformon, C#-ban hogyan kell
megoldani az alábbi rutinfeladatokat!

a)  Hogyan kaphatjuk meg projekt fő mappájának elérési útját? És a fent
    említett mappában lévő, feldolgozandó adatfájlét?

b)  Hogyan szervezhetünk ciklust egy szövegfájl sorról sorra történő
    beolvasására (és feldolgozására)?

c)  Hogyan szervezhetünk ciklust egy szövegfájl létrehozatalára és
    sorról sorra történő feltöltésére (írására)?

d)  A fájlműveletek -- mint az I/O műveletek általában -- dobhatnak
    kivételt, többfélét is. Ha nem kezeljük le korrekt módon a
    kivételeket, nyitva maradhatnak az éppen olvasott és/vagy írt
    fájlok. Ilyenkor az operációs rendszer zárolja („lockolja") az
    érintett fájlokat, azaz más felhasználók számára letiltja az
    elérésüket. Közös használatú (hálózati) meghajtókon ez nyilvánvalóan
    nem kívánatos. Hogyan lehet ezt megelőzni? Másképpen: hogyan kell
    úgy szervezni a C# kódot, hogy a fájlok mindenképpen -- kivétel
    dobása esetén is -- bezáródjanak?
