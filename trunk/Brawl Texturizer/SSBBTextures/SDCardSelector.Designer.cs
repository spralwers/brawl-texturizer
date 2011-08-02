namespace Texturizer {
	partial class SDCardSelector {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SDCardSelector));
			this.cbDrives = new System.Windows.Forms.ComboBox();
			this.cbRegion = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbDrives
			// 
			this.cbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDrives.FormattingEnabled = true;
			resources.ApplyResources(this.cbDrives, "cbDrives");
			this.cbDrives.Name = "cbDrives";
			this.cbDrives.SelectedValueChanged += new System.EventHandler(this.cbDrives_SelectedValueChanged);
			// 
			// cbRegion
			// 
			this.cbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRegion.FormattingEnabled = true;
			resources.ApplyResources(this.cbRegion, "cbRegion");
			this.cbRegion.Name = "cbRegion";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// btnSelect
			// 
			resources.ApplyResources(this.btnSelect, "btnSelect");
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// SDCardSelector
			// 
			this.AcceptButton = this.btnSelect;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSelect);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbRegion);
			this.Controls.Add(this.cbDrives);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SDCardSelector";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cbDrives;
		private System.Windows.Forms.ComboBox cbRegion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnCancel;
	}
}