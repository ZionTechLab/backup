import axios from "axios";
import { Component } from "react";
import * as Config from "../Common/Config";
import linq from "linq";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import classes from "./Item.module.css";
import AppBar from "./Drawer/AppBar.js";
import { useDispatch, useSelector } from "react-redux";
import Modal from "@mui/material/Modal";

class Item extends Component {
  state = {
    FilterdList: [],
    FilterText: "",
    Route_Code: "A",
    Items: [],
    stock: [],
    Pricing: [],
    open: false,
    url: "",
  };
  handleClose = () => {
    this.setState({
      open: false,
      url: "",
    });
  };
  componentDidMount() {
    let url = Config.API_URL + "Inventory/Get_Inventory";

    axios
      .get(url)
      .then((response) => {
        this.setState({ stock: response.data });
      })
      .catch((err) => {
        console.log(err);
      });
    console.log("init");
    console.log(this.state);

    let data = JSON.parse(localStorage.getItem("itemPricing"));

    console.log(data);
    this.setState({ Pricing: data });
  }

  onSearch = (Route_Code, FilterText) => {
    this.setState({ Route_Code: Route_Code });
    this.setState({ FilterText: FilterText });

    console.log(Route_Code);
    console.log(FilterText);

    const result = this.state.Pricing.filter(
      (p) => p.route_Code.toUpperCase() == Route_Code
    );
    console.log(result);

    const result3 = linq
      .from(JSON.parse(localStorage.getItem("items")))
      .join(
        this.state.stock,
        (pk) => pk.item_ID,
        (fk) => fk.item_ID,
        (left, right) => ({ ...left, ...right })
      )
      .join(
        result,
        (pk) => pk.item_ID,
        (fk) => fk.item_ID,
        (left, right) => ({ ...left, ...right })
      )
      .toArray();
    console.log(result3);
    //  console.log(event.target.value);

    this.setState({
      FilterdList: result3.filter((item) =>
        item.itemName.toUpperCase().includes(FilterText.toUpperCase())
      ),
    });
    //  console.log(this.state.FilterdList);
  };

  showImage = (item_ID) => {
    // let  url = Config.API_URL + "Inventory/getImage/"+item_ID;

    // axios
    //   .get(url)
    //   .then((response) => {
    //     console.log(response.data)

    //     // this.setState({ stock: response.data });
    //   })
    //   .catch((err) => {
    //     console.log(err);
    //   });

    console.log("init");
    console.log(this.state);

    this.setState({
      open: true,
      url: Config.API_URL + "Inventory/getImage/" + item_ID,
    });

    console.log(item_ID);
  };

  render() {
    return (
      <div>
        {/* <AppBar/> */}
        <div className={classes.detail}>
          <div className={classes.appBar2}>
            <div>
              <div className="UpdatedTime"> {this.props.lastUpdatedOn} </div>
              Find :{" "}
              <input
                type="text"
                id="filled-basic"
                label="search"
                variant="filled"
                onChange={(event) => {
                  this.onSearch(this.state.Route_Code, event.target.value);
                }}
                value={this.state.searchedValue}
              />
              Route :{" "}
              <input
                type="text"
                id="filled-basic"
                label="search"
                variant="filled"
                onChange={(event) => {
                  this.onSearch(event.target.value, this.state.FilterText);
                }}
                value={this.state.searchedValue}
              />
            </div>
          </div>

          <Box component="main" sx={{ p: 3 }}>
            <div>
              <TableContainer component={Paper}>
                <Table aria-label="simple table">
                  <TableHead>
                    <TableRow>
                      <TableCell>Item</TableCell>
                      <TableCell>Description</TableCell>
                      <TableCell align="right">Qty</TableCell>{" "}
                      <TableCell align="right">Price</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {this.state.FilterdList.map((row) => (
                      <TableRow
                        key={row.name}
                        sx={{
                          "&:last-child td, &:last-child th": { border: 0 },
                        }}
                      >
                        <TableCell component="th" scope="row">
                          {row.item_ID}
                        </TableCell>
                        <TableCell>
                          {" "}
                          <button onClick={() => this.showImage(row.item_ID)}>
                            {row.itemName}
                          </button>
                        </TableCell>
                        <TableCell align="right">{row.qty}</TableCell>
                        <TableCell align="right">{row.sellingPrice}</TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
            </div>
          </Box>
        </div>
        <Modal open={this.state.open} onClose={this.handleClose}>
          <div className={classes.container}>
            <img src={this.state.url} alt="Italian Trulli"></img>
          </div>
        </Modal>
      </div>
    );
  }
}
export default Item;
