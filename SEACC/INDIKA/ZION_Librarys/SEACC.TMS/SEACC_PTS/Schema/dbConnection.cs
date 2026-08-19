using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

class dbConnection
{
	public OleDbConnection scon = new OleDbConnection(settings.getConnectionString());
	public DataTable ResultTable = new DataTable();
	public string strErrorMsg = "";
	public bool SelectToDataTable(string script)
	{
		bool bReturn = true;
		ResultTable.Clear();
		ResultTable.Columns.Clear();
		strErrorMsg = "";
		try
		{
			scon.Open();
			OleDbDataAdapter ad = new OleDbDataAdapter(script, scon);
			ad.Fill(ResultTable);
		}
        catch (OleDbException ex)
        {
            bReturn = false;
            strErrorMsg = ex.Message;
            System.Windows.Forms.MessageBox.Show(strErrorMsg);

        }
		catch (Exception ex2)
		{
			bReturn = false;
			strErrorMsg = ex2.Message;
			System.Windows.Forms.MessageBox.Show(strErrorMsg);
         
		}
            
		finally
		{
			scon.Close();
		}
		return bReturn;
	}
    public bool Execute_Quary(string script)
    {
        try
        {
            scon.Open();
            OleDbCommand scom = new OleDbCommand(script, scon);
            scom.ExecuteNonQuery();
            return true;
        }
        catch (OleDbException ex)
        {
            if (ex.ErrorCode == -2147467259)
            {
                System.Windows.Forms.MessageBox.Show("Connection failed");
            }
            else
            {
                strErrorMsg = ex.Message;
                System.Windows.Forms.MessageBox.Show(strErrorMsg);
            }
            return false;
        }
        catch (Exception ex)
        {

            strErrorMsg = ex.Message; System.Windows.Forms.MessageBox.Show(strErrorMsg);
            return false;
        }
        finally
        {
            scon.Close();
        }
    }

    public string Execute_Quary(string script,ref bool bStatus)
    {
        bStatus = false;
        try
        {
            scon.Open();
            OleDbCommand scom = new OleDbCommand(script, scon);
            string sResult = scom.ExecuteScalar().ToString();
            bStatus = true;
            return sResult;
        }
        catch (OleDbException ex)
        {
            if (ex.ErrorCode == -2147467259)
            {
                System.Windows.Forms.MessageBox.Show("Connection failed");
            }
            else
            {
                strErrorMsg = ex.Message;
                System.Windows.Forms.MessageBox.Show(strErrorMsg);
            }
            return "";
        }
        catch (Exception ex)
        {
            strErrorMsg = ex.Message; System.Windows.Forms.MessageBox.Show(strErrorMsg);
            return "";
        }
        finally
        {
            scon.Close();
        }
    }
}
