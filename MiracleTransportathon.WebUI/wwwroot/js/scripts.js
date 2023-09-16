function getExtraService(veri) {
    // Eşleştirme kurallarını tanımlayın
    var eşleştirmeler = {
        '1': 'Kutulama - Toplama',
        '2': 'Avize Asma - Duvara Tv Montajı - Duvara Sabitleme - Store Perde Takılması',
        '3': 'Bina Dışı Asansör Hizmeti',
        '4': 'Kasa Taşıması',
        '5': 'Kırılacak Eşya'
        // Diğer sayılar için eşleştirmeleri ekleyin
    };

    // Veriyi sayılara göre bölüp diziye dönüştürün
    var sayılar = veri.split(',');

    // Eşleştirmeleri bulup sonuç dizisine ekleyin
    var sonuç = sayılar.map(function (sayı) {
        return eşleştirmeler[sayı.trim()] || 'Eşleşme bulunamadı';
    });

    return sonuç; 
}


var regexPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;

