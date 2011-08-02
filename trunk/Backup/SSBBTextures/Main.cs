using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSBBTextures.Properties;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using FreeImageAPI;


namespace SSBBTextures {
	public partial class Main : Form {

		Skinning skinning;

		private static Font emptyFont;
		private static Font setFont;

		private static Color emptyColor = Color.Black;
		private static Color setColor = Color.Red;

		public Main() {
			InitializeComponent();
			
			emptyFont = new Font(Font, FontStyle.Regular);
			setFont = new Font(Font, FontStyle.Bold);

			string version = GetVersionString();
			Text = string.Format("{0} {1} {2}", Resources.AppName, Resources.Version, version);
		}

		private string GetVersionString() {
			Version version=Assembly.GetExecutingAssembly().GetName().Version;
			return string.Format("{0}.{1} build {2}", version.Major, version.Minor, version.Build);
		}

		private void CreateNewProject() {

			skinning.Clear();
			lstChars.Items.Clear();
			int imgId = 0;
			foreach (Character c in skinning.Characters) {
				ListViewItem lvi = new ListViewItem();
				lvi.Text = c.Name;
				charImages.Images.Add(c.Image);
				lvi.ImageIndex = imgId;
				imgId++;
				lvi.Tag = c;
				lstChars.Items.Add(lvi);
			}

		}

		private void Form1_Load(object sender, EventArgs e) {

			skinning = new Skinning();
			skinning.LoadCharacters();

			CreateNewProject();

			string[] args = Environment.GetCommandLineArgs();
			switch (args.Length) {
				case 2:
					OpenSsbbtFile2(args[1],  OnOpenProgressStart, OnOpenProgressChanged, OnOpenProgressEnd);
					break;
			}
		}

		private void lstChars_ItemActivate(object sender, EventArgs e) {
			lblCharName.Visible = true;
			
			ListViewItem selected=lstChars.SelectedItems[0];
			Character c = (Character)selected.Tag;
			pictureChar.Image = c.Image;
			lblCharName.Text = c.Name;

			outfitImages.Images.Clear();
			lstOutfits.Clear();
			int outfitId = 0;
			if (c.Outfits != null) {
				foreach (Outfit o in c.Outfits) {
					ListViewItem lvi = new ListViewItem();
					lvi.Text = o.Name;
					lvi.Tag = o;
					
					if (o.Image != null) {
						outfitImages.Images.Add(o.Image);
						lvi.ImageIndex = outfitId;
					}
					if (o.AssociatedTexture == null) {
						lvi.ForeColor = emptyColor;
						lvi.Font = emptyFont;
					} else {
						lvi.ToolTipText = o.AssociatedTexture.Name;
						lvi.ForeColor = setColor;
						lvi.Font = setFont;
					}
					outfitId++;
					lstOutfits.Items.Add(lvi);
				}
			}
		}

		private void lstOutfits_ItemActivate(object sender, EventArgs e) {

			ListViewItem lvi=lstOutfits.SelectedItems[0];

			
			Outfit o=(Outfit) lvi.Tag;

			if (o.Available) {

				TextureEdit edit = new TextureEdit(o);
				if (edit.ShowDialog() == DialogResult.OK) {
					lvi.ForeColor = setColor;
					lvi.Font = setFont;
					lvi.ToolTipText = o.AssociatedTexture.Name;
				}
			}
		}

		// Open
		private void OnOpenProgressStart(int totalSteps) {
			Cursor = Cursors.WaitCursor;
			progressBar.Maximum = totalSteps;
			progressBar.Value = 0;
			
			lblStatus.Text = Resources.Opening;
			lblStatus.Visible = true;
			progressBar.Visible = true;
			status.Update();
		}
		private void OnOpenProgressChanged(object currentItem, int stepNumber) {
			progressBar.Value = stepNumber;
			Outfit o = (Outfit)currentItem;
			lblStatus.Text = o.ToString();
			status.Update();
		}
		private void OnOpenProgressEnd() {
			lblStatus.Visible = false;
			progressBar.Visible = false;
			Cursor = Cursors.Default;
		}

		// Save

		private void OnSaveProgressStart(int totalSteps) {
			Cursor = Cursors.WaitCursor;
			progressBar.Maximum = totalSteps;
			progressBar.Value = 0;

			lblStatus.Text = string.Format("{0}. {1}", Resources.Saving, Resources.PleaseWait);
			lblStatus.Visible = true;
			progressBar.Visible = true;
			status.Update();
		}
		private void OnSaveProgressChanged(object currentItem, int stepNumber) {
			progressBar.Value = stepNumber;
			Outfit o = (Outfit)currentItem;
			lblStatus.Text = string.Format("{0}: {1} - {2}", Resources.Saving, o.Character, o);
			status.Update();
		}
		private void OnSaveProgressEnd() {
			lblStatus.Visible = false;
			progressBar.Visible = false;
			Cursor = Cursors.Default;
		}

