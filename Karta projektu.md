## APLIKACJA PRZYJAZNA RODZICOM
#### KARTA PROJEKTU

26/01/2019 

Spis treśći


1.  WSTĘP
    1.  Cel karty projektu
    2. Zarys projektu
    3. Uzasadnienie biznesowe   
2.	ZAKRES	
    1.	Cele	
    2.	Wymagania funkcjonalne	
3.	CZAS TRWANIA	
    1.	Harmonogram	
    2.	Etapy	
4.	SZACOWANY BUDŻET	
    1.	Fundusze	
5.	ORGANIZCJA PROJEKTU	
    1.	Podział obowiązków	
    2.	Osoba zaangażowana w projekt
  
* DODATEK A: PRZYPADKI UŻYCIA	
* DODATEK B: MODEL STRUKTURY DANYCH	
* DODATEK C: PROJEKT ARCHITEKTURY SYSTEMU (DIAGRAMY KLAS)	
* DODATEK C: DIAGRAMY SEKWENCJI	


1.	WSTĘP


        1.1 CEL KARTY PROJEKTU
    
   
Karta projektu ‘Aplikacja przyjazna rodzicom’ stanowi dokumentację i dostarcza koniecznych informacji odnośnie omawianego produktu. Karta zawiera informacje dotyczące zakresu, potrzeb biznesowych oraz środków, które są do dyspozycji dla realizacji projektu.


    1.2	ZARYS PROJEKTU
    
    
Zrealizowana aplikacja powinna być adresowana przede wszystkim do rodziców dzieci w wieku 0-12 lat. Powinna ona w łatwy sposób pozwalać sprawdzić gdzie w pobliżu miejsca, które interesuje użytkownika, znajdują się miejsca przyjazne dla jego dziecka. Produkt powinien być dostępnym przede wszystkim jako aplikacja mobilna, ale również jako strona internetowa.


    1.3	UZASADNIENIE BIZNESOWE
    
    
Aplikacja ma szanse zdobyć dużą popularność wśród docelowych odbiorców. Pomysł na jej stworzenie jest częściowo wynikiem osobistego doświadczenia twórcy i pomysłodawcy projektu oraz wielokrotnie wśród potencjalnych użytkowników zasłyszanej opinie, według której podobne narzędzie mogłoby być bardzo potrzebne. 
Obecnie nie ma źródła, z którego można by było czerpać dane potrzebne do funkcjonowania aplikacji.Według naszych założeń program, będzie funkcjonował na zasadzie podobnej do „user generated content”. To użytkownicy aplikacji mieliby początkowo dostarczać informacji na temat miejsc, które są przyjazne dzieciom. Pozwoliłoby to na dodatkowe zaktywizowanie społeczności odbiorców.  W przypadku zyskania popularności aplikacja mogłaby zacząć pełnić funkcję portalu społecznościowego (tematyczne fora dyskusyjne, sprzedaż/wymiana towarów itp). Jedyna podobna aplikacja działająca na polskim rynku to Mapa Mamy https://www.mapamamy.pl/. W  przypadku tej aplikacji brakuje wersji mobilnej, która dla potencjalnych użytkowników jest najbardziej praktyczna i przydatna.

2.	ZAKRES


        2.1	CELE
        
        
*	Stworzenie aplikacji internetowej z użyciem map jednego z popularnych providerów oraz geolokalizacji (pierwsza wersja) oraz przestrzennej bazy danych
*	Publikacja aplikacji po odpowiednim przetestowaniu funkcjonalności
*	Stworzenie i publikacja wersji mobilnej i jej publikacja

        2.2	 WYMAGANIA
      
      
*	Aplikacja powinna mieć dwa typy widoków. Mapę (domyślny widok), która będzie pokazywała obecne położenie użytkownika za pomocą geolokalizacji. Drugim widokiem jest lista z dostępnymi kategoriami (restauracje, placówki kulturalne itp.)
*	Aplikacja musi zapewnić w prosty sposób możliwość dodawania, oceniania i aktualizowania danych dotyczących miejsc widocznych na mapie poprzez podanie współrzędnych geograficznych, zdjęć, krótkiego opisu.
*	Oglądać mapę mogą wszyscy użytkownicy. Możliwość dodawania miejsc, komentować i oceniać ich będą mieli jedynie użytkownicy zalogowani i zweryfikowani.
*	Do aplikacji można będzie się zalogować używając konta z innych portalów społecznościowych (Facebook, Twitter, Google+)
*	Aplikacja powinna być dostępna w formie aplikacji webowej oraz mobilnej (Android). Ewentualni również aplikacji desktopowej na Windows.
*	Możliwość zapamiętywania ulubionych miejsc. Filtrowania i zapisywania wyników.
*	Miejsca powinny być podzielone na następujące kategorie: restauracje, placówki kulturalne, placówki ochrony zdrowia, place zabaw, sklepy z wybranymi artykułami. Dodatkowo powinny być widoczne osobne podkategorie jak miejsca, w których można liczyć na dodatkowe udogodnienia np. przewijak, podjazd dla wózków, kącik zabaw dla dzieci, miejsce gdzie można nakarmić dziecko. Po wybraniu odpowiedniego zestawu kategorii na mapie powinny pozostać tylko miejsca, które interesują użytkownika.
*	Sama mapa również powinna mieć dwa widoki: standardowe oraz zdjęcie satelitarne
*	Na ekranie powinien być przycisk, który pozwoli użytkownikowi w każdej chwili wrócić do miejsca na mapie, w którym obecnie się znajduje.
*	Aplikacja powinna również zawierać krótki samouczek



