using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;

namespace SSBBTextures {

	[Serializable]
	public class Outfit {

		public Character Character { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Image Image { get; set; }
		private Texture associatedTexture;
		public Texture AssociatedTexture {
			get { return associatedTexture; }
			set { associatedTexture = value; }
		}
		public bool Available { get; set; }
		public Outfit() {
			Available = true;
		}

		public override string ToString() {
			return Name;
		}
	}
}
