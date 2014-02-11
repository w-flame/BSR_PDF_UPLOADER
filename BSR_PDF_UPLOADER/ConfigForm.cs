using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BSR_PDF_UPLOADER
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            TBBSRBASE.Text = Properties.Settings.Default.bsr_base;
            TBBSRUSER.Text = Properties.Settings.Default.bsr_user;

            TBSEARCHFOLDER.Text = Properties.Settings.Default.search_folder;
            if (Properties.Settings.Default.after_action == 0) RBDELETE.Checked = true;
            else
            {
                RBMOVE.Checked = true;
                RBMOVE_CheckedChanged(null, null);
            }
            TBMOVEFOLDER.Text = Properties.Settings.Default.after_action_folder;

            RBREPLACEDOCS.Checked = Properties.Settings.Default.replace_mode;

            CBUSELOG.Checked = Properties.Settings.Default.use_log;
            CBUSELOG_CheckedChanged(null, null);

            TBLOGFOLDER.Text = Properties.Settings.Default.log_folder;

            CBUSECUSTOMREGEX.Checked = Properties.Settings.Default.use_custom_detector;
            TBCUSTOMREG.Text = Properties.Settings.Default.custom_detector;
            TBREPLACEREG.Text = Properties.Settings.Default.custom_replace;
            CBUSECUSTOMREGEX_CheckedChanged(null, null);
        }

        private void RBMOVE_CheckedChanged(object sender, EventArgs e)
        {
            if (RBMOVE.Checked)
            {
                TBMOVEFOLDER.Enabled = true;
                BrowseMoveFolder.Enabled = true;
            }
            else
            {
                TBMOVEFOLDER.Enabled = false;
                BrowseMoveFolder.Enabled = false;
            }
        }

        private void CBUSELOG_CheckedChanged(object sender, EventArgs e)
        {
            if (CBUSELOG.Checked)
            {
                TBLOGFOLDER.Enabled = true;
                BrowseLogFolder.Enabled = true;
            }
            else
            {
                TBLOGFOLDER.Enabled = false;
                BrowseLogFolder.Enabled = false;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.bsr_base = TBBSRBASE.Text;
            Properties.Settings.Default.bsr_user = TBBSRUSER.Text;

            if (TBBSRPASS.Text != "")
            {
                Properties.Settings.Default.bsr_pass = SecurityFunctions.EncryptString(SecurityFunctions.ToSecureString(TBBSRPASS.Text));
            }

            Properties.Settings.Default.search_folder = TBSEARCHFOLDER.Text;
            if (RBDELETE.Checked) Properties.Settings.Default.after_action = 0;
            else
            {
                Properties.Settings.Default.after_action = 1;
                Properties.Settings.Default.after_action_folder = TBMOVEFOLDER.Text;
            }

            Properties.Settings.Default.replace_mode = RBREPLACEDOCS.Checked;
            Properties.Settings.Default.use_custom_detector = CBUSECUSTOMREGEX.Checked;
            Properties.Settings.Default.custom_detector = TBCUSTOMREG.Text;
            Properties.Settings.Default.custom_replace = TBREPLACEREG.Text;

            Properties.Settings.Default.use_log = CBUSELOG.Checked;
            Properties.Settings.Default.log_folder = TBLOGFOLDER.Text;
            Properties.Settings.Default.first_launch = false;
            Properties.Settings.Default.Save();
            MessageBox.Show("Настройки сохранены");
        }

        private void BrowseSearch_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(TBSEARCHFOLDER.Text) && TBSEARCHFOLDER.Text != "") FolderBrowserDLG.SelectedPath = TBSEARCHFOLDER.Text;
            if (FolderBrowserDLG.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TBSEARCHFOLDER.Text = FolderBrowserDLG.SelectedPath;
            }
        }

        private void BrowseMoveFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(TBMOVEFOLDER.Text) && TBSEARCHFOLDER.Text != "") FolderBrowserDLG.SelectedPath = TBMOVEFOLDER.Text;
            if (FolderBrowserDLG.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TBMOVEFOLDER.Text = FolderBrowserDLG.SelectedPath;
            }
        }

        private void BrowseLogFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(TBLOGFOLDER.Text) && TBSEARCHFOLDER.Text != "") FolderBrowserDLG.SelectedPath = TBLOGFOLDER.Text;
            if (FolderBrowserDLG.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TBLOGFOLDER.Text = FolderBrowserDLG.SelectedPath;
            }
        }

        private void checkConnection_Click(object sender, EventArgs e)
        {
            try
            {
                Brain.CheckOracleConnection(TBBSRBASE.Text, TBBSRUSER.Text, TBBSRPASS.Text);
                MessageBox.Show("Соединение успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка соединения: " + ex.Message);
            }
        }

        private void TBBSRPASS_TextChanged(object sender, EventArgs e)
        {
            if (TBBSRPASS.Text == "") checkConnection.Enabled = false;
            else checkConnection.Enabled = true;
        }

        private void CBUSECUSTOMREGEX_CheckedChanged(object sender, EventArgs e)
        {
            TBCUSTOMREG.Enabled = CBUSECUSTOMREGEX.Checked;
            TBREPLACEREG.Enabled = CBUSECUSTOMREGEX.Checked;
        }




    }
}
