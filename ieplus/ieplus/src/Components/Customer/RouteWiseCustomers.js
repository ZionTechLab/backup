import { Component } from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";

import linq from "linq";
import Modal from "@mui/material/Modal";
import classes from "./Customers.module.css";

import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import Typography from "@mui/material/Typography";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";

import Grid from "@mui/material/Grid";
import Customers from "./Customers";

class RouteWiseCustomers extends Component {
  state = {
    Customers: [],
    Customers_Filtered: [],
    open: false,
    selectedCustomer_Code: "",
    selectedcustomerName: "",
    outstanding: [],
    outstandingSelected: [],
    RouteWiseCustomers: [],
  };

  handleOpen = (data) => {
    this.setState({
      open: true,
      selectedCustomer_Code: data.Customer_Code,
      selectedcustomerName: data.customer_Name,
      outstandingSelected: this.state.outstanding.filter(
        (outstanging) => outstanging.customerID === data.Customer_Code
      ),
    });
    console.log(data.Customer_Code);
  };

  handleClose = () => {
    this.setState({
      open: false,
    });
  };

  componentDidMount() {
    let route = localStorage.getItem("route");
    const arrayRoute = route.split(",");
    console.log(arrayRoute);
    let cus = linq
      .from(JSON.parse(localStorage.getItem("customer")))
      .where((c) => arrayRoute.includes(c.route_Code.toUpperCase()))
      .orderBy((p) => p.customerName)
      .toArray();

    var result = linq
      .from(cus)
      .groupBy(
        (g) => g.route_Code,
        (d) => d,
        (key, val) => ({ key, val: val.toArray() })
      )
      .orderBy((p) => p.key)
      .toArray();

    //let ro=   linq.from(cus).groupBy(p=> p.route_Code,s=>).select(r=>new {route_Code=r.route_Code}).toArray();
    console.log(result);
    this.setState({
      Customers: cus,
      outstanding: JSON.parse(localStorage.getItem("customerOutstanding")),
      RouteWiseCustomers: result,
    });
  }

  onSearch = (event) => {
    // console.log(event.target.value);
    let result3 = linq
      .from(this.state.Customers)
      .where((p) =>
        p.customerName.toUpperCase().includes(event.target.value.toUpperCase())
      )
      .take(15)
      .toArray();
    //    console.log(this.state.Customers);

    this.setState({
      Customers_Filtered: result3,
    });
  };

