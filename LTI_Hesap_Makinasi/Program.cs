using System;
using NCalc;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace LTI_Hesap_Makinasi
{
    class Program
    {
        static void Main()
        {
            
            Console.Title = "Gelişmiş Matematik Hesap Makinesi v2.0";
            Console.ForegroundColor = ConsoleColor.Cyan;

            AnaMenu();
        }

        static void AnaMenu()
        {
            while (true)
            {
                Console.Clear();
                YaziBas();

                Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                    GELİŞMİŞ MATEMATİK HESAPLAYİCİSİ                  ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║  1. 📊 Fonksiyon Analizi (Limit, Türev, İntegral)                   ║");
                Console.WriteLine("║  2. 📈 Grafik Bilgisi ve Kritik Noktalar                           ║");
                Console.WriteLine("║  3. 🧮 Temel Hesap Makinesi                                         ║");
                Console.WriteLine("║  4. 📚 Yardım ve Örnekler                                           ║");
                Console.WriteLine("║  5. ❌ Çıkış                                                         ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝");
                Console.Write("\n➤ Seçiminizi yapın (1-5): ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        FonksiyonAnalizi();
                        break;
                    case "2":
                        GrafikAnalizi();
                        break;
                    case "3":
                        TemelHesapMakinesi();
                        break;
                    case "4":
                        YardimMenusu();
                        break;
                    case "5":
                        Console.WriteLine("\n👋 Hesap makinesini kullandığınız için teşekkürler!");
                        Environment.Exit(0);
                        break;
                    default:
                        HataMesaji("Geçersiz seçim! Lütfen 1-5 arası bir sayı girin.");
                        break;
                }
            }
        }

        static void FonksiyonAnalizi()
        {
            Console.Clear();
            YaziBas();
            Console.WriteLine("📊 FONKSİYON ANALİZİ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════");

           
            Console.WriteLine("\n📝 Fonksiyon örnekleri:");
            Console.WriteLine("   • Polinom: x^2 + 3*x + 2");
            Console.WriteLine("   • Trigonometrik: Sin(x), Cos(x), Tan(x)");
            Console.WriteLine("   • Logaritmik: Log(x), Log10(x)");
            Console.WriteLine("   • Üstel: Exp(x), x^3");
            Console.WriteLine("   • Kombinasyon: x^2 + Sin(x) + Log(x)");

            Console.Write("\n🔍 Fonksiyonu girin: ");
            string func = Console.ReadLine();

            if (string.IsNullOrEmpty(func))
            {
                HataMesaji("Fonksiyon girmediniz!");
                return;
            }

            
            if (!FonksiyonGecerliMi(func))
            {
                HataMesaji("Geçersiz fonksiyon! Yardım menüsünden örnekleri inceleyebilirsiniz.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n" + new string('─', 70));
                Console.WriteLine($"📊 Fonksiyon: f(x) = {func}");
                Console.WriteLine(new string('─', 70));
                Console.WriteLine("1. 🎯 Limit Hesaplama");
                Console.WriteLine("2. 📐 Türev Hesaplama");
                Console.WriteLine("3. 🔢 İntegral Hesaplama");
                Console.WriteLine("4. 📊 Fonksiyon Değeri Hesaplama");
                Console.WriteLine("5. 🔙 Ana Menüye Dön");

                Console.Write("\n➤ İşlem seçin (1-5): ");
                string islem = Console.ReadLine();

                switch (islem)
                {
                    case "1":
                        LimitHesapla(func);
                        break;
                    case "2":
                        TurevHesapla(func);
                        break;
                    case "3":
                        IntegralHesapla(func);
                        break;
                    case "4":
                        FonksiyonDegeriHesapla(func);
                        break;
                    case "5":
                        return;
                    default:
                        HataMesaji("Geçersiz seçim!");
                        break;
                }
            }
        }

        static void LimitHesapla(string func)
        {
            Console.Write("\n🎯 Limit noktası (x = ): ");
            if (double.TryParse(Console.ReadLine(), out double xLimit))
            {
                try
                {
                    double limit = Hesaplayici.Limit(func, xLimit);
                    BasariMesaji($"lim(x→{xLimit}) f(x) = {limit:F6}");

                    // Ek bilgi
                    Console.WriteLine($"\n📋 Detaylar:");
                    Console.WriteLine($"   • Soldan limit: {Hesaplayici.SoldanLimit(func, xLimit):F6}");
                    Console.WriteLine($"   • Sağdan limit: {Hesaplayici.SagdanLimit(func, xLimit):F6}");
                }
                catch (Exception ex)
                {
                    HataMesaji(ex.Message);
                }
            }
            else
            {
                HataMesaji("Geçersiz sayı!");
            }

            BekleVeDevamEt();
        }

        static void TurevHesapla(string func)
        {
            Console.Write("\n📐 Türev noktası (x = ): ");
            if (double.TryParse(Console.ReadLine(), out double xTurev))
            {
                try
                {
                    double turev = Hesaplayici.Turev(func, xTurev);
                    BasariMesaji($"f'({xTurev}) = {turev:F6}");

                    // Eğim bilgisi
                    if (Math.Abs(turev) < 1e-6)
                        Console.WriteLine("🔍 Bu noktada fonksiyon yatay (kritik nokta olabilir)");
                    else if (turev > 0)
                        Console.WriteLine("📈 Bu noktada fonksiyon artan");
                    else
                        Console.WriteLine("📉 Bu noktada fonksiyon azalan");
                }
                catch (Exception ex)
                {
                    HataMesaji(ex.Message);
                }
            }
            else
            {
                HataMesaji("Geçersiz sayı!");
            }

            BekleVeDevamEt();
        }

        static void IntegralHesapla(string func)
        {
            Console.Write("\n🔢 Alt sınır (a = ): ");
            if (double.TryParse(Console.ReadLine(), out double a))
            {
                Console.Write("🔢 Üst sınır (b = ): ");
                if (double.TryParse(Console.ReadLine(), out double b))
                {
                    try
                    {
                        double integral = Hesaplayici.Integral(func, a, b);
                        BasariMesaji($"∫[{a} → {b}] f(x)dx = {integral:F6}");

                        
                        if (integral > 0)
                            Console.WriteLine("📊 Pozitif alan (x-ekseni üzerinde)");
                        else if (integral < 0)
                            Console.WriteLine("📊 Negatif alan (x-ekseni altında)");
                        else
                            Console.WriteLine("📊 Net alan sıfır");
                    }
                    catch (Exception ex)
                    {
                        HataMesaji(ex.Message);
                    }
                }
                else
                {
                    HataMesaji("Geçersiz üst sınır!");
                }
            }
            else
            {
                HataMesaji("Geçersiz alt sınır!");
            }

            BekleVeDevamEt();
        }

        static void FonksiyonDegeriHesapla(string func)
        {
            Console.Write("\n📊 x değeri: ");
            if (double.TryParse(Console.ReadLine(), out double x))
            {
                try
                {
                    double deger = Hesaplayici.Evaluate(func, x);
                    BasariMesaji($"f({x}) = {deger:F6}");
                }
                catch (Exception ex)
                {
                    HataMesaji(ex.Message);
                }
            }
            else
            {
                HataMesaji("Geçersiz sayı!");
            }

            BekleVeDevamEt();
        }

        static void GrafikAnalizi()
        {
            Console.Clear();
            YaziBas();
            Console.WriteLine("📈 GRAFİK ANALİZİ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════");

            Console.Write("\n🔍 Fonksiyonu girin: ");
            string func = Console.ReadLine();

            if (!FonksiyonGecerliMi(func))
            {
                HataMesaji("Geçersiz fonksiyon!");
                BekleVeDevamEt();
                return;
            }

            try
            {
                Console.WriteLine($"\n📊 Fonksiyon: f(x) = {func}");
                Console.WriteLine(new string('─', 70));

                
                Console.WriteLine("📋 Fonksiyon Değerleri Tablosu:");
                Console.WriteLine("┌──────────┬──────────────┬──────────────┐");
                Console.WriteLine("│    x     │     f(x)     │     f'(x)    │");
                Console.WriteLine("├──────────┼──────────────┼──────────────┤");

                for (double x = -5; x <= 5; x += 1)
                {
                    try
                    {
                        double fx = Hesaplayici.Evaluate(func, x);
                        double fpx = Hesaplayici.Turev(func, x);
                        Console.WriteLine($"│ {x,8:F1} │ {fx,12:F4} │ {fpx,12:F4} │");
                    }
                    catch
                    {
                        Console.WriteLine($"│ {x,8:F1} │ {"tanımsız",12} │ {"tanımsız",12} │");
                    }
                }
                Console.WriteLine("└──────────┴──────────────┴──────────────┘");

                // Kritik noktalar
                Console.WriteLine("\n🔍 Kritik Noktalar Analizi:");
                List<double> kritikNoktalar = new List<double>();

                for (double x = -10; x <= 10; x += 0.5)
                {
                    try
                    {
                        double turev = Hesaplayici.Turev(func, x);
                        if (Math.Abs(turev) < 0.01)
                        {
                            kritikNoktalar.Add(x);
                            Console.WriteLine($"   • x = {x:F1} → f'(x) ≈ 0 (Kritik nokta)");
                        }
                    }
                    catch { }
                }

                if (kritikNoktalar.Count == 0)
                    Console.WriteLine("   • Belirgin kritik nokta bulunamadı [-10, 10] aralığında");

            }
            catch (Exception ex)
            {
                HataMesaji(ex.Message);
            }

            BekleVeDevamEt();
        }

        static void TemelHesapMakinesi()
        {
            Console.Clear();
            YaziBas();
            Console.WriteLine("🧮 TEMEL HESAP MAKİNESİ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════");

            while (true)
            {
                Console.Write("\n🔢 Matematiksel ifade girin (veya 'çık' yazın): ");
                string ifade = Console.ReadLine();

                if (ifade?.ToLower() == "çık" || ifade?.ToLower() == "cik")
                    break;

                if (string.IsNullOrEmpty(ifade))
                    continue;

                try
                {
                    NCalc.Expression expr = new NCalc.Expression(ifade);
                    var sonuc = expr.Evaluate();
                    BasariMesaji($"Sonuç: {Convert.ToDouble(sonuc):F6}");
                }
                catch (Exception ex)
                {
                    HataMesaji($"Hata: {ex.Message}");
                }
            }
        }

        static void YardimMenusu()
        {
            Console.Clear();
            YaziBas();
            Console.WriteLine("📚 YARDIM VE ÖRNEKLER");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════");

            Console.WriteLine("\n📝 FONKSİYON YAZIM KURALLARI:");
            Console.WriteLine("   • Değişken: x (küçük harf)");
            Console.WriteLine("   • Çarpma: * (2*x, x*x)");
            Console.WriteLine("   • Üs alma: ^ (x^2, x^3)");
            Console.WriteLine("   • Parantez: ( )");

            Console.WriteLine("\n🔢 MATEMATİKSEL FONKSİYONLAR:");
            Console.WriteLine("   • Sin(x), Cos(x), Tan(x) - Trigonometrik");
            Console.WriteLine("   • Log(x) - Doğal logaritma");
            Console.WriteLine("   • Log10(x) - 10 tabanında logaritma");
            Console.WriteLine("   • Exp(x) - e^x");
            Console.WriteLine("   • Sqrt(x) - Karekök");
            Console.WriteLine("   • Abs(x) - Mutlak değer");

            Console.WriteLine("\n✅ ÖRNEK FONKSİYONLAR:");
            Console.WriteLine("   1. x^2 + 3*x + 2");
            Console.WriteLine("   2. Sin(x) + Cos(x)");
            Console.WriteLine("   3. x^3 - 2*x^2 + x - 1");
            Console.WriteLine("   4. Log(x) + x");
            Console.WriteLine("   5. Exp(x) - x^2");
            Console.WriteLine("   6. Sqrt(x^2 + 1)");

            Console.WriteLine("\n💡 İPUÇLARI:");
            Console.WriteLine("   • Trigonometrik fonksiyonlar radyan cinsinden");
            Console.WriteLine("   • Logaritma için x > 0 olmalı");
            Console.WriteLine("   • Karekök için x ≥ 0 olmalı");
            Console.WriteLine("   • Çarpma işaretini (*) unutmayın");

            BekleVeDevamEt();
        }

        // Yardımcı metotlar
        static bool FonksiyonGecerliMi(string func)
        {
            try
            {
                Hesaplayici.Evaluate(func, 1.0);
                return true;
            }
            catch
            {
                return false;
            }
        }

        static void YaziBas()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    🧮 MATEMATİK HESAPLAYICISI 🧮                     ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        static void BasariMesaji(string mesaj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✅ {mesaj}");
            Console.ResetColor();
        }

        static void HataMesaji(string mesaj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ {mesaj}");
            Console.ResetColor();
        }

        static void BekleVeDevamEt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n⏎ Devam etmek için bir tuşa basın...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }

    static class Hesaplayici
    {
        public static double Evaluate(string expr, double x)
        {
            try
            {
                NCalc.Expression e = new NCalc.Expression(expr);
                e.Parameters["x"] = x;
                object result = e.Evaluate();
                return Convert.ToDouble(result);
            }
            catch (Exception)
            {
                throw new Exception("Fonksiyon çözümlenemedi. Geçerli bir ifade girin.");
            }
        }

        public static double Limit(string func, double x)
        {
            double h = 1e-8;
            double sol = SoldanLimit(func, x);
            double sag = SagdanLimit(func, x);

            if (Math.Abs(sol - sag) < 1e-6)
                return (sol + sag) / 2;
            else
                throw new Exception($"Limit mevcut değil. Sol: {sol:F6}, Sağ: {sag:F6}");
        }

        public static double SoldanLimit(string func, double x)
        {
            double h = 1e-8;
            return Evaluate(func, x - h);
        }

        public static double SagdanLimit(string func, double x)
        {
            double h = 1e-8;
            return Evaluate(func, x + h);
        }

        public static double Turev(string func, double x)
        {
            double h = 1e-7;
            double f1 = Evaluate(func, x + h);
            double f0 = Evaluate(func, x - h);
            return (f1 - f0) / (2 * h);
        }

        public static double Integral(string func, double a, double b)
        {
            int n = 50000; 
            double h = (b - a) / n;
            double toplam = 0;

            
            for (int i = 0; i < n; i++)
            {
                double x0 = a + i * h;
                double x1 = x0 + h / 2;
                double x2 = x0 + h;

                try
                {
                    double f0 = Evaluate(func, x0);
                    double f1 = Evaluate(func, x1);
                    double f2 = Evaluate(func, x2);

                    toplam += (h / 6) * (f0 + 4 * f1 + f2);
                }
                catch
                {
                    
                    try
                    {
                        double f0 = Evaluate(func, x0);
                        double f2 = Evaluate(func, x2);
                        toplam += 0.5 * (f0 + f2) * h;
                    }
                    catch
                    {
                        
                    }
                }
            }

            return toplam;
        }
    }
}
