using PublicVariables;

namespace SatelliteMath
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
}