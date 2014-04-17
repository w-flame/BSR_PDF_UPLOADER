using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace BSR_PDF_UPLOADER
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (Properties.Settings.Default.first_launch)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.first_launch = false;
                Properties.Settings.Default.Save();
            }


            bool noArgs = true;
            foreach (string item in args)
            {
                if (item == "/config")
                {
                    noArgs = false;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new ConfigForm());
                    break;
                }
                if (item == "/run")
                {
                    noArgs = false;

                    if (Properties.Settings.Default.first_launch)
                    {
                        MessageBox.Show("Похоже Вы запустили программу в первый раз и ещё не настраивали. Пожалуйста запустите программу с ключем /config для настройки параметров");
                        return;
                    }

                    string[] files = null;
                    try
                    {
                        files = Directory.GetFiles(Properties.Settings.Default.search_folder, "*.pdf");
                    }
                    catch (Exception ex)
                    {
                        Logging.Log("get file list", ex.Message); 
                    }

                    AfterUploadAction ua;
                    if (Properties.Settings.Default.after_action == 0) ua = AfterUploadAction.delete;
                    else
                    {
                        ua = AfterUploadAction.copy;
                        try
                        {
                            string copy_path = Properties.Settings.Default.after_action_folder;
                            if (!Directory.Exists(copy_path)) Directory.CreateDirectory(copy_path);
                            FileStream fs = File.Create(Path.Combine(copy_path, "test"));
                            fs.Close();
                            File.Delete(Path.Combine(copy_path, "test"));
                        }
                        catch (Exception ex)
                        {
                            Logging.Log("move folder check",ex.Message);
                            return;
                        }
                    }

                    try
                    {
                        string regex = "^(\\d+)([а-яА-Я]{0,2}|/\\d+)-(\\d+)(-|/)(\\d+)(.*)";
                        string replace_regex = "$1$2-$3/$5%";
                        if (Properties.Settings.Default.use_custom_detector)
                        {
                            regex = Properties.Settings.Default.custom_detector;
                            replace_regex = Properties.Settings.Default.custom_replace;
                        }
                        

                        Brain.UploadPDF(files, Properties.Settings.Default.bsr_base, Properties.Settings.Default.bsr_user,
                        SecurityFunctions.ToInsecureString(SecurityFunctions.DecryptString(Properties.Settings.Default.bsr_pass)),
                        ua, Properties.Settings.Default.after_action_folder, Properties.Settings.Default.use_log, Properties.Settings.Default.log_folder,
                        Properties.Settings.Default.replace_mode,regex,replace_regex,Properties.Settings.Default.replace_hash);
                    }
                    catch (Exception ex)
                    {
                        Logging.Log("upload pdf", ex.Message + " " + ex.StackTrace);     
                    }

                    break;
                }
            }

            if (noArgs)
            {
                MessageBox.Show("Для того, чтобы настроить программу, запустите её с параметром /config\nДля загрузки PDF файлов с ключем /run");
            }



        }
    }
}
