using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CredValidityAlert
{
	public class GetReportData : IGetReport
	{
		public List<dynamic> GetExpiredList()
		{
			List<object> result;
			using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
			{
				result = Enumerable.ToList<object>(SqlMapper.Query<object>(dbConnection, "[Express].[TLMV2_CredValidityAlertApp] @Status", new
				{
					Status = "EXPIRED"					
				}, null, true, default(int?), default(CommandType?)));
			}
			return result;
		}

		public List<dynamic> GetSummaryBody()
		{
			List<object> result;
			using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
			{
				result = Enumerable.ToList<object>(SqlMapper.Query<object>(dbConnection, "[Express].[TLMV2_CredValidityAlertApp] @Status", new
				{
					Status = "SUMMARY"
				}, null, true, default(int?), default(CommandType?)));
			}
			return result;
		}

		public List<ReportDocRecepDomain> GetReportsRecep()
		{
			List<ReportDocRecepDomain> result;
			using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
			{
				result = Enumerable.ToList<ReportDocRecepDomain>(SqlMapper.Query<ReportDocRecepDomain>(dbConnection, "[Express].[TLMV2_CredValidityAlertApp] @Status", new
				{
					Status = "CREDVALIDITY"
				}, null, true, default(int?), default(CommandType?)));
			}
			return result;
		}
	}
}
