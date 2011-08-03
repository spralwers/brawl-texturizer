using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Texturizer {
	public class MassiveDataManager {

		static string tempFolder = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "Brawl Texturizer")).FullName;

		private static string GetOutfitFilename(Outfit o) {
			string outfitName = o.Id.ToString();
			outfitName = outfitName.Replace("/", "-");
			return Path.Combine(tempFolder, string.Format("{0}-{1}", o.Character.Code, outfitName));
		}

		public static byte[] GetPcsData(Outfit o) {
			return Util.ReadBytesFromFile(string.Concat(GetOutfitFilename(o), ".pcs"));
		}
		public static void SetPcsData(Outfit o, byte[] data) {
			string path = string.Concat(GetOutfitFilename(o), ".pcs");
			if (data != null) {
				Util.WriteBytesToFile(path, data);
			} else {
				File.Delete(path);
			}
		}

		public static byte[] GetPacData(Outfit o) {
			return Util.ReadBytesFromFile(string.Concat(GetOutfitFilename(o), ".pac"));
		}
		public static void SetPacData(Outfit o, byte[] data) {
			string path = string.Concat(GetOutfitFilename(o), ".pac");

			if (data != null) {
				Util.WriteBytesToFile(path, data);
			} else {
				File.Delete(path);
			}
		}


		internal static void SetPortraitData(Outfit outfit, Image img) {
			string path = string.Concat(GetOutfitFilename(outfit), ".png");
			File.Delete(path);
			if (img != null) {
				path = string.Concat(GetOutfitFilename(outfit), ".png");
				img.Save(path, ImageFormat.Png);
			}
		}

		internal static Image GetPortraitData(Outfit outfit) {
			string path = string.Concat(GetOutfitFilename(outfit), ".png");
			if (File.Exists(path))
				return new Bitmap(Image.FromFile(path));
			else
				return null;
		}

		public static void Cleanup() {

			try {
				foreach (string file in Directory.GetFiles(tempFolder)) {
					File.Delete(file);
				}
			} catch {
			}

		}
	}
}
