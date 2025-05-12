using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication11.Models;

namespace YourNamespace.Controllers
{
    public class ConjugationController : Controller
    {
        private static readonly HashSet<string> singleSyllableWords = new HashSet<string>
        {
            
            "aç","ahiret","ahlak","ak","alt","anket", "aşk","at", 
            "bisiklet","bulut", "bük",
            "çak", "çat",  "çek","çöp",
            "devlet", "dost", "dut",  
            "ek", "et", 
            "hakikat","hap","hayat","hukuk",
            "ırk",
            "iç", "ilk", "ip",
            "jet",
            "kaç", "kart", "koç", "konut",
            "maç", "mart", "mat","merak","millet", "mülk",
            "not",
            "ot","ok",
            "pak", "pek", 
            "rest",
            "sanat","saç","sarkıt", "servet", "suç","sürat",
            "şiş",
            "tazyik","tek","tip", "tok", "top",  
            "uç", "un",
            "üç",  "üs", "üst", 
            "yazıt","yok", 
            "zat",
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ConjugationModel());
        }

        [HttpPost]
        public IActionResult Index(ConjugationModel model)
        {
            if (!string.IsNullOrEmpty(model.InputWord))
            {
                model.ConjugatedWords = GenerateConjugations(model.InputWord);
            }
            return View(model);
        }

        private Dictionary<string, string> GenerateConjugations(string word)
        {
            char lastVowel = GetLastVowel(word);
            bool isBackVowel = IsBackVowel(lastVowel);
            bool isRoundedVowel = IsRoundedVowel(lastVowel);
            bool endsWithVowel = IsVowel(word[^1]);

            // Ekleri belirleme
            string suffix1 = (isBackVowel ? (isRoundedVowel ? "um" : "ım") : (isRoundedVowel ? "üm" : "im"));
            string suffix2 = (isBackVowel ? (isRoundedVowel ? "sun" : "sın") : (isRoundedVowel ? "sün" : "sin"));
            string suffix3 = (isBackVowel ? (isRoundedVowel ? "uz" : "ız") : (isRoundedVowel ? "üz" : "iz"));
            string suffix4 = (isBackVowel ? (isRoundedVowel ? "sunuz" : "sınız") : (isRoundedVowel ? "sünüz" : "siniz"));
            string suffixPlural = (isBackVowel ? (isRoundedVowel ? "lar" : "lar") : (isRoundedVowel ? "ler" : "ler"));

            // Eğer kelime sesli harfle bitiyorsa ve ek de sesliyle başlıyorsa araya "y" ekle
            suffix1 = endsWithVowel && IsVowel(suffix1[0]) ? "y" + suffix1 : suffix1;
            suffix2 = endsWithVowel && IsVowel(suffix2[0]) ? "y" + suffix2 : suffix2;
            suffix3 = endsWithVowel && IsVowel(suffix3[0]) ? "y" + suffix3 : suffix3;
            suffix4 = endsWithVowel && IsVowel(suffix4[0]) ? "y" + suffix4 : suffix4;
            suffixPlural = endsWithVowel && IsVowel(suffixPlural[0]) ? "y" + suffixPlural : suffixPlural;

            // Kelime yumuşatma işlemi: sadece sesli harfle başlayan eklerde uygula
            string conjugatedWord1 = ApplyConsonantSoftening(word, suffix1);
            string conjugatedWord2 = ApplyConsonantSoftening(word, suffix2);
            string conjugatedWord3 = ApplyConsonantSoftening(word, suffix3);
            string conjugatedWord4 = ApplyConsonantSoftening(word, suffix4);
            string conjugatedWordPlural = ApplyConsonantSoftening(word, suffixPlural);

            // Ekleri kelimelerle birleştiriyoruz
            return new Dictionary<string, string>
            {
                {"Ben", conjugatedWord1 + suffix1},     // "Ben öğretmenim."
                {"Sen", conjugatedWord2 + suffix2},     // "Sen öğretmensin."
                {"O", word},                             // "O öğretmen."
                {"Biz", conjugatedWord3 + suffix3},     // "Biz öğretmeniz."
                {"Siz", conjugatedWord4 + suffix4},     // "Siz öğretmensiniz."
                {"Onlar", conjugatedWordPlural + suffixPlural} // "Onlar öğretmenler."
            };
        }

        private string ApplyConsonantSoftening(string word, string suffix)
        {
            // Tek heceli kelimelerde yumuşama kurallarını uygulama
            if (singleSyllableWords.Contains(word)) return word;

            // Ek sesli harfle başlıyorsa yumuşama kurallarını uygula
            if (IsVowel(suffix[0]))
            {
                if (word.Length < 1) return word;

                char lastChar = word[^1];

                // Eğer kelime "nk" ile bitiyorsa ve ek sesli ile başlıyorsa
                if (word.EndsWith("nk"))
                {
                    return word[..^1] + "g"; // 'nk' -> 'g' (k'yi g'ye çevir, n kalır)
                }

                if (word.EndsWith("g"))
                {
                    return word[..^1] + "ğ"; 
                }

                // Diğer durumlar için yumuşama kuralları
                return lastChar switch
                {
                    'p' => word[..^1] + "b", // 'p' -> 'b'
                    'ç' => word[..^1] + "c", // 'ç' -> 'c'
                    't' => word[..^1] + "d", // 't' -> 'd'
                    'k' => word[..^1] + "ğ", // 'k' -> 'ğ'
                    _ => word
                };
            }

            return word; // Eğer ek sesli değilse kelimeyi değiştirme
        }

        private char GetLastVowel(string word)
        {
            string vowels = "aeıioöuü"; // Türkçe sesli harfler
            for (int i = word.Length - 1; i >= 0; i--)
            {
                if (vowels.Contains(word[i]))
                {
                    return word[i];
                }
            }
            return '\0'; // Eğer sesli harf bulunmazsa null karakter döndür
        }

        private bool IsVowel(char c)
        {
            return "aeıioöuü".Contains(c);
        }

        private bool IsBackVowel(char c)
        {
            return "aıou".Contains(c);
        }

        private bool IsRoundedVowel(char c)
        {
            return "oöuü".Contains(c);
        }
    }
}





