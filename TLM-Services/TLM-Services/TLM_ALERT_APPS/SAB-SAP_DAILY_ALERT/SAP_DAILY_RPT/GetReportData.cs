using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SAP_DAILY_RPT
{
	public class GetReportData : IGetReport
	{

		public List<dynamic> GetAsAtDateFailedList(string Doctypes)
		{
			List<object> result;
			using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
			{
				result = Enumerable.ToList<object>(SqlMapper.Query<object>(dbConnection, "[SAP].[TLMV2_SAPDailyReport] @Status, @Doctypes", new
				{
					Status = "FAILEDASAT",
					Doctypes = Doctypes
				}, null, true, default(int?), default(CommandType?)));
			}
			return result;
		}


		public List<dynamic> GetFailedList(string Doctypes)
		{
			List<object> result;
			using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
			{
				result = Enumerable.ToList<object>(SqlMapper.Query<object>(dbConnection, "[SAP].[TLMV2_SAPDailyReport] @Status, @Doctypes", new
				{
					Status = "FAILED",
					Doctypes = Doctypes
				}, null, true, default(int?), default(CommandType?)));
			}
			return result;
		}


		public List<dynamic> GetPendingList(string Doctypes)
		{
			List<object> result;
			using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
			{
				result = Enumerable.ToList<object>(SqlMapper.Query<object>(dbConnection, "[SAP].[TLMV2_SAPDailyReport] @Status, @Doctypes", new
				{
					Status = "PENDING",
					Doctypes = Doctypes
				}, null, true, default(int?), default(CommandType?)));
			}
			return result;
		}


		public List<dynamic> GetSuccessList(string Doctypes)
		{
			List<object> result;
			using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
			{
				result = Enumerable.ToList<object>(SqlMapper.Query<object>(dbConnection, "[SAP].[TLMV2_SAPDailyReport] @Status, @Doctypes", new
				{
					Status = "SUCCESS",
					Doctypes = Doctypes
				}, null, true, default(int?), default(CommandType?)));
			}
			return result;
		}


		public List<dynamic> GetSummaryBody(string Doctypes)
		{
			List<object> result;
			using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
			{
				result = Enumerable.ToList<object>(SqlMapper.Query<object>(dbConnection, "[SAP].[TLMV2_SAPDailyReport] @Status, @DocTypes", new
				{
					Status = "SUMMARY",
					Doctypes = Doctypes
				}, null, true, default(int?), default(CommandType?)));
			}
			return result;
		}

		public List<ReportDocRecepDomain> GetReportsRecep()
		{
			List<ReportDocRecepDomain> result;
			using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
			{
				result = Enumerable.ToList<ReportDocRecepDomain>(SqlMapper.Query<ReportDocRecepDomain>(dbConnection, "[SAP].[TLMV2_SAPDailyReport] @Status", new
				{
					Status = "SAPDAILY"
				}, null, true, default(int?), default(CommandType?)));
			}
			return result;
		}
	}
}
