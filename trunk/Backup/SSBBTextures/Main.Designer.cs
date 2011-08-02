namespace SSBBTextures {
	partial class Main {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lstChars = new System.Windows.Forms.ListView();
			this.charImages = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.pictureChar = new System.Windows.Forms.PictureBox();
			this.lblCharName = new System.Windows.Forms.Label();
			this.lstOutfits = new System.Windows.Forms.ListView();
			this.outfitImages = new System.Windows.Forms.ImageList(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.status = new System.Windows.Forms.StatusStrip();
			this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.cmOutfit = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuDeleteTexture = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.archivoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.guToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
			this.abrirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.importarDesdeCarpetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportarACarpetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nuevoProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureChar)).BeginInit();
			this.status.SuspendLayout();
			this.cmOutfit.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.AccessibleDescription = null;
			this.splitContainer1.AccessibleName = null;
			resources.ApplyResources(this.splitContainer1, "splitContainer1");
			this.splitContainer1.BackgroundImage = null;
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Font = null;
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.AccessibleDescription = null;
			this.splitContainer1.Panel1.AccessibleName = null;
			resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
			this.splitContainer1.Panel1.BackgroundImage = null;
			this.splitContainer1.Panel1.Controls.Add(this.lstChars);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Font = null;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.AccessibleDescription = null;
			this.splitContainer1.Panel2.AccessibleName = null;
			resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
			this.splitContainer1.Panel2.BackgroundImage = null;
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel2.Font = null;
			// 
			// lstChars
			// 
			this.lstChars.AccessibleDescription = null;
			this.lstChars.AccessibleName = null;
			resources.ApplyResources(this.lstChars, "lstChars");
			this.lstChars.BackgroundImage = null;
			this.lstChars.Font = null;
			this.lstChars.LargeImageList = this.charImages;
			this.lstChars.Name = "lstChars";
			this.lstChars.UseCompatibleStateImageBehavior = false;
			this.lstChars.ItemActivate += new System.EventHandler(this.lstChars_ItemActivate);
			// 
			// charImages
			// 
			this.charImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			resources.ApplyResources(this.charImages, "charImages");
			this.charImages.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Font = null;
			this.label1.Name = "label1";
			// 
			// splitContainer2
			// 
			this.splitContainer2.AccessibleDescription = null;
			this.splitContainer2.AccessibleName = null;
			resources.ApplyResources(this.splitContainer2, "splitContainer2");
			this.splitContainer2.BackgroundImage = null;
			this.splitContainer2.Font = null;
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.AccessibleDescription = null;
			this.splitContainer2.Panel1.AccessibleName = null;
			resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
			this.splitContainer2.Panel1.BackgroundImage = null;
			this.splitContainer2.Panel1.Controls.Add(this.pictureChar);
			this.splitContainer2.Panel1.Controls.Add(this.lblCharName);
			this.splitContainer2.Panel1.Font = null;
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.AccessibleDescription = null;
			this.splitContainer2.Panel2.AccessibleName = null;
			resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
			this.splitContainer2.Panel2.BackgroundImage = null;
			this.splitContainer2.Panel2.Controls.Add(this.lstOutfits);
			this.splitContainer2.Panel2.Controls.Add(this.label2);
			this.splitContainer2.Panel2.Font = null;
			// 
			// pictureChar
			// 
			this.pictureChar.AccessibleDescription = null;
			this.pictureChar.AccessibleName = null;
			resources.ApplyResources(this.pictureChar, "pictureChar");
			this.pictureChar.BackgroundImage = null;
			this.pictureChar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureChar.Font = null;
			this.pictureChar.ImageLocation = null;
			this.pictureChar.Name = "pictureChar";
			this.pictureChar.TabStop = false;
			// 
			// lblCharName
			// 
			this.lblCharName.AccessibleDescription = null;
			this.lblCharName.AccessibleName = null;
			resources.ApplyResources(this.lblCharName, "lblCharName");
			this.lblCharName.Name = "lblCharName";
			// 
			// lstOutfits
			// 
			this.lstOutfits.AccessibleDescription = null;
			this.lstOutfits.AccessibleName = null;
			resources.ApplyResources(this.lstOutfits, "lstOutfits");
			this.lstOutfits.BackgroundImage = null;
			this.lstOutfits.Font = null;
			this.lstOutfits.LargeImageList = this.outfitImages;
			this.lstOutfits.Name = "lstOutfits";
			this.lstOutfits.ShowItemToolTips = true;
			this.lstOutfits.UseCompatibleStateImageBehavior = false;
			this.lstOutfits.ItemActivate += new System.EventHandler(this.lstOutfits_ItemActivate);
			this.lstOutfits.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstOutfits_MouseClick);
			// 
			// outfitImages
			// 
			this.outfitImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			resources.ApplyResources(this.outfitImages, "outfitImages");
			this.outfitImages.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Font = null;
			this.label2.Name = "label2";
			// 
			// status
			// 
			this.status.AccessibleDescription = null;
			this.status.AccessibleName = null;
			resources.ApplyResources(this.status, "status");
			this.status.BackgroundImage = null;
			this.status.Font = null;
			this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.lblStatus});
			this.status.Name = "status";
			// 
			// progressBar
			// 
			this.progressBar.AccessibleDescription = null;
			this.progressBar.AccessibleName = null;
			resources.ApplyResources(this.progressBar, "progressBar");
			this.progressBar.Name = "progressBar";
			// 
			// lblStatus
			// 
			this.lblStatus.AccessibleDescription = null;
			this.lblStatus.AccessibleName = null;
			resources.ApplyResources(this.lblStatus, "lblStatus");
			this.lblStatus.BackgroundImage = null;
			this.lblStatus.Name = "lblStatus";
			// 
			// cmOutfit
			// 
			this.cmOutfit.AccessibleDescription = null;
			this.cmOutfit.AccessibleName = null;
			resources.ApplyResources(this.cmOutfit, "cmOutfit");
			this.cmOutfit.BackgroundImage = null;
			this.cmOutfit.Font = null;
			this.cmOutfit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeleteTexture});
			this.cmOutfit.Name = "cmOutfit";
			// 
			// menuDeleteTexture
			// 
			this.menuDeleteTexture.AccessibleDescription = null;
			this.menuDeleteTexture.AccessibleName = null;
			resources.ApplyResources(this.menuDeleteTexture, "menuDeleteTexture");
			this.menuDeleteTexture.BackgroundImage = null;
			this.menuDeleteTexture.Name = "menuDeleteTexture";
			this.menuDeleteTexture.ShortcutKeyDisplayString = null;
			this.menuDeleteTexture.Click += new System.EventHandler(this.menuDeleteTexture_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.AccessibleDescription = null;
			this.mainMenu.AccessibleName = null;
			resources.ApplyResources(this.mainMenu, "mainMenu");
			this.mainMenu.BackgroundImage = null;
			this.mainMenu.Font = null;
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem1,
            this.ayudaToolStripMenuItem});
			this.mainMenu.Name = "mainMenu";
			// 
			// archivoToolStripMenuItem1
			// 
			this.archivoToolStripMenuItem1.AccessibleDescription = null;
			this.archivoToolStripMenuItem1.AccessibleName = null;
			resources.ApplyResources(this.archivoToolStripMenuItem1, "archivoToolStripMenuItem1");
			this.archivoToolStripMenuItem1.BackgroundImage = null;
			this.archivoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guToolStripMenuItem,
            this.abrirToolStripMenuItem1,
            this.guardarToolStripMenuItem,
            this.toolStripMenuItem4,
            this.importarDesdeCarpetaToolStripMenuItem,
            this.exportarACarpetaToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem1});
			this.archivoToolStripMenuItem1.Name = "archivoToolStripMenuItem1";
			this.archivoToolStripMenuItem1.ShortcutKeyDisplayString = null;
			// 
			// abrirToolStripMenuItem
			// 
			this.abrirToolStripMenuItem.AccessibleDescription = null;
			this.abrirToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.abrirToolStripMenuItem, "abrirToolStripMenuItem");
			this.abrirToolStripMenuItem.BackgroundImage = null;
			this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
			this.abrirToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.abrirToolStripMenuItem.Click += new System.EventHandler(this.nuevoProyectoToolStripMenuItem_Click);
			// 
			// guToolStripMenuItem
			// 
			this.guToolStripMenuItem.AccessibleDescription = null;
			this.guToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.guToolStripMenuItem, "guToolStripMenuItem");
			this.guToolStripMenuItem.Name = "guToolStripMenuItem";
			// 
			// abrirToolStripMenuItem1
			// 
			this.abrirToolStripMenuItem1.AccessibleDescription = null;
			this.abrirToolStripMenuItem1.AccessibleName = null;
			resources.ApplyResources(this.abrirToolStripMenuItem1, "abrirToolStripMenuItem1");
			this.abrirToolStripMenuItem1.BackgroundImage = null;
			this.abrirToolStripMenuItem1.Name = "abrirToolStripMenuItem1";
			this.abrirToolStripMenuItem1.ShortcutKeyDisplayString = null;
			this.abrirToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// guardarToolStripMenuItem
			// 
			this.guardarToolStripMenuItem.AccessibleDescription = null;
			this.guardarToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.guardarToolStripMenuItem, "guardarToolStripMenuItem");
			this.guardarToolStripMenuItem.BackgroundImage = null;
			this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
			this.guardarToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.guardarToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.AccessibleDescription = null;
			this.toolStripMenuItem4.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			// 
			// importarDesdeCarpetaToolStripMenuItem
			// 
			this.importarDesdeCarpetaToolStripMenuItem.AccessibleDescription = null;
			this.importarDesdeCarpetaToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.importarDesdeCarpetaToolStripMenuItem, "importarDesdeCarpetaToolStripMenuItem");
			this.importarDesdeCarpetaToolStripMenuItem.BackgroundImage = null;
			this.importarDesdeCarpetaToolStripMenuItem.Name = "importarDesdeCarpetaToolStripMenuItem";
			this.importarDesdeCarpetaToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.importarDesdeCarpetaToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
			// 
			// exportarACarpetaToolStripMenuItem
			// 
			this.exportarACarpetaToolStripMenuItem.AccessibleDescription = null;
			this.exportarACarpetaToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.exportarACarpetaToolStripMenuItem, "exportarACarpetaToolStripMenuItem");
			this.exportarACarpetaToolStripMenuItem.BackgroundImage = null;
			this.exportarACarpetaToolStripMenuItem.Name = "exportarACarpetaToolStripMenuItem";
			this.exportarACarpetaToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.exportarACarpetaToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.AccessibleDescription = null;
			this.toolStripSeparator1.AccessibleName = null;
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			// 
			// salirToolStripMenuItem1
			// 
			this.salirToolStripMenuItem1.AccessibleDescription = null;
			this.salirToolStripMenuItem1.AccessibleName = null;
			resources.ApplyResources(this.salirToolStripMenuItem1, "salirToolStripMenuItem1");
			this.salirToolStripMenuItem1.BackgroundImage = null;
			this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
			this.salirToolStripMenuItem1.ShortcutKeyDisplayString = null;
			this.salirToolStripMenuItem1.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
			// 
			// ayudaToolStripMenuItem
			// 
			this.ayudaToolStripMenuItem.AccessibleDescription = null;
			this.ayudaToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.ayudaToolStripMenuItem, "ayudaToolStripMenuItem");
			this.ayudaToolStripMenuItem.BackgroundImage = null;
			this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutDeToolStripMenuItem});
			this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
			this.ayudaToolStripMenuItem.ShortcutKeyDisplayString = null;
			// 
			// aboutDeToolStripMenuItem
			// 
			this.aboutDeToolStripMenuItem.AccessibleDescription = null;
			this.aboutDeToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.aboutDeToolStripMenuItem, "aboutDeToolStripMenuItem");
			this.aboutDeToolStripMenuItem.BackgroundImage = null;
			this.aboutDeToolStripMenuItem.Name = "aboutDeToolStripMenuItem";
			this.aboutDeToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.aboutDeToolStripMenuItem.Click += new System.EventHandler(this.aboutDeToolStripMenuItem_Click);
			// 
			// archivoToolStripMenuItem
			// 
			this.archivoToolStripMenuItem.AccessibleDescription = null;
			this.archivoToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.archivoToolStripMenuItem, "archivoToolStripMenuItem");
			this.archivoToolStripMenuItem.BackgroundImage = null;
			this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoProyectoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem2,
            this.importarToolStripMenuItem,
            this.exportarToolStripMenuItem,
            this.toolStripMenuItem3,
            this.salirToolStripMenuItem});
			this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
			this.archivoToolStripMenuItem.ShortcutKeyDisplayString = null;
			// 
			// nuevoProyectoToolStripMenuItem
			// 
			this.nuevoProyectoToolStripMenuItem.AccessibleDescription = null;
			this.nuevoProyectoToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.nuevoProyectoToolStripMenuItem, "nuevoProyectoToolStripMenuItem");
			this.nuevoProyectoToolStripMenuItem.BackgroundImage = null;
			this.nuevoProyectoToolStripMenuItem.Name = "nuevoProyectoToolStripMenuItem";
			this.nuevoProyectoToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.nuevoProyectoToolStripMenuItem.Click += new System.EventHandler(this.nuevoProyectoToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.AccessibleDescription = null;
			this.toolStripMenuItem1.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.AccessibleDescription = null;
			this.openToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
			this.openToolStripMenuItem.BackgroundImage = null;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.AccessibleDescription = null;
			this.saveToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
			this.saveToolStripMenuItem.BackgroundImage = null;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.AccessibleDescription = null;
			this.toolStripMenuItem2.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			// 
			// importarToolStripMenuItem
			// 
			this.importarToolStripMenuItem.AccessibleDescription = null;
			this.importarToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.importarToolStripMenuItem, "importarToolStripMenuItem");
			this.importarToolStripMenuItem.BackgroundImage = null;
			this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
			this.importarToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.importarToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
			// 
			// exportarToolStripMenuItem
			// 
			this.exportarToolStripMenuItem.AccessibleDescription = null;
			this.exportarToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.exportarToolStripMenuItem, "exportarToolStripMenuItem");
			this.exportarToolStripMenuItem.BackgroundImage = null;
			this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
			this.exportarToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.AccessibleDescription = null;
			this.toolStripMenuItem3.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			// 
			// salirToolStripMenuItem
			// 
			this.salirToolStripMenuItem.AccessibleDescription = null;
			this.salirToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
			this.salirToolStripMenuItem.BackgroundImage = null;
			this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
			this.salirToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
			// 
			// openFileDialog
			// 
			resources.ApplyResources(this.openFileDialog, "openFileDialog");
			// 
			// saveFileDialog
			// 
			resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
			// 
			// folderBrowserDialog
			// 
			resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
			// 
			// Main
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.status);
			this.Controls.Add(this.mainMenu);
			this.Font = null;
			this.MainMenuStrip = this.mainMenu;
			this.Name = "Main";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureChar)).EndInit();
			this.status.ResumeLayout(false);
			this.status.PerformLayout();
			this.cmOutfit.ResumeLayout(false);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ImageList charImages;
		private System.Windows.Forms.ImageList outfitImages;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.StatusStrip status;
		private System.Windows.Forms.ContextMenuStrip cmOutfit;
		private System.Windows.Forms.ToolStripMenuItem menuDeleteTexture;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nuevoProyectoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ListView lstChars;
		private System.Windows.Forms.Label lblCharName;
		private System.Windows.Forms.PictureBox pictureChar;
		private System.Windows.Forms.ListView lstOutfits;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator guToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem importarDesdeCarpetaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportarACarpetaToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripProgressBar progressBar;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutDeToolStripMenuItem;
	}
}

