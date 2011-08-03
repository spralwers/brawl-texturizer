using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;

namespace Texturizer {
	public sealed class CharacterProvider {
		static readonly CharacterProvider instance = new CharacterProvider();

		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static CharacterProvider() {
		}

		ResourceManager namesManager = new ResourceManager("Texturizer.CharNames", typeof(CharNames).Assembly);
		ResourceManager imagesManager = new ResourceManager("Texturizer.CharImages", typeof(CharImages).Assembly);

		CharacterProvider() {

		}

		public static CharacterProvider Instance {
			get {
				return instance;
			}
		}
	}
}
