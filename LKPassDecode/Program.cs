using System;

namespace LKPassDecode {
	class Program {
		static int Main(string[] args) {
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			// US, Django & Sabata
			//string password = "?UEKpeitSGuHtbC0IAbmY?SvFGPNUoRYAA3HJeCv";
			// US, Aaron & Lucian
			string password = "xTDyGunFea8I4Sa7bE4rHenROavcPBcnfCv2GOnB";
			// JP, Grand Master
			//string password = "げわいはほちそぜぬゆめむひりねきるせづたとぐかきまりごをけだふきげそれいあぐぜき";
			BoktaiDSPassword data;

			Console.WriteLine("Loading password " + password + "...");
			bool loaded = BoktaiDSPassword.Load(password, out data);

			if (!loaded) {
				Console.WriteLine("Could not load password.");
			} else {
				// Data validity.
				Console.WriteLine("Password data is " + (data.Validate() ? "valid" : "invalid") + ".");
				Console.WriteLine();

				// Region.
				Console.WriteLine("Region:\t\t\t" + data.Region);

				// Earned titles.
				if (data.EarnedTitles == 0) {
					Console.WriteLine("Titles:\t\t\tNone");
				} else {
					bool first = true;
					foreach (BoktaiDSPassword.Titles title in Enum.GetValues(typeof(BoktaiDSPassword.Titles))) {
						if (!data.EarnedTitles.HasFlag(title)) {
							continue;
						}

						if (first) {
							Console.Write("Titles:\t\t\t");
						} else {
							Console.Write("\t\t\t");
						}
						first = false;

						Console.WriteLine(title);
					}
				}

				// Difficulty.
				Console.WriteLine("Difficulty:\t\t" + data.Difficulty);

				// Hours played.
				Console.WriteLine("Hours played:\t\t" + data.HoursPlayed + " ~ " + (data.HoursPlayed + 1));

				// Soll acquired.
				Console.WriteLine("Soll acquired:\t\t" + data.SollAcquired + " ~ " + (data.SollAcquired + 4095));

				// Favorite sword.
				Console.WriteLine("Favorite sword:\t\t" + data.FavoriteSword);

				// Favorite gun.
				Console.WriteLine("Favorite gun:\t\t" + data.FavoriteGun);

				// Favorite Terrennial.
				Console.WriteLine("Favorite Terrennial:\t" + data.FavoriteTerrennial);

				// Favorite climate.
				Console.WriteLine("Favorite climate:\t" + data.FavoriteClimate);

				// Sabata name.
				Console.WriteLine("Sabata name:\t\t\"" + data.SabataName + "\"");

				// Django name.
				Console.WriteLine("Django name:\t\t\"" + data.DjangoName + "\"");
			}

			Console.WriteLine();
			Console.WriteLine("Done.");
#if DEBUG
			Console.ReadKey();
#endif
			return loaded ? 0 : 1;
		}
	}
}
