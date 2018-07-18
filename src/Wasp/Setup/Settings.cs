using System;
using System.IO;

using Wasp.Enums;

namespace Wasp.Setup
{
    /// <summary>
    /// A simple in-memory version of the <see cref="ISettings"/> interface.
    /// </summary>
    public class Settings : ISettings
    {
        private string _screenCapturePath;

        /// <summary>
        /// Initializes a default instance of the <see cref="Settings"/> class with <see cref="ScreenCapturePath"/> of the current directory.
        /// </summary>
        public Settings()
        {
            this.ScreenCapturePath = Environment.CurrentDirectory;
            this.CaptureScreenOnVerificationFailure = false;
            this.IsLocalTestRun = false;
            this.ChoosedWebBrowser = BrowserType.None;
        }

        /// <summary>
        /// Gets or sets the screen capture output path.
        /// </summary>
        /// <value>
        /// The screen capture path.
        /// </value>
        public string ScreenCapturePath
        {
            get => this._screenCapturePath;
            set
            {
                if (Directory.Exists(value) == false)
                {
                    throw new ArgumentException("Not an existing directory.", "value");
                }

                this._screenCapturePath = value;
            }
        }

        public bool CaptureScreenOnVerificationFailure { get; set; }

        public BrowserType ChoosedWebBrowser { get; set; }

        public bool IsLocalTestRun { get; set; }
    }
}
