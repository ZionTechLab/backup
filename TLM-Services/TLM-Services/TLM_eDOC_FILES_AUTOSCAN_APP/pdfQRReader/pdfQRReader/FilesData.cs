using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfQRReader
{
    public class FilesData
    {

		public List<FileQRDataDomainView> GetPendingList(string FileType,string ScanType)
		{
			List<FileQRDataDomainView> result;
			using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
			{
				result = Enumerable.ToList<FileQRDataDomainView>(SqlMapper.Query<FileQRDataDomainView>(dbConnection, "[eDoc].[TLMV2_GetPendingScanFiles] @FileType, @ScanType", new
				{
					FileType = FileType,
					ScanType = ScanType
				}, null, true, default(int?), default(CommandType?)));
			}
			return result;
		}
		public DataTable ToDataTables<T>(IList<T> data)
		{
			PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
			DataTable table = new DataTable();
			for (int i = 0; i < props.Count; i++)
			{
				PropertyDescriptor prp = props[i];
				table.Columns.Add(prp.Name, Nullable.GetUnderlyingType(prp.PropertyType) ?? prp.PropertyType);
			}
			object[] values = new object[props.Count];
			foreach (T item in data)
			{
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = props[i].GetValue(item) ?? DBNull.Value;
				}
				table.Rows.Add(values);
			}
			return table;
		}

		public ResponseMessage SaveQRScanData(List<FileQRDataDomainView> QRData, string ScanType)
		{
			ResponseMessage result = new ResponseMessage();
			try
			{
				 
				using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
				{
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
					result = Enumerable.FirstOrDefault(SqlMapper.Query<ResponseMessage>(dbConnection, "[eDoc].[TLMV2_SaveScanData] @ScanData, @ScanType", new
					{
						ScanData = ToDataTables(QRData).AsTableValuedParameter("eDoc.TEMPScanData"),
						ScanType = ScanType
					}, null, true, default(int?), default(CommandType?)));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
				}
			}
			catch(Exception ex)
            {

            }
			return result;
		}

	}
}
