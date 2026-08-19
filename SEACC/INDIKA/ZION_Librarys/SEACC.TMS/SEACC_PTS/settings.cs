using SEACC_PTS.NmsSecurity;
using System;

class settings
{
    public static string sImagePath = "image\\default_User.png";
   // public static System.Drawing.Image
    public static string strDBServerName = "";
    public static string strDBName = "";
    public static string strDBUser = "";
    public static string strDBPW = "";

    public static string strLogedUserName = "";
    public static int UserId_Loged;
    public static int UserGroupID;

    public static int Organization_ID = 1;
    public static int Branch_ID = 1;

    public static string AutoAlert_SenderAddress = "dtqalert@digiteq.biz";
    public static string AutoAlert_Host = "";
    public static int AutoAlert_port;
    public static bool AutoAlert_SSLEnabled =false;
    public static string AutoAlert_PassWord = "";

    public static string getConnectionString()
    {
        return "Provider=sqloledb;Server=" + strDBServerName + ";Database=" + strDBName + ";User ID=" + strDBUser + "; Password=" + strDBPW;
    }

    public static bool GetConfigaration()
    {
        bool status = true;
        try
        {
            if (System.IO.File.Exists("config.ini"))
            {
                System.IO.StreamReader file = new System.IO.StreamReader("config.ini");
                //strDBServerName = file.ReadLine();
                //strDBName = file.ReadLine();
                //strDBUser = file.ReadLine();
                //strDBPW = file.ReadLine();

                strDBServerName = clsSecurity.decryptPassword(file.ReadLine());
                strDBName = clsSecurity.decryptPassword(file.ReadLine());
                strDBUser = clsSecurity.decryptPassword(file.ReadLine());
                strDBPW = clsSecurity.decryptPassword(file.ReadLine());

                file.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Configuration file not exists");
                status = false;
            }
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.ToString());
            status = false;
        }
        return status;
    }
}
