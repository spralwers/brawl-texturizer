using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Resources;
using System.Drawing;
using Texturizer.Properties;

using System.Windows.Forms;
using System.IO;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.SSBBTypes;
using System.Security;

namespace Texturizer {

	[Serializable]
	public class VisualsManager {

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

		public VisualsManager() {
		}

		public void Clear() {
			foreach (Character c in Characters) {
				foreach (Outfit o in c.Outfits) {
					o.AssociatedTexture = null;
				}
			}
		}

		public void ExportToFileSystem(string root, string common5pac, ProgressStartHander onProgressStart, ProgressChangedHandler onProgressChanged, ProgressEndHandler onProgressEnd) {

			string fighterPath = Path.Combine(root, "fighter");
			string systemPath = Path.Combine(root, "system");

			if (onProgressStart != null)
				onProgressStart(characters.Count);

			int stepProgress = 0;
			foreach (Character c in characters) {

				string charRoot = Path.Combine(fighterPath, c.Code);
				Directory.CreateDirectory(charRoot);
				TextureInfo[] infos = new TextureInfo[c.Outfits.Length];

				int id = 0;
				foreach (Outfit o in c.Outfits) {

					string filenameNoExt = string.Format("Fit{0}{1:00}", c.Code, id);

					if (onProgressChanged != null)
						onProgressChanged(o, stepProgress);

					if (o.Available && o.AssociatedTexture != null) {

						bool written = false;
						do {
							try {
								o.AssociatedTexture.SaveTextureData(filenameNoExt, charRoot);
								written = true;
							} catch (SecurityException) {
								if (MessageBox.Show(string.Format(Resources.ErrorWritingTextureData, o), Resources.ErrorWritingTextureDataTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.No)
									written = true;
							}

						} while (!written);

						// Creamos la información de cada traje en el directorio
						TextureInfo info = new TextureInfo();
						Texture t = o.AssociatedTexture;
						info.Index = id;
						info.Portrait = o.AssociatedTexture.Portrait;
						info.Description = t.Description;
						info.Name = t.Name;

						infos[id] = info;
					} else {
						string pcsPath = Path.Combine(charRoot, string.Concat(filenameNoExt, ".pcs"));
						if (File.Exists(pcsPath))
							File.Delete(pcsPath);
						if (c.NeedsPac) {
							string pacPath = Path.Combine(charRoot, string.Concat(filenameNoExt, ".pac"));
							if (File.Exists(pacPath))
								File.Delete(pacPath);
						}
					}

					id++;
				}

				TextureInfo.WriteToXml(infos, Path.Combine(charRoot, string.Format("{0}.xml", c.Code)));
				stepProgress++;
			}

			string dest = Path.Combine(systemPath, "common5.pac");
			if (common5pac!=null && !common5pac.Equals(string.Empty))
				WritePortraits(common5pac, dest);

			if (onProgressEnd != null)
				onProgressEnd();
		}


		public Character GetCharacter(string code) {
			if (charsDict.ContainsKey(code)) {
				return charsDict[code];
			} else {
				return null;
			}
		}

		static ResourceManager outfitsManager = new ResourceManager("Texturizer.OutfitImages", typeof(OutfitImages).Assembly);

		public void LoadCharacters() {

			ResourceManager namesManager = new ResourceManager("Texturizer.CharNames", typeof(CharNames).Assembly);
			ResourceManager imagesManager = new ResourceManager("Texturizer.CharImages", typeof(CharImages).Assembly);
			

			Characters = new List<Character>();

			CharacterInfo[] charInfos = {
								 new CharacterInfo("Captain", 9), 
								 new CharacterInfo("Dedede", 31), 
								 new CharacterInfo("Diddy", 26),
								 new CharacterInfo("Donkey", 1),
								 new CharacterInfo("Falco", 18),
								 new CharacterInfo("Fox", 6),
								 new CharacterInfo("GameWatch", -1),
								 new CharacterInfo("Ganon", 19),
								 new CharacterInfo("GKoopa", -1),
								 new CharacterInfo("Ike", 33),
								 new CharacterInfo("Kirby", 5),
								 new CharacterInfo("Koopa", 11),
								 new CharacterInfo("Link", 2),
								 new CharacterInfo("Lucario", 32),
								 new CharacterInfo("Lucas", 25),
								 new CharacterInfo("Luigi", 8),
								 new CharacterInfo("Mario", 0),
								 new CharacterInfo("Marth", 16),
								 new CharacterInfo("MetaKnight", 21),
								 new CharacterInfo("Ness", 10),
								 new CharacterInfo("Peach", 12),
								 new CharacterInfo("Pikachu", 7),
								 new CharacterInfo("Pikmin", 24),
								 new CharacterInfo("Pit", 22),
								 new CharacterInfo("PokeFushigisou", 30),
								 new CharacterInfo("PokeLizardon", 28),
								 new CharacterInfo("PokeZenigame", 29),
								 new CharacterInfo("PokeTrainer", 27),
								 new CharacterInfo("Popo", 15),
								 new CharacterInfo("Purin", 36),
								 new CharacterInfo("Robot", 34),
								 new CharacterInfo("Samus", 3),
								 new CharacterInfo("Sheik", 14),
								 new CharacterInfo("Snake", 45),
								 new CharacterInfo("Sonic", 46),
								 new CharacterInfo("SZeroSuit", 23),
								 new CharacterInfo("ToonLink", 40),
								 new CharacterInfo("Wario", 37),
								 new CharacterInfo("WarioMan", -1),
								 new CharacterInfo("Wolf", 43),
								 new CharacterInfo("Yoshi", 4),
								 new CharacterInfo("Zelda", 13)
							 };
			
			string[] needsPac = { "PokeTrainer", "Wario", "Samus", "SZeroSuit", "Zelda", "Sheik", "Koopa", "GameWatch", "GKoopa", "WarioMan" };
			

			foreach (CharacterInfo charInfo in charInfos) {
				Character c = new Character(charInfo.Code, charInfo.ResourceId);
				c.Name = namesManager.GetString(charInfo.Code);
				c.NeedsPac = needsPac.Contains(charInfo.Code);

				try {
					c.Image = (Bitmap)imagesManager.GetObject(charInfo.Code);
				} catch {

				}
				c.Outfits = LoadOutfits(c);

				// Temporalmente cargamos un icono 
				if (c.Outfits != null)
					foreach (Outfit o in c.Outfits) {
						if (o.Available && o.Image==null)
							o.Image = Resources.Outfit;
						else if (!o.Available) {
							o.Image = Resources.NotAvailable;
						}
					}
				Characters.Add(c);
				charsDict.Add(charInfo.Code, c);
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
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 3;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 4;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 1;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					o.ResOrder = 5;
					outfits[5] = o;

					break;
				case "Dedede":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 2;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.DededeBlueWhite;
					o.ResOrder = 4;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.DededeGameBoy;
					o.ResOrder = 5;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					o.ResOrder = 3;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					o.ResOrder = 1;
					outfits[6] = o;

					break;

				case "Diddy":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 5;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					o.ResOrder = 2;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					o.ResOrder = 1;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					o.ResOrder = 3;
					outfits[6] = o;

					break;

				case "Donkey":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 3;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 1;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 5;
					outfits[5] = o;

					break;

				case "Falco":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 3;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 5;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Orange;
					o.ResOrder = 1;
					outfits[5] = o;

					break;

				case "Fox":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 3;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 4;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 1;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 5;
					outfits[5] = o;

					break;

				case "GameWatch":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Khaki;
					o.ResOrder = 2;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 3;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.LightBlue;
					o.ResOrder = 5;
					outfits[5] = o;

					break;

				case "Ganon":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 4;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 3;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 1;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Brown;
					o.ResOrder = 5;
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
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 3;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Beige;
					o.ResOrder = 5;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					o.ResOrder = 1;
					outfits[5] = o;

					break;

				case "Kirby":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 3;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					o.ResOrder = 1;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.KirbyGameBoy;
					o.ResOrder = 5;
					outfits[5] = o;

					break;

				case "Koopa":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 3;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 1;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 4;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Brown;
					o.ResOrder = 5;
					outfits[6] = o;

					break;

				case "Link":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Dark;
					o.ResOrder = 5;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					o.ResOrder = 3;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					o.ResOrder = 4;
					outfits[6] = o;

					break;

				case "Lucario":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 3;
					outfits[5] = o;

					break;

				case "Lucas":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 3;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Orange;
					o.ResOrder = 1;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					o.ResOrder = 5;
					outfits[5] = o;

					break;

				case "Luigi":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.Available = false;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 3;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.LuigiFieryLuigi;
					o.ResOrder = 4;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Orange;
					o.ResOrder = 1;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.LuigiWaluigi;
					o.ResOrder = 5;
					outfits[6] = o;

					break;

				case "Mario":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 5;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.MarioWario;
					o.ResOrder = 3;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 4;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.MarioFiery;
					o.ResOrder = 1;
					outfits[6] = o;

					break;

				case "Marth":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 2;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 5;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 3;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 4;
					outfits[5] = o;

					break;

				case "MetaKnight":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 3;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 4;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 1;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					o.ResOrder = 5;
					outfits[5] = o;

					break;

				case "Ness":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 3;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 4;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.NessBumbleBee;
					o.ResOrder = 2;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 1;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 5;
					outfits[6] = o;

					break;

				case "Peach":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 3;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 5;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.PeachDaisy;
					o.ResOrder = 1;
					outfits[5] = o;

					break;

				case "Pikachu":
					outfits = new Outfit[4];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.PikachuCap;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.PikachuBandana;
					o.ResOrder = 2;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.PikachuGoggles;
					o.ResOrder = 3;
					outfits[3] = o;

					break;

				case "Pikmin":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 5;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 1;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Dirty;
					o.ResOrder = 3;
					outfits[5] = o;

					break;

				case "Pit":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 3;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 4;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					o.ResOrder = 1;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 5;
					outfits[5] = o;

					break;

				case "PokeFushigisou":
										outfits = new Outfit[5];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 2;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 3;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 4;
					outfits[4] = o;

					break;

				case "PokeLizardon":
										outfits = new Outfit[5];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 2;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 3;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 4;
					outfits[4] = o;
					break;

				case "PokeZenigame":
										outfits = new Outfit[5];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 2;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 3;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 4;
					outfits[4] = o;

					break;

				case "PokeTrainer":
					outfits = new Outfit[5];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 2;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 3;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 4;
					outfits[4] = o;

					break;

				case "Popo":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Gray;
					o.ResOrder = 3;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 5;
					outfits[5] = o;

					break;

				case "Purin":
					outfits = new Outfit[5];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.JigglyFlower;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.JigglySleepingHat;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.JiggleTrainerCap;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.JigglyCap;
					o.ResOrder = 3;
					outfits[4] = o;

					break;

				case "Samus":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 5;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.SamusFusion;
					o.ResOrder = 1;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					o.ResOrder = 4;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 3;
					outfits[5] = o;

					break;

				case "Robot":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 5;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 4;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					o.ResOrder = 3;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					o.ResOrder = 2;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Gray;
					o.ResOrder = 1;
					outfits[6] = o;

					break;

				case "Sheik":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 5;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Ocarina;
					o.ResOrder = 3;
					outfits[5] = o;

					break;

				case "Snake":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.SnakeRedBlack;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 3;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.SnakeLeopard;
					o.ResOrder = 5;
					outfits[5] = o;

					break;

				case "Sonic":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 4;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 3;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					o.ResOrder = 2;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 1;
					outfits[5] = o;

					break;

				case "SZeroSuit":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					o.ResOrder = 2;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 5;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.SamusFusion;
					o.ResOrder = 1;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					o.ResOrder = 4;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 3;
					outfits[5] = o;

					break;

				case "ToonLink":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Purple;
					o.ResOrder = 3;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.ToonLinkNES;
					o.ResOrder = 4;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.Dark;
					o.ResOrder = 5;
					outfits[6] = o;
					break;

				case "Wolf":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 3;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 4;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 2;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.White;
					o.ResOrder = 5;
					outfits[5] = o;

					break;

				case "Yoshi":
					outfits = new Outfit[7];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.NotUsed;
					o.Available = false;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Yellow;
					o.ResOrder = 3;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Pink;
					o.ResOrder = 4;
					outfits[5] = o;

					o = new Outfit();
					o.Name = OutfitNames.LightBlue;
					o.ResOrder = 5;
					outfits[6] = o;

					break;

				case "Zelda":
					outfits = new Outfit[6];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = OutfitNames.Red;
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = OutfitNames.Green;
					o.ResOrder = 4;
					outfits[2] = o;

					o = new Outfit();
					o.Name = OutfitNames.Blue;
					o.ResOrder = 2;
					outfits[3] = o;

					o = new Outfit();
					o.Name = OutfitNames.Black;
					o.ResOrder = 5;
					outfits[4] = o;

					o = new Outfit();
					o.Name = OutfitNames.Ocarina;
					o.ResOrder = 3;
					outfits[5] = o;

					break;

				case "Wario":

					outfits = new Outfit[12];

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Original, OutfitNames.WarioWarioWare);
					o.ResOrder = 0;
					outfits[0] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Red, OutfitNames.WarioWarioWare);
					o.ResOrder = 1;
					outfits[1] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Green, OutfitNames.WarioWarioWare);
					o.ResOrder = 3;
					outfits[2] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Blue, OutfitNames.WarioWarioWare);
					o.ResOrder = 5;
					outfits[3] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.WarioRedBlack, OutfitNames.WarioWarioWare);
					o.ResOrder = 4;
					outfits[4] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.WarioOrangeBlue, OutfitNames.WarioWarioWare);
					o.ResOrder = 2;
					outfits[5] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Original, OutfitNames.WarioGeneral);
					o.ResOrder = 6;
					outfits[6] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Red, OutfitNames.WarioGeneral);
					o.ResOrder = 7;
					outfits[7] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Green, OutfitNames.WarioGeneral);
					o.ResOrder = 9;
					outfits[8] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Blue, OutfitNames.WarioGeneral);
					o.ResOrder = 8;
					outfits[9] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.Dirty, OutfitNames.WarioGeneral);
					o.ResOrder = 10;
					outfits[10] = o;

					o = new Outfit();
					o.Name = string.Format("{0} ({1})", OutfitNames.WarioSailor, OutfitNames.WarioGeneral);
					o.ResOrder = 11;
					outfits[11] = o;

					break;

				case "WarioMan":
					outfits = new Outfit[1];

					o = new Outfit();
					o.Name = OutfitNames.Original;
					outfits[0] = o;

					break;
			}


			int t = 0;
			foreach (Outfit outfit in outfits) {
				outfit.Character = chr;
				outfit.Id = t;
				outfit.Image = (Image)outfitsManager.GetObject(string.Format("{0}{1}", outfit.Character.Code, outfit.ResOrder));
				if (outfit.Available)
					t++;
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

		private struct CharacterInfo {
			public string Code { get; set; }
			public int ResourceId { get; set; }
			public CharacterInfo(string code, int resId)
				: this() {
				Code = code;
				ResourceId = resId;
			}
		}

		public void WritePortraits(string sourcePath, string destPath) {

			Directory.CreateDirectory(Path.GetDirectoryName(destPath));
			ResourceNode resNode = NodeFactory.FromFile(null, sourcePath);

			foreach (Character c in characters) {

				if (c.ResourceId != -1) {
					
					foreach (Outfit o in c.Outfits) {
						if (o.AssociatedTexture != null && o.AssociatedTexture.Portrait != null) {
							TEX0Node texNode = (TEX0Node)resNode.FindChild(string.Format("sc_selcharacter_en/char_bust_tex_lz77/Type1[{0}]/Textures(NW4R)/MenSelchrFaceB.{1:000}", c.ResourceId, c.ResourceId * 10 + o.ResOrder + 1), false);
							texNode.Replace((Bitmap)o.AssociatedTexture.Portrait);
						}
					}
				}	
			}

			resNode.Merge(false);
			resNode.Export(destPath);
		}

		public ImportInfo ImportFromFileSystem(string path, ProgressStartHander onProgressStart, ProgressChangedHandler onProgressChange, ProgressEndHandler onProgressEnd) {

			ImportInfo importInfo = new ImportInfo();

			//Process fighter folder
			string fighterPath = Path.Combine(path, "fighter");
			DirectoryInfo dirInfo = new DirectoryInfo(fighterPath);
			DirectoryInfo[] directories = dirInfo.GetDirectories();

			if (onProgressStart != null)
				onProgressStart(directories.Length);

			int dirStep = 0;
			foreach (DirectoryInfo info in directories) {
				// Si devuelve false es que ha tenido que recrear los trajes de cero
				if (!ImportFighterDirectory(info, dirStep, onProgressChange)) {
					importInfo.Recreated++;
				}
				dirStep++;
			}
			importInfo.Total=dirStep;

			if (onProgressEnd != null)
				onProgressEnd();

			return importInfo;
		}

		private bool ImportFighterDirectory(DirectoryInfo info, int dirStep, ProgressChangedHandler onProgressChange) {

			Character character = GetCharacter(info.Name);
			bool has_metadata = true;

			if (character != null) {

				if (onProgressChange != null)
					onProgressChange(character, dirStep);

				string infoPath = Path.Combine(info.FullName, string.Format("{0}.xml", info.Name));

				// Si existe el archivo de metadatos
				if (File.Exists(infoPath)) {
					TextureInfo[] outfitInfos = TextureInfo.ReadFromXml(infoPath);
					Texture[] textures = TextureInfo.ToTextureArray(character, info.FullName, outfitInfos);

					int t = 0;
					foreach (Outfit outfit in character.Outfits) {
						if (t < textures.Length) {
							if (textures[t] != null)
								textures[t].Outfit = outfit;
							outfit.AssociatedTexture = textures[t];
						}
						t++;
					}
				} else {
					RecreateCharacterOutfitsFromScratch(info.FullName, character);
					has_metadata = false;
				}
			}

			return has_metadata;
		}

		private void RecreateCharacterOutfitsFromScratch(string charRoot, Character character) {
			int t = 0;
			int oi = 1;	// Outfit ID (for naming)
			foreach (Outfit o in character.Outfits) {
				// Solamente si necesitamos cargarlo
				if (o.Available) {
					Texture texture = new Texture(o);
					texture.PcsTextureData=Texture.ReadPcsData(charRoot, character, t);
					if (texture.PcsTextureData != null) {
						texture.PacTextureData = Texture.ReadPacData(charRoot, character, t);
						texture.Name = string.Format(Resources.DefaultOutfitName, oi);
						o.AssociatedTexture = texture;
					}
					oi++;
				}
				t++;
			} // Fin foreach

			
		}

		
		public void ReadPortraits(string common5path) {
			ResourceNode resNode = NodeFactory.FromFile(null, common5path);

			foreach (Character c in characters) {

				if (c.ResourceId != -1) {

					foreach (Outfit o in c.Outfits) {
						if (o.Available && o.AssociatedTexture!=null) {
							TEX0Node texNode = (TEX0Node)resNode.FindChild(string.Format("sc_selcharacter_en/char_bust_tex_lz77/Type1[{0}]/Textures(NW4R)/MenSelchrFaceB.{1:000}", c.ResourceId, c.ResourceId * 10 + o.ResOrder + 1), false);
							o.AssociatedTexture.Portrait = texNode.GetImage(0);
						}
					}
				}
			}
		}

		public struct ImportInfo {
			public int Total { get; set; }
			public int Recreated { get; set; }
		}

	}

}
