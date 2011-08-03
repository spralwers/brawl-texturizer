namespace Texturizer {
	partial class TextureEdit {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureEdit));
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.grpSetTexture = new System.Windows.Forms.GroupBox();
			this.textPath = new System.Windows.Forms.TextBox();
			this.btnBrowsePcs = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textDesc = new System.Windows.Forms.TextBox();
			this.textName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnRemovePortrait = new System.Windows.Forms.Button();
			this.btnBrowePicture = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkAutoAsign = new System.Windows.Forms.CheckBox();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.grpSetTexture.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAccept
			// 
			this.btnAccept.AccessibleDescription = null;
			this.btnAccept.AccessibleName = null;
			resources.ApplyResources(this.btnAccept, "btnAccept");
			this.btnAccept.BackgroundImage = null;
			this.btnAccept.Font = null;
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleDescription = null;
			this.btnCancel.AccessibleName = null;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.BackgroundImage = null;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = null;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			resources.ApplyResources(this.errorProvider1, "errorProvider1");
			// 
			// statusStrip1
			// 
			this.statusStrip1.AccessibleDescription = null;
			this.statusStrip1.AccessibleName = null;
			resources.ApplyResources(this.statusStrip1, "statusStrip1");
			this.statusStrip1.BackgroundImage = null;
			this.errorProvider1.SetError(this.statusStrip1, resources.GetString("statusStrip1.Error"));
			this.statusStrip1.Font = null;
			this.errorProvider1.SetIconAlignment(this.statusStrip1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statusStrip1.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.statusStrip1, ((int)(resources.GetObject("statusStrip1.IconPadding"))));
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
			this.statusStrip1.Name = "statusStrip1";
			// 
			// statusLabel
			// 
			this.statusLabel.AccessibleDescription = null;
			this.statusLabel.AccessibleName = null;
			resources.ApplyResources(this.statusLabel, "statusLabel");
			this.statusLabel.BackgroundImage = null;
			this.statusLabel.Name = "statusLabel";
			// 
			// panel1
			// 
			this.panel1.AccessibleDescription = null;
			this.panel1.AccessibleName = null;
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BackgroundImage = null;
			this.panel1.Controls.Add(this.btnAccept);
			this.panel1.Controls.Add(this.btnCancel);
			this.errorProvider1.SetError(this.panel1, resources.GetString("panel1.Error"));
			this.panel1.Font = null;
			this.errorProvider1.SetIconAlignment(this.panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("panel1.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.panel1, ((int)(resources.GetObject("panel1.IconPadding"))));
			this.panel1.Name = "panel1";
			// 
			// grpSetTexture
			// 
			this.grpSetTexture.AccessibleDescription = null;
			this.grpSetTexture.AccessibleName = null;
			resources.ApplyResources(this.grpSetTexture, "grpSetTexture");
			this.grpSetTexture.BackgroundImage = null;
			this.grpSetTexture.Controls.Add(this.textPath);
			this.grpSetTexture.Controls.Add(this.btnBrowsePcs);
			this.grpSetTexture.Controls.Add(this.label1);
			this.errorProvider1.SetError(this.grpSetTexture, resources.GetString("grpSetTexture.Error"));
			this.grpSetTexture.Font = null;
			this.errorProvider1.SetIconAlignment(this.grpSetTexture, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpSetTexture.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.grpSetTexture, ((int)(resources.GetObject("grpSetTexture.IconPadding"))));
			this.grpSetTexture.Name = "grpSetTexture";
			this.grpSetTexture.TabStop = false;
			// 
			// textPath
			// 
			this.textPath.AccessibleDescription = null;
			this.textPath.AccessibleName = null;
			resources.ApplyResources(this.textPath, "textPath");
			this.textPath.BackgroundImage = null;
			this.errorProvider1.SetError(this.textPath, resources.GetString("textPath.Error"));
			this.textPath.Font = null;
			this.errorProvider1.SetIconAlignment(this.textPath, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textPath.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.textPath, ((int)(resources.GetObject("textPath.IconPadding"))));
			this.textPath.Name = "textPath";
			// 
			// btnBrowsePcs
			// 
			this.btnBrowsePcs.AccessibleDescription = null;
			this.btnBrowsePcs.AccessibleName = null;
			resources.ApplyResources(this.btnBrowsePcs, "btnBrowsePcs");
			this.btnBrowsePcs.BackgroundImage = null;
			this.errorProvider1.SetError(this.btnBrowsePcs, resources.GetString("btnBrowsePcs.Error"));
			this.btnBrowsePcs.Font = null;
			this.errorProvider1.SetIconAlignment(this.btnBrowsePcs, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnBrowsePcs.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.btnBrowsePcs, ((int)(resources.GetObject("btnBrowsePcs.IconPadding"))));
			this.btnBrowsePcs.Name = "btnBrowsePcs";
			this.btnBrowsePcs.UseVisualStyleBackColor = true;
			this.btnBrowsePcs.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.errorProvider1.SetError(this.label1, resources.GetString("label1.Error"));
			this.label1.Font = null;
			this.errorProvider1.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
			this.label1.Name = "label1";
			// 
			// groupBox2
			// 
			this.groupBox2.AccessibleDescription = null;
			this.groupBox2.AccessibleName = null;
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.BackgroundImage = null;
			this.groupBox2.Controls.Add(this.textDesc);
			this.groupBox2.Controls.Add(this.textName);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label3);
			this.errorProvider1.SetError(this.groupBox2, resources.GetString("groupBox2.Error"));
			this.groupBox2.Font = null;
			this.errorProvider1.SetIconAlignment(this.groupBox2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox2.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.groupBox2, ((int)(resources.GetObject("groupBox2.IconPadding"))));
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// textDesc
			// 
			this.textDesc.AccessibleDescription = null;
			this.textDesc.AccessibleName = null;
			resources.ApplyResources(this.textDesc, "textDesc");
			this.textDesc.BackgroundImage = null;
			this.errorProvider1.SetError(this.textDesc, resources.GetString("textDesc.Error"));
			this.textDesc.Font = null;
			this.errorProvider1.SetIconAlignment(this.textDesc, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textDesc.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.textDesc, ((int)(resources.GetObject("textDesc.IconPadding"))));
			this.textDesc.Name = "textDesc";
			// 
			// textName
			// 
			this.textName.AccessibleDescription = null;
			this.textName.AccessibleName = null;
			resources.ApplyResources(this.textName, "textName");
			this.textName.BackgroundImage = null;
			this.errorProvider1.SetError(this.textName, resources.GetString("textName.Error"));
			this.textName.Font = null;
			this.errorProvider1.SetIconAlignment(this.textName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textName.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.textName, ((int)(resources.GetObject("textName.IconPadding"))));
			this.textName.Name = "textName";
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.errorProvider1.SetError(this.label2, resources.GetString("label2.Error"));
			this.label2.Font = null;
			this.errorProvider1.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
			this.label2.Name = "label2";
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.errorProvider1.SetError(this.label3, resources.GetString("label3.Error"));
			this.label3.Font = null;
			this.errorProvider1.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
			this.label3.Name = "label3";
			// 
			// btnRemovePortrait
			// 
			this.btnRemovePortrait.AccessibleDescription = null;
			this.btnRemovePortrait.AccessibleName = null;
			resources.ApplyResources(this.btnRemovePortrait, "btnRemovePortrait");
			this.btnRemovePortrait.BackgroundImage = null;
			this.errorProvider1.SetError(this.btnRemovePortrait, resources.GetString("btnRemovePortrait.Error"));
			this.btnRemovePortrait.Font = null;
			this.errorProvider1.SetIconAlignment(this.btnRemovePortrait, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnRemovePortrait.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.btnRemovePortrait, ((int)(resources.GetObject("btnRemovePortrait.IconPadding"))));
			this.btnRemovePortrait.Name = "btnRemovePortrait";
			this.btnRemovePortrait.UseVisualStyleBackColor = true;
			this.btnRemovePortrait.Click += new System.EventHandler(this.RemoveImage);
			// 
			// btnBrowePicture
			// 
			this.btnBrowePicture.AccessibleDescription = null;
			this.btnBrowePicture.AccessibleName = null;
			resources.ApplyResources(this.btnBrowePicture, "btnBrowePicture");
			this.btnBrowePicture.BackgroundImage = null;
			this.errorProvider1.SetError(this.btnBrowePicture, resources.GetString("btnBrowePicture.Error"));
			this.btnBrowePicture.Font = null;
			this.errorProvider1.SetIconAlignment(this.btnBrowePicture, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnBrowePicture.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.btnBrowePicture, ((int)(resources.GetObject("btnBrowePicture.IconPadding"))));
			this.btnBrowePicture.Name = "btnBrowePicture";
			this.btnBrowePicture.UseVisualStyleBackColor = true;
			this.btnBrowePicture.Click += new System.EventHandler(this.btnBrowsePortrait_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.AccessibleDescription = null;
			this.pictureBox1.AccessibleName = null;
			resources.ApplyResources(this.pictureBox1, "pictureBox1");
			this.pictureBox1.BackgroundImage = null;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.errorProvider1.SetError(this.pictureBox1, resources.GetString("pictureBox1.Error"));
			this.pictureBox1.Font = null;
			this.errorProvider1.SetIconAlignment(this.pictureBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pictureBox1.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.pictureBox1, ((int)(resources.GetObject("pictureBox1.IconPadding"))));
			this.pictureBox1.ImageLocation = null;
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = null;
			this.groupBox1.AccessibleName = null;
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.BackgroundImage = null;
			this.groupBox1.Controls.Add(this.chkAutoAsign);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.btnBrowePicture);
			this.groupBox1.Controls.Add(this.btnRemovePortrait);
			this.errorProvider1.SetError(this.groupBox1, resources.GetString("groupBox1.Error"));
			this.groupBox1.Font = null;
			this.errorProvider1.SetIconAlignment(this.groupBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox1.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.groupBox1, ((int)(resources.GetObject("groupBox1.IconPadding"))));
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// chkAutoAsign
			// 
			this.chkAutoAsign.AccessibleDescription = null;
			this.chkAutoAsign.AccessibleName = null;
			resources.ApplyResources(this.chkAutoAsign, "chkAutoAsign");
			this.chkAutoAsign.BackgroundImage = null;
			this.chkAutoAsign.Checked = global::Texturizer.Properties.Settings.Default.AutoAssignPortrait;
			this.chkAutoAsign.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAutoAsign.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Texturizer.Properties.Settings.Default, "AutoAssignPortrait", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.errorProvider1.SetError(this.chkAutoAsign, resources.GetString("chkAutoAsign.Error"));
			this.chkAutoAsign.Font = null;
			this.errorProvider1.SetIconAlignment(this.chkAutoAsign, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkAutoAsign.IconAlignment"))));
			this.errorProvider1.SetIconPadding(this.chkAutoAsign, ((int)(resources.GetObject("chkAutoAsign.IconPadding"))));
			this.chkAutoAsign.Name = "chkAutoAsign";
			this.chkAutoAsign.UseVisualStyleBackColor = true;
			// 
			// toolTip
			// 
			this.toolTip.AutoPopDelay = 10000;
			this.toolTip.InitialDelay = 500;
			this.toolTip.IsBalloon = true;
			this.toolTip.ReshowDelay = 100;
			// 
			// openFileDialog
			// 
			resources.ApplyResources(this.openFileDialog, "openFileDialog");
			this.openFileDialog.InitialDirectory = global::Texturizer.Properties.Settings.Default.PcsFolder;
			// 
			// TextureEdit
			// 
			this.AcceptButton = this.btnAccept;
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpSetTexture);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = null;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TextureEdit";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TextureEdit_FormClosed);
			this.Load += new System.EventHandler(this.TextureEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.grpSetTexture.ResumeLayout(false);
			this.grpSetTexture.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnBrowePicture;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textDesc;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox grpSetTexture;
		private System.Windows.Forms.Button btnBrowsePcs;
		private System.Windows.Forms.TextBox textPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRemovePortrait;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkAutoAsign;
		private System.Windows.Forms.ToolTip toolTip;
	}
}