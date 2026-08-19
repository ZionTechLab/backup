using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tmpStockTracking {
		#region Fields
		private string transaction_ID;
		private DateTime transactionDate;
		private string store_ID;
		private string item_ID;
		private string itemSubcategory_ID;
		private string itemSubcategory_ID2;
		private string itemSerial1;
		private string itemSerial2;
		private decimal qtyGRN;
		private decimal qtyPRN;
		private decimal qtySRN;
		private decimal qtySAN;
		private decimal qtyDGN;
		private decimal qtyDIS;
		private decimal qtyiGIN;
		private decimal qtyiGRN;
		private decimal qtyLIn;
		private decimal qtyLOut;
		private decimal qtyISPIn;
		private decimal qtyISPOut;
		private decimal qtyFGTN;
		private decimal qtyDO;
        private decimal qtyTotal;
        private decimal weightGRN;
        private decimal weightPRN;
        private decimal weightSRN;
        private decimal weightSAN;
        private decimal weightDGN;        
        private decimal weightDIS;
        private decimal weightiGIN;
        private decimal weightiGRN;
        private decimal weightLIn;
        private decimal weightLOut;
        private decimal weightISPIn;
        private decimal weightISPOut;
        private decimal weightFGTN;
        private decimal weightDO;
        private decimal weightTotal;
       
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tmpStockTracking class.
		/// </summary>
		public tbl_tmpStockTracking() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tmpStockTracking class.
		/// </summary>
        public tbl_tmpStockTracking(string transaction_ID, DateTime transactionDate, string store_ID, string item_ID, string itemSubcategory_ID, string itemSubcategory_ID2, string itemSerial1, string itemSerial2, decimal qtyGRN, decimal qtyPRN, decimal qtySRN, decimal qtySAN, decimal qtyDGN, decimal qtyDIS, decimal qtyiGIN, decimal qtyiGRN, decimal qtyLIn, decimal qtyLOut, decimal qtyISPIn, decimal qtyISPOut, decimal qtyFGTN, decimal qtyDO, decimal qtyTotal,
            decimal weightGRN, decimal weightPRN, decimal weightSRN, decimal weightSAN, decimal weightDGN, decimal weightDIS, decimal weightiGIN, decimal weightiGRN, decimal weightLIn, decimal weightLOut, decimal weightISPIn, decimal weightISPOut, decimal weightFGTN, decimal weightDO, decimal weightTotal)
        {
			this.transaction_ID = transaction_ID;
			this.transactionDate = transactionDate;
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.itemSubcategory_ID = itemSubcategory_ID;
			this.itemSubcategory_ID2 = itemSubcategory_ID2;
			this.itemSerial1 = itemSerial1;
			this.itemSerial2 = itemSerial2;
			this.qtyGRN = qtyGRN;
			this.qtyPRN = qtyPRN;
			this.qtySRN = qtySRN;
			this.qtySAN = qtySAN;
			this.qtyDGN = qtyDGN;
			this.qtyDIS = qtyDIS;
			this.qtyiGIN = qtyiGIN;
			this.qtyiGRN = qtyiGRN;
			this.qtyLIn = qtyLIn;
			this.qtyLOut = qtyLOut;
			this.qtyISPIn = qtyISPIn;
			this.qtyISPOut = qtyISPOut;
			this.qtyFGTN = qtyFGTN;
			this.qtyDO = qtyDO;
            this.qtyTotal = qtyTotal;
            this.weightGRN = weightGRN;
            this.weightPRN = weightPRN;
            this.weightSRN = weightSRN;
            this.weightSAN = weightSAN;
            this.weightDGN = weightDGN;
            this.weightDIS = weightDIS;
            this.weightiGIN = weightiGIN;
            this.weightiGRN = weightiGRN;
            this.weightLIn = weightLIn;
            this.weightLOut = weightLOut;
            this.weightISPIn = weightISPIn;
            this.weightISPOut = weightISPOut;
            this.weightFGTN = weightFGTN;
            this.weightDO = weightDO;
            this.weightTotal = weightTotal;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransactionDate value.
		/// </summary>
		public DateTime TransactionDate {
			get { return transactionDate; }
			set { transactionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubcategory_ID value.
		/// </summary>
		public string ItemSubcategory_ID {
			get { return itemSubcategory_ID; }
			set { itemSubcategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubcategory_ID2 value.
		/// </summary>
		public string ItemSubcategory_ID2 {
			get { return itemSubcategory_ID2; }
			set { itemSubcategory_ID2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerial1 value.
		/// </summary>
		public string ItemSerial1 {
			get { return itemSerial1; }
			set { itemSerial1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerial2 value.
		/// </summary>
		public string ItemSerial2 {
			get { return itemSerial2; }
			set { itemSerial2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyGRN value.
		/// </summary>
		public decimal QtyGRN {
			get { return qtyGRN; }
			set { qtyGRN = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyPRN value.
		/// </summary>
		public decimal QtyPRN {
			get { return qtyPRN; }
			set { qtyPRN = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtySRN value.
		/// </summary>
		public decimal QtySRN {
			get { return qtySRN; }
			set { qtySRN = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtySAN value.
		/// </summary>
		public decimal QtySAN {
			get { return qtySAN; }
			set { qtySAN = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyDGN value.
		/// </summary>
		public decimal QtyDGN {
			get { return qtyDGN; }
			set { qtyDGN = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyDIS value.
		/// </summary>
		public decimal QtyDIS {
			get { return qtyDIS; }
			set { qtyDIS = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyiGIN value.
		/// </summary>
		public decimal QtyiGIN {
			get { return qtyiGIN; }
			set { qtyiGIN = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyiGRN value.
		/// </summary>
		public decimal QtyiGRN {
			get { return qtyiGRN; }
			set { qtyiGRN = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyLIn value.
		/// </summary>
		public decimal QtyLIn {
			get { return qtyLIn; }
			set { qtyLIn = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyLOut value.
		/// </summary>
		public decimal QtyLOut {
			get { return qtyLOut; }
			set { qtyLOut = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyISPIn value.
		/// </summary>
		public decimal QtyISPIn {
			get { return qtyISPIn; }
			set { qtyISPIn = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyISPOut value.
		/// </summary>
		public decimal QtyISPOut {
			get { return qtyISPOut; }
			set { qtyISPOut = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyFGTN value.
		/// </summary>
		public decimal QtyFGTN {
			get { return qtyFGTN; }
			set { qtyFGTN = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtyDO value.
		/// </summary>
		public decimal QtyDO {
			get { return qtyDO; }
			set { qtyDO = value; }
		}

        public decimal QtyTotal
        {
            get { return qtyTotal; }
            set { qtyTotal = value; }
        }
        public decimal WeightGRN
        {
            get { return weightGRN; }
            set { weightGRN = value; }
        }
        public decimal WeightPRN
        {
            get { return weightPRN; }
            set { weightPRN = value; }
        }

        public decimal WeightSRN
        {
            get { return weightSRN; }
            set { weightSRN = value; }
        }
        public decimal WeightSAN
        {
            get { return weightSAN; }
            set { weightSAN = value; }
        }

        public decimal WeightDGN
        {
            get { return weightDGN; }
            set { weightDGN = value; }
        }
        public decimal WeightDIS
        {
            get { return weightDIS; }
            set { weightDIS = value; }
        }

        public decimal WeightiGIN
        {
            get { return weightiGIN; }
            set { weightiGIN = value; }
        }

        public decimal WeightiGRN
        {
            get { return weightiGRN; }
            set { weightiGRN = value; }
        }

        public decimal WeightLIn
        {
            get { return weightLIn; }
            set { weightLIn = value; }
        }

        public decimal WeightLOut
        {
            get { return weightLOut; }
            set { weightLOut = value; }
        }
        public decimal WeightISPIn
        {
            get { return weightISPIn; }
            set { weightISPIn = value; }
        }

        public decimal WeightISPOut
        {
            get { return weightISPOut; }
            set { weightISPOut = value; }
        }

        public decimal WeightFGTN
        {
            get { return weightFGTN; }
            set { weightFGTN = value; }
        }

        public decimal WeightDO
        {
            get { return weightDO; }
            set { weightDO = value; }
        }

        public decimal WeightTotal
        {
            get { return weightTotal; }
            set { weightTotal = value; }
        }
		#endregion
		

	}
}
