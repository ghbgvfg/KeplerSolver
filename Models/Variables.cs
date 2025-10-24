namespace PublicVariables
{
	public class PlanetVariables // Класс для переменных планет
	{
		public string Name { get; set; }
		public double Radius { get; set; } // км
		public double Mass { get; set; } // кг
		public double GravitationalParameter { get; set; } // м^3/с^2

		// Конструктор для кастомных планет
		public PlanetVariables(string name, double radius, double mass, double gravParam)
		{
			Name = name;
			Radius = radius;
			Mass = mass;
			GravitationalParameter = gravParam;
		}

		// Методы пресеты
		public static PlanetVariables Earth() => new("Earth", 6371.0, 5.9722e24, 3.986004418e14);
		public static PlanetVariables Mars() => new("Mars", 3389.5, 6.4171e23, 4.282837e13);
		public static PlanetVariables Moon() => new("Moon", 1737.4, 7.342e22, 4.9048695e12);

		public static double CalculateGravParam(double mass)
		{
			const double G = 6.67430e-11; // гравитационная постоянная
			return G * mass;
		}
	}

	public class Satellite // Класс для хранения данных спутника
	{
		public string? Name; // Имя спутника

		public double Altitude; // км над Планетой (будет определять в будущем скорость полета - чем выше тем медленнее, период обращения вокруг земли и зону обзора)

		// Работа с градусами
		public double Inclination; // градусы (0 - 180, где 0° = экваториальная орбита, 90° = полярная орбита, 180° = ретроградная орбита)
		public double CurrentAnomaly; // градусы (0 - 360, показывает где сейчас спутник на своей орбите)

		public double OrbitalPeriod; // минут - время полного витка вокруг Планеты
		public double OrbitalVelocity; // м/с
	}
}