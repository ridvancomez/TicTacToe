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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool siraKimde = true; // true:x false:o
        int hamleSayisi = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if(siraKimde)
            {
                b.Content = "X";
                b.IsEnabled = false;
                hamleSayisi++;
            }
            else
            {
                b.Content = "O";
                b.IsEnabled = false;
                hamleSayisi++;

            }

            siraKimde = !siraKimde;
            
            //Yatay  - Horizontal
            if(A1.Content == A2.Content && A2.Content == A3.Content && A1.IsEnabled == false)
            {
                Kazanan();
            }
            else if (B1.Content == B2.Content && B2.Content == B3.Content && B1.IsEnabled == false)
            {
                Kazanan();
            }
            else if (C1.Content == C2.Content && C2.Content == C3.Content && C1.IsEnabled == false)
            {
                Kazanan();
            }

            //Dikey  - Vertical
            if (A1.Content == B1.Content && B1.Content == C1.Content && A1.IsEnabled == false)
            {
                Kazanan();
            }
            else if (A2.Content == B2.Content && B2.Content == C2.Content && A2.IsEnabled == false)
            {
                Kazanan();
            }
            else if (A3.Content == B3.Content && B3.Content == C3.Content && A3.IsEnabled == false)
            {
                Kazanan();
            }

            //Çapraz  - Cross - Diogonal
            if (A1.Content == B2.Content && B2.Content == C3.Content && A1.IsEnabled == false)
            {
                Kazanan();
            }
            else if (A3.Content == B2.Content && B2.Content == C1.Content && A3.IsEnabled == false)
            {
                Kazanan();
            }
            

            if(hamleSayisi == 9)
            {
                MessageBox.Show("berabere", "iyi oyundu");
                beraberlikSayisi.Content = (Convert.ToInt32(beraberlikSayisi.Content) + 1).ToString();
                //Sifirla();
            }
        }

        private void Kazanan()
        {
            if(!siraKimde) // değilini aldım çünkü her hamleden sonra sıra diğer oyuncuda olarak tutuyoruz
            {
                MessageBox.Show("x kazandı", "tebrikler");
                xSayisi.Content = (Convert.ToInt32(xSayisi.Content) + 1).ToString();
                hamleSayisi = 0;
            }
            else if(siraKimde)
            {
                MessageBox.Show("o kazandı", "tebrikler");
                oSayisi.Content = (Convert.ToInt32(oSayisi.Content) + 1).ToString();
                hamleSayisi = 0;
            }

            foreach (var btn in main.Children.OfType<Button>())
            {
                btn.IsEnabled = false;
            }
            sifirla.IsEnabled = true;
        }

        private void Sifirla(object sender, RoutedEventArgs e)
        {
            foreach(var btn in main.Children.OfType<Button>())
            {
                btn.Content = "";
                btn.IsEnabled = true;
                hamleSayisi = 0;
            }
            sifirla.Content = "Tekrar oyna";
            siraKimde = true;
        }
        
        private void MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            if(button.IsEnabled)
            {
                if (siraKimde)
                {
                    button.Content = "X";
                }
                else
                {
                    button.Content = "O";
                }
            }
        }

        private void MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;

            if (button.IsEnabled)
            {
                button.Content = "";
            }
        }
    }
}
