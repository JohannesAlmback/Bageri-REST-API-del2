Inlämningsuppgift 2
Koden är refakturerad ifrån föregående inlämningsuppgift. Jag har nu använt mig av repositories och interfaces. Jag har satt enable på nullable i .csproj och fixat till alla varningar i koden. Jag har även delat in projektet i api, core och infrastructure. När programmet startar upp med ny databas så fylls databasen med data från json dokument i infrastructure/Data/Json. 

- Endpoint för inlämning 2
    - Lägga till kunder med adresser.
    - Lägga till kontaktperson till vald kund och uppdatera vid behov.
    - Lista kunder med information och dess beställningshistorik.
    - Lägga till ny produkt.
    - Lista produkter och hämta ut enskilda.
    - Uppdatera priset på vald produkt.
    - Skapa en ny beställning.
    - Söka efter beställningar på beställningsnummer och beställningsdatum. Om ingen sökning anges i URL:en så listas alla beställningar. När en eller flera beställningar listas så presenteras information om vilken kund som lagt beställningen och vilka produkter som är beställda.

Jag har även skapat en Postgres container via en Dockerfil. Detta var besvärligt men fick det till sist att fungera men med några varningar när jag körde "docker compose up". Databasen fungerar och jag får in datat från Json mappen.

