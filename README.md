PROBLEMA. Si deve realizzare per un condominio il software per il pagamento delle spese (Luce, H2O oppure Gas) tutte espresse in euro. 

Cognome condomino	Luce	H2O	Gas
Rossi	15,70	150,40	500,60

Neri	14,50	300,70	570,70

Verdi	13,50	100,40	680,60

Gialli	12,50	148,50	801,40

Bianchi	17,90	180,20	424,50


L’amministratore del condominio necessita delle seguenti operazioni mediante un’app WPF di nome cognome_condominio.

1.	Definire il modello dei dati del problema fondato su una classe/record/riga Spesa e una classe/archivio/tabella Condominio.
•	Definire una nuova classe Spesa applicando in modo corretto l’incapsulamento dei dati (costruttore e property): convalidare tutti i dati delle spese in modo che tutte le spese non possano mai avere un valore negativo mediante la generazione di un oggetto della classe FormatException. 
•	Definire una nuova classe Condominio che contenga come attributo privato la tabella con le spese. Applicare in modo corretto l’incapsulamento dei dati mediante l’indicizzazione della tabella.
•	Creare l’interfaccia grafica WPF con un datagrid che permetta di eseguire il data binding con la tabella del condominio.



2.	Aggiungere una nuova spesa dalla GUI in modo dinamico (metodo Add() nella classe Condominio).
•	Prima di aggiungere una spesa verificare che il nome del condomino non sia già presente nella tabella e, in questo caso, vietare l’aggiunta della nuova riga. Definire un metodo ExistsCondomino() della classe Condominio().

3.	Rimuovere una spesa dalla tabella dato il numero della riga (metodo RemoveAt() nella classe Condominio).
•	Prima di rimuovere una spesa verificare che la riga esista nella tabella. mediante un metodo ExistCondomino() della classe Condominio().

4.	Visualizzare i dati sulla GUI in tempo reale ad ogni modifica (inserimento, cancellazione) della tabella.

5.	Aggiungere la possibilità di salvare e recuperare i dati da un archivio-file, il cui nome è scelto nella GUI, usando il formato CSV con questo formato: 
cognome # luce # H2O # gas
•	Facoltativo: salvare i dati anche in formato XML (a scelta dell’utente mediante delle check box) con questo formato:
<condominio>
	<spesa>
		<cognome>...</cognome>
          <luce>...</luce>
          <H2O>...</H2O>
          <gas>...</gas>
	</spesa>
	<spesa>
         ...
	</spesa>
...
</condominio>

6.	Dato il nome di un condomino ricercare quanto deve pagare per una determinata spesa (Luce, H2O oppure Gas).
•	Selezionare la spesa mediante una lista a comparsa con le tre spese e il nome del condomino, dopo aver verificato che esista nella tabella.

7.	Dato il nome di un condomino calcolare l’importo totale delle sue spese.
•	Implementare questa operazione mediante una property a sola lettura di nome TotaleSpese nella classe Spesa.

8.	Calcolare l’importo totale che deve pagare l’amministratore dell’intero condominio.
•	Implementare questa operazione mediante una property a sola lettura di nome TotaleSpese nella classe Condominio.

9.	Facoltativo: riordinare la tabella sulla base sulla base dei nomi dei condomini e, dopo aver aggiornato la GUI, salvare i dati ordinati in un file XML con questo formato:
<condominio spesa_totale="…">
	<spesa>
		<cognome>...</cognome>
      <totale>...</totale>
	</spesa>
	<spesa>
         ...
	</spesa>
...
</condominio>

Il tag <totale> riporta per ogni condomino la sua spesa totale, mentre la proprietà del condominio spesa_totale riporta la spesa complessiva del condominio.
