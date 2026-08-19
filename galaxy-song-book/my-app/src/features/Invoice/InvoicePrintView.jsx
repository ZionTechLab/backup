import {  useState,useEffect } from "react";
import ApiService from "./InvoiceService";
import transformDateFields from "../../helpers/transformDateFields";
import formatAmount from '../../helpers/formatAmount';
import './Invoice.css';
import InvoiceHeader from './InvoiceHeader';

const InvoicePrintView = ({ formikValues, lineItems = [], isTaxInvoice,txnType,id,fields }) => {
  const values = formikValues || {};
  const [ReportData, setReportData] = useState({loading: false, success: false, error: '', data: {} });
  useEffect(() => {

    if (id) {
      const fetchTxn = async () => {
        const response = await ApiService.getPrint(id,txnType);
        if (response.success) {
          if (response.data) {
             const normalized = transformDateFields(response.data, fields);
                       
             setReportData(prev => ({ ...prev, ...normalized , loading: false }));
          }
        }
      };
      fetchTxn();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);




  return (
    <div className="invoice-print-layout">
  <InvoiceHeader isTaxInvoice={isTaxInvoice} />
      <div className="row g-2 p-3">
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
                {/* <td className="desc">&nbsp;</td>
                <td className="amt">&nbsp;</td> */}
              </>
            )}

            {/* {Array.from({
              length: Math.max(7 - (lineItems?.length || 0), 0),
            }).map((_, i) => (
              <tr key={`blank-${i}`}>
                <td className="desc">&nbsp;</td>
                <td className="amt">&nbsp;</td>
              </tr>
            ))} */}
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
  {/* {isTaxInvoice} */}
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

      {/* <div className="inv-serial">{values.id || ""}</div> */}
    </div>
  );
};

export default InvoicePrintView;