using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SSBBTextures.Properties;
using System.Diagnostics;
using BrawlLib.Wii.Compression;
using System.Runtime.InteropServices;

namespace SSBBTextures {
	public partial class TextureEdit : Form {

		Outfit outfit;

		public bool Modified { get; set; }

		public TextureEdit(Outfit outfit) {
			InitializeComponent();
			this.outfit = outfit;
			Text = outfit.Name;

			openFileDialog.Filter = string.Format("{0}|*.pcs", Resources.PcsFiles);

			if (outfit.AssociatedTexture != null) {
				textName.Text = outfit.AssociatedTexture.Name;
				textDesc.Text = outfit.AssociatedTexture.Description;
				grpSetTexture.Visible = false;
			} else {
				grpSetTexture.Visible = true;
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
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				textPath.Text = openFileDialog.FileName;
				textName.Text = Path.GetFileNameWithoutExtension(textPath.Text);
				textPath.Enabled = true;
			}
		}

		private void btnAccept_Click(object sender, EventArgs e) {

			errorProvider1.Clear();

			try {
				if (outfit.AssociatedTexture == null) {
					Texture t = new Texture();
					t.Description = textDesc.Text;
					t.Name = textName.Text;
					t.Outfit = outfit;

					string filename = textPath.Text;
					if (File.Exists(filename)) {

						statusLabel.Text = Resources.AssociatingPcsData;
						Application.DoEvents();
						t.PcsTextureData = Util.ReadBytesFromFile(filename);

						Character ch = outfit.Character;

						statusLabel.Text = Resources.AssociatingPacData;
						Application.DoEvents();
						AssociatePacData(t, filename, ch);

						outfit.AssociatedTexture = t;

						DialogResult = DialogResult.OK;
						Close();
					} else {
						errorProvider1.SetError(textPath, Resources.InvalidPcsPath);
					}
				}
				
			} catch (Exception ex) {
				MessageBox.Show(string.Format(Resources.ErrorAsigningTexture, ex.ToString()));
			}
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

		private unsafe byte[] GeneratePacData2(string filenamePcs) {
			CompressionHeader header = new CompressionHeader();
			header.Algorithm = CompressionType.LZ77;
			byte[] data = Util.ReadBytesFromFile(filenamePcs);
			header.Data.address=Marshal
			VoidPtr p = new VoidPtr();
			//Compressor.Expand(header,
		}

		private byte[] GeneratePacData(string filenamePcs) {
			string filenameNoExt=Path.GetFileNameWithoutExtension(filenamePcs);
			byte[] data = null;

			Process proccess= new Process();
			proccess.StartInfo.CreateNoWindow = true;
			proccess.StartInfo.FileName="lz77ex.exe";
			proccess.StartInfo.Arguments = string.Format("\"{0}\"", filenamePcs);
			proccess.StartInfo.UseShellExecute=false;
			proccess.Start();
			proccess.WaitForExit();
			if (proccess.ExitCode == 0) {
				string outputName = string.Concat(filenamePcs, ".out");
				data = Util.ReadBytesFromFile(outputName);
				File.Delete(outputName);
			}
			return data;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void TextureEdit_Load(object sender, EventArgs e) {

		}
	}
}
