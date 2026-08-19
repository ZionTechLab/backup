import React from "react";
import classes from "./item.module.css";
import { useState, useEffect } from "react";

const MyComponent = (props) => {
  const options = {
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  };

  useEffect(() => {
    console.log(props);
  }, []);

  let x =
    props.user_id == "indika" ? (
      <div>
        Cost Price :{" "}
        {props.item.costPrice_WA.toLocaleString(undefined, options)}
      </div>
    ) : (
      ""
    );

  return (
    <div className={classes.card}>
      <div className={classes.carditem_Itemcode}>
        {props.item.item_ID} - {props.item.itemName}
      </div>
      <div className={classes.carditem}>
        <div className={classes.carditem_50}>
          Stock : {props.item.qty.toLocaleString()} {props.item.uomCode}
        </div>
        <div className={classes.carditem_50}>
          Packing Size : {props.item.packingSize.toLocaleString()}
        </div>
      </div>
      <div className={classes.carditem}>
        <div className={classes.carditem_Cost}>{x}</div>
        <div className={classes.carditem_price}>
          {props.item.sellingPrice.toLocaleString(undefined, options)}
        </div>
      </div>
    </div>
  );
};

export default MyComponent;
