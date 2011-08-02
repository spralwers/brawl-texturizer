using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using SSBBTextures.Properties;

namespace SSBBTextures {

	public class Texture {
		public Outfit Outfit { get; set; }
		public String Name { get; set; }
		public Image Image { get; set; }
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
			string path=Path.Combine(destFolder, string.Concat(name, ".pcs"));
			FileStream file = new FileStream(path, FileMode.Create);
			file.Write(PcsTextureData, 0, PcsTextureData.Length);
			file.Close();

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

			if (Image != null) {
				byte[] imgData = Util.GetBytesFromImage(Image);
				writer.Write(true);
				writer.Write(imgData.Length);
				writer.Write(imgData);
			} else {
				writer.Write(false);
			}

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
		}

		internal static Texture LoadFrom(Outfit parentOutfit, BinaryReader reader) {
			Texture texture = new Texture();

			texture.Outfit = parentOutfit;
			texture.Name = reader.ReadString();
			texture.Description = reader.ReadString();

			bool contentsFlag;
			contentsFlag = reader.ReadBoolean();
			if (contentsFlag) {
				texture.Image = Util.CreateImageFromReader(reader);
			}
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

			return texture;
		}
	}
}