3.	CZAS TRWANIA

        3.1	HARMONOGRAM
        
       

![Harmonogram](https://raw.githubusercontent.com/marlej1/Aplikacka-przyjazna-rodzicom/master/Harmonogram.PNG)

4	SZACOWANY BUDŻET

        4.1	FUNDUSZE I SPOSOBY FINANSOWANIA
        
        
W tej  chwili projekt nie ma zewnętrznego finanasowania. Wszelkie koszy związanie z treningami, sprzętem są pokrywane przez wyłącznie przez twórcę tego projekt.

5.	ORGANIZACJA  - ROLE I ZADANIA


 Na obecną chwilę jedyną osobą zaangażowaną w projekt jest jego twórca i autor tego dokumentu.
 
 
<h3><b> DODATEK A: PRZYPADKI UŻYCIA	</b></h3>

<b><p>A. Filtrowanie miejsc pod względem na kategorii</p></b>


Aktor | Użytkownik | Rozszerzenia
------------ | ------------- | ------
Warunek Początkowy | Użytkownik nie musi być  zalogowany dos systemu. Użytkownik cche zobaczyć miejsca w jego okolicy, które należą do intersującej go kategorii | -
Warunek Końcowy|Na ekranie widać przeczywistą pozycję urządzenia/użytkownika. Zaznaczone są wszystkie miejsca w promieniu kilkuse metrów | -
Główny scenariusz powodzenia|<ol><li>Jeśli nie jest otwarty widok mapy, użytkownik otwiera go.</li><li>Użytkownik wybiera z wysuwanego  menu, które znajduje się po lewej stronie ekranu, jedną lub kilka  kategorii(Aplikacja zakłada możliwość mieszania katgorii). </li><li> System filtruje wyniki zgodnie za zapytaniem użytkownika</li><li> Na ekranie zostają wyświetlone wyniki z z ikonkami  przypisanymi do odpowiednich kategorii</li></ol>| -

<b><p>B. Dodawanie miejsc do bazy danych(Użytkownik)</p></b>


Aktor | Użytkownik | Rozszerzenia
------------ | ------------- | ------
Warunek Początkowy | Użytkowni musi być zalogowany do systemu. Użytkownik chce dodać nowe miejsce, które do tej pory nie jest widoczne na mapie| -
Warunek Końcowy|Nowe miejsce wraz z ze wszystkimi wymaganami danymi zostają dodane do bazy danych.| -
Główny scenariusz powodzenia|<ol><li>Jeśli nie jest otwarty widok mapy, użytkownik otwiera go.</li><li>Użytkownik z menu wybiera formularz,który służy do dodawania nowych miejsc do bazy danych</li><li>System sprwadza poprawność danych. Wymagane dane to m in. nazwa, miejsca, adres(wraz z kodem pocztowym) i/lub współrzędne geograficzny. Przy dodawaniu miejsca należy wybrać przynajmniej jedną kategorię. </li><li> Przy dodawaniu miejsca będzie można załączyć, krótki opis, zdjęcia oraz ocena w skali od 1 do 5 </li><li>Po sprawdzeniu przez system poprawności danych administrator dostaje powiadomienie o nowym miejscu</li><li>Po sprawdzeniu przez system poprawności danych administrator dostaje powiadomienie o nowym miejscu</li></ol>| -



<b><p>C. Dodawanie miejsc do bazy danych i akceptacja propoycji użytkowników(Administrator)</p></b>


Aktor | Administrator | Rozszerzenia
------------ | ------------- | ------
Warunek Początkowy | Administrator cche zaakceptować miejsce zaproponowane przez użytkownika lub sam dodać nowe miejsce | -
Warunek Końcowy|Miejsce zostaje zaakceptowane i dodane do bazy danych | -
Główny scenariusz powodzenia|<ol><li>Użytkownik loguje się do panelu administratora</li><li>Administrator sprawdza czy dane nadają się do publikacji(np . czy nie zawierają obraźliwych treści)</li><li>Jeśli wszystko się zgadza, administrator klika przycis akceptuj </li><li> Nowa propozycja zostaja dodan ado bazy danych. Powinna w jak najszybszym czasie poajawić się na ekranie</li></ol>| -


<b><p>C. Znajdowania najkrószej drogi do wybranego miejsca</p></b>


Aktor | Użytkownik | Rozszerzenia
------------ | ------------- | ------
Warunek Początkowy | Użykownik chce dostać się w najkrótszym czasei do wybranego przez siebie miejsca | -
Warunek Końcowy|Aplikacja pokazuje propozycje w jakie można dotrzeć do wybranego miejsca | - 
Główny scenariusz powodzenia|<ol><li>Użytkownik znajduje miejsce, do którego chciałby dotrzeć</li><li>Użytkownik wybiera sposób , w jaki chciałbym dotrzeć do wybranego miejsca(piechotą, komunikacją publiczną, samochodem)</li><li>Aplikacja sprawdza możliwe trasy dojazdu i proponuje 2-3 najbardzie dogodne</li></ol>| -


<h3><b> DODATEK B: DIAGRAM KLAS	</b></h3>


![Image of Yaktocat](https://raw.githubusercontent.com/marlej1/Aplikacka-przyjazna-rodzicom/master/DiagramKlas.PNG)



