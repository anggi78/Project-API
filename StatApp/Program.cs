using System;
using Library;

class Program
{
    static void Main()
    {
        Console.WriteLine("Selamat datang di Aplikasi Kalkulator Kelompok 3");
        Console.WriteLine("------------------------------------------------");

        while (true)
        {
            Console.WriteLine("Pilih jenis kalkulator:");
            Console.WriteLine("1. Kalkulator Matematika");
            Console.WriteLine("2. Kalkulator Statistik");
            Console.WriteLine("3. Kalkulator Fisika");
            Console.WriteLine("0. Keluar");

            LibraryAPI api = LibraryAPI.Instance;
            PhysicsCalculator calculator = api.PhysicsCalculator;
            Geometry geometry = api.Geometry;
            StatCalculatorFactory calculatorFactory = api.StatCalculatorFactory;


            Console.Write("Masukkan pilihan Anda (0-3): ");
            int pilihan = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (pilihan == 0)
            {
                Console.WriteLine("Terima kasih telah menggunakan Aplikasi Kalkulator. Sampai jumpa lagi!");
                break;
            }
            else if (pilihan == 1)
            {
                PerformGeometryCalculation();
            }
            else if (pilihan == 2)
            {
                PerformStatisticsCalculation();
            }
            else if (pilihan == 3)
            {
                PerformPhysicsCalculation();
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid. Silakan pilih kembali.");
            }

            Console.WriteLine();
        }
    }

    public static void PerformGeometryCalculation()
    {
        // Meminta input jenis bangun geometri
        Console.WriteLine("Silakan pilih jenis bangun geometri:");
        Console.WriteLine("1. Piramida Segitiga");
        Console.WriteLine("2. Piramida Persegi");
        Console.WriteLine("3. Balok");
        Console.WriteLine("4. Kubus");
        Console.WriteLine("5. Silinder");
        Console.Write("Pilihan: ");
        int shapeChoice = int.Parse(Console.ReadLine());

        Geometry geometry = Geometry.Instance;

        switch (shapeChoice)
        {
            case 1:
                Console.Write("Masukkan panjang sisi dasar: ");
                double baseLength = double.Parse(Console.ReadLine());
                Console.Write("Masukkan tinggi: ");
                double height = double.Parse(Console.ReadLine());
                double triangularPyramidVolume = geometry.CalculateTriangularPyramidVolume(baseLength, height);
                Console.WriteLine("Volume piramida segitiga: " + triangularPyramidVolume);
                break;
            case 2:
                Console.Write("Masukkan panjang sisi dasar: ");
                double squareBaseLength = double.Parse(Console.ReadLine());
                Console.Write("Masukkan tinggi: ");
                double squareHeight = double.Parse(Console.ReadLine());
                double squarePyramidVolume = geometry.CalculateSquarePyramidVolume(squareBaseLength, squareHeight);
                Console.WriteLine("Volume piramida persegi: " + squarePyramidVolume);
                break;
            case 3:
                Console.Write("Masukkan panjang: ");
                double length = double.Parse(Console.ReadLine());
                Console.Write("Masukkan lebar: ");
                double width = double.Parse(Console.ReadLine());
                Console.Write("Masukkan tinggi: ");
                double cuboidHeight = double.Parse(Console.ReadLine());
                double cuboidVolume = geometry.CalculateCuboidVolume(length, width, cuboidHeight);
                Console.WriteLine("Volume balok: " + cuboidVolume);
                break;
            case 4:
                Console.Write("Masukkan panjang sisi: ");
                double cubeSide = double.Parse(Console.ReadLine());
                double cubeVolume = geometry.CalculateCubeVolume(cubeSide);
                Console.WriteLine("Volume kubus: " + cubeVolume);
                break;
            case 5:
                Console.Write("Masukkan jari-jari: ");
                double cylinderRadius = double.Parse(Console.ReadLine());
                Console.Write("Masukkan tinggi: ");
                double cylinderHeight = double.Parse(Console.ReadLine());
                double cylinderVolume = geometry.CalculateCylinderVolume(cylinderRadius, cylinderHeight);
                Console.WriteLine("Volume silinder: " + cylinderVolume);
                break;
            default:
                Console.WriteLine("Pilihan tidak valid.");
                break;
        }
    }

