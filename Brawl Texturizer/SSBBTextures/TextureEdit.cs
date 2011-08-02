using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Texturizer.Properties;
using System.Diagnostics;
using BrawlLib.Wii.Compression;
using System.Runtime.InteropServices;
using BrawlLib.Imaging;

namespace Texturizer {
	public partial class TextureEdit : Form {

		Outfit outfit;
		static class ImageLoader {
			static string extString = "*.jpg;*.bmp;*.png;*.tga;*.tiff";
			static string filter = string.Format("{0}|{1}", Resources.SupportedImages, extString);

			public static string Filter { get { return filter; } }

			public static Image LoadImage(string p) {

				Bitmap bmp;
				string extension=Path.GetExtension(p).ToLowerInvariant();

				if (extension.Equals(".tga", StringComparison.OrdinalIgnoreCase)) {
					bmp = TGA.FromFile(p);
				} else {
					bmp = (Bitmap) Image.FromFile(p);
				}

				switch (extension) {
					case ".png": case ".gif":
						break;
					default:
						bmp.MakeTransparent(Color.Magenta);
						break;
				}
				return bmp;
			}
		}

		public bool Modified { get; set; }

		public TextureEdit(Outfit outfit) {
			InitializeComponent();
			this.outfit = outfit;
			Text = outfit.Name;

			if (outfit.AssociatedTexture != null) {
				textName.Text = outfit.AssociatedTexture.Name;
				textDesc.Text = outfit.AssociatedTexture.Description;
				if (outfit.AssociatedTexture.Portrait!=null)
					pictureBox1.Image = outfit.AssociatedTexture.Portrait;
				btnAccept.Text = Resources.Update;
				if (outfit.AssociatedTexture.PcsTextureData!=null)
					textPath.Enabled = false;

				textPath.Text = outfit.AssociatedTexture.Name;
			} else {
				btnAccept.Text = Resources.Associate;
			}
		}

		public string TexturePath {
			get {
				return textPath.Text;
			}
			set {
				textPath.Text = value;
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e) {

			openFileDialog.Filter = string.Format("{0}|*.pcs", Resources.PcsFiles);

			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				textPath.Text = openFileDialog.FileName;
				textName.Text = Path.GetFileNameWithoutExtension(textPath.Text);
				if (chkAutoAsign.Checked) {
					try {
						Image img = LookForCorrespondingImage(textName.Text, Path.GetDirectoryName(textPath.Text));
						if (img != null && img.Size.Equals(new Size(128, 160)))
							pictureBox1.Image = img;
					} catch {
					}
				}
				textPath.Enabled = true;
			}
		}

		private Image LookForCorrespondingImage(string name, string path) {

			Image img=null;
			string[] extensions ={"png", "tga", "gif", "tif", "bmp" };

			bool found = false;
			int t = 0;
			do {
				string currentExt = extensions[t];
				string pathToTry = Path.Combine(path, string.Format("{0}.{1}", name, currentExt));
				if (File.Exists(pathToTry)) {
					img = Image.FromFile(pathToTry);
					found = true;
				}
				t++;
			} while (!found && t < extensions.Length);

			return img;
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			Texture t = new Texture(outfit);
			outfit.AssociatedTexture = t;

			bool modifyPcs = textPath.Enabled && !textPath.Text.Equals(string.Empty);
			bool modifyPortrait = (pictureBox1.Image == null);
			bool bad_input=false;

			errorProvider1.Clear();

			// Si se ha modificado la textura PCS...
			if (modifyPcs) {
				string pcsPath = textPath.Text;
				if (File.Exists(pcsPath)) {
					Character character = outfit.Character;
					t.PcsTextureData = Util.ReadBytesFromFile(pcsPath);
					AssociatePacData(t, pcsPath, character);
				} else {
					errorProvider1.SetError(textPath, Resources.InvalidPcsPath);
					bad_input = true;
				}
			}

			if (!bad_input) {

				if (pictureBox1.Image != null) {
					Image img = pictureBox1.Image;
					t.Portrait = img;
				} else {
					t.Portrait = null;
				}

				// Asignar otras propiedades de la textura
				t.Name = textName.Text;
				t.Description = textDesc.Text;

				DialogResult = DialogResult.OK;
				Close();
			}

			

		}

		// No usado
		private void btnAccept_Click2(object sender, EventArgs e) {

			errorProvider1.Clear();

			Texture texture=outfit.AssociatedTexture;

			if (textPath.Enabled) {
				texture = new Texture(outfit);
				texture.Description = textDesc.Text;
				texture.Name = textDesc.Text;

				string filename = textPath.Text;
				if (File.Exists(filename)) {
					statusLabel.Text = Resources.AssociatingPcsData;
					Application.DoEvents();
					texture.PcsTextureData = Util.ReadBytesFromFile(filename);
					Character ch = outfit.Character;
					statusLabel.Text = Resources.AssociatingPacData;
					Application.DoEvents();
					AssociatePacData(texture, filename, ch);
				} else {
					errorProvider1.SetError(textPath, Resources.InvalidPcsPath);
				}
			}

			if (pictureBox1.Image != null) {
				texture.Portrait = new Bitmap(pictureBox1.Image);
			}  else
				texture.Portrait = null;

			outfit.AssociatedTexture = texture;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void AssociatePacData(Texture t, string filenamePcs, Character ch) {
			string filenameNoExt = Path.GetFileNameWithoutExtension(filenamePcs);
			string filenamePac = string.Concat(filenameNoExt, ".pac");

			// Si el archivo PAC existe, añade sus datos
			if (File.Exists(filenamePac)) {
				statusLabel.Text = Resources.ReadingPacFile;
				Application.DoEvents();
				t.PacTextureData = Util.ReadBytesFromFile(filenamePac);
			} else if (ch.NeedsPac) {
				statusLabel.Text = Resources.GeneratingPacData;
				Application.DoEvents();
				t.PacTextureData = GeneratePacData(filenamePcs);
				if (t.PacTextureData == null) {
					MessageBox.Show(Resources.ErrorGeneratingPacData);
				}
			}
		}

		private unsafe byte[] GeneratePacData(string filenamePcs) {

			byte[] data = Util.ReadBytesFromFile(filenamePcs);
			byte[] expanded = null;

			if (data != null) {

				fixed (byte* ptr = data) {
					CompressionHeader* hdr = (CompressionHeader*)ptr;
					int outLen = hdr->ExpandedSize;
					expanded = new byte[outLen];
					fixed (byte* outPtr = expanded) {
						LZ77.Expand(hdr, outPtr, outLen);
					}
				}
			}

			return expanded;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnBrowsePortrait_Click(object sender, EventArgs e) {
			openFileDialog.Filter = ImageLoader.Filter;
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				Image img = ImageLoader.LoadImage(openFileDialog.FileName);
				if (img.Size.Equals(new Size(128, 160))) {
					pictureBox1.Image = img;
				} else {
					MessageBox.Show(Resources.BitmapSizeNotValid);
				}
			}
		}

		private void RemoveImage(object sender, EventArgs e) {
			pictureBox1.Image = null;
		}

		private void TextureEdit_Load(object sender, EventArgs e) {
			toolTip.SetToolTip(chkAutoAsign, Resources.AutoAssignPortrait);
		}

		private void TextureEdit_FormClosed(object sender, FormClosedEventArgs e) {
			Settings.Default.Save();
		}
	}
}
