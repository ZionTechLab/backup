import * as Config from "../../Common/Config";
import { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getInventory } from "../../store";
import Box from "@mui/material/Box";
import Enumerable from "linq";
import MyComponent from "./txn";
import classes from "./Customer2.module.css";
import Checkbox from "@mui/material/Checkbox";
import Modal from "@mui/material/Modal";
import CloseIcon from "@mui/icons-material/Close";

function Customer() {
  const [Customers, setCustomers] = useState([]);
  const [Outstanding, setOutstanding] = useState([]);
  const [dataset, setdataset] = useState([]);
  const [route, setRoute] = useState([]);
  const [checked, setChecked] = useState(true);
  const [open, setOpenImage] = useState(false);

  const handleClose = () => {
    setOpenImage(false);
  };

  const showImage = (customer_ID) => {
    console.log(customer_ID);
    setOpenImage(true);

    let dd = dataset.filter((p) => p.customer_ID === customer_ID);
    console.log(dd[0].Txn);
    setOutstanding(dd[0].Txn === undefined ? [] : dd[0].Txn);
  };

  const onSearch = (FilterText) => {
    console.log(FilterText);
    let xxx = Customers.filter((item) =>
      item.customerName.toUpperCase().includes(FilterText.toUpperCase())
    );

    setdataset(xxx);

    console.log(xxx);
  };

  const handleChange = (event) => {
    setChecked(event.target.checked);
  };

  const options = {
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  };
  useEffect(() => {
    let c = JSON.parse(localStorage.getItem("customer"));
    let zz = JSON.parse(localStorage.getItem("customerOutstanding"));
    let r = localStorage.getItem("route").split(",");

    setRoute(r);

    c = c.filter((customer) =>
      r.some((route) => route === customer.route_Code)
    );

    const groupedTransactions = Enumerable.from(zz)
      .groupBy((transaction) => transaction.customerID)
      .select((group) => ({
        customerID: group.key(),
        Txn: group.toArray(),
        summary: group.sum((transaction) => transaction.amount),
        outstanding: group.sum((transaction) =>
          transaction.transactionType == 5 ? 0 : transaction.amount
        ),
      }))
      .toArray();

    console.log(groupedTransactions);

    const result3 = Enumerable.from(c)
      .leftJoin(
        groupedTransactions,
        (pk) => pk.customer_ID,
        (fk) => fk.customerID,
        (left, right) => ({ ...left, ...right })
      )
      .toArray();
    setCustomers(result3);
    setdataset(result3);

    console.log(result3);
  }, []);

  return (
    <div>
      <div>
        <div className={classes.appBar2}>
          <div>
            Find :{" "}
            <input
              type="text"
              id="filled-basic"
              label="search"
              variant="filled"
              onChange={(event) => {
                onSearch(event.target.value);
              }}
            />
          </div>
          {/* <div>
            <Checkbox
              checked={checked}
              onChange={handleChange}
              inputProps={{ "aria-label": "controlled" }}
            />
            Outstanding Only
          </div> */}
        </div>
      </div>
      <div>
        {route.map((r) => (
          <div>
            Route - {r}
            {dataset
              .filter((outstanging) => outstanging.route_Code === r)

              .map((row) => (
                <div
                  className={classes.card}
                  onClick={() => showImage(row.customer_ID)}
                >
                  <div className={classes.customerCard}>
                    <div className={classes.cusCode}>{row.customer_ID}</div>
                    <div className={classes.cusName}>{row.customerName}</div>
                    <div className={classes.cusTotal}>
                      {row.outstanding === undefined
                        ? "0.00"
                        : row.outstanding.toLocaleString(undefined, options)}
                    </div>

                    {/* <div className={classes.cusTotal}>
                      {row.summary === undefined
                        ? "0.00"
                        : row.summary.toLocaleString(undefined, options)}
                    </div> */}
                  </div>
                  {/* <MyComponent txn={row.Txn} /> */}
                </div>
              ))}
          </div>
        ))}
      </div>
      <Modal open={open} onClose={handleClose}>
        <div className={classes.itemModal}>
          <CloseIcon
            fontSize="70px"
            className={classes.CloseButton}
            onClick={handleClose}
          />

          <MyComponent txn={Outstanding} />
        </div>
      </Modal>
    </div>
  );
}

export default Customer;
