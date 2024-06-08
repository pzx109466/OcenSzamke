SZCZEGÓŁOWA INSTRUKCJA PIERWSZEGO URUCHOMIENIA WRAZ Z PORADNIKIEM / SCREENAMI ZNAJDUJE SIĘ W PLIKU Z DOKUMENTACJĄ TECHNICZNą 

Instrukcja pierwszego uruchomienia - sposób 1
Zacznijmy od przygotowania oprogramowania potrzebnego do uruchomienia aplikacji.
1) Potrzebny będzie program Microsoft Visual Studio 2022, należy pobrać Microsoft Visual Studio Installer do wersji Community ze strony:
https://visualstudio.microsoft.com/pl/free-developer-offers/
2) Podczas instalacji ważne jest zaznaczenie poniższej opcji:

Jeśli już wcześniej instalowaliśmy Microsoft Studio 2022 możemy doinstalować wybraną opcję poprzez “Narzędzia->Pobierz narzędzia i funkcje…”.
3) Następnie trzeba uruchomić Visual Studio oraz wybrać pierwszą opcję jaką jest “Klonuj repozytorium…”
4) Następnie wklejamy odpowiedni link do repozytorium znajdujący się poniżej, automatycznie powinno nam dobrać lokalizację pliku jako C:\Users\*nazwa*\Source\Repos\OcenSzamke

Link: https://github.com/pzx109466/OcenSzamke
Oraz klikamy przycisk “Klonuj”

5) W tym momencie musimy upewnić się czy mamy zainstalowane odpowiednie pakiety NuGet poprzez wejście w “Narzędzia->Menedżer pakietów NuGet->Zarządzaj pakietami NuGet rozwiązania…”.

a) Microsoft.AspNetCore.Identity.EntityFrameworkCore
b) Microsoft.AspNetCore.Identity.UI
c) Microsoft.Entity.FrameworkCore.Sqlite
d) Microsoft.Entity.FrameworkCore.SqlServer
e) Microsoft.EntityFrameworkCore.Tools
f) Microsoft.VisualStudio.Web.CodeGeneration.Design


Jeśli ich nie ma, należy je zainstalować poprzez opcję również widoczną na screenie “Przeglądaj”->Wyszukaj->Instaluj

9) W kolejnym kroku potrzebujemy stworzyć nową migrację oraz zaktualizować bazę dancyh, dokładniej w kolejności jak poniżej:
1-Wybieramy “Narzędzia->Menedżer pakietów NuGet->Konsola menedżera pakietów”
2-Wpisujemy komendę “Add-Migration TestowaMigracja” i klikamy enter:

Operacja powinna zakończyć się sukcesem:

3-Wpisujemy komendę “Update-Database” i klikamy enter:

Operacja powinna zakończyć się sukcesem:

4- W tym momencie możemy uruchomić aplikację przyciskiem jak poniżej, przekieruje nas automatycznie do przeglądarki i możemy rozpocząć test wszystkich funkcjonalności opisanych w tej dokumentacji. Jeśli ten przycisk nie nazywa się https możemy rozwinąć strzałkę obok oraz go wybrać.
Jeśli automatycznie nie przekieruje do przeglądarki to należy w niej wpisać localhost.  Aby uniknąć problemu z certyfikatem w przeglądarce warto wybrać, aby uruchomić projekt w trybie HTTP.




Instrukcja pierwszego uruchomienia - sposób 2
Jeśli z jakiegoś powodu wystąpiła potrzeba manualnego zainstalowania aplikacji możemy to zrobić bezpośrednio poprzez pobranie pliku .zip projektu przez GitHub’a Aby to zrobić na stronie projektu rozwijamy zielony przycisk Code (https://github.com/pzx109466/OcenSzamke)  i pobieramy plik

Pobrany plik należy rozpakować w folderze user/source/repos

Przechodzimy przez foldery i uruchamiamy plik OcenSzamke.sln za pomocą Visual Studiio 2022

Może wyskoczyć ostrzeżenie bezpieczeństwa, aby przejść dalej trzeba po prostu kliknąć Otwórz i pogodzić się z ryzykiem

Kolejnym krokiem jest upewnienie się, że wszystkie wymagane pakiety NuGet są zainstalowane w: Narzędzia->Menedżer pakietów NuGet->Zarządzaj pakietami NuGet rozwiązania…

a) Microsoft.AspNetCore.Identity.EntityFrameworkCore
b) Microsoft.AspNetCore.Identity.UI
c) Microsoft.Entity.FrameworkCore.Sqlite
d) Microsoft.Entity.FrameworkCore.SqlServer
e) Microsoft.EntityFrameworkCore.Tools
f) Microsoft.VisualStudio.Web.CodeGeneration.Design

Jeśli ich nie ma, należy je zainstalować “Przeglądaj”->Wyszukaj->Instaluj

Jeśli tą część mamy za sobą konieczne jest jeszcze stworzenie migracji i aktualizacji bazy danych, w tym celu:
Wybieramy “Narzędzia->Menedżer pakietów NuGet->Konsola menedżera pakietów” i wpisujemy kolejno: 
“Add-Migration [nazwa - np. TestowaMigracja]”
“Update-Database”

Po przeprowadzeniu tych czynności wszystko powinno już działać. Jesteśmy gotowi do uruchomienia i testowania projektu. Aby uniknąć problemu z certyfikatem w przeglądarce warto wybrać, aby uruchomić projekt w trybie HTTP.

