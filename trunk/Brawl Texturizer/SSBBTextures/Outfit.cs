using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using BrawlLib.SSBB.ResourceNodes;

namespace Texturizer {

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

		public int Id { get; set; }
		public int ResOrder { get; set; }

		public override string ToString() {
			return string.Format("{0} - {1}", Character, Name);
		}
	}
	


	

}
