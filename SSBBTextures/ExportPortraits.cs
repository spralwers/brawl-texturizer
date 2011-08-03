using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using System.Drawing.Imaging;
using Texturizer.Properties;

namespace Texturizer {
	public partial class ExportPortraits : Form {
		public ExportPortraits() {
			InitializeComponent();
		}

		private void btnBrowse_Click(object sender, EventArgs e) {
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
				txtFolder.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void btnBrowseFile_Click(object sender, EventArgs e) {
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				txtFile.Text = openFileDialog1.FileName;
			}
		}

		private void btnExport_Click(object sender, EventArgs e) {
			ResourceNode root = NodeFactory.FromFile(null, txtFile.Text);

			string[] filenames = {
									"Mario",
									"Donkey",
									"Link",
									"Samus",
									"Yoshi",
									"Kirby",
									"Fox",
									"Pikachu",
									"Luigi",
									"Captain",
									"Ness",
									"Koopa",
									"Peach",
									"Zelda",
									"Sheik",
									"Popo",
									"Marth",
									"GameWatch",
									"Falco",
									"Ganon",
									"MetaKnight",
									"Pit",
									"SZeroSuit",
									"Pikmin",
									"Lucas",
									"Diddy",
									"PokeTrainer",
									"PokeLizardon",
									"PokeZenigame",
									"PokeFushigisou",
									"Dedede",
									"Lucario",
									"Ike",
									"Robot",
									"Purin",
									"Wario",
									"ToonLink",
									"Unknown",
									"Wolf",
									"Snake",
									"Sonic"
								};

			ResourceNode charRootNode = root.FindChild(
					"char_bust_tex_lz77",
					true
				);

			int t = 0;
			foreach (ResourceNode charNode in charRootNode.Children) {
				BRESGroupNode group = (BRESGroupNode) charNode.Children[1];

				int z = 0;
				foreach (TEX0Node texNode in group.Children) {
					texNode.GetImage(0).Save(Path.Combine(txtFolder.Text, string.Format("{0}{1}.png", filenames[t], z)), ImageFormat.Png);
					z++;
				}
				t++;
			}

			MessageBox.Show(Resources.PortraitsExportFinished);
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			DialogResult=DialogResult.Cancel;
			Close();
		}
	}
}
