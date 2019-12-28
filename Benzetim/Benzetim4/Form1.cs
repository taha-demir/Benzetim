using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benzetim4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Rassal rs = new Rassal();
        List<int> GASList = new List<int>();
        List<int> GelisZamaniList = new List<int>();
        List<int> GelisZamaniYedekList = new List<int>();
        List<int> DizimSuresiList = new List<int>();
        List<int> BitisZamaniList = new List<int>();
        List<int> ProjeNoList = new List<int>();
        List<string> TezgahList = new List<string>();
        List<int> BeklemeSuresiList = new List<int>();
        List<int> BaslamaZamaniList = new List<int>();
        List<int> bekleyen = new List<int>();

        bool Tezgah1Durum, Tezgah2Durum;
        int BenzetimZamani, sipNo = -1, T1BitisZamani, T2BitisZamani, T1BaslayanProje,
            T1BitenProje, T2BaslayanProje, T2BitenProje, T1BaslamaZamani, T2BaslamaZamani, BeklemeSuresi,
            ToplamBeklemeSuresi = 0, ToplamDizimSuresi = 0;
        double OrtBS, OrtDS;

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < BitisZamaniList.Count; i++)
            {
                listProjeNo.Items.Add(ProjeNoList[i] + 1);
                listGAS.Items.Add(GASList[i]);
                listGelisZamani.Items.Add(GelisZamaniList[i]);
                listDizimSuresi.Items.Add(DizimSuresiList[i]);
                listBitisZamani.Items.Add(BitisZamaniList[i]);
                listTezgah.Items.Add(TezgahList[i]);
                listBeklemeSuresi.Items.Add(BeklemeSuresiList[i]);

                ToplamBeklemeSuresi += BeklemeSuresiList[i];
                ToplamDizimSuresi += DizimSuresiList[i];
                OrtBS = ToplamBeklemeSuresi / BitisZamaniList.Count;
                OrtDS = ToplamDizimSuresi / BitisZamaniList.Count;
                lblOrtBS.Text = OrtBS + " " + "Gün";
                lblOrtDS.Text = OrtDS + " " + "Gün";
            }
        }

        string GelenSiparis, BekleyenSiparis;
        private void RassalDegerler()
        {
            for (int i = 0; i < 200; i++)
            {
                rs.GASCek();
                GASList.Add(rs.GAS);
                rs.CDSureCek();
                DizimSuresiList.Add(rs.CDSure);

                if (i == 0)
                {

                    GelisZamaniList.Add(GASList[0]);
                    GelisZamaniYedekList.Add(GASList[0]);
                }
                else
                {
                    GelisZamaniList.Add(GelisZamaniList[i - 1] + GASList[i]);
                    GelisZamaniYedekList.Add(GelisZamaniList[i - 1] + GASList[i]);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RassalDegerler();
            for (int i = 0; i < 200; i++)
            {
                BenzetimZamani = i;
                if (T1BitisZamani == BenzetimZamani)
                {
                    Tezgah1Durum = false;
                    if (bekleyen.Count > 0)
                    {
                        T1BaslayanProje = bekleyen[0];
                        T1BaslamaZamani = BenzetimZamani;
                        BaslamaZamaniList.Add(T1BaslamaZamani);
                        T1BitisZamani = T1BaslamaZamani + DizimSuresiList[bekleyen[0]];
                        BitisZamaniList.Add(T1BitisZamani);
                        TezgahList.Add("Tezgah 1");
                        BeklemeSuresi = T1BaslamaZamani - GelisZamaniList[bekleyen[0]];
                        BeklemeSuresiList.Add(BeklemeSuresi);
                        Tezgah1Durum = true;
                        bekleyen.Remove(bekleyen[0]);
                    }

                }
                if (T2BitisZamani == BenzetimZamani)
                {
                    Tezgah2Durum = false;
                    if (bekleyen.Count > 0)
                    {
                        T2BaslayanProje = bekleyen[0];
                        T2BaslamaZamani = BenzetimZamani;
                        BaslamaZamaniList.Add(T2BaslamaZamani);
                        T2BitisZamani = T2BaslamaZamani + DizimSuresiList[bekleyen[0]];
                        BitisZamaniList.Add(T2BitisZamani);
                        TezgahList.Add("Tezgah 2");
                        BeklemeSuresi = T2BaslamaZamani - GelisZamaniList[bekleyen[0]];
                        BeklemeSuresiList.Add(BeklemeSuresi);
                        Tezgah2Durum = true;
                        bekleyen.Remove(bekleyen[0]);
                    }
                }
                if (GelisZamaniYedekList[0] == BenzetimZamani)
                {
                    sipNo++;
                    ProjeNoList.Add(sipNo);
                    if (Tezgah1Durum == false)
                    {
                        T1BaslayanProje = sipNo;
                        T1BitisZamani = BenzetimZamani + DizimSuresiList[sipNo];
                        BitisZamaniList.Add(T1BitisZamani);
                        TezgahList.Add("Tezgah 1");
                        BeklemeSuresiList.Add(0);
                        Tezgah1Durum = true;
                    }
                    else if (Tezgah2Durum == false)
                    {
                        T2BaslayanProje = sipNo;
                        T2BitisZamani = BenzetimZamani + DizimSuresiList[sipNo];
                        BitisZamaniList.Add(T2BitisZamani);
                        TezgahList.Add("Tezgah 2");
                        BeklemeSuresiList.Add(0);
                        Tezgah2Durum = true;
                    }
                    else
                    {
                        bekleyen.Add(sipNo);
                    }
                    GelisZamaniYedekList.Remove(GelisZamaniYedekList[0]);
                }

            }

        }
    }
}
