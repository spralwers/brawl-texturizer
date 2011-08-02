using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Resources;
using System.Drawing;
using SSBBTextures.Properties;

using System.Windows.Forms;
using System.IO;

namespace SSBBTextures {

	[Serializable]
	public class Skinning {

		[XmlAttribute("Characters")]
		private List<Character> characters;
		private string signature = "com.superjmn.app.brawltexturizer";

		private Dictionary<string, Character> charsDict = new Dictionary<string, Character>(StringComparer.InvariantCultureIgnoreCase);

		public List<Character> Characters {
			get {
				return characters;
			}
			set {
				characters = value;
			}
		}

		public Skinning() {
		}

		public void Clear() {
			foreach (Character c in Characters) {
				foreach (Outfit o in c.Outfits) {
					o.AssociatedTexture = null;
				}
			}
		}

		public Character GetCharacter(string code) {
			if (charsDict.ContainsKey(code)) {
				return charsDict[code];
			} else {
				return null;
			}
		}

		public void LoadCharacters() {

			ResourceManager namesManager = new ResourceManager("SSBBTextures.CharNames", typeof(CharNames).Assembly);
			ResourceManager imagesManager = new ResourceManager("SSBBTextures.CharImages", typeof(CharImages).Assembly);

			Characters = new List<Character>();

			string[] charCodes = {
								 "Captain",
								 "Dedede", 
								 "Diddy",
								 "Donkey",
								 "Falco",
								 "Fox",
								 "GameWatch",
								 "Ganon",
								 "GKoopa",
								 "Ike",
								 "Kirby",
								 "Koopa",
								 "Link",
								 "Lucario",
								 "Lucas",
								 "Luigi",
								 "Mario",
								 "Marth",
								 "MetaKnight",
								 "Ness",
								 "Peach",
								 "Pikachu",
								 "Pikmin",
								 "Pit",
								 "PokeFushigisou",
								 "PokeLizardon",
								 "PokeZenigame",
								 "PokeTrainer",
								 "Popo",
								 "Purin",
								 "Robot",
								 "Samus",
								 "Sheik",
								 "Snake",
								 "Sonic",
								 "SZeroSuit",
								 "ToonLink",
								 "Wario",
								 "WarioMan",
								 "Wolf",
								 "Yoshi",
								 "Zelda"
							 };
			
			string[] needsPac = { "PokeTrainer", "Wario", "Samus", "SZeroSuit", "Zelda", "Sheik", "Koopa", "GameWatch", "GKoopa", "WarioMan" };
			

			foreach (string str in charCodes) {
				Character c = new Character();
				c.Name = namesManager.GetString(str);
				c.Code = str;
				c.NeedsPac = needsPac.Contains(str);

				try {
					c.Image = (Bitmap)imagesManager.GetObject(str);
				} catch {

				}
				c.Outfits = LoadOutfits(c);


				// Temporalmente cargamos un icono 
				if (c.Outfits != null)
					foreach (Outfit o in c.Outfits) {
						if (o.Available)
							o.Image = Resources.Outfit;
						else {
							o.Image = Resources.NotAvailable;
						}
					}
				Characters.Add(c);
				charsDict.Add(str, c);
			}
		}

