using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DersNotları : MonoBehaviour
{   
    // VIDEO 1 :
       // 1. X:24 Y:2 Z: 24 ölçekli bir küp oluşturduk.
          // SHIFT + CTRL + F ile main kamera seçiliyken bastığımızda bizim ekranda gördüğümüzü görecek şekilde kamerayı yerleştiri.
       // 2. Bir küp daha ekledi zeminin biraz üstüne.
          // GOOGLE > UNITY GRAVITY COMPONENT > RIGITBODY COMPONENT > MANUEL  seçersek kodsuz kısıma geldik.
          // ADD COMPONENT > RIGIDBODY küpe yerçekimi etki edebilecek. Burada Use Gravity bir bool değer ve tıklı ise true olur.
          // Box Collider altında Size 2şer birim artır > çalıştır > küp düştü altında boşluk kaldı temas etmedi zeminle.
          // Box Collider 0.5 size olduğunda küp zeminin içine girdi.
             // !!!ÖNEMLİ!!!  Box Collider > Is Trigger > Click:
             // Bu tık ile biz küpün nesnenin içinden geçip devam etmesini sağlarız.
             // Bunu coin toplamada playerın coinlere çarpmasın,çarpıp sekmesin  diye kullanırız böylece içinden geçebilir.


    // VIDEO 2 : Mouse ile yerleştirip Poaisyon kısmından tamsayıya tamamladım 
       // 1. Boyutlandırdığımız ilk küp Rename: Base
          // Pozition : X:0  Y:0  Z:0     <Benim Yaptığım>  Position : X:0 Y:0  Z:0
          // Rotation : X:90 Y:10  Z:0    <Benim Yaptığım>  Rotation : X:0 Y:0  Z:-10
          // Scale    : X:24 Y:2  Z:24    <Benim Yaptığım>  Scale    : X:2 Y:24 Z:24
          // Scale kısmında X:2 Y:24 Z:0 ken bir kare prizma Z:24 yaptığımızda yanlara genişledi ve dikdörtgen prizma oldu.
          // Burada Base (0,0,0) noktasında olduğundan yüksekliği aslında 12 birim yukarı ve 12 birim aşağı.
          //.
       // 2. İkinci küp rename: Wall_1.
          // Bu küp ile duvarları oluşturacağız.
          // Yerçekiminden etkilenmemesi için Rigidbody > REMOVE COMPONENT
          //                              <Benim Yaptığım>  Position : X:0  Y:11  Z: 0
          // Scale    : X:24  Y:2   Z:2   <Benim Yaptığım>  Scale    : X:2  Y:2   Z:24
             //ÖNEMLİ!!! Platformda topun hareketi için Rotation: Z:-10 z ekseninde eğim olmalı rotasyon yapsaydım x eks .
          // (0,0,0) nokatsına göre 11 birim yukarı aldık.
          // Base in kenarlarından taşmasını vs istemediğimizden z ekseninde hareket olmadı ilk duruma göre bu yüzden Z:0 kaldı
          // Bu boyuttaki Wall ağırlık noktasından 11 birim yukarı alındığında Base in yukarı bitiş noktasında bitti.          
          //
       // 3. Wall > Duplicate > Base i çevrele
          //!!!ÖNEMLİ!!! Şimdilik Hocanın yapyığı şekilde devam edip daha sonra kendi yaptığım şekilde ilerlemeyi denerim.
       // 4. Base > Inspector > Mesh Renderer > Materials > Seçebilmem için
          //... Assets Panel > Right Click > Create > Folder rename: Materials > Create > Material rename: Base
          //... Siyah renk yaptık.
          //...Ekrana sürükleyebilir ya da Base seçili iken insp.>material> Default olan kısma sürükle ve bırak.
          //Bir tane de Walls için oluştur.
             //Hierarcy > Wall_1 i seç SHIFT + ALT + Wall_4 e tıkla hepsini seç ve default kısmına yenisini bırak.
             //CTRL + D ile seçili objeyi hızlıca duplicate et.
             //SHIFT + F ya da seçili oyun objesine çift tıklayarak ODAKLAN 
       // 5. Hierarcy > Empty Create > Rename: Parent ve oluşturduğumuz tüm objeleri Player hariç Parentın içine atalım.
          // Player > Rigidbody Component > Mass: 0.03 ve açısal hız sıfırla Angular Drag :0 .
          // !!!ÖNEMLİ!!! Player ın z ekseninde hareket etmesini istemiyoruz.
          // Rigidbody > Constrains > Freeze Position : Z yi seçili yap.
       // 6. Google > Unity  Manuel > Physics > Built-in 3D > Rigidbody > Constant Force işimize yara dedik.
          // Parent seçili > Add Component > Constant Force ekledik Rigidbody de geldi çünkü bunu kullanabilmemiz için lazım.
          // Platformun aşağı düşmemesi için Use Gravity deki tiki kaldır.
          // Ancak bu sefer Playera etki eden yerçekimi ile platform aşağı düşer.
          // Bu sorunu engellemek için Freeze Position X,Y,Z dekiler ve Freeze Rotation Z hariç hepsinin tikli olması gerekir.
          // !!!Önemlii!!! Benim eksenleri farklı kullanmam nedeniyle Freeze Pozition hepsi ve Rotation X hariç tikli yap.
          // Normalde Constant Force > Torque kısmında Z değeri verirken ben X için değer verdim.
       // 7. Her iki yöne dönecek bir yapı için Torque +5 ve -5 değerlerini ayrı ayrı denedik iki yöne dönüş nasıl olacak?
          // Add Component dedik izin vermedi iki aynı component objeye eklenemiyor.
          // GrandParent oluşturup ona bir Constant Force componentı daha ekleyelim.
       // 8. Parent torque X: 1 ve Grandparent torque: -1 değerleri ile Angular Drag =0 yaptık.
       // 9. Parent a ait tüm objelere RIGIDBODY ekleyelim.
          // !!!ÖNEMLİ!!! Bunu yapmazsak sağa ve soluş dönüş hızında farklılıklar görebiliriz.
          // Use Gravity kaldır ve is Kinematik tıkla.
          // Sadece Dönüş yönü hariç her ekseni Freeze Rotation ve Pozition seçeneklerini tıkla.
          // ???? Video 5 dk:4.09 a kadarki adımları takip ettim ama çalıştırdığımda çok hızlı bir dönüş var ve topun hareketi anlamsız.
          // Bu yüzden Parent içindeki objelere eklediğim Rigidbody i kaldırdım.
       // 10.Hierarcy > UI > Legacy > Button... sahneye bir tane buton ekledik. Bende Farklı
          // Game > Free Aspect > Full HD (1920*1080)seçip HD görüntü.
          // Buton geldiğinde INSPECTOR > TRANSFOTM yerine RECT TRANSFORM görünüyor.
          // Bir de Hierarcy bölüme Canvas la birlikte geldi onun child ı olarak.
          // Canvas nasıl göründüğünü ekran çözünürlülüğüne göre belirliyor.
          // Canvas > Insp. Render Mode : Screen Space- Overlay yazıyor buradan anladık.
          // Butonun child ı Text işimize yaramayacak Text> Insp. > Text isminin yanındaki tiki kaldır.
          // Button > Width : 140 Height : 140 ile kare bir buton elde et.
          // !!!ÖNEMLİ!!! Dosyadaki png leri Asset paneline sürükle ve bırak.
          // !!! Assetlere Tıkla > Inspector > Texure Type : Sprite (2D and UI) seç.
          // Buton seçili iken > inspector > Image component da Source image tıkla ve sola dönüş resmini seç.
          // .
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
