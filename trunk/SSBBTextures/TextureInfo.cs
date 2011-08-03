using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace Texturizer {
	public class TextureInfo {
		[XmlAttribute("Name")]
		public string Name { get; set; }
		[XmlAttribute("Description")]
		public string Description { get; set; }
		[XmlAttribute("Index")]
		public int Index { get; set; }

		[XmlIgnore]
		public Image Portrait { get; set; }

		// Set PictureByteArray Property 
		// to be an attribute of the Picture node 
		[XmlAttribute("Portrait")]
		public byte[] PictureByteArray {
			get {
				if (Portrait != null) {
					//get a TypeConverter object for converting Bitmap to bytes
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
					return (byte[])converter.ConvertTo(Portrait, typeof(byte[]));
				}
				else
					return null;
			}
			set {
				if (value!=null)
					Portrait = new Bitmap(new MemoryStream(value));
			}
		}

		internal static void WriteToXml(TextureInfo[] infos, string path) {
			XmlSerializer serializer = new XmlSerializer(typeof(TextureInfo[]));
			StreamWriter writer = new StreamWriter(path);
			serializer.Serialize(writer, infos);
			writer.Close();
		}

		internal static TextureInfo[] ReadFromXml(string path) {
			XmlSerializer serializer = new XmlSerializer(typeof(List<TextureInfo>));
			StreamReader reader = new StreamReader(path);
			List<TextureInfo> lista = (List<TextureInfo>)serializer.Deserialize(reader);
			reader.Close();
			return lista.ToArray();
		}

		internal static Texture[] ToTextureArray(Character character, string path, TextureInfo[] infos) {
			Texture[] textures = new Texture[infos.Length];
			int t = 0;
			foreach (TextureInfo info in infos) {
				if (info != null) {

					Texture texture = null;
					try {
						
						byte[] pcsData = Util.ReadBytesFromFile(Path.Combine(path, string.Format("Fit{0}{1:00}.pcs", character.Code, info.Index)));
						byte[] pacData = Util.ReadBytesFromFile(Path.Combine(path, string.Format("Fit{0}{1:00}.pac", character.Code, info.Index)));
						texture=new Texture(character.Outfits[t]);

						texture.Name = info.Name;
						texture.Portrait = info.Portrait;
						texture.Description = info.Description;
						texture.PcsTextureData = pcsData;
						texture.PacTextureData = pacData;
					} catch {
					}

					textures[t] = texture;
				}
				t++;
			}
			return textures;
		}
	}
}
