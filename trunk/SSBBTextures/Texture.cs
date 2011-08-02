using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using Texturizer.Properties;

namespace Texturizer {

	public class Texture {
		public Texture(Outfit outfit) {
			this.Outfit = outfit;
			this.Name = string.Empty;
			this.Description = string.Empty;
		}
		public Outfit Outfit { get; set; }

		public String Name { get; set; }


		public Image Portrait { get; set; }


		public string Description { get; set; }


		public byte[] PcsTextureData {
			get {
				return MassiveDataManager.GetPcsData(this.Outfit);
			}
			set {
				MassiveDataManager.SetPcsData(this.Outfit, value);
			}
		}
		public byte[] PacTextureData {
			get {
				return MassiveDataManager.GetPacData(this.Outfit);
			}
			set {
				MassiveDataManager.SetPacData(this.Outfit, value);
			}
		}


		private const int MAX_SIZE = 5024000;

		internal void SaveTextureData(string name, string destFolder) {

			string path;
			FileStream file;

			if (PcsTextureData != null) {
				path = Path.Combine(destFolder, string.Concat(name, ".pcs"));
				file = new FileStream(path, FileMode.Create);
				file.Write(PcsTextureData, 0, PcsTextureData.Length);
				file.Close();
			}

			if (PacTextureData != null) {
				path=Path.Combine(destFolder, string.Concat(name, ".pac"));
				file = new FileStream(path, FileMode.Create);
				file.Write(PacTextureData, 0, PacTextureData.Length);
				file.Close();
			}
		}

		internal void SaveTo(BinaryWriter writer) {

			writer.Write(Name);
			writer.Write(Description);

			if (PcsTextureData != null) {
				writer.Write(true);
				writer.Write(PcsTextureData.Length);
				writer.Write(PcsTextureData);
			} else {
				writer.Write(false);
			}

			if (PacTextureData != null) {
				writer.Write(true);
				writer.Write(PacTextureData.Length);
				writer.Write(PacTextureData);
			} else {
				writer.Write(false);
			}

			if (Portrait != null) {
				byte[] data = (Util.GetBytesFromImage(Portrait));
				writer.Write(true);
				writer.Write(data.Length);
				writer.Write(data);
			} else {
				writer.Write(false);
			}
		}

		internal static Texture LoadFrom(Outfit parentOutfit, BinaryReader reader) {
			Texture texture = new Texture(parentOutfit);

			texture.Name = reader.ReadString();
			texture.Description = reader.ReadString();

			bool contentsFlag;

			contentsFlag = reader.ReadBoolean();
			if (contentsFlag) {
				int length = reader.ReadInt32();
				if (length <= MAX_SIZE)
					texture.PcsTextureData = reader.ReadBytes(length);
				else
					throw new ApplicationException(Resources.ErrorLoadingSssbtFile);
			}
			contentsFlag = reader.ReadBoolean();
			if (contentsFlag) {
				int length = reader.ReadInt32();
				if (length <= MAX_SIZE) {
					texture.PacTextureData = reader.ReadBytes(length);
				} else
					throw new ApplicationException(Resources.ErrorLoadingSssbtFile);
			}
			contentsFlag = reader.ReadBoolean();
			if (contentsFlag) {
				texture.Portrait = Util.CreateImageFromReader(reader);
			}
			return texture;
		}
		public static byte[] ReadPcsData(string charRoot, Character character, int id) {
			return Util.ReadBytesFromFile(Path.Combine(charRoot, string.Format("Fit{0}{1:00}.pcs", character.Code, id)));
		}
		
		public static byte[] ReadPacData(string charRoot, Character character, int id) {
			return Util.ReadBytesFromFile(Path.Combine(charRoot, string.Format("Fit{0}{1:00}.pac", character.Code, id)));
		}
		
	}
}
