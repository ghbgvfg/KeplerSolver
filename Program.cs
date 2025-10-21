using System;
using PublicVariables;

namespace MainNameSpace
{
    class OrbitalCalculator
    {
        public static double OrbitalPeriodviaHeight(Satellite satellite, PlanetVariables planet)
        {
            double semiMajorAxis = (planet.Radius + satellite.Altitude) * 1000; // полуось
            double periodSeconds = 2 * Math.PI * Math.Sqrt(Math.Pow(semiMajorAxis,3) / planet.GravitationalParameter);

            return periodSeconds / 60;
        }
    }

    class Program
    {
        static void Main()
        {
            var earth = PlanetVariables.Earth();
            var iss = new Satellite
            {
                Name = "Terra",
                Altitude = 705,
                Inclination = 98.2,
                CurrentAnomaly = 0
            };

            double period = OrbitalCalculator.OrbitalPeriodviaHeight(iss, earth);
            iss.OrbitalPeriod = period; // можно использовать iss.OrbitalPeriod в других вычислениях
            Console.WriteLine($"Orbital period for {iss.Name}: {period:F2} minutes");
        }
    }
}