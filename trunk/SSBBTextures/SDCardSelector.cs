using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Texturizer.Properties;

namespace Texturizer {
	public partial class SDCardSelector : Form {

		private class GameVersion {
			public string Code { get; set; }
			public string Region { get; set; }
			public bool Detected { get; set; }
			private GameVersion() { }
			public GameVersion(string code, string region)
				: this() {
				Code = code;
				Region = region;
				Detected = false;
			}
			public override string ToString() {
				return string.Format("{0} {1} {2}", Code, Region, Detected?Resources.Detected:string.Empty);
			}
		}

		private const string dataFolder = @"private\wii\app\{0}\pf";
		BindingList<GameVersion> list = new BindingList<GameVersion>();

		public SDCardSelector() {
			InitializeComponent();

			foreach (DriveInfo driveInfo in DriveInfo.GetDrives()) {
				if (driveInfo.DriveType == DriveType.Removable) 
					cbDrives.Items.Add(driveInfo);
			}

			list.Add(new GameVersion("RSBE", "NTSC"));
			list.Add(new GameVersion("RSBP", "PAL"));

			cbRegion.DataSource = list;
		}

		private string GetPath(string drive, string code) {
			return Path.Combine(drive, string.Format(dataFolder, code));
		}

		private string GetSelectedDrive() {
			
			DriveInfo df = (DriveInfo)cbDrives.SelectedItem;
			return df.Name;
		
		}
		private string GetSelectedCode() {
			GameVersion gv = (GameVersion)cbRegion.SelectedItem;
			return gv.Code;
		}

		private void cbDrives_SelectedValueChanged(object sender, EventArgs e) {

			int t=0;
			foreach (GameVersion gv in list) {
				string pathToTest = GetPath(GetSelectedDrive(), gv.Code);

				if (Directory.Exists(pathToTest)) {
					gv.Detected = true;
				} else {
					gv.Detected = false;
				}
				list.ResetItem(t);
				t++;
			}

			cbRegion.EndUpdate();

			btnSelect.Enabled = (cbDrives.SelectedItem != null);
		}

		void SetSelectedDrive(string drive) {
			foreach (DriveInfo di in cbDrives.Items) {
				if (di.Name.Equals(drive))
					cbDrives.SelectedItem = di;
			}
		}
		void SetSelectedCode(string code) {
			foreach (GameVersion gv in cbRegion.Items) {
				if (gv.Code.Equals(code))
					cbRegion.SelectedItem = gv;
			}
		}


		public string SdCardPath { 
			get {
				return GetPath(GetSelectedDrive(), GetSelectedCode());
			}
			set {

				if (!value.Equals(string.Empty)) {
					string drive = Path.GetPathRoot(value);
					string code = GetCodeFromPath(value);
					SetSelectedDrive(drive);
					SetSelectedCode(code);
					btnSelect.Enabled = true;
				}
			} 
		}

		private string GetCodeFromPath(string value) {
			string startToken=@"private\wii\app\";
		
			int start = value.IndexOf(startToken, 0) + startToken.Length;
			int end = value.IndexOf("\\", start);

			string ret = value.Substring(start, end - start);
			return ret;
		}

		private void btnSelect_Click(object sender, EventArgs e) {

			DialogResult = DialogResult.OK;
			Close();

		}

	}
}
