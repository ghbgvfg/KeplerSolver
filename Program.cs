using System;
using PublicVariables;
using SatelliteMath;

namespace MainNameSpace
{
    class AskUser
    {
        public static void AskSatelliteData()
        {

        }
    }

    class Program
    {
        static void Main()
        {
            AskUser.AskSatelliteData();

            var earth = PlanetVariables.Earth();
            var iss = new Satellite
            {
                Name = "Terra",
                Altitude = 705,
                Inclination = 98.2,
                CurrentAnomaly = 0
            };

            double period = SatelliteMath.OrbitalCalculator.OrbitalPeriodviaHeight(iss, earth);
            //iss.OrbitalPeriod = period; // можно использовать iss.OrbitalPeriod в других вычислениях
            Console.WriteLine($"Orbital period for {iss.Name}: {period:F2} minutes");
        }
    }
}