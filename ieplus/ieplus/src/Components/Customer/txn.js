import React from "react";
// import classes from "./item.module.css";
import { useState, useEffect } from "react";
import classes from "./Customer2.module.css";

const MyComponent = (props) => {
  const [txn, settxn] = useState([]);

  useEffect(() => {
    //  console.log(props.txn);

    settxn(props.txn == undefined ? [] : props.txn);
    //  console.log(props.txn === undefined ? [] : props);
  }, []);
  const options = {
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  };
  return (
    <div className={classes.moddle}>
      {txn.map((row) => (
        <div
          className={`${classes.carditem} ${
            row.transactionType == 5 ? classes.CIH : ""
          }`}
        >
          <div className={classes.txncode}>{row.transactionCode}</div>
          <div className={classes.txndate}>
            {new Date(row.transactionDate).toLocaleDateString("en-US")}
          </div>
          <div className={classes.txnremarks}>{row.transactionRemark}</div>
          <div className={classes.txnage}>{row.age}</div>

          <div className={classes.txnamount}>
            {row.amount.toLocaleString(undefined, options)}
          </div>
        </div>
      ))}
    </div>
  );
};

export default MyComponent;
