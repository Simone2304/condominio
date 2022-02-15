using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace prof_condominio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ATTRIBUTI
        private CondominioXML oggetto;

        // COSTRUTTORE
        public MainWindow()
        {
            InitializeComponent();
            oggetto = new CondominioXML();
        } // fine costruttore

        // METODI
        private void UpgradeGUI()
        {
            dataGrid.Items.Clear();
            for(int i=0; i<oggetto.Length; i++)
                dataGrid.Items.Add(oggetto[i]);
            txtTotaleCondominio.Text = oggetto.TotaleCondominio() + " euro";
        } // fine metodo

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!oggetto.ExistsCondomino(txtCognome.Text))
                    oggetto.Add(new Spesa
                    {
                        Cognome = txtCognome.Text,
                        Luce = decimal.Parse(txtLuce.Text),
                        H2O = decimal.Parse(txtH2O.Text),
                        Gas = decimal.Parse(txtGas.Text)
                    });
                else
                    MessageBox.Show("Il nome del condomino esiste nell'archivio");
            } // fine try
            catch(FormatException errore)
            {
                MessageBox.Show(errore.Message);
            }  // fine catch
            UpgradeGUI();
        } // fine metodo

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            int riga_selezionata;
            riga_selezionata = dataGrid.SelectedIndex;
            if (riga_selezionata != -1)
            {
                oggetto.RemoveAt(riga_selezionata);
                UpgradeGUI();
            } // fine if
            else
                MessageBox.Show("Devi selezionare una riga nella tabella");

        } // fine metodo

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var dialogo = new Microsoft.Win32.SaveFileDialog();
            dialogo.FileName = txtNomeFile.Text; // Default file name
            dialogo.DefaultExt = ".csv"; // Default file extension
            dialogo.Filter = "Text documents (.csv)|*.csv"; // Filter files by extension
            bool? result = dialogo.ShowDialog();
            if (result==true)
            {
                oggetto.SaveFileCSV(dialogo.FileName);
            } // fine if
        } // fine evento

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            var dialogo = new Microsoft.Win32.OpenFileDialog();
            dialogo.FileName = txtNomeFile.Text; // Default file name
            dialogo.DefaultExt = ".csv"; // Default file extension
            dialogo.Filter = "Text documents (.csv)|*.csv"; // Filter files by extension
            bool? result = dialogo.ShowDialog();
            if (result == true)
            {
                oggetto.LoadFileCSV(dialogo.FileName);
                UpgradeGUI();
            } // fine if
        } // fine evento

        private void btnCalcolaTotale_Click(object sender, RoutedEventArgs e)
        {
            txtTotaleCondominio.Text = oggetto.TotaleCondominio() + " euro";
        } // fine evento

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            oggetto.Sort();
            UpgradeGUI();
        } // fine evento

        private void btnSaveFileXML_Click(object sender, RoutedEventArgs e)
        {
            var dialogo = new Microsoft.Win32.SaveFileDialog();
            dialogo.FileName = txtNomeFile.Text; // Default file name
            dialogo.DefaultExt = ".xml"; // Default file extension
            dialogo.Filter = "XML documents (.xml)|*.xml"; // Filter files by extension
            bool? result = dialogo.ShowDialog();
            if (result == true)
            {
                oggetto.SaveFileXML(dialogo.FileName);
            } // fine if
        } // fine evento

        private void btnLoadFileXML_Click(object sender, RoutedEventArgs e)
        {
            var dialogo = new Microsoft.Win32.OpenFileDialog();
            dialogo.FileName = txtNomeFile.Text; // Default file name
            dialogo.DefaultExt = ".xml"; // Default file extension
            dialogo.Filter = "XML documents (.xml)|*.xml"; // Filter files by extension
            bool? result = dialogo.ShowDialog();
            if (result == true)
            {
                oggetto.LoadFileXML(dialogo.FileName);
                UpgradeGUI();
            } // fine if
        } // fine evento

    } // fine classe
} // fine namespace


