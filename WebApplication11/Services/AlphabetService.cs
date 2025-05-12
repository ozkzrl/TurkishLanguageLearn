using System.Collections.Generic;
using WebApplication11.Models;

public class AlphabetService
{
    private static readonly List<string> TurkishAlphabet = new List<string>
    {
        "A", "B", "C", "Ç", "D", "E", "F", "G", "Ğ", "H", "I", "İ", "J",
        "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z"
    };

    public List<string> GetAlphabet()
    {
        return TurkishAlphabet;
    }

    public List<ImageModel> GetImagesForLetter(string letter)
    {
        var images = new List<ImageModel>();

        switch (letter.ToUpper())
        {
            case "A":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/at.png", ImageName = "at" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/araba.png", ImageName = "araba" });
                break;
            case "B":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/bal.png", ImageName = "bal" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/balık.png", ImageName = "balık" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/beş.png", ImageName = "beş" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/bilgisayar.png", ImageName = "bilgisayar" });
                break;
            case "C":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/cadde.png", ImageName = "cadde" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/cam.png", ImageName = "cam" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/casus.png", ImageName = "casus" });
                
                break;
            case "Ç":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/çay.png", ImageName = "çay" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/çiçek.png", ImageName = "çiçek" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/çocuk.png", ImageName = "çocuk" });
                
                break;
            case "D":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/daire.png", ImageName = "daire" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/defter.png", ImageName = "defter" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/domuz.png", ImageName = "domuz" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/dünya.png", ImageName = "dünya" });
                
                break;
            case "E":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/eğlence.png", ImageName = "eğlence" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ekmek.png", ImageName = "ekmek" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ev.png", ImageName = "ev" });
                break;
            case "F":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/fabrika.png", ImageName = "fabrika" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/fakir.png", ImageName = "fakir" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/fare.png", ImageName = "fare" });
                break;
            case "G":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/gazete.png", ImageName = "gazete" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/gemi.png", ImageName = "gemi" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/genç.png", ImageName = "genç" });
                break;
            case "Ğ":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ağ.png", ImageName = "ağ" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ağlamak.png", ImageName = "ağlamak" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ağaç.png", ImageName = "ağaç" });
                break;
            case "H":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/halı.png", ImageName = "halı" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/hapishane.png", ImageName = "hapishane" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/horoz.png", ImageName = "horoz" });
                break;
            case "I":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ırmak.png", ImageName = "ırmak" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ışık.png", ImageName = "ışık" });
                break;
            case "İ":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/içmek.png", ImageName = "içmek" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ihtiyar.png", ImageName = "ihtiyar" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/iki.png", ImageName = "iki" });
                break;
            case "J":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/Japonya.png", ImageName = "Japonya" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/jet.png", ImageName = "jet" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/jimnastik.png", ImageName = "Jimnastik" });
                break;
            case "K":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/kadın.png", ImageName = "kadın" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/kale.png", ImageName = "kale" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/kapı.png", ImageName = "kadı" });
                break;
            case "L":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/lale.png", ImageName = "lale" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/limon.png", ImageName = "limon" });
                break;
            case "M":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/makas.png", ImageName = "makas" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/masa.png", ImageName = "masa" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/mavi.png", ImageName = "mavi" });
                break;
            case "N":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/nar.png", ImageName = "nar" });
                break;
            case "O":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ocak.png", ImageName = "ocak" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ok.png", ImageName = "ok" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/okumak.png", ImageName = "okumak" });
                break;
            case "Ö":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ördek.png", ImageName = "ördek" });
                break;
            case "P":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/pahalı.png", ImageName = "pahalı" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/palto.png", ImageName = "palto" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/parmak.png", ImageName = "parmak" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/pantolon.png", ImageName = "pantolo" });
                break;
            case "R":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/reçel.png", ImageName = "reçel" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/reçete.png", ImageName = "reçete" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/radio.png", ImageName = "radio" });
                break;
            case "S":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/sarı.png", ImageName = "sarı" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/saç.png", ImageName = "saç" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/sayı.png", ImageName = "sayı" });
                break;
            case "Ş":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/şarkısöylemek.png", ImageName = "şarkı söylemek" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/şeker.png", ImageName = "şeker" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/şemsiye.png", ImageName = "şemsiye" });
                break;
            case "T":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/taksi.png", ImageName = "taksi" });
                break;
            case "U":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/uçak.png", ImageName = "uçak" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/uydu.png", ImageName = "uydu" });
                break;
            case "Ü":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ülke.png", ImageName = "ülke" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/ütü.png", ImageName = "ütü" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/üye.png", ImageName = "üye" });
                break;
            case "V":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/vaha.png", ImageName = "vaha" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/vapur.png", ImageName = "vapur" });
                break;
            case "Y":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/yaz.png", ImageName = "yaz" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/yirmi.png", ImageName = "yirmi" });
                break;
            case "Z":
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/zehir.png", ImageName = "zehir" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/zincir.png", ImageName = "zincir" });
                images.Add(new ImageModel { ImagePath = "/images/harfresimleri/zengin.png", ImageName = "zengin" });
                break;
        }

        return images;
    }
}