		// Export
		private void OnExportProgressStart(int totalSteps) {
			Cursor = Cursors.WaitCursor;
			progressBar.Maximum = totalSteps;
			progressBar.Value = 0;
			progressBar.Visible = true;
			lblStatus.Text = Resources.Exporting;
			lblStatus.Visible = true;
			status.Update();
		}
		private void OnExportProgressChanged(object currentItem, int stepNumber) {
			progressBar.Value = stepNumber;
			Outfit o = (Outfit)currentItem;
			lblStatus.Text = string.Format("{0}: {1} - {2}", Resources.Exporting, o.Character, o);
			status.Update();
		}
		private void OnExportProgressEnd() {
			lblStatus.Visible = false;
			progressBar.Visible = false;
			Cursor = Cursors.Default;
		}

		// Import

		private void OnImportProgressStart(int totalSteps) {
			Cursor = Cursors.WaitCursor;
			progressBar.Maximum = totalSteps;
			progressBar.Value = 0;
			progressBar.Visible = true;
			lblStatus.Text = Resources.Importing;
			lblStatus.Visible = true;
			status.Update();
		}
		private void OnImportProgressChanged(object currentItem, int stepNumber) {
			progressBar.Value = stepNumber;
			Character c = (Character)currentItem;
			lblStatus.Text = string.Format("{0}: {1}", Resources.Importing, c);
			status.Update();
		}
		private void OnImportProgressEnd() {
			lblStatus.Visible = false;
			progressBar.Visible = false;
			Cursor = Cursors.Default;
		}

		private void ExportToFileSystem(string root, Skinning skn, ProgressStartHander onProgressStart, ProgressChangedHandler onProgressChanged, ProgressEndHandler onProgressEnd) {

			if (onProgressStart != null)
				onProgressStart(skinning.Characters.Count);

			int stepProgress = 0;
			foreach (Character c in skinning.Characters) {

				string charRoot = Path.Combine(root, c.Code);
				Directory.CreateDirectory(charRoot);
				TextureInfo[] infos = new TextureInfo[c.Outfits.Length];

				int id=0;
				foreach (Outfit o in c.Outfits) {

					string filenameNoExt = string.Format("Fit{0}{1:00}", c.Code, id);

					if (onProgressChanged!=null)
						onProgressChanged(o, stepProgress);

					if (o.Available && o.AssociatedTexture != null) {

						bool written = false;
						do {
							try {
								o.AssociatedTexture.SaveTextureData(filenameNoExt, charRoot);
								written = true;
							} catch (Exception ex) {
								if (MessageBox.Show(string.Format(Resources.ErrorWritingPcs, charRoot), Resources.ErrorWritingPcsTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.No)
									written = true;
							}
						} while (!written);

						// Creamos la información de cada traje en el directorio
						TextureInfo info = new TextureInfo();
						Texture t = o.AssociatedTexture;
						info.Index = id;
						info.Description = t.Description;
						info.Image = t.Image;
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

			if (onProgressEnd != null)
				onProgressEnd();				
		}

		private void menuDeleteTexture_Click(object sender, EventArgs e) {
			ListViewItem lvi = lstOutfits.SelectedItems[0];
			Outfit outfit = (Outfit)lvi.Tag;
			outfit.AssociatedTexture = null;
			lvi.ToolTipText = null;
			lvi.ForeColor = emptyColor;
			lvi.Font = emptyFont;
		}

		private void lstOutfits_MouseClick(object sender, MouseEventArgs e) {
			ListViewItem lvi = lstOutfits.SelectedItems[0];
			Outfit outfit = (Outfit)lvi.Tag;
			if (e.Button == MouseButtons.Right) {
				menuDeleteTexture.Enabled = (outfit.AssociatedTexture != null);
				cmOutfit.Show(lstOutfits, e.Location);
			}
		}

		private void nuevoProyectoToolStripMenuItem_Click(object sender, EventArgs e) {
			CreateNewProject();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e) {

			try {


				saveFileDialog.InitialDirectory = Settings.Default.SaveFolder;
				saveFileDialog.Filter = string.Format("{0}|*.SSBBT", Resources.SsbbtFiles);
				if (saveFileDialog.ShowDialog() == DialogResult.OK) {

					SaveSsbbtFile2(saveFileDialog.FileName, OnSaveProgressStart, OnSaveProgressChanged, OnSaveProgressEnd);

					Settings.Default.SaveFolder = Path.GetDirectoryName(saveFileDialog.FileName);
					Settings.Default.Save();
					
					MessageBox.Show(Resources.FileSaved);
				}
				
			} catch (Exception ex) {
				MessageBox.Show(string.Format("{0}: {1}", Resources.ErrorSaving, ex.ToString()));
			}
		}

		private void SaveSsbbtFile2(string path, ProgressStartHander onSaveProgressStart, ProgressChangedHandler onSaveProgressChanged, ProgressEndHandler onSaveProgressEnd) {
			BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.Create));
			skinning.SaveTo(writer, onSaveProgressStart, onSaveProgressChanged, onSaveProgressEnd);
			writer.Close();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {

			try {
				openFileDialog.InitialDirectory = Settings.Default.OpenFolder;
				openFileDialog.Filter = string.Format("{0}|*.SSBBT", Resources.SsbbtFiles);
				if (openFileDialog.ShowDialog() == DialogResult.OK) {
					OpenSsbbtFile2(openFileDialog.FileName, OnOpenProgressStart, OnOpenProgressChanged, OnOpenProgressEnd);
				}
			} catch (Exception ex) {
				MessageBox.Show(string.Format("{0}: {1}", Resources.ErrorOpening, ex.ToString()));
			}
		}

		private void OpenSsbbtFile2(string path, ProgressStartHander onProgressStart, ProgressChangedHandler onProgressChanged, ProgressEndHandler onProgressEnd) {
			BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open));
			skinning.LoadFrom(reader, onProgressStart, onProgressChanged, onProgressEnd);
			reader.Close();
		}


		private void importToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				folderBrowserDialog.SelectedPath = Settings.Default.ImportPath;
				folderBrowserDialog.Description = Resources.ImportDescription;

				if (folderBrowserDialog.ShowDialog()== DialogResult.OK) {
					ImportFromFileSystem(folderBrowserDialog.SelectedPath, OnImportProgressStart, OnImportProgressChanged, OnImportProgressEnd);
					
					Settings.Default.ImportPath = folderBrowserDialog.SelectedPath;
					Settings.Default.Save();

					MessageBox.Show(Resources.StructureLoadedSuccessfully);
				}
				
			} catch (Exception ex) {
				MessageBox.Show(string.Format("{0}: {1}", Resources.ErrorImporting, ex.ToString()));
			}
		}