  body = (
    <div>
      <h2 id="simple-modal-title">Text in a modal</h2>
      <p id="simple-modal-description">
        Duis mollis, est non commodo luctus, nisi erat porttitor ligula.
      </p>
    </div>
  );
  render() {
    return (
      <div>
        f
        {/* <TextField id="filled-basic" label="search" variant="filled" onChange={this.onSearch} value={this.state.searchedValue} /> */}
        <div className="Page-Cotaint">
          <Paper>
            {this.state.RouteWiseCustomers.map((row) => (
              <Accordion>
                <AccordionSummary
                  expandIcon={<ExpandMoreIcon />}
                  aria-controls="panel1a-content"
                  id="panel1a-header"
                >
                  <Typography className={classes.heading}>{row.key}</Typography>
                </AccordionSummary>
                <AccordionDetails>
                  <Grid item xs={12}>
                    <Customers
                      Data={row.val}
                      onClick={(data) => this.handleOpen(data)}
                    />
                  </Grid>
                </AccordionDetails>
              </Accordion>
            ))}

            <Modal open={this.state.open} onClose={this.handleClose}>
              <div className={classes.CustomerDetail}>
                {this.state.selectedcustomerName}
                <h4>Invoices</h4>
                <Table stickyHeader size="small" aria-label="sticky table">
                  <TableHead>
                    <TableRow>
                      <TableCell>
                        <div className={classes.row11}>Inv. No.</div>
                      </TableCell>
                      <TableCell>
                        <div className={classes.row11}>Inv. date</div>
                      </TableCell>
                      <TableCell>
                        <div className={classes.row11}>Inv Amount</div>
                      </TableCell>
                      <TableCell>
                        <div className={classes.row11}>Balance</div>
                      </TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {this.state.outstandingSelected
                      .filter(
                        (outstanging) =>
                          outstanging.transactionType === 2 ||
                          outstanging.transactionType === 1
                      )
                      .map((row) => (
                        <TableRow hover role="checkbox" key={row.customer_ID}>
                          <TableCell component="th" scope="row">
                            {" "}
                            <div className={classes.row11}>
                              {row.transactionCode}
                            </div>
                          </TableCell>
                          <TableCell align="left">
                            <div className={classes.row11}>
                              {new Date(row.transactionDate).toLocaleDateString(
                                "en-US"
                              )}
                            </div>
                          </TableCell>
                          <TableCell align="left">
                            <div className={classes.row11}>
                              {row.totalAmount}
                            </div>
                          </TableCell>
                          <TableCell align="left">
                            <div className={classes.row11}>{row.amount}</div>
                          </TableCell>
                        </TableRow>
                      ))}
                  </TableBody>
                </Table>

                <h4>Returned Cheques</h4>
                <Table stickyHeader size="small" aria-label="sticky table">
                  <TableHead>
                    <TableRow>
                      <TableCell>
                        <div className={classes.row11}>Inv. No.</div>
                      </TableCell>
                      <TableCell>
                        <div className={classes.row11}>Inv. date</div>
                      </TableCell>
                      <TableCell>
                        <div className={classes.row11}>Inv Amount</div>
                      </TableCell>
                      <TableCell>
                        <div className={classes.row11}>Balance</div>
                      </TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {this.state.outstandingSelected
                      .filter(
                        (outstanging) => outstanging.transactionType === 3
                      )
                      .map((row) => (
                        <TableRow hover role="checkbox" key={row.customer_ID}>
                          <TableCell component="th" scope="row">
                            {" "}
                            <div className={classes.row11}>
                              {row.transactionCode}
                            </div>
                          </TableCell>
                          <TableCell align="left">
                            <div className={classes.row11}>
                              {new Date(row.transactionDate).toLocaleDateString(
                                "en-US"
                              )}
                            </div>
                          </TableCell>
                          <TableCell align="left">
                            <div className={classes.row11}>
                              {row.totalAmount}
                            </div>
                          </TableCell>
                          <TableCell align="left">
                            <div className={classes.row11}>{row.amount}</div>
                          </TableCell>
                        </TableRow>
                      ))}
                  </TableBody>
                </Table>

                {/* <h4>Cheques In Hand</h4>
                <Table stickyHeader size="small" aria-label="sticky table" >
                <TableHead>
                  <TableRow>
                  <TableCell ><div className={classes.row11}>Inv. No.</div></TableCell>
                    <TableCell><div className={classes.row11}>Inv. date</div></TableCell>
                    <TableCell><div className={classes.row11}>Inv Amount</div></TableCell>
                    <TableCell><div className={classes.row11}>Balance</div></TableCell>
                    

                  </TableRow>
                </TableHead>
                <TableBody>
                  {this.state.outstandingSelected.filter((outstanging)=>outstanging.transactionType===5).map((row) => (
                    <TableRow hover role="checkbox" key={row.customer_ID}>
                     <TableCell  component="th" scope="row"> <div className={classes.row11}>{row.transactionCode}</div></TableCell>
                      <TableCell align="left"><div className={classes.row11}>{(new Date(row.transactionDate)).toLocaleDateString("en-US")}</div></TableCell>
                      <TableCell align="left"><div className={classes.row11}>{row.totalAmount}</div></TableCell>
                      <TableCell align="left"><div className={classes.row11}>{row.amount}</div></TableCell>
 
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
 */}

                {/* <h4>Other</h4>
                <Table stickyHeader size="small" aria-label="sticky table" >
                <TableHead>
                  <TableRow>
                  <TableCell ><div className={classes.row11}>Inv. No.</div></TableCell>
                    <TableCell><div className={classes.row11}>Inv. date</div></TableCell>
                    <TableCell><div className={classes.row11}>Inv Amount</div></TableCell>
                    <TableCell><div className={classes.row11}>Balance</div></TableCell>
                 

                  </TableRow>
                </TableHead>
                <TableBody>
                  {this.state.outstandingSelected.filter((outstanging)=>
                  outstanging.transactionType===4 || outstanging.transactionType===0
                  ||outstanging.transactionType===7 || outstanging.transactionType===8
                 || outstanging.transactionType===9 || outstanging.transactionType===10
                  ).map((row) => (
                    <TableRow hover role="checkbox" key={row.customer_ID}>
                     <TableCell  component="th" scope="row"> <div className={classes.row11}>{row.transactionCode}</div></TableCell>
                      <TableCell align="left"><div className={classes.row11}>{(new Date(row.transactionDate)).toLocaleDateString("en-US")}</div></TableCell>
                      <TableCell align="left"><div className={classes.row11}>{row.totalAmount}</div></TableCell>
                      <TableCell align="left"><div className={classes.row11}>{row.amount}</div></TableCell>
 
                    </TableRow>
                  ))}
                </TableBody>
              </Table> */}
              </div>
            </Modal>
          </Paper>
        </div>
        {/* <Contacts contacts={this.state.contacts} /> */}
      </div>
    );
  }
}

export default RouteWiseCustomers;
