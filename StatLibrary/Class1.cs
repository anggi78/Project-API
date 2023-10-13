using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Geometry
    {
        private static Geometry instance;

        // Private constructor untuk mencegah pembuatan instansi dari luar kelas
        private Geometry() { }

        // Metode public untuk mendapatkan instansi tunggal dari kelas
        public static Geometry Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Geometry();
                }
                return instance;
            }
        }

        public double CalculateTriangularPyramidVolume(double baseLength, double height)
        {
            return (baseLength * baseLength * height) / 3;
        }

        public double CalculateSquarePyramidVolume(double baseLength, double height)
        {
            return (baseLength * baseLength * height) / 3;
        }

        public double CalculateCuboidVolume(double length, double width, double height)
        {
            return length * width * height;
        }

        public double CalculateCubeVolume(double side)
        {
            return Math.Pow(side, 3);
        }

        public double CalculateCylinderVolume(double radius, double height)
        {
            return Math.PI * Math.Pow(radius, 2) * height;
        }
    }
}


namespace Library
{
    public class PhysicsCalculator
    {
        private static PhysicsCalculator instance;

        // Private constructor untuk mencegah pembuatan instansi dari luar kelas
        private PhysicsCalculator() { }

        // Metode public untuk mendapatkan instansi tunggal dari kelas
        public static PhysicsCalculator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhysicsCalculator();
                }
                return instance;
            }
        }

        public double CalculateVelocity(double distance, double time)
        {
            return distance / time;
        }

        public double CalculateElectricCurrent(double voltage, double resistance)
        {
            return voltage / resistance;
        }

        public double CalculateDistance(double velocity, double time)
        {
            return velocity * time;
        }

        public double CalculatePressure(double force, double area)
        {
            return force / area;
        }

        public double CalculateMomentumChange(double initialMomentum, double finalMomentum)
        {
            return finalMomentum - initialMomentum;
        }
    }
}


namespace Library
{
    public interface IStatCalculator
    {
        double Calculate(List<double> data);
    }

    public class RangeCalculator : IStatCalculator
    {
        public double Calculate(List<double> data)
        {
            // Hitung range
            double min = data.Min();
            double max = data.Max();
            double range = max - min;
            return range;
        }
    }

    public class QuartileCalculator : IStatCalculator
    {
        public double Calculate(List<double> data)
        {
            // Hitung kuartil
            List<double> sortedData = data.OrderBy(x => x).ToList();

            int n = sortedData.Count;
            double q1, q2, q3;

            // Hitung posisi kuartil
            double posQ1 = (n + 1) * 0.25;
            double posQ2 = (n + 1) * 0.5;
            double posQ3 = (n + 1) * 0.75;

            // Periksa apakah posisi kuartil adalah bilangan bulat
            if (IsInteger(posQ1))
            {
                q1 = sortedData[(int)posQ1 - 1];
            }
            else
            {
                int lowerIndex = (int)Math.Floor(posQ1) - 1;
                int upperIndex = (int)Math.Ceiling(posQ1) - 1;
                q1 = Interpolate(sortedData[lowerIndex], sortedData[upperIndex], posQ1 % 1);
            }

            if (IsInteger(posQ2))
            {
                q2 = sortedData[(int)posQ2 - 1];
            }
            else
            {
                int lowerIndex = (int)Math.Floor(posQ2) - 1;
                int upperIndex = (int)Math.Ceiling(posQ2) - 1;
                q2 = Interpolate(sortedData[lowerIndex], sortedData[upperIndex], posQ2 % 1);
            }

            if (IsInteger(posQ3))
            {
                q3 = sortedData[(int)posQ3 - 1];
            }
            else
            {
                int lowerIndex = (int)Math.Floor(posQ3) - 1;
                int upperIndex = (int)Math.Ceiling(posQ3) - 1;
                q3 = Interpolate(sortedData[lowerIndex], sortedData[upperIndex], posQ3 % 1);
            }

            return q2;
        }

        private bool IsInteger(double number)
        {
            return number % 1 == 0;
        }

        private double Interpolate(double lowerValue, double upperValue, double fraction)
        {
            return lowerValue + (upperValue - lowerValue) * fraction;
        }
    }

    public class QuartileRangeCalculator : IStatCalculator
    {
        public double Calculate(List<double> data)
        {
            // Hitung rentang kuartil
            double[] quartiles = CalculateQuartiles(data);
            double quartileRange = quartiles[2] - quartiles[0];
            return quartileRange;
        }

        private double[] CalculateQuartiles(List<double> data)
        {
            double[] quartiles = new double[3];
            List<double> sortedData = data.OrderBy(x => x).ToList();

            // Kuartil pertama (Q1)
            int n = sortedData.Count;
            int indexQ1 = (int)(n * 0.25);
            quartiles[0] = sortedData[indexQ1];

            // Kuartil kedua (Q2)
            int indexQ2 = (int)(n * 0.5);
            quartiles[1] = sortedData[indexQ2];

            // Kuartil ketiga (Q3)
            int indexQ3 = (int)(n * 0.75);
            quartiles[2] = sortedData[indexQ3];

            return quartiles;
        }
    }

    public class SkewnessCalculator : IStatCalculator
    {
        public double Calculate(List<double> data)
        {
            // Hitung kemiringan
            double mean = data.Average();
            double sumSquaredDeviations = data.Sum(x => Math.Pow(x - mean, 2));
            double variance = sumSquaredDeviations / data.Count;
            double standardDeviation = Math.Sqrt(variance);

            double sumCubedDeviations = data.Sum(x => Math.Pow(x - mean, 3));
            double skewness = sumCubedDeviations / (data.Count * Math.Pow(standardDeviation, 3));
            return skewness;
        }
    }

    public class KurtosisCalculator : IStatCalculator
    {
        public double Calculate(List<double> data)
        {
            // Hitung kurtosis
            int n = data.Count;
            double mean = data.Average();
            double variance = data.Sum(x => Math.Pow(x - mean, 2)) / n;
            double sumFourthMoment = data.Sum(x => Math.Pow(x - mean, 4));
            double kurtosis = (sumFourthMoment / n) / Math.Pow(variance, 2) - 3;
            return kurtosis;
        }
    }

    public class StatCalculatorFactory
    {
        private static StatCalculatorFactory instance;

        private StatCalculatorFactory() { }

        public static StatCalculatorFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StatCalculatorFactory();
                }
                return instance;
            }
        }

        public IStatCalculator GetCalculator(string calculatorType)
        {
            switch (calculatorType)
            {
                case "Range":
                    return new RangeCalculator();
                case "Quartile":
                    return new QuartileCalculator();
                case "QuartileRange":
                    return new QuartileRangeCalculator();
                case "Skewness":
                    return new SkewnessCalculator();
                case "Kurtosis":
                    return new KurtosisCalculator();
                default:
                    throw new ArgumentException("Invalid calculator type");
            }
        }
    }
}

namespace Library
{
    public class LibraryAPI
    {
        private static LibraryAPI instance;
        private static readonly object lockObject = new object();

        private LibraryAPI()
        {
            // Private constructor untuk mencegah pembuatan instansi dari luar kelas
        }

        public static LibraryAPI Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new LibraryAPI();
                        }
                    }
                }
                return instance;
            }
        }

        public Geometry Geometry { get; } = Geometry.Instance;
        public PhysicsCalculator PhysicsCalculator { get; } = PhysicsCalculator.Instance;
        public StatCalculatorFactory StatCalculatorFactory { get; } = StatCalculatorFactory.Instance;
    }
}


