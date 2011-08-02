using System;
using System.Drawing;
using System.Windows.Forms;
using Texturizer.Properties;
using System.Reflection;
using System.IO;

namespace Texturizer {
	public partial class Main : Form {

		VisualsManager visualsManager;

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
			UpdateExportToSdMenus();
		}

		private void UpdateExportToSdMenus() {

			bool enabled = !Settings.Default.SDPath.Equals(string.Empty);
			
			desdeTarjetaSDToolStripMenuItem.Enabled = enabled;
			aTarjetaSDToolStripMenuItem.Enabled=enabled;
		}

		private string GetVersionString() {
			Version version=Assembly.GetExecutingAssembly().GetName().Version;
			return string.Format("{0}.{1} build {2}", version.Major, version.Minor, version.Build);
		}

		private void CreateNewProject() {

			visualsManager.Clear();
			lstChars.Items.Clear();
			int imgId = 0;
			foreach (Character c in visualsManager.Characters) {
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

			visualsManager = new VisualsManager();
			visualsManager.LoadCharacters();

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

					if (o.Available) {
						ListViewItem lvi = new ListViewItem();
						lvi.Text = o.Name;
						lvi.Tag = o;

						if (o.AssociatedTexture != null && o.AssociatedTexture.Portrait != null) {
							outfitImages.Images.Add(o.AssociatedTexture.Portrait);
							lvi.ImageIndex = outfitId;
						} else if (o.Image != null) {
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
		}

		private void lstOutfits_ItemActivate(object sender, EventArgs e) {

			ListViewItem lvi=lstOutfits.SelectedItems[0];

			
			Outfit o=(Outfit) lvi.Tag;

			if (o.Available) {

				TextureEdit edit = new TextureEdit(o);
				if (edit.ShowDialog() == DialogResult.OK) {
					int index = lstOutfits.SelectedIndices[0];
					if (o.AssociatedTexture.Portrait != null) {
						outfitImages.Images[index] = new Bitmap(o.AssociatedTexture.Portrait, outfitImages.ImageSize);
					} else {
						outfitImages.Images[index] = new Bitmap(o.Image, outfitImages.ImageSize);
					}
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
			lblStatus.Text = string.Format("{0}: {1}", Resources.Opening, o);
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
			lblStatus.Text = string.Format("{0}: {1}", Resources.Saving, o);
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
			lblStatus.Text = string.Format("{0}: {1}", Resources.Exporting, o);
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


		private void DeleteTexture(object sender, EventArgs e) {
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

		private void newProject(object sender, EventArgs e) {
			CreateNewProject();
		}

		private void SaveProject(object sender, EventArgs e) {

			try {
				saveFileDialog.InitialDirectory = Settings.Default.SaveFolder;
				saveFileDialog.Filter = string.Format("{0}|*.SSBBT", Resources.SsbbtFiles);
				if (saveFileDialog.ShowDialog() == DialogResult.OK) {

					SaveSsbbtFile(saveFileDialog.FileName, OnSaveProgressStart, OnSaveProgressChanged, OnSaveProgressEnd);

					Settings.Default.SaveFolder = Path.GetDirectoryName(saveFileDialog.FileName);
					Settings.Default.Save();
					
					MessageBox.Show(Resources.FileSaved);
				}
				
			} catch (Exception ex) {
				MessageBox.Show(string.Format("{0}: {1}", Resources.ErrorSaving, ex.ToString()));
			}
		}

		private void SaveSsbbtFile(string path, ProgressStartHander onSaveProgressStart, ProgressChangedHandler onSaveProgressChanged, ProgressEndHandler onSaveProgressEnd) {
			BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.Create));
			visualsManager.SaveTo(writer, onSaveProgressStart, onSaveProgressChanged, onSaveProgressEnd);
			writer.Close();
		}

		private void OpenProject(object sender, EventArgs e) {

			try {
				openFileDialog.InitialDirectory = Settings.Default.OpenFolder;
				openFileDialog.Filter = string.Format("{0}|*.SSBBT", Resources.SsbbtFiles);
				if (openFileDialog.ShowDialog() == DialogResult.OK) {
					OpenSsbbtFile2(openFileDialog.FileName, OnOpenProgressStart, OnOpenProgressChanged, OnOpenProgressEnd);
					//OpenSsbbtFile2(openFileDialog.FileName, OnOpenProgressStart, OnOpenProgressChanged, OnOpenProgressEnd);
					MessageBox.Show(Resources.FileLoaded);
				}
			} catch (Exception ex) {
				MessageBox.Show(string.Format("{0}: {1}", Resources.ErrorOpening, ex.ToString()));
			}
		}

		private void OpenSsbbtFile2(string path, ProgressStartHander onProgressStart, ProgressChangedHandler onProgressChanged, ProgressEndHandler onProgressEnd) {
			try {
				BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open));
				visualsManager.LoadFrom(reader, onProgressStart, onProgressChanged, onProgressEnd);
				reader.Close();
			} catch (InvalidDataException) {
				MessageBox.Show(Resources.ErrorNotValidSsbbtFile);
			}
		}


		private void Export(string path) {
			try {
				if (Settings.Default.SourceCommon5pac.Equals(string.Empty))
					RequestForCommon5();
				visualsManager.ExportToFileSystem(path, Settings.Default.SourceCommon5pac, OnExportProgressStart, OnExportProgressChanged, OnExportProgressEnd);
				MessageBox.Show(string.Format(Resources.ExportedSuccessfully, path));
			} catch (Exception ex) {
				MessageBox.Show(string.Format("{0}: {1}", Resources.ErrorExporting, ex.ToString()));
			}
		}

		private void Import(string path) {
			try {
				VisualsManager.ImportInfo info=visualsManager.ImportFromFileSystem(path, OnImportProgressStart, OnImportProgressChanged, OnImportProgressEnd);

				if (info.Recreated > 0) {
					float percent=(float) info.Recreated/info.Total;
					if (MessageBox.Show(string.Format(Resources.ImportFromScratchWarning, percent), null, MessageBoxButtons.YesNo) == DialogResult.Yes) {
						string common5path = Path.Combine(path, "system\\common5.pac");
						if (File.Exists(common5path)) {
							visualsManager.ReadPortraits(common5path);
						} else {
							// Posible mensaje al usuario indicándole que no se ha restaurado nada
						}
					}
				}

				MessageBox.Show(Resources.StructureLoadedSuccessfully);
			} catch (Exception ex) {
				MessageBox.Show(string.Format("{0}\n{1}:\n{2}", Resources.ErrorImporting, Resources.ExceptionDetails, ex.ToString()));
			}
		}

		private void ImportFromFolder(object sender, EventArgs e) {
			
			folderBrowserDialog.SelectedPath = Settings.Default.ImportPath;
			folderBrowserDialog.Description = Resources.ImportDescription;

			if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {

				Import(folderBrowserDialog.SelectedPath);

				Settings.Default.ImportPath = folderBrowserDialog.SelectedPath;
				Settings.Default.Save();
			}
		}


		private void ExportToFolder(object sender, EventArgs e) {

				folderBrowserDialog.SelectedPath = Settings.Default.ExportPath;
				folderBrowserDialog.Description = Resources.ExportDescription;
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
					Export(folderBrowserDialog.SelectedPath);
					Settings.Default.ExportPath = folderBrowserDialog.SelectedPath;
					Settings.Default.Save();
				}

			
		}

		private void RequestForCommon5() {
			if (!File.Exists(Settings.Default.SourceCommon5pac)) {
				MessageBox.Show(Resources.Common5Required);
				openFileDialog.Filter = string.Format("{0}|*.pac", Resources.PacFiles);
				if (openFileDialog.ShowDialog() == DialogResult.OK) {
					Settings.Default.SourceCommon5pac = openFileDialog.FileName;
					Settings.Default.Save();
				} else {
					MessageBox.Show(Resources.PortraitsWontBeExported);
				}
			}
		}

		private void Quit(object sender, EventArgs e) {
			Close();
		}

		private void About(object sender, EventArgs e) {
			AboutBox aboutBox = new AboutBox();
			aboutBox.ShowDialog();
		}

		private void ImportFromSD(object sender, EventArgs e) {

			if (!Settings.Default.SDPath.Equals(string.Empty)) {
				Import(Settings.Default.SDPath);
			}
		}

		private void SelectSdCard(object sender, EventArgs e) {
			SDCardSelector selector = new SDCardSelector();
			selector.SdCardPath = Settings.Default.SDPath;

			if (selector.ShowDialog() == DialogResult.OK) {
				Settings.Default.SDPath = selector.SdCardPath;
				Settings.Default.Save();
				UpdateExportToSdMenus();
			}
		}

		private void ExportToSd(object sender, EventArgs e) {
			if (!Settings.Default.SDPath.Equals(string.Empty)) {
				
				if (Settings.Default.SourceCommon5pac.Equals(string.Empty))
					RequestForCommon5();
				Export(Settings.Default.SDPath);
			}
		}

		private void ExportPortraits(object sender, EventArgs e) {
			ExportPortraits ep = new ExportPortraits();
			ep.Show();
		}
	}
}
