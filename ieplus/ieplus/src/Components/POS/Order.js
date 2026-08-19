import { Component } from "react";
import { connect } from "react-redux";
import TextField from "@material-ui/core/TextField";
import Item from "./Item2";
import CustomerSearch from "./CustomerSearch";
import linq from "linq";
import classes from "./Order.module.css";
import Modal from "@material-ui/core/Modal";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableRow from "@material-ui/core/TableRow";

class Order extends Component {
  state = {
    showItemSearch: false,
    FilterdList: [],
    value: "",
    OrderItems: [],
    Customer: [],
    SelectedCustomerValidity: 0,// 0-invalid 1- valied 2-confirmed 
  };

  componentDidMount() {
    // let cus = linq
    //   .from(JSON.parse(localStorage.getItem("customer")))
    //   .orderBy((p) => p.customerName)
    //   .toArray();

    // console.log(cus);

    // this.setState({
    //   Customers: cus,
    // });

    this.updateFilter("");
  }
  onSearch = (event) => {
    // console.log('ado')
    this.updateFilter(event.target.value.toUpperCase());
  };
  updateFilter = (value) => {
    let result = linq
      .from(this.props.items)
      .where((p) => p.itemName.toUpperCase().includes(value))
      .take(10)
      .toArray();

    this.setState({
      FilterdList: result,
    });
  };

  inputChangedHandler = (event, controlID) => {

    // console.log(this.state.OrderItems);

    let updatedControls = {
      ...this.state.OrderItems,
      [controlID]: {
        ...this.state.OrderItems[controlID],
        Amount: event.Amount,
        DiscountPre: event.DiscountPre,
      },
    };

    this.setState({
      OrderItems: updatedControls,
    });
  };

  customerUpdated = (customer) => {
    let v = 0;
    // console.log(customer);
    if (customer != null) {
      if (customer.customer_ID != '')
        v = 1;
    }
    this.setState({
      SelectedCustomerValidity: v,
      Customer: customer,
    });
  };

  customerConfirmed = () => {

    this.setState({
      SelectedCustomerValidity: 2,
    });
  };

  ItemSelected = (event, newValue) => {

    if (this.state.OrderItems.length != 0) {

      if (this.state.OrderItems[newValue.item_ID] != undefined && this.state.OrderItems[newValue.item_ID] != null) {
        alert("Selected item already added!");
        return;
      }

    }

    if (newValue != null) {


      var newArray = {
        ...this.state.OrderItems,
        [newValue.item_ID]: newValue,
      };

      this.setState({
        OrderItems: newArray,
        showItemSearch: false,
      });
    }
  };

  render() {
    const formElementsArray = [];
    let Sum = 0;

    for (let key in this.state.OrderItems) {
      let item = this.state.OrderItems[key];
      Sum += item.Amount;
      formElementsArray.push({
        item_ID: key,
        itemName: item.itemName,
        Amount: item.Amount,
      });
    }
    let modal = (
      <div>
        <Modal open={this.state.showItemSearch}>
          <div className={classes.model}>
            <div>


              <TextField
                id="filled-basic"
                label="Find Item"
                variant="filled"
                onChange={this.onSearch}
              // value={this.state.searchedValue}
              />
            </div>
            <Table stickyHeader size="small" aria-label="sticky table">
              <TableBody>
                {this.state.FilterdList.map((row) => (
                  <TableRow
                    hover
                    role="checkbox"
                    key={row.item_ID}
                    onClick={(event) => this.ItemSelected(event, row)}
                  >
                    <TableCell component="th" scope="row">
                      {" "}
                      {row.item_ID}
                    </TableCell>
                    <TableCell align="left">{row.itemName}</TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </div>
        </Modal>
      </div>
    );

    // let OrderForm = (

    // );

    let CustomerFind = '';
    if (this.state.SelectedCustomerValidity == 2) {
      // console.log(this.state.SelectedCustomerValidity);
      CustomerFind = (<div>

        <div className={classes.CustomerDetail}> <div className='BoxShadow'>
          <h5>{this.state.Customer.customer_ID} - {this.state.Customer.customerName}</h5>
        </div>
        </div>

        <div>
          {formElementsArray.map((row) => (
            <Item
              key={row.item_ID}
              item_ID={row.item_ID}
              itemName={row.itemName}
              UnitPrice="100.00"
              PackingSize="10"
              MaxDiscount="25"
              changed={(event) => this.inputChangedHandler(event, row.item_ID)}
            />
          ))}
          <div className={classes.AddItem} onClick={() => this.setState({ showItemSearch: true })}       >
            Add Item
          </div>
          {Sum}
          {modal}
        </div>
      </div>)
    }
    else {
      CustomerFind = (
        <div>
          <CustomerSearch CustomerSelectionChanged={(event) => this.customerUpdated(event)} />
          {this.state.SelectedCustomerValidity === 1 ?
            <div className={classes.btn}>
              <button className='btn' onClick={(event) => this.customerConfirmed()}    >Select</button>
            </div>
            : ""}
        </div>
      )
    }

    return (
      <div className="Form">
        {CustomerFind}





      </div>
    );
  }
}

let mapStateToProps = (state) => {
  return {
    stock: state.inventory.stock,
    items: state.init.items,
  };
};

export default connect(mapStateToProps, null)(Order);
