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
        public static double OrbitalVelocity(Satellite satellite, PlanetVariables planet)
        {
            double r = (planet.Radius + satellite.Altitude) * 1000;
            double velocityMs = Math.Sqrt(planet.GravitationalParameter / r);
            return velocityMs;
            // Формула: v = √(μ / r)
            // где r = planet.Radius + satellite.Altitude
        }
        public static double AngularVelocity(Satellite satellite)
        {
            return 360.0 / satellite.OrbitalPeriodviaHeight;
        }
    }
}