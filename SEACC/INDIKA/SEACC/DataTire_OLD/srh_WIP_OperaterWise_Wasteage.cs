using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_WIP_OperaterWise_Wasteage {
		
        #region Fields
        private string productionJob_ID;     
        private string section_ID;
        private string employee_ID;
        private string employeeName;
        private decimal weightWasteage;
        private decimal weighOut;
        private string sectionName;
        private DateTime dateStart;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_WIP_ProductionAndWasteage class.
		/// </summary>
		public srh_WIP_OperaterWise_Wasteage() {
		}
		
	
		#endregion
		
		#region Properties	
      
        public string ProductionJob_ID
        {
            get { return productionJob_ID; }
            set { productionJob_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Section_ID value.
        /// </summary>
        public string Section_ID
        {
            get { return section_ID; }
            set { section_ID = value; }
        }


        /// <summary>
        /// Gets or sets the Section_ID value.
        /// </summary>
        public string Employee_ID
        {
            get { return employee_ID; }
            set { employee_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Section_ID value.
        /// </summary>
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }


		/// <summary>
		/// Gets or sets the WeightWasteage value.
		/// </summary>
		public decimal WeightWasteage {
			get { return weightWasteage; }
			set { weightWasteage = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeighOut value.
		/// </summary>
		public decimal WeighOut {
			get { return weighOut; }
			set { weighOut = value; }
		}	
		

		/// <summary>
		/// Gets or sets the SectionName value.
		/// </summary>
		public string SectionName {
			get { return sectionName; }
			set { sectionName = value; }
		}

        /// <summary>
        /// Gets or sets the  ProductionOrderDate value.
        /// </summary>
        public DateTime DateStart
        {
            get { return dateStart; }
            set { dateStart = value; }
        }
		#endregion
		
		#region Methods
        public static List<srh_WIP_OperaterWise_Wasteage> SelectAll(DateTime dateFrom, DateTime dateTo)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("srh_WIP_OperaterWise_WasteageSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1) ;

            List<srh_WIP_OperaterWise_Wasteage> srh_WIP_ProductionAndWasteageList = new List<srh_WIP_OperaterWise_Wasteage>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_WIP_OperaterWise_Wasteage srh_WIP_ProductionAndWasteage = Makesrh_WIP_ProductionAndWasteage(dataReader);
                    srh_WIP_ProductionAndWasteageList.Add(srh_WIP_ProductionAndWasteage);
                }
            }
            scon.Close();
            return srh_WIP_ProductionAndWasteageList;
        }
		private static srh_WIP_OperaterWise_Wasteage Makesrh_WIP_ProductionAndWasteage(SqlDataReader dataReader) {
            srh_WIP_OperaterWise_Wasteage srh_WIP_ProductionAndWasteage = new srh_WIP_OperaterWise_Wasteage();
			
			if (dataReader.IsDBNull(0) == false) {
                srh_WIP_ProductionAndWasteage.ProductionJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
                srh_WIP_ProductionAndWasteage.Section_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
                srh_WIP_ProductionAndWasteage.Employee_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
                srh_WIP_ProductionAndWasteage.EmployeeName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
                srh_WIP_ProductionAndWasteage.WeightWasteage = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
                srh_WIP_ProductionAndWasteage.WeighOut = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
                srh_WIP_ProductionAndWasteage.SectionName = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_WIP_ProductionAndWasteage.DateStart = dataReader.GetDateTime(7);
			}
			
			return srh_WIP_ProductionAndWasteage;
		}		
		#endregion
	}
}
