# Bază de date pentru o firmă de turism

## Descrierea Temei de Proiect

Se doreste informatizarea unei agentii de turism a carei oferta consta in excursii (sejur,circuit,croaziera) pe sezoane,oferte speciale(revelion, pasti, 1 mai, last minute, etc.), in mai multe tari. In fiecare tara exista oferte de sejururi pentru mai multe loclalitati pentru care se precizeaza perioada, tip cazare (denumire- hotel-pensiune-apartamente-etc.,categorie (nr stele/margarete), facilitati, mic dejun/demipensiune/pensiune completa/all inclusive, transport: propriu/autocar/avion. Pentru circuite se precizeaza traseul exact, numarul de nopti , facilitate cazare, vizite incluse,etc. Pentru croaziere, perioada,categorie vas, facilitate, traseu, vizite incluse, etc. Pentru toate excursiile se precizeaza pretul pe sejur/croaziera/circuit de persoana. Copii beneficiaza de reducere 50% pentru cazare doar, nu si transport.
Pentru fiecare client se retin datele personale(cele din buletin/pasaport). Un client in momentul in care opteaza pt o excusrsie face o rezervare si poate plati integral, sau doar un avans de 20%, pentru care se elibereaza chitante . Daca plateste integral beneficiaza de o reducere de 5% din costul excursiei. Daca renunta la rezervare pierde suma data ca avans, sau daca a achitat integral, pierde doa 20% din suma.

## Cerinte extra

•	Se poate lista in orice moment oferta completa a agentiei sau numai pe : tip/sezon/oferte speciale/tara/in functie de un anumit camp (!!!cel putin o lista)(tip cazare, cu sau fara transport, etc.) sau numai oferta unei anume excursii.
•	Se vor tipari chitante pentru fiecare incasare.
•	Se poate obtine o lista anuala cu toti clientii agentiei . Daca un client a folosit serviciile agentiei de mai multe ori intr-un an,el va fi marcat in baza de date cu un camp special (Client top) .In acet caz beneficiaza de o reducere de 2% la orice excursie.
•	Se vor obtine situatii cu incasarile firmei lunar, anual, precum si situatia reducerilor acordate lunar si annual.

## Structura tabelelor create

Baza de date este formata din urmatoarele tabele:
##### Pentru sectiunea de excursii/oferte:

Sejururi:

![SejururiImage](/images/Sejururi.png)

Croaziere

![CroaziereImage](/images/Croaziere.png)

Circuite

![CircuiteImage](/images/Circuite.png)

Oferte

![OferteImage](/images/Oferte.png)

##### Pentru sectiunea de management

Clienti

![ClientiImage](/images/Clienti.png)

Incasari

![IncasariImage](/images/Incasari.png)
