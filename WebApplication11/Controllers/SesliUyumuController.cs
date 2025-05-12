using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

public class SesliUyumuController : Controller
{
    private char[] kalinSesliler = { 'a', 'ı', 'o', 'u' };
    private char[] inceSesliler = { 'e', 'i', 'ö', 'ü' };
    private char[] duzSesliler = { 'a', 'e', 'ı', 'i' };
    private char[] yuvarlakSesliler = { 'o', 'ö', 'u', 'ü' };

    public IActionResult Index()
    {
        // Rastgele sessiz harfleri gönderiyoruz
        ViewBag.RandomConsonants = GenerateRandomConsonants();
        return View();
    }

    [HttpPost]
    public IActionResult CheckHarmony(List<string> inputs)
    {
        List<char> vowels = new List<char>();

        // Yalnızca sesli harfleri alıyoruz (çift numaralı input alanları)
        for (int i = 1; i < inputs.Count; i += 2)
        {
            if (!string.IsNullOrEmpty(inputs[i]) && IsVowel(inputs[i][0]))
            {
                vowels.Add(inputs[i][0]);
            }
        }

        if (vowels.Count == 0)
        {
            ViewBag.ErrorMessage = "Lütfen sesli harfler girin.";
        }
        else if (!CheckSequentialMajorVowelHarmony(vowels))
        {
            ViewBag.ErrorMessage = "Büyük ünlü uyumu hatası!";
        }
        else if (!CheckSequentialMinorVowelHarmony(vowels))
        {
            ViewBag.ErrorMessage = "Küçük ünlü uyumu hatası!";
        }
        else
        {
            ViewBag.ErrorMessage = "Tebrikler! Ünlü uyumuna uygun.";
        }

        // Tekrar rasgele sessiz harflerle sayfayı yeniden yükleme
        ViewBag.RandomConsonants = GenerateRandomConsonants();
        return View("Index");
    }

    // İki ardışık sesli arasında büyük ünlü uyumu kontrolü
    private bool CheckSequentialMajorVowelHarmony(List<char> vowels)
    {
        for (int i = 0; i < vowels.Count - 1; i++)
        {
            bool currentIsKalin = kalinSesliler.Contains(vowels[i]);
            bool nextIsKalin = kalinSesliler.Contains(vowels[i + 1]);

            if (currentIsKalin != nextIsKalin)
            {
                return false; // Kalın ve ince uyumu sağlanmıyorsa hata
            }
        }
        return true;
    }

    // İki ardışık sesli arasında küçük ünlü uyumu kontrolü
    private bool CheckSequentialMinorVowelHarmony(List<char> vowels)
    {
        for (int i = 0; i < vowels.Count - 1; i++)
        {
            char currentVowel = vowels[i];
            char nextVowel = vowels[i + 1];

            // Düz ünlüden sonra düz ünlü gelmeli
            if (duzSesliler.Contains(currentVowel))
            {
                if (currentVowel == 'a' && !(nextVowel == 'a' || nextVowel == 'ı') || // 'a' dan sonra 'a' veya 'ı'
                    currentVowel == 'e' && !(nextVowel == 'e' || nextVowel == 'i') || // 'e' den sonra 'e' veya 'i'
                    currentVowel == 'ı' && !(nextVowel == 'a' || nextVowel == 'ı') || // 'ı' dan sonra 'a' veya 'ı'
                    currentVowel == 'i' && !(nextVowel == 'i' || nextVowel == 'e'))   // 'i' den sonra 'i' veya 'e'
                {
                    return false; // Eğer uyum sağlanmıyorsa hata
                }
            }
            // Yuvarlak ünlüden sonra yuvarlak dar veya düz geniş ünlü gelmeli
            else if (yuvarlakSesliler.Contains(currentVowel))
            {
                if (currentVowel == 'o' && !(nextVowel == 'u' || nextVowel == 'a') || // 'o' dan sonra 'u' veya 'a' gelmeli
                    currentVowel == 'ö' && !(nextVowel == 'ü' || nextVowel == 'e') || // 'ö' den sonra 'ü' veya 'e' gelmeli
                    currentVowel == 'u' && !(nextVowel == 'u' || nextVowel == 'a') || // 'u' dan sonra 'u' veya 'a' gelmeli
                    currentVowel == 'ü' && !(nextVowel == 'ü' || nextVowel == 'e'))   // 'ü' den sonra 'ü' veya 'e' gelmeli
                {
                    return false; // Eğer uyum sağlanmıyorsa hata
                }
            }

            // 'o' ve 'ö' seslilerinden sonra kendileri gelmemeli
            if ((currentVowel == 'o' && nextVowel == 'o') || (currentVowel == 'ö' && nextVowel == 'ö'))
            {
                return false; // Eğer uyum sağlanmıyorsa hata
            }
        }
        return true; // Uyum sağlanıyorsa
    }

    // Sesli harf kontrolü (geçerli harfin bir sesli olup olmadığını kontrol eder)
    private bool IsVowel(char c)
    {
        return kalinSesliler.Contains(c) || inceSesliler.Contains(c);
    }

    // Rastgele sessiz harfleri üretir
    private string[] GenerateRandomConsonants()
    {
        Random random = new Random();
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "r", "s", "t", "v", "y", "z" };
        string[] randomConsonants = new string[10];

        for (int i = 0; i < 10; i++)
        {
            randomConsonants[i] = consonants[random.Next(consonants.Length)];
        }
        return randomConsonants;
    }
}
