using System;
using System.Collections; // ArrayList'i içeren namespace
using System.Data.SqlClient; // SqlConnection tipini içeren namespace

namespace ArrayList_Kullanimi
{
    class ArrayList_Temelleri
    {
        static void Main(string[] args)
        {
            // Bu konuya başlamadan önce aşağıdaki başlıklar hakkında bilgi sahibi olmanız önerilir.
            // Diziler
            // boxing/unboxing
            // Tür Dönüşümleri
            // Katılım

            System.Collections.ArrayList uyelerim;

            ArrayList arrayList = new ArrayList(); // Bir ArrayList hafızaya çıkarılıyor ve yine ArrayList tipinden bir değişkene atanıyor.

            // ArrayList üzerinde bulunan Add metodunu kullanarak ArrayList içerisine eleman ekleyebiliriz.
            // Add metodu object tipinden parametre alır. .NET dünyasında her şey object olduğuna göre, ArrayList içerisine her tipten veri ekleyebiliriz.

            arrayList.Add(5); // ArrayList'e int ekledik.

            arrayList.Add(3.14); // double ekledik.

            arrayList.Add('A'); // char ekledik

            arrayList.Add("Tilki, kendisini kovalayan kurbağadan saklanarak kurtuldu."); // string ekledik.

            // ArrayList koleksiyonundaki eleman sayısını öğrenmek için ArrayList üzerinde yer alan Count property'sini kullanırız.
            Console.WriteLine(arrayList.Count); // Ekran Çıktısı 4 olacaktır.

            arrayList.Add(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }); // int dizisi ekledik. Dizi de bir nesnedir.

            arrayList.Add(new SqlConnection()); // SqlConnection da bir nesnedir. Bir koleksiyonda ihtiyaç durumunda birden fazla SqlConnection nesnesi tutulabilir.
            // Hatırlatma: .NET Core platformunda SqlConnection ile çalışmak için System.Data.SqlClient paketinin projeye dahil edilmesi gerekir.
            
            arrayList.Add(new object()); // Yeni bir object oluşturarak da ArrayList'e eklemek mümkündür.

            // Eleman sayısına tekrar bakacak olursak yeni elemanların da sayıldığını görürüz.
            Console.WriteLine(arrayList.Count); // Ekran Çıktısı 7 olacaktır.
            // ArrayList'e dizi ekledik. Dizi bir elemandır. Bu dizinin kendine ait kaç elemanı olduğu önemli değil. Koleksiyonun elemanı dizidir. Koleksiyonun içindeki dizinin elemanları çok tane olabilir.

            // ArrayList elemanlarına ulaşmak için aynı dizilerde olduğu gibi indeksleyici kullanırız.
            Console.WriteLine(arrayList[0]); // ilk elemana eriştik ve ekrana yazdırdık.
            Console.WriteLine(arrayList[arrayList.Count - 1]); // son elemana eriştik ve ekrana yazdırdık.

            int[] sayilar = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // Elimizde bulunan bir dizinin elemanlarını tek tek koleksiyona ekleyelim.

            ArrayList sayiListesi = new ArrayList();

            foreach (int sayi in sayilar)
            {
                sayiListesi.Add(sayi); // her ekleme sırasında boxing olayı meydana gelecektir.
            }

            ArrayList yeniListe = new ArrayList();
            yeniListe.AddRange(sayilar); // AddRange metodu ICollection tipinden parametre alır.

            // Tüm diziler Array tipinden kalıtılır. Array tipi de ICollection interface'ini implement etmiştir. Bundan dolayı AddRange metoduna parametre olarak dizi verebiliriz. Bir önceki örnekteki döngü yerine direkt olarak AddRange metodunu kullanarak aynı işlemi yapabiliriz.

            // Koleksiyondaki elemanları kullanarak yeni bir dizi elde etmek isteyelim.
            int[] yeniDizi = new int[sayilar.Length];
            for (int i = 0; i < yeniDizi.Length; i++)
            {
                yeniDizi[i] = (int)sayiListesi[i]; // listenin içerisindeki her bir eleman object olduğundan bunları int olarka elde etmek için cast işlemi yapmak zorundayız. Unboxing olayı meydana gelir.
            }
        }
    }
}
