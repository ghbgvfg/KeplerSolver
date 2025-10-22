using System;
using PublicVariables;
using SatelliteMath;

namespace GUI
{
	public static class UserGUI
	{
		public static void MainMenu()
		{
			while (true)
			{
				Console.WriteLine($"Welcome to my 'program' KeplerSolver!\nSelect a function by writing its number");
				Console.WriteLine("1.Calculate the orbital period via height");
				Console.WriteLine("0.exit");
				Console.Write("Your choice: ");

				var choice = Console.ReadLine();
				switch (choice)
				{
					case "0":
						return;
					case "1":
						CalculOrbPeriodViaHeightGUI();
						break;
					default:
						Console.WriteLine("{choice} is probably not a command. If u think that u typed command correctly problem might be on program's side");
						break;
				}
			}
		}
		static void CalculOrbPeriodViaHeightGUI()
		{
			PlanetVariables ChosenPlanet = PlanetVariables.Earth(); // значение по умолчанию

			Console.Write("Pls enter your planet(Eath,Mars.Moon): ");
			string InputChosenPlanet = Console.ReadLine() ?? "Earth";
			switch (InputChosenPlanet.ToLower())
			{
				case "earth":
					ChosenPlanet = PlanetVariables.Earth();
					break;
				case "mars":
					ChosenPlanet = PlanetVariables.Mars();
					break;
				case "moon":
					ChosenPlanet = PlanetVariables.Moon();
					break;
				default:
					Console.WriteLine($"Unknown planet: {InputChosenPlanet}. Using Earth as default.");
					ChosenPlanet = PlanetVariables.Earth();
					break;
			}

			Console.Write($"Please enter Name of sattelite: ");
			string UserChosenName = Console.ReadLine() ?? "Unnamed";

			Console.Write("Please enter Altitude: ");
			double UserChosenAltitude = SafeParseDouble(Console.ReadLine());

			Console.Write("Please enter Inclination: ");
			double UserChosenInclination = SafeParseDouble(Console.ReadLine());

			Console.Write("Please enter Current anomaly(if you don't know just type 0): ");
			double UserChosenCurrentAnomaly = SafeParseDouble(Console.ReadLine());

			var iss = new Satellite
			{
				Name = UserChosenName,
				Altitude = UserChosenAltitude,
				Inclination = UserChosenInclination,
				CurrentAnomaly = UserChosenCurrentAnomaly
			};

			double period = SatelliteMath.OrbitalCalculator.OrbitalPeriodviaHeight(iss, ChosenPlanet);
			iss.OrbitalPeriod = period; // можно использовать iss.OrbitalPeriod в других вычислениях
			Console.WriteLine($"Orbital period for {iss.Name}: {period:F2} minutes\n");
		}

		private static double SafeParseDouble(string? input)
		{
			return double.TryParse(input, out double result) ? result : 0;
		}
	}
}