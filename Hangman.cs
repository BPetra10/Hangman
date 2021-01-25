using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akasztofa
{
	class Program
	{
		static void akasztofa()
		{
			// Én a felhasználó által megadott szavakkal töltöm fel a listát.
			List<string> szavak = new List<string>();
			string beszo = "";
			do
			{
				Console.WriteLine("Adj meg egy szót! Ha több szót nem szeretnél, nyomj entert!");
				beszo = Console.ReadLine();
				beszo = beszo.ToLower();
				while (szavak.Contains(beszo))
				{
					if (szavak.Contains(beszo))
					{
						Console.WriteLine("Adj meg egy MÁSIK szót, ezt már írtad!");
						Console.WriteLine("Ha több szót nem szeretnél, nyomj entert!");
						beszo = Console.ReadLine();
						beszo = beszo.ToLower();
					}
				}
				szavak.Add(beszo);
			}
			while (beszo != "");

			//Ha a felhasználó egyből entert nyom, már első lehetőségre, akkor majd az "alap" listámból kap egy szót.
			if (szavak[0] =="")
			{
				Console.WriteLine("Mivel nem adtál meg egy szót sem, én töltöttem fel a listát!");
				szavak = new List<string> { "alma", "piros", "barack", "obama", "televízió", "holokauszt", "lagzi"};
			}

			Random rnd = new Random();
			int szam = rnd.Next(1, szavak.Count);
			string szo = szavak[szam-1];
			string allas = "";
			string ideig = "";

			for (int i = 0; i < szo.Length; i++)
			{
				allas += "_";
			}

			bool Jatek = true;
			Console.WriteLine(allas);
			int szamlalo = 0;

			List<char> beirt = new List<char>();

			while (Jatek)
			{

				Console.WriteLine("Adj meg egy betűt!");
				char megadottbetu = Console.ReadKey().KeyChar;
				char kisbetu = char.ToLower(megadottbetu); 
				//azért alakítom kisbetűssé mert a szavak amiket beírtam, csak kisbetűket tartalmaznak.
				//ne vegye külön pl.: a és a A páros, és így tovább. Mivel mindkettű ugyanaz a betű, csak kis és nagybetűs formában.
				Console.WriteLine();
					do
					{
						//A már beírt betűket ne lehessen újra megtippelni:
						if (beirt.Contains(kisbetu))
						{
							Console.WriteLine("Adj meg egy másik betűt, ezt már írtad!");
							megadottbetu = Console.ReadKey().KeyChar;
							kisbetu = char.ToLower(megadottbetu);
							Console.WriteLine();
						}
					} while (beirt.Contains(kisbetu));

				beirt.Add(kisbetu);

				for (int i = 0; i < szo.Length; i++)
				{
					if (kisbetu == szo[i])
					{
						ideig += szo[i];
					}
					else 
					{
						ideig += allas[i];
					}
				}

				//A videóban leírt folyamatos növelés helyett én csak akkor növelek, ha rossz betűt adott a felhasználó.
				//Az akasztófánál is csak akkor rajzoljuk az emberkét, ha rossz tipp volt :)
				if (!szo.Contains(kisbetu))
				{
					szamlalo++;
				}

				allas = ideig;
				ideig = "";

				if (allas.Contains("_"))
				{
					Console.WriteLine(allas + " \n Rossz betűk száma: " + szamlalo);
					if (szamlalo >= szo.Length + 5)
					{
						Console.WriteLine("Vesztettél! A szó: " + szo + " volt.");
						Jatek = false;
					}

				}
				else
				{
					Console.WriteLine("Nyertél! A szó: " + szo + " volt.");
					Jatek = false;
				}
				
			}
		}

		static void Main(string[] args)
		{
			akasztofa();
			Console.ReadKey();
		}
	}
}
