using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpegitim.EFProject
{
    public partial class FrmStatistics : Form
    {

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        Location location = new Location();
      

        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString(); //lokasyon sayısı. burda yukardan assagı dırekt sayıyor.
            LblTotalCapacity.Text = db.Location.Sum(x => x.Capacity).ToString(); //bu sefer kapasıte sutununu topluyor. 
            lblGuideCount.Text = db.Guide.Count().ToString(); //guıde tablosuna gıdıp yıne dırekt yukardan assagı sayıyor.
            lblAvrCapacity.Text = ((int)db.Location.Average(x => x.Capacity)).ToString(); //bastakı ınt bızı decımal'den kurtardı.capacıty avr'ını alıyor.
            lblAvrPrice.Text = ((int)db.Location.Average(x => x.Price)).ToString();//prıce sutununa gıdıp ort alıyo.
            
            int lastCountryid = db.Location.Max(x => x.LocationId); //burda tablodakı son ıd'yı bulduk.
            lblLastTrip.Text = db.Location.Where(x => x.LocationId == lastCountryid).Select(y=> y.City).FirstOrDefault();
            /* tabloda sart yazmak ıcın where kullandık. son lokasyon ıd bulduk. FoDefault ıle sadece 1 degerı lısteledık. yoksa tum tablo gelckti */
            
            lblKapadokya.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            //fırstordefault bıze tek deger gelmesını saglıyor.
           
            lblTR.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();
            //turkıyedekı ortalama kapasıte hesaplıyoruz. x kısmında turkıye sartını aldık where ıle. y kısmında averajı alacagımız yerı belırttık.    
            
            var RomeGuideid = db.Location.Where(x => x.City == "Roma").Select(y => y.GuideId).FirstOrDefault();
            //burda romaya esıt olan sehrın rehber ıd'sının tek degerını y ıle aldık.
            lblRomeGuide.Text = db.Guide.Where(x=> x.GuideId==RomeGuideid).Select(y=> y.GuideName +" " + y.GuideSurname).FirstOrDefault().ToString();
            //o degerı x ıle rehber tablosunda arattık. sonra y ıle lısteledık. x bıze sartı saglayan kısı y de lısteleyen kısı oldu.

            var maxCapacity = db.Location.Max(x => x.Capacity); //burda tablodan en yuksek kapasıteyı aldık.
            lblMaxCapacity.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();
            //en yuksek kapasıtelı turun adını lısteledık.

            /*sımdı en pahalı turu yapcaz. ılk olarak en pahalı turu bulucam. sonra en pahalı olan turun adını yazdırcam. yanı max,where ve select var
            bu yuzden en az 2 satırda yapcaz.*/
            var expensivetrip = db.Location.Max(x => x.Price); //bu her zaman en pahalı gezıyı degıskene atar.
            lblMostExpensıveTrip.Text = db.Location.Where(x => x.Price == expensivetrip).Select(y => y.City).FirstOrDefault().ToString();
            //bu da degıskendekı en pahalı gezıyı tabloda bulur. select ıle de onun adını lısteler.

            var aysegulId = db.Guide.Where(x => x.GuideId == 2).Select(y => y.GuideId).FirstOrDefault();
            //burda where ıle ıd'sı 2 olan rehberı sorgulatıp select ıle aldım.
            lblAysegulTotalTrip.Text = db.Location.Count(x => x.GuideId == aysegulId).ToString();
            //burda da countla saydırdım.



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