    public static void PerformStatisticsCalculation()
    {
        // Meminta input jenis perhitungan statistik
        Console.WriteLine("Silakan pilih jenis perhitungan statistik:");
        Console.WriteLine("1. Rentang (Range)");
        Console.WriteLine("2. Kuartil (Quartile)");
        Console.WriteLine("3. Rentang Kuartil (Quartile Range)");
        Console.WriteLine("4. Kemiringan (Skewness)");
        Console.WriteLine("5. Kurtosis (Kurtosis)");
        Console.Write("Pilihan: ");
        int statChoice = int.Parse(Console.ReadLine());

        // Meminta input data
        Console.WriteLine("Masukkan data (pisahkan dengan spasi): ");
        string[] dataValues = Console.ReadLine().Split(' ');
        List<double> data = new List<double>();
        foreach (string value in dataValues)
        {
            data.Add(double.Parse(value));
        }

        StatCalculatorFactory factory = StatCalculatorFactory.Instance;
        IStatCalculator calculator = null;
        switch (statChoice)
        {
            case 1:
                calculator = factory.GetCalculator("Range");
                break;
            case 2:
                calculator = factory.GetCalculator("Quartile");
                break;
            case 3:
                calculator = factory.GetCalculator("QuartileRange");
                break;
            case 4:
                calculator = factory.GetCalculator("Skewness");
                break;
            case 5:
                calculator = factory.GetCalculator("Kurtosis");
                break;
            default:
                Console.WriteLine("Pilihan tidak valid.");
                break;
        }
        if (calculator != null)
        {
            double result = calculator.Calculate(data);
            Console.WriteLine("Hasil perhitungan: " + result);
        }
    }

    public static void PerformPhysicsCalculation()
    {
        Console.WriteLine("Pilih jenis perhitungan fisika:");
        Console.WriteLine("1. Menghitung kecepatan");
        Console.WriteLine("2. Menghitung arus listrik");
        Console.WriteLine("3. Menghitung jarak tempuh");
        Console.WriteLine("4. Menghitung tekanan (Hukum Pascal)");
        Console.WriteLine("5. Menghitung momentum (Hukum Kekekalan Momentum)");
        Console.Write("Masukkan pilihan Anda (1-5): ");
        int pilihan = Convert.ToInt32(Console.ReadLine());

        PhysicsCalculator calculator = PhysicsCalculator.Instance;

        double hasil = 0;

        switch (pilihan)
        {
            case 1:
                Console.Write("Masukkan jarak (dalam meter): ");
                double jarak = Convert.ToDouble(Console.ReadLine());
                Console.Write("Masukkan waktu (dalam detik): ");
                double waktu = Convert.ToDouble(Console.ReadLine());

                hasil = calculator.CalculateVelocity(jarak, waktu);
                Console.WriteLine("Kecepatan = " + hasil.ToString("0.##") + " m/s");
                break;
            case 2:
                Console.Write("Masukkan tegangan (dalam volt): ");
                double tegangan = Convert.ToDouble(Console.ReadLine());
                Console.Write("Masukkan hambatan (dalam ohm): ");
                double hambatan = Convert.ToDouble(Console.ReadLine());

                hasil = calculator.CalculateElectricCurrent(tegangan, hambatan);
                Console.WriteLine("Arus Listrik = " + hasil.ToString("0.##") + " Ampere");
                break;
            case 3:
                Console.Write("Masukkan kecepatan (dalam m/s): ");
                double kecepatan = Convert.ToDouble(Console.ReadLine());
                Console.Write("Masukkan waktu (dalam detik): ");
                double waktuTempuh = Convert.ToDouble(Console.ReadLine());

                hasil = calculator.CalculateDistance(kecepatan, waktuTempuh);
                Console.WriteLine("Jarak Tempuh = " + hasil.ToString("0.##") + " meter");
                break;
            case 4:
                Console.Write("Masukkan gaya (dalam Newton): ");
                double gaya = Convert.ToDouble(Console.ReadLine());
                Console.Write("Masukkan luas permukaan (dalam meter persegi): ");
                double luas = Convert.ToDouble(Console.ReadLine());

                hasil = calculator.CalculatePressure(gaya, luas);
                Console.WriteLine("Tekanan = " + hasil.ToString("0.##") + " Pascal");
                break;
            case 5:
                Console.Write("Masukkan momentum awal (dalam kg.m/s): ");
                double momentumAwal = Convert.ToDouble(Console.ReadLine());
                Console.Write("Masukkan momentum akhir (dalam kg.m/s): ");
                double momentumAkhir = Convert.ToDouble(Console.ReadLine());

                hasil = calculator.CalculateMomentumChange(momentumAwal, momentumAkhir);
                Console.WriteLine("Perubahan Momentum (Hukum Kekekalan Momentum) = " + hasil.ToString("0.##") + " kg.m/s");
                break;
            default:
                Console.WriteLine("Pilihan tidak valid.");
                break;
        }
    }
}