		private void ImportFromFileSystem(string path, ProgressStartHander onProgressStart, ProgressChangedHandler onProgressChange, ProgressEndHandler onProgressEnd) {
			
			DirectoryInfo dirInfo = new DirectoryInfo(path);
			DirectoryInfo[] directories= dirInfo.GetDirectories() ;

			if (onProgressStart!=null)
				onProgressStart(directories.Length);

			int dirStep = 0;
			foreach (DirectoryInfo info in directories) {
				ProcessDirectory(info, dirStep, onProgressChange);
				dirStep++;
			}

			if (onProgressEnd != null)
				onProgressEnd();
		}

		private void ProcessDirectory(DirectoryInfo info, int dirStep, ProgressChangedHandler onProgressChange) {
			
			Character character = skinning.GetCharacter(info.Name); 
			if (character != null) {

				if (onProgressChange != null)
					onProgressChange(character, dirStep);

				string infoPath = Path.Combine(info.FullName, string.Format("{0}.xml", info.Name));
				TextureInfo[] outfitInfos = TextureInfo.ReadFromXml(infoPath);
				Texture[] textures = TextureInfo.ToTextureArray(character.Code, info.FullName, outfitInfos);

				int t = 0;
				foreach (Outfit outfit in character.Outfits) {
					if (t < textures.Length) {
						if (textures[t]!=null)
							textures[t].Outfit = outfit;
						outfit.AssociatedTexture = textures[t];
					}
					t++;
				}
			}
		}

		private void exportarToolStripMenuItem_Click(object sender, EventArgs e) {
			//try {
				folderBrowserDialog.SelectedPath = Settings.Default.ExportPath;
				folderBrowserDialog.Description = Resources.ExportDescription;
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
					ExportToFileSystem(folderBrowserDialog.SelectedPath, skinning, OnExportProgressStart, OnExportProgressChanged, OnExportProgressEnd);

					Settings.Default.ExportPath = folderBrowserDialog.SelectedPath;
					Settings.Default.Save();

					MessageBox.Show(string.Format(Resources.ExportedSuccessfully, folderBrowserDialog.SelectedPath));
				}

			//} catch (Exception ex) {
				//MessageBox.Show(string.Format("{0}: {1}", Resources.ErrorExporting, ex.ToString()));
			//}
		}

		private void salirToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void aboutDeToolStripMenuItem_Click(object sender, EventArgs e) {
			AboutBox aboutBox = new AboutBox();
			aboutBox.ShowDialog();
		}
	}
}
