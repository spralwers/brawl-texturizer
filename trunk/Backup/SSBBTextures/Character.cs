using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using SSBBTextures.Properties;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace SSBBTextures {

	public class Character {


		public Image Image { get; set; }

		public string Name { get; set; }
		private Outfit[] outfits;

		public Outfit[] Outfits {
			get {
				return outfits;
			}
			set {
				outfits = value;
			}
		}
		public bool NeedsPac { get; set; }
		public string Code { get; set; }

		public override string ToString() {
			return Name;
		}
	}
}
