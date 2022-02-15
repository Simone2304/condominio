using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.RegularExpressions;


class CondominioXML : Condominio
{
    public void LoadFileXML(string NomeFile)
    {
        string docXML, pattern, rigaXML;
        Spesa nuovo_record;
        int pos_start, pos_stop;
        MatchCollection lista_match;
        // prima di caricare nuovi record cancello la tabella
        tabella.Clear();
        // leggo intero contenuto file XML
        using (StreamReader file = new StreamReader(NomeFile))
        {
            docXML = file.ReadToEnd();
        } // fine using
        // ricerco il pattern <spesa>
        pattern = "<spesa>";
        lista_match = Regex.Matches(docXML, pattern);
        // estrazione dei record <spesa>
        for (int i = 0; i < lista_match.Count; i++)
        {
            nuovo_record = new Spesa();
            pos_start = lista_match[i].Index;
            if (i == lista_match.Count - 1) // all'ultimo record/riga
            {
                pos_stop = docXML.Length;
            } // fine if
            else
            {
                pos_stop = lista_match[i + 1].Index;
            } // fine else
            rigaXML = docXML.Substring(pos_start, pos_stop - pos_start);
            nuovo_record.FromStringXML(rigaXML);
            tabella.Add(nuovo_record);
        } // fine for
    } // fine metodo

    public void SaveFileXML(string NomeFile)
    {
       
        using (StreamWriter fileW = new StreamWriter(NomeFile, false))
        {
            fileW.WriteLine("<?xml version=\"1.0\" ?>");
            fileW.WriteLine("<condominio>");
            foreach (Spesa record in tabella)
            {
                fileW.WriteLine(record.ToStringXML());
            } // fine foreach
            fileW.WriteLine("</condominio>\n");
        } // fine using
    } // fine metodo

} // fine classe