		private static Outfit[] LoadOutfits(Character chr) {
			Outfit[] outfits = null;
			Outfit o;
			switch (chr.Code) {

				case "Captain":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					outfits[5] = o;

					break;
				case "Dedede":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.DededeBlueWhite;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.DededeGameBoy;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					outfits[6] = o;

					break;

				case "Diddy":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					outfits[6] = o;

					break;

				case "Donkey":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[5] = o;

					break;

				case "Falco":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Orange;
					outfits[5] = o;

					break;

				case "Fox":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[5] = o;

					break;

				case "GameWatch":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Khaki;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.LightBlue;
					outfits[5] = o;

					break;

				case "Ganon":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Brown;
					outfits[5] = o;

					break;

				case "GKoopa":
					outfits = new Outfit[1];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;
					break;

				case "Ike":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.IkeGreen2;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					outfits[5] = o;

					break;

				case "Kirby":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.KirbyGameBoy;
					outfits[5] = o;

					break;

				case "Koopa":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Brown;
					outfits[6] = o;

					break;

				case "Link":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Dark;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Beige;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					outfits[6] = o;

					break;

				case "Lucario":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[5] = o;

					break;

				case "Lucas":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Orange;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					outfits[5] = o;

					break;

				case "Luigi":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.Available = false;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.LuigiFieryLuigi;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Orange;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.LuigiWaluigi;
					outfits[6] = o;

					break;

				case "Mario":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.MarioWario;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.MarioFiery;
					outfits[6] = o;

					break;

				case "Marth":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[5] = o;

					break;

				case "MetaKnight":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					outfits[5] = o;

					break;

				case "Ness":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.NessBumbleBee;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[6] = o;

					break;

				case "Peach":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.PeachDaisy;
					outfits[5] = o;

					break;

				case "Pikachu":
					outfits = new Outfit[4];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.PikachuCap;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.PikachuBandana;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.PikachuGoggles;
					outfits[3] = o;

					break;

				case "Pikmin":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Dirty;
					outfits[5] = o;

					break;

				case "Pit":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[5] = o;

					break;

				case "PokeFushigisou":
					outfits = new Outfit[5];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[4] = o;

					break;

				case "PokeLizardon":
					outfits = new Outfit[5];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[4] = o;

					break;

				case "PokeZenigame":
					outfits = new Outfit[5];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[4] = o;

					break;

				case "PokeTrainer":
					outfits = new Outfit[5];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[4] = o;

					break;

				case "Popo":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[5] = o;

					break;

				case "Purin":
					outfits = new Outfit[5];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.JigglyFlower;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.JigglySleepingHat;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.JiggleTrainerCap;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.JigglyCap;
					outfits[4] = o;

					break;

				case "Samus":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.SamusFusion;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[5] = o;

					break;

				case "Robot":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Gray;
					outfits[6] = o;

					break;

				case "Sheik":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Ocarina;
					outfits[5] = o;

					break;

				case "Snake":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.SnakeRedBlack;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.SnakeLeopard;
					outfits[5] = o;

					break;

				case "Sonic":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[5] = o;

					break;

				case "SZeroSuit":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.SamusFusion;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[5] = o;

					break;

				case "ToonLink":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.ToonLinkNES;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Dark;
					outfits[6] = o;
					break;

				case "Wolf":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					outfits[5] = o;

					break;

				case "Yoshi":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.LightBlue;
					outfits[6] = o;

					break;

				case "Zelda":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Ocarina;
					outfits[5] = o;

					break;

				case "Wario":

					outfits = new Outfit[12];

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Original, OutfitNames.WarioWarioWare);
					outfits[0] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Red, OutfitNames.WarioWarioWare);
					outfits[1] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Green, OutfitNames.WarioWarioWare);
					outfits[2] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Blue, OutfitNames.WarioWarioWare);
					outfits[3] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.WarioRedBlack, OutfitNames.WarioWarioWare);
					outfits[4] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.WarioOrangeBlue, OutfitNames.WarioWarioWare);
					outfits[5] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Original, OutfitNames.WarioGeneral);
					outfits[6] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Red, OutfitNames.WarioGeneral);
					outfits[7] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Green, OutfitNames.WarioGeneral);
					outfits[8] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Blue, OutfitNames.WarioGeneral);
					outfits[9] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.WarioWarioLand2, OutfitNames.WarioGeneral);
					outfits[10] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.WarioWarioLand3, OutfitNames.WarioGeneral);
					outfits[11] = o;

					break;

				case "WarioMan":
					outfits = new Outfit[1];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					break;
			}


			foreach (Outfit outfit in outfits) {
				outfit.Character = chr;
			}

			return outfits;
		}





		internal void LoadFrom(BinaryReader reader, ProgressStartHander onOpenProgressStart, ProgressChangedHandler onOpenProgressChanged, ProgressEndHandler onOpenProgressEnd) {
			
			if (onOpenProgressStart!=null)
				onOpenProgressStart(characters.Count);
			
			int t = 0;

			string s = reader.ReadString();
			if (!s.Equals(signature))
				throw new ApplicationException(Resources.ErrorNotValidSsbbtFile); 

			foreach (Character c in characters) {
				foreach (Outfit o in c.Outfits) {
					if (onOpenProgressChanged != null)
						onOpenProgressChanged(o, t);
					bool associated = reader.ReadBoolean();
					if (associated) 
						o.AssociatedTexture=Texture.LoadFrom(o, reader);
				}
				t++;
			}
			if (onOpenProgressEnd!=null)
				onOpenProgressEnd();
		}
			 

		internal void SaveTo(BinaryWriter writer, ProgressStartHander onSaveProgressStart, ProgressChangedHandler onSaveProgressChanged, ProgressEndHandler onSaveProgressEnd) {

			onSaveProgressStart(characters.Count);

			//Firma del archivo
			writer.Write(signature);

			int t = 0;
			foreach (Character c in characters) {
				foreach (Outfit o in c.Outfits) {
					if (o.AssociatedTexture != null) {
						onSaveProgressChanged(o, t);
						writer.Write(true);
						o.AssociatedTexture.SaveTo(writer);
					} else {
						writer.Write(false);
					}
				}
				t++;
			}
			onSaveProgressEnd();
		}
	}
}
