import { Component } from "react";
import classes from "./Item.module.css";
import Modal from "@material-ui/core/Modal";
import { Price } from "../../Common/DecimalFormater";

class RouteWiseCustomers extends Component {
  state = {
    DiscountPre: 0,
    Amount: 0,
    Qty: 0,
  };

  componentDidMount = () => {
    let _qty = Number(this.props.PackingSize);

    this.setState({
      Qty: _qty,
      Amount: this.UpdateAmount(_qty),
    });
  };

  componentDidUpdate = (prevProps, prevState) => {
    //console.log(prevState);
    // console.log(this.state);
    if (this.state.Amount != prevState.Amount) {
      // console.log('Ado');
      // code
      this.props.changed(this.state);
    }
    //else
    //console.log('Not changed');
  };

  QtyUpdate = (isAddition) => {
    let _Qty = this.state.Qty;
    let PackingSize = Number(this.props.PackingSize);

    if (isAddition) {
      _Qty += PackingSize;
    } else {
      _Qty -= PackingSize;
    }

    if (_Qty < 0) _Qty = 0;
    //console.log(_Qty);

    this.setState({
      Qty: _Qty,
      Amount: this.UpdateAmount(_Qty),
    });
  };

  UpdateAmount = (Qty) => {
    let DiscP = Number(this.state.DiscountPre);

    return (Qty * this.props.UnitPrice * (100 - DiscP)) / 100;
  };

  DiscountChange = (e) => {
    let _Disc = Number(e.target.value.replace(/[^0-9.]/, ""));
    if (_Disc > Number(this.props.MaxDiscount)) console.log("overdisc");
    else {
      this.setState({
        DiscountPre: _Disc,
      });
    }
  };

  DiscountUpdates = () => {
    let _Qty = this.state.Qty;

    this.setState({
      showAdvanceOp: false,
      Amount: this.UpdateAmount(_Qty),
    });
  };

  render() {

    return (
      <div className={classes.border}>
        <div className={[classes.grid1].join(" ")}>
          <div className={classes.t1}> {this.props.itemName}</div>
          <div className={classes.Qty}>
            <button
              className={classes.btn_QtyChange}
              onClick={() => this.QtyUpdate(false)}
            >
              -
            </button>
            {/* <input
              pattern="[0-9]*"
              className={classes.Qty_Input}
              value={this.state.Qty}
            // defaultValue={this.state.Qty}
            /> */}
            <div
              // pattern="[0-9]*"
              className={classes.Qty_Input}

            // defaultValue={this.state.Qty}
            >{this.state.Qty}</div>
            <button
              className={classes.btn_QtyChange}
              onClick={() => this.QtyUpdate(true)}
            >
              +
            </button>
          </div>

          <div className={[classes.Amount, classes.t1].join(" ")}>
            <Price showDecimals={true} showSymbol={false}>
              {this.state.Amount}
            </Price>
          </div>
        </div>
        <div className={[classes.grid2].join(" ")}>
          <div className={classes.t2}> {this.props.item_ID}</div>
          <div className={classes.t2}> Price : {this.props.UnitPrice}</div>
          <div
            className={classes.t2}
            onClick={() => this.setState({ showAdvanceOp: true })}  >
            Disc : {this.state.DiscountPre}%
          </div>

        </div>

        <Modal open={this.state.showAdvanceOp}>
          <div className={classes.model}>
            <h6>Discount</h6>
            <input
              value={this.state.DiscountPre}
              onChange={(e) => this.DiscountChange(e)}
            />
            <button onClick={() => this.DiscountUpdates()}>OK</button>
          </div>
        </Modal>
        <div ></div>
      </div>
    );
  }
}

export default RouteWiseCustomers;
