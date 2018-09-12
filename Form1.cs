using MAPIClientSelector.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPIClientSelector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var mail = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\Mail", false);
            if (mail != null)
            {
                foreach (var _key in mail.GetSubKeyNames())
                {
                    var key = _key;
                    var keyKey = mail.OpenSubKey(key, false);
                    if (keyKey != null)
                    {
                        var text = keyKey.GetValue(null) + "";
                        Button button = new Button
                        {
                            AutoSize = true,
                            AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            Image = Resources.Next_16x,
                            TextImageRelation = TextImageRelation.ImageBeforeText,
                            Text = text,
                        };
                        button.Click += (a, b) =>
                        {
                            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Clients\Mail", "", key);
                            MessageBox.Show(this, $"{text} に変更しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        };
                        flow.Controls.Add(button);
                        flow.SetFlowBreak(button, true);
                    }
                }
            }
        }
    }
}
