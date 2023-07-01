using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System.Net;

namespace BuildMaster.Utilities
{
    public static class colourManager
    {
        //Processing of loading and initialising font from resources.
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        static PrivateFontCollection mFontCollection = new PrivateFontCollection();
        public static void initFont()
        {
            Stream fontStream = new MemoryStream(Properties.Resources.Roboto_Light);
            System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
            Byte[] fontData = new Byte[fontStream.Length];
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            Marshal.Copy(fontData, 0, data, (int)fontStream.Length);
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);
            mFontCollection.AddMemoryFont(data, (int)fontStream.Length);
            fontStream.Close();
            Marshal.FreeCoTaskMem(data);
        }
        //Called when changing colour theme. Assigns colour and font to all controls.
        public static void colourDefinition(Form form, Color backcolour, Color forecolour)
        {
            Properties.Settings.Default.BackColour = backcolour;
            Properties.Settings.Default.ForeColour = forecolour;
            Properties.Settings.Default.Save();
            form.BackColor = backcolour;
            form.ForeColor = forecolour;
            //Is this a really stupid way of finding every control in the scope and changing it's colour? God yes. Am I going to fix it? God no.
            //When you poll form.Controls, it only gives you the top level and not any relevant children. So, repetatively poll until you reach the end.
            //This many was enough to get the theme change to work stabily on all screens. If you're wanting to do something similar, first off don't do this, but if you insist, you may need to add or be able to remove loops.
            foreach (Control c in form.Controls)
            {
                if (c.Controls != null)
                {
                    foreach (Control d in c.Controls)
                    {
                        if (d.Controls != null)
                        {
                            foreach (Control e in d.Controls)
                            {
                                if (e.Controls != null)
                                {
                                    foreach (Control f in e.Controls)
                                    {
                                        if (f.Controls != null)
                                        {
                                            foreach (Control g in f.Controls)
                                            {
                                                g.BackColor = backcolour;
                                                g.ForeColor = forecolour;
                                                g.Font = new Font(mFontCollection.Families[0], g.Font.Size);
                                            }
                                        }
                                        f.BackColor = backcolour;
                                        f.ForeColor = forecolour;
                                        f.Font = new Font(mFontCollection.Families[0], f.Font.Size);
                                    }
                                }
                                e.BackColor = backcolour;
                                e.ForeColor = forecolour;
                                e.Font = new Font(mFontCollection.Families[0], e.Font.Size);
                            }
                        }
                        d.BackColor = backcolour;
                        d.ForeColor = forecolour;
                        d.Font = new Font(mFontCollection.Families[0], d.Font.Size);
                    }
                }
                c.BackColor = backcolour;
                c.ForeColor = forecolour;
                c.Font = new Font(mFontCollection.Families[0], c.Font.Size);
            }
        }
    }
}