using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SSBBTextures {
	public class MassiveDataManager {

		static string tempFolder = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "Brawl Texturizer")).FullName;

		private static string GetOutfitFilename(Outfit o) {
			string outfitName = o.Name;
			outfitName = outfitName.Replace("/", "-");
			return Path.Combine(tempFolder, string.Format("{0}-{1}", o.Character.Code, outfitName));
		}

		public static byte[] GetPcsData(Outfit o) {
			return Util.ReadBytesFromFile(string.Concat(GetOutfitFilename(o), ".pcs"));
		}
		public static void SetPcsData(Outfit o, byte[] data) {
			string path = string.Concat(GetOutfitFilename(o), ".pcs");
			Util.WriteBytesToFile(path, data);
		}

		public static byte[] GetPacData(Outfit o) {
			return Util.ReadBytesFromFile(string.Concat(GetOutfitFilename(o), ".pac"));
		}
		public static void SetPacData(Outfit o, byte[] data) {
			string path = string.Concat(GetOutfitFilename(o), ".pac");
			Util.WriteBytesToFile(path, data);
		}

	}
}
