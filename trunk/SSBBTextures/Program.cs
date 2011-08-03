using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Texturizer {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main());
			MassiveDataManager.Cleanup();
		}
	}


	public delegate void ProgressStartHander(int totalSteps);
	public delegate void ProgressChangedHandler(object currentItem, int stepNumber);
	public delegate void ProgressEndHandler();
}
