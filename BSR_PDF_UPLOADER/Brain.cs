using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;

namespace BSR_PDF_UPLOADER
{



    public class Logging
    {
        public static void Log(string source, string message)
        {
            String Log_path =
    Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\pdfuploader.log";
            StreamWriter sw;
            if (!File.Exists(Log_path)) sw = File.CreateText(Log_path);
            else sw = File.AppendText(Log_path);
            sw.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + ": (" + source + ") " + message);
            sw.Close();
        }

        public static void CSV(string log_folder, string filename, string operation, string result, string detected_case_number, string bsr_case_number,string pornum)
        {
            String Log_path = Path.Combine(log_folder,"pdf2bsr.csv");
            StreamWriter sw;
            try
            {
                if (!File.Exists(Log_path))
                {
                    sw = new StreamWriter(
                        new FileStream(Log_path, FileMode.Create, FileAccess.Write),
                        Encoding.GetEncoding(1251)
                    );

                    sw.WriteLine("Время;Имя файла;Операция;Результат;Определённый номер дела;Номер дела в БСР;Порядковый номер документа");
                }
                else sw = new StreamWriter(
                        new FileStream(Log_path, FileMode.Append, FileAccess.Write),
                        Encoding.GetEncoding(1251)
                    );
                sw.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + ";" + filename + ";" + operation + ";" + result + ";" + detected_case_number + ";" + bsr_case_number + ";" + pornum);
                sw.Close();
            }
            catch (Exception)
            {

            }
            
        }
    }


    class SecurityFunctions
    {

        static byte[] entropy = System.Text.Encoding.Unicode.GetBytes("Another sweet salt");

        public static string EncryptString(System.Security.SecureString input)
        {
            byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(
                System.Text.Encoding.Unicode.GetBytes(ToInsecureString(input)),
                entropy,
                System.Security.Cryptography.DataProtectionScope.LocalMachine);
            return Convert.ToBase64String(encryptedData);
        }

        public static SecureString DecryptString(string encryptedData)
        {
            try
            {
                byte[] decryptedData = System.Security.Cryptography.ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData),
                    entropy,
                    System.Security.Cryptography.DataProtectionScope.LocalMachine);
                return ToSecureString(System.Text.Encoding.Unicode.GetString(decryptedData));
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString ToSecureString(string input)
        {
            SecureString secure = new SecureString();
            foreach (char c in input)
            {
                secure.AppendChar(c);
            }
            secure.MakeReadOnly();
            return secure;
        }

        public static string ToInsecureString(SecureString input)
        {
            string returnValue = string.Empty;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input);
            try
            {
                returnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
            return returnValue;
        }
    }
    
    enum AfterUploadAction{
        leave, copy, delete
    }

    class Brain
    {
        public static bool CheckOracleConnection(string Base, string User, string Pass)
        {
            using (OracleConnection connection = new OracleConnection())
            {
                connection.ConnectionString = "Data Source=" + Base + ";Password=" + Pass + ";User ID=" + User;
                connection.Open();
                connection.Close();
                return true;
            }
        }

        public static void UploadPDF(string[] pdf_paths, string bsr_base, string bsr_user, string bsr_pass, AfterUploadAction after_upload, string copy_path, bool use_log, string log_path, bool replace_mode, string regex, string replace_regex, bool replace_hash)
        {
           
				using (OracleConnection connection = new OracleConnection())
	            {
                    connection.ConnectionString = "Data Source="+bsr_base+";Password="+bsr_pass+";User ID="+bsr_user;
	                connection.Open();
	                
	                foreach (string pdf_path in pdf_paths) {
	                	
	                    string case_number = Path.GetFileNameWithoutExtension(pdf_path);
	                    string bsr_case_number = "";
	                    string rubricat = "000";
		                object cmd_res = null;
		                
	
		                using (OracleCommand cmd = new OracleCommand()){
		                	cmd.Connection = connection;
		                	cmd.CommandText = "SELECT ID_DOCUM, NUMDOCUM, RUBRIKAT FROM BSR.BSRP WHERE NUMDOCUM LIKE :numdoc";

		                	
		                	if (replace_hash) {
		                		case_number = case_number.Replace('#','/');
		                	}
                            case_number = Regex.Replace(case_number, regex, replace_regex);
                            
	
	                        OracleParameter op = new OracleParameter()
	                        {
	                            Direction = System.Data.ParameterDirection.Input,
	                            OracleType = OracleType.VarChar,
	                            Value = string.Concat(case_number),
	                            ParameterName = ":numdoc"
	                        };
	                        cmd.Parameters.Add(op);
	
	                        
	
	                        OracleDataReader reader = cmd.ExecuteReader();
	                        if (reader.Read())
	                        {
	                            cmd_res = reader.GetOracleNumber(0);
	                            bsr_case_number = reader.GetString(1);
	                            if (!reader.IsDBNull(2)) {
	                            	rubricat = reader.GetString(2);
	                            }
	                        }
	                        reader.Close();
		                	
		                }
		                
	                	OracleNumber case_id;
	                    if (cmd_res != null)
	                    {
	
	                        case_id = (OracleNumber)cmd_res;
	
	                        FileStream fs = new FileStream(pdf_path, FileMode.Open, FileAccess.Read);
	                        byte[] ImageData = new byte[fs.Length];
	                        fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
	                        fs.Close();
	
	                        using (OracleCommand cmd = new OracleCommand())
	                        {
	                            cmd.Connection = connection;
	                            cmd.CommandText = "SELECT MAX(PORNUM) FROM BSR.IMAGE_DOCUM WHERE ID_DOCUM = :id";
	
	                            OracleParameter op = new OracleParameter()
	                            {
	                                Direction = System.Data.ParameterDirection.Input,
	                                OracleType = OracleType.Number,
	                                Value = case_id,
	                                ParameterName = ":id"
	                            };
	
	                            cmd.Parameters.Add(op);
	
	                            cmd_res = cmd.ExecuteScalar();
	                        }
	
	                        int PORNUM = 1;
	
	                        if (cmd_res != null && cmd_res != DBNull.Value)
	                        {
	                            PORNUM = (int)((decimal)cmd_res + 1);
	                        }


                            
							OracleTransaction transaction = connection.BeginTransaction();
                            using (OracleCommand cmd = new OracleCommand())
                            {

                                cmd.Connection = connection;
                                cmd.Transaction = transaction;

                                if (replace_mode && PORNUM != 1)
                                {
                                    PORNUM--;
                                    cmd.CommandText = "UPDATE BSR.IMAGE_DOCUM SET IMAGEDOCUM=:image, USERMOD=:usr, DATEMOD=SYSDATE, EXT=:ext WHERE ID_DOCUM=:id AND PORNUM=:pornum";
                                }
                                else
                                {
                                    cmd.CommandText = "INSERT INTO BSR.IMAGE_DOCUM (ID_DOCUM,IMAGEDOCUM,PORNUM,USERADD,DATEADD,EXT) VALUES (:id,:image,:pornum,:usr,SYSDATE,:ext)";
                                }

                                OracleParameter op_id = new OracleParameter()
                                {
                                    Direction = System.Data.ParameterDirection.Input,
                                    OracleType = OracleType.Number,
                                    Value = case_id,
                                    ParameterName = ":id"
                                };
                                cmd.Parameters.Add(op_id);

                                OracleParameter op_image = new OracleParameter()
                                {
                                    Direction = System.Data.ParameterDirection.Input,
                                    OracleType = OracleType.Blob,
                                    Value = ImageData,
                                    ParameterName = ":image"
                                };
                                cmd.Parameters.Add(op_image);

                                OracleParameter op_pornum = new OracleParameter()
                                {
                                    Direction = System.Data.ParameterDirection.Input,
                                    OracleType = OracleType.Number,
                                    Value = PORNUM,
                                    ParameterName = ":pornum"
                                };
                                cmd.Parameters.Add(op_pornum);

                                OracleParameter op_user = new OracleParameter()
                                {
                                    Direction = System.Data.ParameterDirection.Input,
                                    OracleType = OracleType.VarChar,
                                    Value = bsr_user,
                                    ParameterName = ":usr"
                                };
                                cmd.Parameters.Add(op_user);


                                OracleParameter op_ext = new OracleParameter()
                                {
                                    Direction = System.Data.ParameterDirection.Input,
                                    OracleType = OracleType.VarChar,
                                    Value = Path.GetExtension(pdf_path).Substring(1).ToUpper(),
                                    ParameterName = ":ext"
                                };
                                cmd.Parameters.Add(op_ext);
                                
                                
                               
                                System.Data.OracleClient.OracleCommand update_rubricat_cmd = new OracleCommand();
                                update_rubricat_cmd.Connection = connection;
                                update_rubricat_cmd.Transaction = transaction;
                                update_rubricat_cmd.CommandText = "UPDATE BSR.BSRP b SET b.rubrikat = :rub WHERE b.id_docum = :id";
                                
                                
                                
                                char[] chars = rubricat.ToCharArray();
    							chars[1] = '1';
    							rubricat  = new string(chars);
                                
                                OracleParameter op_rub = new OracleParameter() {
                                	Direction = System.Data.ParameterDirection.Input,
                                	OracleType = OracleType.VarChar,
                                	Value = rubricat,
                                	ParameterName = ":rub"
                                };
    							update_rubricat_cmd.Parameters.Add(op_rub);
    							
    							OracleParameter op_id_2 = new OracleParameter()
                                {
                                    Direction = System.Data.ParameterDirection.Input,
                                    OracleType = OracleType.Number,
                                    Value = case_id,
                                    ParameterName = ":id"
                                };
    							update_rubricat_cmd.Parameters.Add(op_id_2);
                                
                                try
                                {
                                	
                                    cmd.ExecuteNonQuery();
                                    update_rubricat_cmd.ExecuteNonQuery();
                                    transaction.Commit();
                                    
                                    if (use_log) Logging.CSV(log_path, Path.GetFileName(pdf_path), "Загрузка документа", "Загружено", case_number, bsr_case_number, PORNUM.ToString());


                                    if (after_upload == AfterUploadAction.copy)
                                    {
                                        string dest_file = Path.Combine(copy_path, Path.GetFileName(pdf_path));
                                        int i = 2;
                                        while (File.Exists(dest_file))
                                        {
                                            dest_file = Path.Combine(copy_path, Path.GetFileNameWithoutExtension(pdf_path) + i.ToString() + Path.GetExtension(pdf_path));
                                            i++;
                                        }
                                        try
                                        {
                                            File.Move(pdf_path, dest_file);
                                            if (use_log) Logging.CSV(log_path, Path.GetFileName(pdf_path).Replace(';', ' '), "Перемещение документа", "Успешно", "", "", "");
                                        }
                                        catch (Exception ex)
                                        {
                                            if (use_log) Logging.CSV(log_path, Path.GetFileName(pdf_path).Replace(';', ' '), "Перемещение документа", "Ошибка: " + ex.Message + " попытамся переименовать файл в текущей папке", "", "", "");
                                            File.Move(pdf_path, pdf_path + "_uploaded");
                                        }


                                    }

                                    if (after_upload == AfterUploadAction.delete)
                                    {
                                        try
                                        {
                                            File.Delete(pdf_path);
                                            if (use_log) Logging.CSV(log_path, Path.GetFileName(pdf_path).Replace(';', ' '), "Удаление документа", "Успешно", "", "", "");
                                        }
                                        catch (Exception ex)
                                        {
                                            if (use_log) Logging.CSV(log_path, Path.GetFileName(pdf_path).Replace(';', ' '), "Удаление документа", "Ошибка: " + ex.Message, "", "", "");
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    if (use_log) Logging.CSV(log_path, Path.GetFileName(pdf_path).Replace(';', ' '), "Загрузка документа", "Ошибка: " + ex.Message, case_number, bsr_case_number, PORNUM.ToString());
                                }

                            }
                            transaction.Dispose();
                           
	
	                    }
	                    else
	                    {
	                        if (use_log) Logging.CSV(log_path, Path.GetFileName(pdf_path).Replace(';', ' '), "Загрузка документа", "Ошибка: дело не найдено", case_number, "", "");
	                    }
	                
	               
                    }
	                connection.Close();
	                
	            }
			}
        }
}

