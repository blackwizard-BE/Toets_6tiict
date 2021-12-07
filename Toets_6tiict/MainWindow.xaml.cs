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

namespace OEF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginClass[] login = new LoginClass[10];//maakt alle glob variablen aan
        int account = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)//slaat de toepassing ,login en passwoord op 
        {
            login[account] = new LoginClass();

            login[account].Save(txbLogin.Text, txbWachtwoord.Text, txbToepassing.Text);
            cmbToepassing.Items.Add(txbToepassing.Text);
            account++;

        }

        private void btnOphalen_Click(object sender, RoutedEventArgs e)//toont alle data in de listbox maar het paswoord is vervangen door ####
        {
            lsbRes.Items.Clear();
            string temp = "";
            lsbRes.Items.Add(cmbToepassing.Text);
            lsbRes.Items.Add(login[ToepassingSearch(cmbToepassing.Text)].OphalenUser());
            for(int i = 0; i< login[ToepassingSearch(cmbToepassing.Text)].OphalenPass().Length; i++)
            {
                temp = $"{temp}#";
            }
            lsbRes.Items.Add(temp);
            btnToon.IsEnabled = true;
        }
        public int ToepassingSearch(string cmbToep)//zoekt naar de toepasselijke toepassing
        {
            bool search = true;
            int i = 0;
            do
            {
                if (cmbToep == login[i].toepassing)
                {
                    search = false;
                }
                else
                {
                    i++;
                }



            }
            while (search);
            return i;
        }

        private void btnToon_Click(object sender, RoutedEventArgs e)//toont het passwoord ipv ####
        {
            lsbRes.Items.Clear();
            lsbRes.Items.Add(cmbToepassing.Text);
            lsbRes.Items.Add(login[ToepassingSearch(cmbToepassing.Text)].OphalenUser());
            lsbRes.Items.Add(login[ToepassingSearch(cmbToepassing.Text)].OphalenPass());
            btnToon.IsEnabled = false;

        }
    }
}
