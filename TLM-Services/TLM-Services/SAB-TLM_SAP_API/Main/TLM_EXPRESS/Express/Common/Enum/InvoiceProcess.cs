using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Common.Enum
{
    /// <summary>
    /// Keep status of invoice or payment process
    /// </summary>
    public enum InvoiceProcess
    {
        /// <summary>
        /// invoice procced
        /// </summary>
        INVOICE,
        /// <summary>
        /// payment procced
        /// </summary>
        PAYMENT,
        /// <summary>
        /// invoice and payment procced
        /// </summary>
        INVPAY,
        /// <summary>
        /// invoice and payment bill
        /// </summary>
        BILL,     
        /// <summary>
        /// block for bill , invoice and payment
        /// </summary>
        BLOCK,
        /// <summary>
        /// block for invoice
        /// </summary>
        BLOCKINV,
        /// <summary>
        /// block for payment
        /// </summary>
        BLOCKPAY,
        NEW,



    }
}
