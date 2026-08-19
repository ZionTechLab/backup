import {  useState,useEffect } from "react";
import ApiService from "./service";
import transformDateFields from "../../helpers/transformDateFields";
import formatAmount from '../../helpers/formatAmount';
import '../Invoice/Invoice.css';
import InvoiceHeader from './InvoiceHeader';
import QRCode from 'react-qr-code';

const InvoicePrintView = ({ formikValues, lineItems = [], isTaxInvoice,txnType,id,fields }) => {
  const values = formikValues || {};
  const [ReportData, setReportData] = useState({loading: false, success: false, error: '', data: {} });
  useEffect(() => {

    if (id) {
      const fetchTxn = async () => {
        const response = await ApiService.getPrint(id);
        if (response.success) {
          if (response.data) {
             const normalized = transformDateFields(response.data, fields);
                       
             setReportData(prev => ({ ...prev, ...normalized , loading: false }));
            // const { lineItems, ...formData } = response.data;
          }
        }
      };
      fetchTxn();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  // derive job id and QR value (use whatever id field is available)
  // const jobId = ReportData?.txnNoDisplay || "";
  // const qrValue = jobId || "";




  return (
    <div className="invoice-print-layout">
      <div className="row g-2 ">
        <div className="col-9 seperator">
          <InvoiceHeader ReportName={ReportData?.reportName} />
          <hr />
        </div>
        <div className="col-3 g-2 p-3">
          <InvoiceHeader ReportName={ReportData?.reportName} />
          <hr />
          <div className="row ">
            <div className="col-12 d-flex align-items-center">
            <div >
              {ReportData?.txnNoDisplay ? (
                <div >
                <QRCode
                  value={ReportData?.txnNoDisplay}
                  size={200}
                  bgColor="#ffffff"
                  fgColor="#000000"
                  level="M"
                  includeMargin={true}
                />
               </div>
            ) : (
              <div className="invoice-qr-placeholder" />
            )}
          </div>
       

        </div>
      </div>
      <div className="row">
       <div className="key">Job No</div>
        <div className="value">{ReportData?.txnNoDisplay}</div>
      </div>
        <div className="row">
       <div className="key">Date</div>
        <div className="value">{ReportData?.txnDate}</div>
      </div>
        <div className="row">
       <div className="key">Customer</div>
        <div className="value">{ReportData?.partnerName}<br/>{ReportData?.address} </div>
        phone
      </div>
       <div className="row">
       <div className="key">Delivered By</div>
        <div className="value">{ReportData?.ref3}</div>
      </div>
          <div className="row">
       <div className="key">Item</div>
        <div className="value">{ReportData?.ref1}</div>
      </div>
         <div className="row">
       <div className="key">Serial No</div>
        <div className="value">{ReportData?.ref2}</div>
      </div>
            <div className="row">
       <div className="key key-long">Fault</div>
        <div className="value">{ReportData?.description}</div>
      </div>
      {/* //need to add box and display {reportdata?.jobTags} -jobTags is a array of strings */}
      <div className="row">
        <div className="key">Accessories</div>
        <div className="value">
          {ReportData?.jobTags?.map((tag, index) => (
            <span key={index} className="badge bg-secondary me-1">
              {tag}
            </span>
          ))}
        </div>
      </div>
      {/* QR code for Job ID */}


      </div>
        <div className="col-6">
          <div className="row">
            <div className="col-5 text-end">
              <b>Customer : </b>
            </div>
            <div className="col-7 text-start">
              {ReportData.partnerName || ""} <br /> {ReportData.address || ""}
      
            </div>
          </div>
          {!isTaxInvoice && (
            <div className="row">
              <div className="col-5 text-end">
                <b>Vehicle :</b>
              </div>
              <div className="col-7 text-start">
                {ReportData.vType || ""} - {ReportData.vehicle || ""}
              </div>
            </div>
          )}
        </div>
        <div className="col-6">
          <div className="row">
            <div className="col-4 text-end">
              <b>Invoice No :</b>
            </div>
            <div className="col-8">{ReportData.txnNoDisplay || ""}</div>
          </div>
          <div className="row">
            <div className="col-4 text-end">
              <b>Invoice Date :</b>
            </div>
            <div className="col-8">{ReportData.txnDate || ""}</div>
          </div>
        </div>
      </div>
      {/* <div className="row g-2 p-3">
        <div className="col-6">
          <div className="row">
              <div className="col-5 text-end">
                <b>To : </b>
              </div>
              <div className="col-7 text-start">
                {ReportData.partnerName || ""} <br /> {ReportData.address || ""}
              </div>
          </div>
          {!isTaxInvoice && (
            <div className="row">
              <div className="col-5 text-end">
                <b>Vehicle :</b>
              </div>
              <div className="col-7 text-start">
                {ReportData.vType || ""} - {ReportData.vehicle || ""}
              </div>
          </div>)}
        </div>
        <div className="col-6">
          <div className="row">
              <div className="col-4 text-end">
                <b>Invoice No :</b>
              </div>
              <div className="col-8">
                {ReportData.txnNoDisplay || ""}
              </div>
          </div>
            <div className="row">
              <div className="col-4 text-end">
                <b>Invoice Date :</b>
              </div>
              <div className="col-8">
                {ReportData.txnDate || ""}
              </div>
          </div>
        </div>
   

      </div> 


      <section className="inv-table">
        <table>
          <thead>
            <tr>
              <th >Description</th>
              <th className="text-end">Amount</th>
            </tr>
          </thead>
          <tbody>
            {lineItems && lineItems.length ? (
              lineItems.map((li, idx) => (
                <tr key={idx}>
                  <td >{li.description}</td>
                  <td className="text-end">{formatAmount(li.amount)}</td>
                </tr>
              ))
            ) : (
              <>
              //  <td className="desc">&nbsp;</td>
              //   <td className="amt">&nbsp;</td> 
              </>
            )}

            // {Array.from({
            //   length: Math.max(7 - (lineItems?.length || 0), 0),
            // }).map((_, i) => (
            //   <tr key={`blank-${i}`}>
            //     <td className="desc">&nbsp;</td>
            //     <td className="amt">&nbsp;</td>
            //   </tr>
            // ))}
           
          </tbody>
        </table>

        <div className="inv-km">K.M. / Hours</div>
      </section>

      <section className="inv-bottom">
        <div className="left">
          <div>
            Prepared by :{" "}
            <span className="inv-dots">
              ......................................
            </span>
          </div>
          <div className="received">Received by</div>
        </div>
        <div className="right">
          <div className="tot-row">
            <span>Amount</span>
            <span>{formatAmount(values.amount)}</span>
          </div>
          {isTaxInvoice!==true && (
            <div className="tot-row">
              <span>Advance</span>
              <span>{formatAmount(values.advance)}</span>
            </div>
  )}

             {isTaxInvoice===true && (
            <div className="tot-row">
              <span>Vat</span>
              <span>{formatAmount(values.taxAmount)}</span>
            </div>
          )}
          <div className="tot-row total">
            <span>Total Amount</span>
            <span>{formatAmount(values.totalAmount)}</span>
          </div>
        </div>
      </section>
*/}
      {/* <div className="inv-serial">{values.id || ""}</div> */}
    </div>
  );
};

export default InvoicePrintView;