using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SSBBTextures {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main());
		}
	}


	public delegate void ProgressStartHander(int totalSteps);
	public delegate void ProgressChangedHandler(object currentItem, int stepNumber);
	public delegate void ProgressEndHandler();
}
