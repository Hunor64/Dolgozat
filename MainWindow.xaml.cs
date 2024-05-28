using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DolgozatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btn2a_Click(object sender, RoutedEventArgs e)
        {
            //todo 2a)
            //Mennyi azoknak a háromjegyű számoknak az összege, ahol a szám első számjegye (100-as helyiérték) háromszorosa a szám utolsó számjegyének (1-esek helyiértéke)
            //Példa: 632 , mivel 6 = 2 * 3

            int szamErtek = 0;
            for (int i = 100; i != 999; i++)
            {
                int szam1 = Convert.ToInt32(i.ToString().Substring(0, 1));
                var szam2 = i.ToString().ToCharArray();
                if (szam1 == Convert.ToInt32(Convert.ToString(szam2[szam2.Length - 1])) * 3)
                {
                    szamErtek = szamErtek + i;
                }
            }
            labEredmeny1.Content = szamErtek;

        }


        private void btn2b_Click(object sender, RoutedEventArgs e)
        {
            //todo 2b)
            //A megadott szám prímtényezős felbontásában hányszor szerepel a 2 és a 3 ?
            //pld: 1008 = 2^4 * 3^2 * 7   <- mivel 2*2*2*2 * 3*3 * 7 = 1008
            //Írja ki a következő formátumban az eredményt!  2^■ * 3^■ * ■ , ahol a ■ helyére kerülő számokat a programja határozza meg.

            int count2 = 0;
            int count3 = 0;
            long szam = 86220288;
            List<int> other = new List<int>();
            for (long i = szam; i != 1;)
            {
                if (i % 2 == 0)
                {
                    count2++;
                    i = i / 2;
                }
                else if (i % 3 == 0)
                {
                    count3++;
                    i = i / 3;
                }
                else
                {
                    i = i / 77;
                }
            }
            labEredmeny2.Content = $"{szam} = 2^{count2} * 3^{count3} * 77";
        }


        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            //Alakítsa át az XAML leíró lapot a minta szerint!
            //Első két sor magassága 60px. A második oszlop 5x szélesebb mint az első
            //A meglévő elnevezett (x:name) vezérlőket tartsa meg, de attribútumain módosíthat!
            //Helyezzen el ListBox vezérlőt lbLista néven és egy Grid elrendezés vezérlőt grdRacs néven!

            int[] befizetesek = { 1250, 37500, 25900, 3500, 460, 580, 6985, 72500 };

            //todo: A felület átalakítása után a mintának megfelelően helyezze a listadobozba a sorokat!
            //Minden sor formtáuma a következő: kasszában lévő érték + új befizetés = új összeg

            lbLista.Items.Clear();
            int ujOsszeg = 0;
            foreach (var elem in befizetesek)
            {
                ListBoxItem ujElem = new ListBoxItem();
                ujElem.Content = $"{ujOsszeg} + {elem} = {ujOsszeg + elem}";
                ujOsszeg = ujOsszeg + elem;
                lbLista.Items.Add(ujElem);
            }
        }
        private void UjElem(string textContent)
        {
            ListBoxItem ujElem = new ListBoxItem();
            ujElem.Content = textContent;
            lbLista.Items.Add(ujElem);
        }
        List<Lakohely> lakohely = new List<Lakohely>();
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            //todo: OpenFileDialog segítségével talózza ki a kapott fájlt és olvassa be annak tartalmát!
            //A fájl CSV formátumú sorokat tartalmaz.
            //Hozzon létre egy új osztályt Lakohely néven és a beolvasást az osztályból álló listába végezze!
            //Ezt követően válaszoljon az alábbi kérdésekre és az eredményt konzolra írja ki a minta szerint!
            //Használjon LINQ eszközöket és törekedjen az egysoros válaszokra!

            //4a) Melyik településen él a legkevesebb nő?

            //4b) Listázza ki azoknak a településeknek a nevét névsorrendben csökkenően, amelyek városok és ahol több férfi él mint nő!

            //4c) Hány olyan megye van, ahol 500 000 főt meghaladja a lakosság létszáma?

            lbLista.Items.Clear();
            OpenFileDialog fileNyit = new OpenFileDialog();
            fileNyit.ShowDialog();

            List<string> sorok = File.ReadAllLines(fileNyit.FileName).ToList();
            sorok.RemoveAt(0);
            foreach (var sor in sorok)
            {
                lakohely.Add(new Lakohely(sor));
            }

            UjElem("4a feladat");
            UjElem(lakohely.MinBy(x => x.Nok).Telepules);

            UjElem("4b feladat");
            List<Lakohely> tobbFerfiMintNo = lakohely.Where(x => x.Ferfiak > x.Nok && x.Tipus == "város").OrderBy(x => x.Telepules).Reverse().ToList();
            foreach (var elem in tobbFerfiMintNo) { UjElem(elem.Telepules); }

            UjElem("4c feladat");
            int megyekSzama = 0;
            List<string> meglevoMegyek = new List<string>();

            foreach (var eleme in lakohely.Where(x => lakohely.Where(y => y.VarmegyeKod == x.VarmegyeKod).Sum(y => y.Ferfiak + y.Nok) > 500000).ToList())
            {
                if (meglevoMegyek.FindIndex(x => x == eleme.VarmegyeKod) == -1)
                {
                    meglevoMegyek.Add(eleme.VarmegyeKod);
                    megyekSzama++;
                }
            }
            UjElem($"Megyék száma:{megyekSzama}");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {


        }


    }
}