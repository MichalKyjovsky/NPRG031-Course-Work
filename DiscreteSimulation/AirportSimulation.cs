using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; 


namespace DiscreteSimulation
{
    public partial class simulaceLetiste : Form
    {
        enum Stav { UvodniStrana, NastaveniSKufry, NastaveniObsluhy, PredvolbyLetiste, Vysledek }; //Stavy které se mění na základě tlačítka volby_1_button
        private int pocitadlo; //Počítadlo tlačítka volby_1_button, na jehož základě se mění funkčnost tlačítka
        private int pocitadloObsluhy = 1;//Počítadlo tlačítka rychlostObsluhy_button, na jehož základě se mění funkčnost tlačítka
        private int pocitadloPotvrzeni = 1;//Počítadlo tlačítka potvrditButton, na jehož základě se mění funkčnost tlačítka
        private int pocitadloKontroly; //Počítadlo tlačítka rychlostKontrolButton, na jehož základě se mění funkčnost tlačítka
        private int pocitadloVypisu = 0; 

        private DateTime datumCas = new DateTime();
        private int casOdletu;
        private int prichodPrvnihoCestujiciho;

        public NastaveniObsluhy nastaveniObsluhy = new NastaveniObsluhy();
        public NastaveniCasu nastaveniCasu = new NastaveniCasu();
        public GeneratorCestujicich generatorCestujicich = new GeneratorCestujicich();

        public simulaceLetiste()
        {
            this.Text = "Simulace letiště Brno";
            InitializeComponent();
            NastavStav(Stav.UvodniStrana);
        }

