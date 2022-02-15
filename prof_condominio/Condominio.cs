using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
public class Condominio
{
    // ATTRIBUTI
    protected List<Spesa> tabella;

    // COSTRUTTORE
    public Condominio(int numero_spese=0)
    {
        tabella = new List<Spesa>(numero_spese);
    } // fine costruttore
//salve
    // PROPERTY
    public Spesa this[int indice]
    {
        get
        {
            return tabella[indice];
        } // fine get
        set
        {
            tabella[indice] = value;
        } // fine set
    } // fine property

    public int Length
    {
        get
        {
            return tabella.Count;
        } // fine get
    } // fine property

    // METODI
    public bool ExistsCondomino(string cognome_cercato)
    {
        bool trov = false;
        foreach(Spesa x in tabella)
            if(string.Compare(x.Cognome, cognome_cercato, true)==0)
            {
                trov = true;
                break;
            } // fine if               
        return trov;
    } // fine metodo

    public void Add(Spesa nuova_spesa)
    {
        tabella.Add(nuova_spesa);
        //Array.Resize(ref tabella, tabella.Length + 1);
        //tabella[tabella.Length - 1] = nuova_spesa;
    } // fine metodo

    public void RemoveAt(int posizione)
    {
        tabella.RemoveAt(posizione);
        //for(int i=posizione; i<this.Length-1; i++)
        //{
        //    tabella[i] = tabella[i+1];
        //} // fine for
        //Array.Resize(ref tabella, tabella.Length - 1);
    } // fine metodo

    public void SaveFileCSV(string NomeFile)
    {
        using (StreamWriter fileW = new StreamWriter(NomeFile, false))
        {
            foreach (Spesa record in tabella)
            {
                fileW.WriteLine(record.ToStringCSV());
            } // fine foreach
            // fileW.Close();
        } // fine using
    } // fine metodo

    public void LoadFileCSV(string NomeFile)
    {
        string rigaCSV;
        Spesa record_letto;
        // prima di caricare nuovi record cancello la tabella
        tabella.Clear();
        using( StreamReader file = new StreamReader(NomeFile))
        {
            while(!file.EndOfStream)
            {
                rigaCSV = file.ReadLine();
                if(rigaCSV != null && rigaCSV.Length>0)
                {
                    record_letto = new Spesa();
                    record_letto.FromStringCSV(rigaCSV);
                    this.Add(record_letto);
                } // file if
            } // fine while
        } // fine using
    } // fine metodo

    public decimal TotaleCondominio()
    {
        decimal totale;
        totale = 0m;
        foreach (Spesa x in tabella)
            totale += x.Totale;
        return totale;
    } // fine metodo

    public void Clear()
    {
        tabella.Clear();
    } // fine metodo

   public void Sort()
    {
        tabella.Sort();
    } // fine metodo

} // fine costruttore

