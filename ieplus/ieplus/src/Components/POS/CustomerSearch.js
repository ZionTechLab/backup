import React, { useState, useEffect } from "react";
import linq from "linq";
import classes from "./CustomerSearch.module.css";
import Autocomplete from "../UI/Autocomplete/Autocomplete";
import KpiCard from "../UI/Cards/KpiCard";
import { Price } from "../../Common/DecimalFormater";

const CustomerSearch = (props) => {
  const [Customers, setCustomers] = useState([]);
  const [Customers1, setCustomers1] = useState([]);
  const [Customer_Selected, setCustomer_Selected] = useState([]);
  const [Outstanding, setOutstanding] = useState([]);
  const [Outstanding_Selected, setOutstanding_Selected] = useState([]);
  const [isHide, setisHide] = useState(true);

  const mount = () => {
    let cus = JSON.parse(localStorage.getItem("customer"));

    var result = linq
      .from(cus)
      .select((user) => ({
        key: user.customer_ID,
        value: user.customerName,
      }))
      .toArray();

    setCustomers(cus);
    setCustomers1(result);
    let dd = JSON.parse(localStorage.getItem("customerOutstanding"));

    setOutstanding(dd);
  };

  const inputChangedHandler = (customer_ID) => {
    if (customer_ID != "") {
      var result = linq
        .from(Customers)
        .where((p) => p.customer_ID == customer_ID)
        .first();

      var result_Outstanding = linq
        .from(Outstanding)
        .where((p) => p.customerID == customer_ID)
        .toArray();

      setCustomer_Selected(result);
      setOutstanding_Selected(result_Outstanding);
      setisHide(false);
    } else {
      setCustomer_Selected([]);
      setOutstanding_Selected([]);
      setisHide(true);
    }
    if (customer_ID != '')
      props.CustomerSelectionChanged(result);
    else
      props.CustomerSelectionChanged(null);
  };

  useEffect(mount, []);
  let cusDetail = '';
  if (!isHide) {
    cusDetail = (
      <div >
        <div className='BoxShadow'>
          <div className={classes.CustomerDetail}>
            <div>Customer Code</div>
            <div>:</div>
            <div>{Customer_Selected.customer_ID}</div>

            <div>Telephone</div>
            <div>:</div>
            <div>{Customer_Selected.telephone}</div>

            <div>Mobile</div>
            <div>:</div>
            <div>{Customer_Selected.mobile}</div>

            <div>Address</div>
            <div>:</div>
            <div>{Customer_Selected.addressRegister}</div>

            <div className={classes.Route}> {Customer_Selected.route_Code}</div>
          </div>
        </div>
        <div className={classes.grid}>
          <KpiCard Color="#332722" Heading="Cr. Period" Value1="0" />
          <KpiCard Color="#f39c12" Heading="Credit Limit" Value1="0" />
          <KpiCard
            Color="#e74c3c"
            Heading="Outstanding"
            Value1={
              Customer_Selected.outstanding == null
                ? 0
                : Customer_Selected.outstanding
            }
          />
          <KpiCard Color="#4fb443" Heading="Balance" Value1="0" />
        </div>

        <div className={classes.KpiContainer}>
          <div className='BoxShadow'>
            <h5>Outstanding Invoices</h5>
            <div className={classes.GridHeader}>
              <div>Inv. Date</div>
              <div>Inv. No.</div>
              <div className={classes.right}>Amount</div>
              <div className={classes.right}>Balance</div>
            </div>
            {Outstanding_Selected.filter(
              (outstanging) =>
                outstanging.transactionType === 2 ||
                outstanging.transactionType === 1
            ).map((row) => (
              <div className={classes.GridDetail}>
                <div>
                  {new Date(row.transactionDate).toLocaleDateString("en-US")}
                </div>
                <div> {row.transactionCode}</div>
                <div className={classes.right}>
                  <Price showDecimals={true} showSymbol={false}>
                    {row.totalAmount}{" "}
                  </Price>
                </div>
                <div className={classes.right}>
                  <Price showDecimals={true} showSymbol={false}>
                    {row.amount}
                  </Price>
                </div>
              </div>
            ))}
          </div>
          <div className='BoxShadow'>
            <h5>Returned Cheques</h5>
            <div className={classes.GridHeader}>
              <div>Inv. Date</div>
              <div>Inv. No.</div>
              <div className={classes.right}>Amount</div>
              <div className={classes.right}>Balance</div>
            </div>
            {Outstanding_Selected.filter(
              (outstanging) => outstanging.transactionType === 3
            ).map((row) => (
              <div className={classes.GridDetail}>
                <div>
                  {new Date(row.transactionDate).toLocaleDateString("en-US")}
                </div>
                <div> {row.transactionCode}</div>
                <div className={classes.right}>
                  <Price showDecimals={true} showSymbol={false}>
                    {row.totalAmount}{" "}
                  </Price>
                </div>
                <div className={classes.right}>
                  <Price showDecimals={true} showSymbol={false}>
                    {row.amount}
                  </Price>
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>

    );
  }
  return (
    <div className={classes.Margin}>
      <div className={classes.heading}>
        <h2>Find Customer</h2>
      </div>
      <div className={classes.srh}>
        <Autocomplete
          options={Customers1}
          changed={(event) => inputChangedHandler(event)}
        />
      </div>
      {cusDetail}
    </div>
  );
};
export default CustomerSearch;