        //Metoda na nastavení jednotlivých stavů (různá zobrazení)
        private void NastavStav(Stav novy)
        {
            switch (novy)
            {
                case Stav.UvodniStrana:
                    pasazeriAmanualLabel.Visible = false;
                    pctPasazeruLabel.Visible = false;
                    pctPasazeruSKufremLabel.Visible = false;
                    volby_1_Button.Visible = true;
                    pasazeriKufrNadpis.Visible = false;
                    pocetPasazeruSKufremSlider.Visible = false;
                    hlavniNadpisLabel.Visible = true;
                    rychlostObsluhy_button.Visible = false;
                    odletyLabel.Visible = false;
                    vDevetCheckBox.Visible = false;
                    vJedenactCheckBox.Visible = false;
                    veDveCheckBox.Visible = false;
                    vSestCheckBox.Visible = false;
                    bufetSlider.Visible = false;
                    cestujiciBufetLabel.Visible = false;
                    pocitadloBufet.Visible = false;
                    butikSlider.Visible = false;
                    cestujiciButikLabel.Visible = false;
                    pocitadloButik.Visible = false;
                    potvrditButton.Visible = false;
                    nastaveniOdletuLabel.Visible = false;
                    odletySlider.Visible = false;
                    obsluhaVysledkyLabel.Visible = false;
                    prvniCestujiciLabel.Visible = false;
                    bzpKontrolaSlider.Visible = false;
                    bzpLabel.Visible = false;
                    bzpTextLabel.Visible = false;
                    pasKontrolaSlider.Visible = false;
                    pasLabel.Visible = false;
                    pasTextLabel.Visible = false;
                    odbaveniLabel.Visible = false;
                    odbaveniSlider.Visible = false;
                    odbaveniTextLabel.Visible = false;
                    nalodeniLabel.Visible = false;
                    nalodeniSlider.Visible = false;
                    nalodeniTextLabel.Visible = false;
                    rychlostKontrolButton.Visible = false;
                    vysledkyVypis.Visible = false;
                    dlouhyVypisButton.Visible = false;
                    scoreLabel.Visible = false; 
                    break;
                case Stav.NastaveniSKufry:
                    pasazeriAmanualLabel.Visible = true;
                    pctPasazeruLabel.Visible = true;
                    pctPasazeruSKufremLabel.Visible = true;
                    volby_1_Button.Visible = true;
                    pasazeriKufrNadpis.Visible = true;
                    pocetPasazeruSKufremSlider.Visible = true;
                    hlavniNadpisLabel.Visible = false;
                    rychlostObsluhy_button.Visible = false;
                    odletyLabel.Visible = false;
                    vDevetCheckBox.Visible = false;
                    vJedenactCheckBox.Visible = false;
                    veDveCheckBox.Visible = false;
                    vSestCheckBox.Visible = false;
                    bufetSlider.Visible = false;
                    cestujiciBufetLabel.Visible = false;
                    pocitadloBufet.Visible = false;
                    butikSlider.Visible = false;
                    cestujiciButikLabel.Visible = false;
                    pocitadloButik.Visible = false;
                    potvrditButton.Visible = false;
                    nastaveniOdletuLabel.Visible = false;
                    odletySlider.Visible = false;
                    obsluhaVysledkyLabel.Visible = false;
                    prvniCestujiciLabel.Visible = false;
                    bzpKontrolaSlider.Visible = false;
                    bzpLabel.Visible = false;
                    bzpTextLabel.Visible = false;
                    pasKontrolaSlider.Visible = false;
                    pasLabel.Visible = false;
                    pasTextLabel.Visible = false;
                    odbaveniLabel.Visible = false;
                    odbaveniSlider.Visible = false;
                    odbaveniTextLabel.Visible = false;
                    nalodeniLabel.Visible = false;
                    nalodeniSlider.Visible = false;
                    nalodeniTextLabel.Visible = false;
                    rychlostKontrolButton.Visible = false;
                    vysledkyVypis.Visible = false;
                    dlouhyVypisButton.Visible = false;
                    scoreLabel.Visible = false;
                    break;
                case Stav.PredvolbyLetiste:
                    pasazeriAmanualLabel.Visible = false;
                    pctPasazeruLabel.Visible = false;
                    pctPasazeruSKufremLabel.Visible = false;
                    volby_1_Button.Visible = true;
                    pasazeriKufrNadpis.Visible = false;
                    pocetPasazeruSKufremSlider.Visible = false;
                    hlavniNadpisLabel.Visible = false;
                    rychlostObsluhy_button.Visible = true;
                    odletyLabel.Visible = true;
                    vDevetCheckBox.Visible = true;
                    vJedenactCheckBox.Visible = true;
                    veDveCheckBox.Visible = true;
                    vSestCheckBox.Visible = true;
                    bufetSlider.Visible = false;
                    cestujiciBufetLabel.Visible = false;
                    pocitadloBufet.Visible = false;
                    butikSlider.Visible = false;
                    cestujiciButikLabel.Visible = false;
                    pocitadloButik.Visible = false;
                    potvrditButton.Visible = true;
                    nastaveniOdletuLabel.Visible = false;
                    odletySlider.Visible = false;
                    obsluhaVysledkyLabel.Visible = true;
                    prvniCestujiciLabel.Visible = false;
                    bzpKontrolaSlider.Visible = true;
                    bzpLabel.Visible = true;
                    bzpTextLabel.Visible = true;
                    pasKontrolaSlider.Visible = true;
                    pasLabel.Visible = true;
                    pasTextLabel.Visible = true;
                    odbaveniLabel.Visible = true;
                    odbaveniSlider.Visible = true;
                    odbaveniTextLabel.Visible = true;
                    nalodeniLabel.Visible = true;
                    nalodeniSlider.Visible = true;
                    nalodeniTextLabel.Visible = true;
                    rychlostKontrolButton.Visible = true;
                    vysledkyVypis.Visible = false;
                    dlouhyVypisButton.Visible = false;
                    scoreLabel.Visible = false;


                    //Vynulování hodnot

                    nalodeniSlider.Value = nalodeniSlider.Minimum;
                    nalodeniLabel.Text = "0";
                    odbaveniSlider.Value = odbaveniSlider.Minimum;
                    odbaveniLabel.Text = "0";
                    pasKontrolaSlider.Value = pasKontrolaSlider.Minimum;
                    pasLabel.Text = "0";
                    bzpKontrolaSlider.Value = bzpKontrolaSlider.Minimum;
                    bzpLabel.Text = "0";

                    vDevetCheckBox.Checked = false;
                    vJedenactCheckBox.Checked = false;
                    veDveCheckBox.Checked = false;
                    vSestCheckBox.Checked = false;
                    bufetSlider.Value = bufetSlider.Minimum;
                    butikSlider.Value = butikSlider.Minimum;
                    pocitadloBufet.Text = "0";
                    pocitadloButik.Text = "0";

                    obsluhaVysledkyLabel.Text = "";

                    break;
                case Stav.NastaveniObsluhy:
                    pasazeriAmanualLabel.Visible = false;
                    pctPasazeruLabel.Visible = false;
                    pctPasazeruSKufremLabel.Visible = false;
                    volby_1_Button.Visible = true;
                    pasazeriKufrNadpis.Visible = false;
                    pocetPasazeruSKufremSlider.Visible = false;
                    hlavniNadpisLabel.Visible = false;
                    rychlostObsluhy_button.Visible = true;
                    bufetSlider.Visible = true;
                    cestujiciBufetLabel.Visible = true;
                    pocitadloBufet.Visible = true;
                    butikSlider.Visible = true;
                    cestujiciButikLabel.Visible = true;
                    pocitadloButik.Visible = true;
                    vysledkyVypis.Visible = false;
                    dlouhyVypisButton.Visible = false;
                    scoreLabel.Visible = false;


                    break;
                case Stav.Vysledek:
                    pasazeriAmanualLabel.Visible = false;
                    pctPasazeruLabel.Visible = false;
                    pctPasazeruSKufremLabel.Visible = false;
                    volby_1_Button.Visible = true;
                    pasazeriKufrNadpis.Visible = false;
                    pocetPasazeruSKufremSlider.Visible = false;
                    hlavniNadpisLabel.Visible = false;
                    rychlostObsluhy_button.Visible = false;
                    odletyLabel.Visible = false;
                    vDevetCheckBox.Visible = false;
                    vJedenactCheckBox.Visible = false;
                    veDveCheckBox.Visible = false;
                    vSestCheckBox.Visible = false;
                    bufetSlider.Visible = false;
                    cestujiciBufetLabel.Visible = false;
                    pocitadloBufet.Visible = false;
                    butikSlider.Visible = false;
                    cestujiciButikLabel.Visible = false;
                    pocitadloButik.Visible = false;
                    potvrditButton.Visible = false;
                    nastaveniOdletuLabel.Visible = false;
                    odletySlider.Visible = false;
                    obsluhaVysledkyLabel.Visible = false;
                    prvniCestujiciLabel.Visible = false;
                    bzpKontrolaSlider.Visible = false;
                    bzpLabel.Visible = false;
                    bzpTextLabel.Visible = false;
                    pasKontrolaSlider.Visible = false;
                    pasLabel.Visible = false;
                    pasTextLabel.Visible = false;
                    odbaveniLabel.Visible = false;
                    odbaveniSlider.Visible = false;
                    odbaveniTextLabel.Visible = false;
                    nalodeniLabel.Visible = false;
                    nalodeniSlider.Visible = false;
                    nalodeniTextLabel.Visible = false;
                    rychlostKontrolButton.Visible = false;
                    kontrolyLabel.Visible = false;
                    vysledkyVypis.Visible = true;
                    dlouhyVypisButton.Visible = true;
                    scoreLabel.Visible = true;
                    break;
            }
        }

