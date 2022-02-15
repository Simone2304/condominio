using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Spesa : IComparable
{
    // ATTRIBUTI
    public string Cognome { get; set; } // property-attributo auto-implementata
    protected decimal _luce;
    protected decimal _H2O;
    protected decimal _gas;

    // COSTRUTTORE
    public Spesa(string Cognome = "", decimal Luce = 0m, decimal H2O = 0m, decimal Gas = 0m)
    {
        this.Cognome = Cognome;
        _luce = Luce;
        _H2O = H2O;
        _gas = Gas;
    } // fine costruttore

    // PROPERTY
    public decimal Luce
    {
        get
        {
            return _luce;
        } // fine get
        set
        {
            if (value >= 0m)
                _luce = value;
            else
                throw new FormatException("La luce deve essere positiva!");
        } // fine set
    } // fine property
    public decimal H2O
    {
        get
        {
            return _H2O;
        } // fine get
        set
        {
            if (value >= 0m)
                _H2O = value;
            else
                throw new FormatException("L'acqua deve essere positiva!");
        } // fine set
    } // fine property
    public decimal Gas
    {
        get
        {
            return _gas;
        } // fine get
        set
        {
            if (value >= 0m)
                _gas = value;
            else
                throw new FormatException("Il gas deve essere positiva!");
        } // fine set
    } // fine property

    public decimal Totale
    {
        get
        {
            return _luce + _H2O + _gas;
        } // get
    } // fine property

    // METODI

    // #### formato CSV ####
    public string ToStringCSV()
    {
        return $"{Cognome} # {_luce} # {_H2O} # {_gas}";
    } // fine metodo

    public void FromStringCSV(string strCSV)
    {
        string[] campi;
        campi = strCSV.Split("#");
        this.Cognome = campi[0].Trim();
        this._luce = decimal.Parse(campi[1].Trim());
        this._H2O = decimal.Parse(campi[2].Trim());
        this._gas = decimal.Parse(campi[3].Trim());
    } // fine metodo

    public int CompareTo(object objB)
    {
        Spesa A = this;
        Spesa B = (Spesa)objB;
        return String.Compare(A.Cognome, B.Cognome, true);
    } // fine metodo

    // #### formato XML ####

    public string ToStringXML()
    {
        return $"<spesa>\n\t" +
               $"<cognome>{Cognome}</cognome>\n\t" +
               $"<luce>{_luce}</luce>\n\t" +
               $"<H2O>{_H2O}</H2O>\n\t" +
               $"<gas>{_gas}</gas>\n" +
               $"</spesa>";  
    } // fine metodo

    public void FromStringXML(string strXML)
    {
        this.Cognome = LeggiDatoTag(strXML,"cognome");
        this._luce   = decimal.Parse(LeggiDatoTag(strXML, "luce"));
        this._H2O    = decimal.Parse(LeggiDatoTag(strXML, "H2O"));
        this._gas    = decimal.Parse(LeggiDatoTag(strXML, "gas"));
    } // fine metodo

    private string LeggiDatoTag(string strXML, string nome_tag)
    {
        int pos1, pos2;
        pos1 = strXML.IndexOf("<" + nome_tag + ">", 0); // inizio <tag>
        pos1 = pos1 + nome_tag.Length + 2;
        pos2 = strXML.IndexOf("</" + nome_tag + ">", pos1); // fine </tag>
        return strXML.Substring(pos1, pos2 - pos1).Trim();
    } // fine metodo

} // fine classe

