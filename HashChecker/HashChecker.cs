using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpShell;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;

namespace HashChecker
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFiles)]
    public class HashChecker : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return true;
        }

        protected override ContextMenuStrip CreateMenu()
        {
            //  Create the menu strip.
            var menu = new ContextMenuStrip();
            
            //  Create a 'count lines' item.
            var itemMD5Checker = new ToolStripMenuItem
            {
                Text = "Calculate MD5Sum"
            };

            var itemSHA256Checker = new ToolStripMenuItem
            {
                Text = "Calculate SHA256Sum"
            };
            
            //  When we click, we'll call the 'CountLines' function.
            itemMD5Checker.Click += (sender, args) => CalculateHashSum("MD5");
            itemSHA256Checker.Click += (sender, args) => CalculateHashSum("SHA256");

            //  Add the item to the context menu.
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(itemMD5Checker);
            menu.Items.Add(itemSHA256Checker);
            menu.Items.Add(new ToolStripSeparator());

            //  Return the menu.
            return menu;
        }

        private void CalculateHashSum(string algorithm)
        {
            string hashsum = "";

            using (var stream = File.OpenRead(SelectedItemPaths.First()))
            {
                switch (algorithm)
                {
                    case "MD5":
                        MD5 md5 = System.Security.Cryptography.MD5.Create();
                        hashsum = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                        break;
                    case "SHA256":
                        SHA256 sha256 = System.Security.Cryptography.SHA256.Create();
                        hashsum = BitConverter.ToString(sha256.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                        break;
                }
            }

            MessageBox.Show(hashsum.ToString(), algorithm + " Checksum", MessageBoxButtons.OK);            
        }
    }
}