        //Metoda pro nastavení počtu cestujících s kufrem 
        private void PocetPasazeruSKufremSlider_Scroll(object sender, EventArgs e)
        {
            pocetPasazeruSKufremSlider.LargeChange = 15;
            pocetPasazeruSKufremSlider.TickFrequency = 10;
            pocetPasazeruSKufremSlider.Maximum = 189;
            pctPasazeruSKufremLabel.Text = pocetPasazeruSKufremSlider.Value.ToString();
        }

        //Metoda nastavující funkce tlačítka pro přepínání mezi jednotlivými stavy
        private void Volby_1_Button_Click(object sender, EventArgs e)
        {
            switch (pocitadlo)
            {
                case 0:
                    volby_1_Button.Text = "Předvolby letiště";
                    NastavStav(Stav.NastaveniSKufry);
                    volby_1_Button.Location = new Point(400, 410);
                    pocetPasazeruSKufremSlider.Value = pocetPasazeruSKufremSlider.Minimum;
                    pctPasazeruSKufremLabel.Text = "0";
                    break;
                case 1:
                    generatorCestujicich.PctPasazeruSKufrem(pocetPasazeruSKufremSlider.Value);
                    volby_1_Button.Text = "Výsledek";
                    NastavStav(Stav.PredvolbyLetiste);
                    volby_1_Button.Location = new Point(730, 410);
                    break;
                case 2:
                    //Spuštění výpočtu a zobrazení výsledků

                    if ((NastaveniObsluhy.rychlostBzpCtrl == 0) || (NastaveniObsluhy.rychlostNalodeni == 0) || (NastaveniObsluhy.rychlostOdbaveni == 0) || (NastaveniObsluhy.rychlostPasCtrl == 0)||(NastaveniCasu.cas == 0) || (NastaveniCasu.casOdletu== 0))
                    {
                        DialogResult dialog = MessageBox.Show("Neplatné hodnoty!", "Začít znovu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Model model = new Model();

                    vysledkyVypis.Text = String.Format("                -----------------------------------------------Inicializace všech cestujících---------------------------------------------------------\n");
                    model.Vypocet();
                     
                    foreach (string item in Cestujici.kratkyVypis)
                    {
                        vysledkyVypis.Text += String.Format(item + "\n");
                    }
                    vysledkyVypis.Text += String.Format("                -----------------------------------------------Konec simulace---------------------------------------------------------\n");

                    scoreLabel.Text = String.Format("{0}/189\nNALODĚNO",Cestujici.uspesni);

                    volby_1_Button.Text = "Úvodní strana";
                    NastavStav(Stav.Vysledek);
                    volby_1_Button.Location = new Point(730, 410);
                    break;
                case 3:
                    volby_1_Button.Text = "Nová simulace";
                    NastavStav(Stav.UvodniStrana);
                    volby_1_Button.Location = new Point(730, 410);
                    Cestujici.uspesni = 0;
                    break;
            }
            pocitadlo = (pocitadlo + 1) % 4;

        }

        /*Metoda tlačítka rychlostObsluhy_button, které má 3 stavy a nastavuje 
         * počet cestujících jdoucích do bufetu/butiku a rychlost obou obsluh, 
         * a také restartovat zvolené nastavení*/
        private void RychlostObsluhy_button_Click(object sender, EventArgs e)
        {
            if (pocitadloObsluhy % 3 == 1)
            {
                butikSlider.Maximum = generatorCestujicich.PctPasazeru(189 - bufetSlider.Value);
                bufetSlider.Maximum = generatorCestujicich.PctPasazeru(189 - butikSlider.Value);

                obsluhaVysledkyLabel.Text = "";
                NastavStav(Stav.NastaveniObsluhy);
                rychlostObsluhy_button.Text = "Nastavení rychlosti";
            }
            else if (pocitadloObsluhy % 3 == 2)
            {
                NastaveniObsluhy.pctNavstevnikuBufetu = nastaveniObsluhy.nastavObsluhu(bufetSlider.Value);
                NastaveniObsluhy.pctNavstevnikuButiku = nastaveniObsluhy.nastavObsluhu(butikSlider.Value);

              
                pocitadloBufet.Text = "0";
                pocitadloButik.Text = "0";

                bufetSlider.Maximum = 20;
                butikSlider.Maximum = 20;
                bufetSlider.TickFrequency = 2;
                bufetSlider.LargeChange = 2;
                butikSlider.TickFrequency = 2;
                butikSlider.LargeChange = 2;

                cestujiciBufetLabel.Text = "Rychlost obsluhy v bufetu:";
                cestujiciButikLabel.Text = "Rychlost obsluhy v butiku:";
                rychlostObsluhy_button.Text = "Potvrdit";
                bufetSlider.Value = bufetSlider.Minimum;
                butikSlider.Value = butikSlider.Minimum;
            }
            else
            {
                rychlostObsluhy_button.Text = "Nastavení obsluhy";

                NastaveniObsluhy.rychlostBufetu = nastaveniObsluhy.nastavObsluhu(bufetSlider.Value);
                NastaveniObsluhy.rychlostButiku = nastaveniObsluhy.nastavObsluhu(butikSlider.Value);

                bufetSlider.Visible = false;
                cestujiciBufetLabel.Visible = false;
                pocitadloBufet.Visible = false;
                butikSlider.Visible = false;
                cestujiciButikLabel.Visible = false;
                pocitadloButik.Visible = false;

                obsluhaVysledkyLabel.Text = String.Format("Zvolené nastavení:\n\nPočet cestujících jdoucích do bufetu: {0}\nPočet cestujících jdoucích do butiku: {1}\nRychlost obsluhy bufetu: {2}\nRychlost obsluhy butiku: {3}"
                    , NastaveniObsluhy.pctNavstevnikuBufetu, NastaveniObsluhy.pctNavstevnikuButiku, NastaveniObsluhy.rychlostBufetu, NastaveniObsluhy.rychlostButiku);

                pocitadloBufet.Text = "0";
                pocitadloButik.Text = "0";
                bufetSlider.Value = bufetSlider.Minimum;
                butikSlider.Value = butikSlider.Minimum;
            }

            pocitadloObsluhy++;
        }

        
        /*Metoda tlačítka potvrditButton, které nastavuje čas odletu a čas příchodu
         prvního cestujícího. Na závěr je zde i možnost změny zvoleného nastavení*/
        private void PotvrditButton_Click(object sender, EventArgs e)
        {
            nastaveniOdletuLabel.Visible = false;
            nastaveniOdletuLabel.Text = "";
            

            if (pocitadloPotvrzeni % 3 == 1)
            {
                potvrditButton.Text = "Potvrdit";
                datumCas = DateTime.Today;
                if (vDevetCheckBox.Checked == true)
                {
                    casOdletu = 9;
                    nastaveniCasu.NastavOdlet(datumCas.AddHours(casOdletu));
                }
                else if (vJedenactCheckBox.Checked == true)
                {  
                    casOdletu = 11;
                    nastaveniCasu.NastavOdlet(datumCas.AddHours(casOdletu));
                }
                else if (veDveCheckBox.Checked == true)
                {
                    casOdletu = 14;
                    nastaveniCasu.NastavOdlet(datumCas.AddHours(casOdletu));
              }
                else if (vSestCheckBox.Checked == true)
                {
                    casOdletu = 18;
                    nastaveniCasu.NastavOdlet(datumCas.AddHours(casOdletu));
                }

                if ((casOdletu == 0))
                {
                    DialogResult dialog = MessageBox.Show("Neplatné hodnoty!", "Začít znovu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                vDevetCheckBox.Visible = false;
                vJedenactCheckBox.Visible = false;
                veDveCheckBox.Visible = false;
                vSestCheckBox.Visible = false;

                nastaveniCasu.NastavOdlet(casOdletu);

                prichodPrvnihoCestujiciho = 0; 
                odletySlider.Value = odletySlider.Minimum ;
                odletyLabel.Text = "Zvolte čas příchodu\n prvního cestujícího";
                odletySlider.Visible = true;
                prvniCestujiciLabel.Visible = true;
                odletySlider.Minimum = casOdletu - 5;
                odletySlider.Maximum = casOdletu - 2;
                odletySlider.TickFrequency = 1;
                odletySlider.LargeChange = 1;


            }
            else if (pocitadloPotvrzeni % 3 == 2)
            {
                
                prichodPrvnihoCestujiciho = nastaveniCasu.NastavCas(odletySlider.Value);
                if ((prichodPrvnihoCestujiciho == 0))
                {
                    DialogResult dialog = MessageBox.Show("Neplatné hodnoty!", "Začít znovu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                

                datumCas = DateTime.Now;
                datumCas = datumCas.AddHours(odletySlider.Value);
                odletySlider.Visible = false;
                prvniCestujiciLabel.Visible = false;
                odletySlider.Value = odletySlider.Minimum;
                prvniCestujiciLabel.Text = prichodPrvnihoCestujiciho.ToString();

                potvrditButton.Text = "Změnit nastavení";
                odletyLabel.Text = "Zvolené nastavení";
                nastaveniOdletuLabel.Visible = true;
                nastaveniOdletuLabel.Text = String.Format("Čas odletu letadla: {0}\nČas příchodu prvního cestujícího: {1}", casOdletu, prichodPrvnihoCestujiciho);
                casOdletu = 0;
                odletySlider.Minimum = casOdletu - 5;
                odletySlider.Maximum = casOdletu - 2;
                odletySlider.TickFrequency = 1;
                odletySlider.LargeChange = 1;
                prichodPrvnihoCestujiciho = 0;
            }
            else
            {
                prvniCestujiciLabel.Text = "0";
                vDevetCheckBox.Visible = true;
                vJedenactCheckBox.Visible = true;
                veDveCheckBox.Visible = true;
                vSestCheckBox.Visible = true;

                vDevetCheckBox.Checked = false;
                vJedenactCheckBox.Checked = false;
                veDveCheckBox.Checked = false;
                vSestCheckBox.Checked = false;

                odletySlider.Minimum = 0;
                odletySlider.Maximum = 0;
            }



            pocitadloPotvrzeni++;
        }

        //Nastavení parametrů pro TrackBar nastavující pčt návštěvníků a rychlost bufetu
        private void BufetSlider_Scroll(object sender, EventArgs e)
        {
            bufetSlider.Minimum = 0;
            pocitadloBufet.Text = bufetSlider.Value.ToString();
            bufetSlider.LargeChange = 5;
            bufetSlider.TickFrequency = 10;
        }

        //Nastavení parametrů pro TrackBar nastavující pčt návštěvníků a rychlost butiku
        private void ButikSlider_Scroll(object sender, EventArgs e)
        {
            butikSlider.Minimum = 0;
            pocitadloButik.Text = butikSlider.Value.ToString();
            butikSlider.LargeChange = 5;
            butikSlider.TickFrequency = 10;
        }

        //Nastavení parametrů pro TrackBar nastavující čas příchodu prvního cestujícího
        private void OdletySlider_Scroll(object sender, EventArgs e)
        {
            
           

            prvniCestujiciLabel.Text = odletySlider.Value.ToString();
        }

        //Nastavení parametrů pro TrackBar nastavující rychlost nalodění na palubu letadla
        private void NalodeniSlider_Scroll(object sender, EventArgs e)
        {
            nalodeniSlider.Minimum = 0;
            nalodeniSlider.Maximum = 20;
            nalodeniSlider.TickFrequency = 2;
            nalodeniSlider.LargeChange = 2;
            nalodeniLabel.Text = nalodeniSlider.Value.ToString();
        }

        //Nastavení parametrů pro TrackBar nastavující rychlost odbavení
        private void OdbaveniSlider_Scroll(object sender, EventArgs e)
        {
            odbaveniSlider.Minimum = 0;
            odbaveniSlider.Maximum = 20;
            odbaveniSlider.TickFrequency = 2;
            odbaveniSlider.LargeChange = 2;
            odbaveniLabel.Text = odbaveniSlider.Value.ToString();
        }

        //Nastavení parametrů pro TrackBar nastavující rychlost bezpečnostní kontroly
        private void BzpKontrolaSlider_Scroll(object sender, EventArgs e)
        {
            bzpKontrolaSlider.Minimum = 0;
            bzpKontrolaSlider.Maximum = 20;
            bzpKontrolaSlider.TickFrequency = 2;
            bzpKontrolaSlider.LargeChange = 2;
            bzpLabel.Text = bzpKontrolaSlider.Value.ToString();
        }

        //Nastavení parametrů pro TrackBar nastavující rychlost pasové kontroly
        private void PasKontrolaSlider_Scroll(object sender, EventArgs e)
        {
            pasKontrolaSlider.Minimum = 0;
            pasKontrolaSlider.Maximum = 20;
            pasKontrolaSlider.TickFrequency = 2;
            pasKontrolaSlider.LargeChange = 2;
            pasLabel.Text = pasKontrolaSlider.Value.ToString();
        }

        //Tlačítko pro potvrzení hodnot povinných kontrol, viz 4 metody pro nastavení TrackBars výše 
        private void RychlostKontrolButton_Click(object sender, EventArgs e)
        {
            if (pocitadloKontroly % 2 == 0)
            {
                kontrolyLabel.Text = "";

                NastaveniObsluhy.rychlostBzpCtrl = nastaveniObsluhy.nastavObsluhu(bzpKontrolaSlider.Value);
                NastaveniObsluhy.rychlostNalodeni = nastaveniObsluhy.nastavObsluhu(nalodeniSlider.Value);
                NastaveniObsluhy.rychlostOdbaveni = nastaveniObsluhy.nastavObsluhu(odbaveniSlider.Value);
                NastaveniObsluhy.rychlostPasCtrl = nastaveniObsluhy.nastavObsluhu(pasKontrolaSlider.Value);
                if ((NastaveniObsluhy.rychlostBzpCtrl == 0) || (NastaveniObsluhy.rychlostNalodeni == 0) || (NastaveniObsluhy.rychlostOdbaveni == 0) || (NastaveniObsluhy.rychlostPasCtrl == 0))
                {
                    DialogResult dialog = MessageBox.Show("Neplatné hodnoty!", "Začít znovu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                kontrolyLabel.Text = String.Format("Zvolené nastavení\n\nRychlost odbavení: {0}\nRychlost bezpečnostní kontroly: {1}\nRychlost pasové kontroly: {2}\nRychlost nalodění: {3}", NastaveniObsluhy.rychlostOdbaveni,
                    NastaveniObsluhy.rychlostBzpCtrl, NastaveniObsluhy.rychlostPasCtrl, NastaveniObsluhy.rychlostNalodeni);

              

                bzpKontrolaSlider.Visible = false;
                bzpLabel.Visible = false;
                bzpTextLabel.Visible = false;
                pasKontrolaSlider.Visible = false;
                pasLabel.Visible = false;
                pasTextLabel.Visible = false;
                odbaveniLabel.Visible = false;
                odbaveniSlider.Visible = false;
                odbaveniTextLabel.Visible = false;
                nalodeniLabel.Visible = false;
                nalodeniSlider.Visible = false;
                nalodeniTextLabel.Visible = false;

                rychlostKontrolButton.Text = "Změnit";
            }
            else
            {
                rychlostKontrolButton.Text = "Potvrdit";
                bzpKontrolaSlider.Visible = true;
                bzpLabel.Visible = true;
                bzpTextLabel.Visible = true;
                pasKontrolaSlider.Visible = true;
                pasLabel.Visible = true;
                pasTextLabel.Visible = true;
                odbaveniLabel.Visible = true;
                odbaveniSlider.Visible = true;
                odbaveniTextLabel.Visible = true;
                nalodeniLabel.Visible = true;
                nalodeniSlider.Visible = true;
                nalodeniTextLabel.Visible = true;
                rychlostKontrolButton.Visible = true;

                nalodeniSlider.Value = nalodeniSlider.Minimum;
                nalodeniLabel.Text = "0";
                odbaveniSlider.Value = odbaveniSlider.Minimum;
                odbaveniLabel.Text = "0";
                pasKontrolaSlider.Value = pasKontrolaSlider.Minimum;
                pasLabel.Text = "0";
                bzpKontrolaSlider.Value = bzpKontrolaSlider.Minimum;
                bzpLabel.Text = "0";

                kontrolyLabel.Text = "";

            }
            pocitadloKontroly++;
        }

        //Vyskakovací okno pro ověření ukončení aplikace
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Opravdu chcete ukončit program?", "Odejít", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                
            } 
            //Application.Exit();
            else if (dialog == DialogResult.No)
                e.Cancel = true;
        }

        private void DlouhyVypisButton_Click(object sender, EventArgs e)
        {
            vysledkyVypis.Clear();
            string buffer = ""; 
            if (pocitadloVypisu % 2 == 0)
            {
                dlouhyVypisButton.Text = "Krátký výpis";

                vysledkyVypis.Text = String.Format("                -----------------------------------------------Inicializace všech cestujících---------------------------------------------------------\n");

                foreach (string item in Cestujici.dlouhyVypis)
                {
                    buffer += String.Format(item + "\n");
                }
                vysledkyVypis.Text += buffer; 
                vysledkyVypis.Text += String.Format("                -----------------------------------------------Konec simulace---------------------------------------------------------\n");

            }
            else
            {
                dlouhyVypisButton.Text = "Dlouhý výpis";
                vysledkyVypis.Text = String.Format("                -----------------------------------------------Inicializace všech cestujících---------------------------------------------------------\n");

                foreach (string item in Cestujici.kratkyVypis)
                {
                    buffer += String.Format(item + "\n");
                }
                vysledkyVypis.Text += buffer;
                vysledkyVypis.Text += String.Format("                -----------------------------------------------Konec simulace---------------------------------------------------------\n");
            }
            pocitadloVypisu++; 
        }

        private void VysledkyVypis_TextChanged(object sender, EventArgs e)
        {

        }
    }

}





