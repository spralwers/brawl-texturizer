using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Texturizer {
	class Util {

		private static int MAX_READ_LENGTH = 2000000;

		public static byte[] ReadBytesFromFile(string path) {
			
			if (File.Exists(path)) {
				FileStream file = new FileStream(path, FileMode.Open);
				byte[] data = new byte[file.Length];
				file.Read(data, 0, (int)file.Length);
				file.Close();
				return data;
			} else {
				return null;
			}
		}

		internal static void WriteBytesToFile(string path, byte[] data) {
			FileStream file = new FileStream(path, FileMode.Create);
			file.Write(data, 0, data.Length);
			file.Close();
		}

		internal static byte[] GetBytesFromImage(Image img) {

			byte[] data = new byte[0];

			if (img != null) {
				MemoryStream m = new MemoryStream();
				img.Save(m, ImageFormat.Png);
				data = m.ToArray();
				m.Close();
			}

			return data;
		}

		internal static Image CreateImageFromReader(BinaryReader reader) {
			
			int imageSize=reader.ReadInt32();
			if (imageSize > MAX_READ_LENGTH)
				throw new InvalidDataException();
			byte[] imgData = reader.ReadBytes(imageSize);
			MemoryStream ms = new MemoryStream(imgData, false);
			return Image.FromStream(ms);
		}

		
	}
}
