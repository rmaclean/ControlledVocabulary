﻿//--------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfExtensions.cs">(c) Controlled Vocabulary on GitHub, 2015. All other rights reserved.</copyright>
//--------------------------------------------------------------------------------------------------------------------------------
namespace ControlledVocabulary
{
    /// <summary>
    /// WpfExtensions
    /// </summary>
    public static class WpfExtensions
    {
        /// <summary>
        /// GetIWin32Window
        /// </summary>
        /// <param name="visual">System.Windows.Media.Visual</param>
        /// <returns>IWin32Window</returns>
        public static System.Windows.Forms.IWin32Window GetIWin32Window(this System.Windows.Media.Visual visual)
        {
            var source = System.Windows.PresentationSource.FromVisual(visual) as System.Windows.Interop.HwndSource;
            System.Windows.Forms.IWin32Window win = new OldWindow(source.Handle);
            return win;
        }

        private class OldWindow : System.Windows.Forms.IWin32Window
        {
            private readonly System.IntPtr ptrhandle;

            public OldWindow(System.IntPtr handle)
            {
                this.ptrhandle = handle;
            }

            #region IWin32Window Members
            System.IntPtr System.Windows.Forms.IWin32Window.Handle
            {
                get { return this.ptrhandle; }
            }
            #endregion
        }
    }
}
