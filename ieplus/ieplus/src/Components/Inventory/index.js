import * as Config from "../../Common/Config";
import { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getInventory } from "../../store";
import Box from "@mui/material/Box";
import Modal from "@mui/material/Modal";
import classes from "./inventory.module.css";
import CloseIcon from "@mui/icons-material/Close";
import Select from "@mui/material/Select";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Item from "./item";

function Inventory() {
  const [routes, setRoutes] = useState([]);
  const [route, setroute] = useState("");
  const [open, setOpenImage] = useState(false);
  const [url, setUrl] = useState("");
  const [itemName, setitemName] = useState("");
  const [dataset, setdataset] = useState([]);

  const options = {
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  };

  const dispatch = useDispatch();

  const handleChange = (event) => {
    setroute(event.target.value);

    dispatch(
      getInventory({
        route: event.target.value,
        isInit: false,
      })
    );
  };

  const InventoryState = useSelector((state) => {
    return state.inventory;
  });

  const AuthState = useSelector((state) => {
    return state.auth;
  });

  useEffect(() => {
    console.log("Component mounted!");
    // let x = localStorage.getItem("route");
    let r = localStorage.getItem("route").split(",");
    setroute(r[0]);
    setRoutes(r);

    dispatch(
      getInventory({
        route: r[0],
        isInit: true,
      })
    );

    console.log(route);
  }, []);

  useEffect(() => {
    setdataset(InventoryState.stock);
  }, [InventoryState.stock]);

  const handleClose = () => {
    setOpenImage(false);
    setUrl("");
  };

  const showImage = (item_ID) => {
    setOpenImage(true);
    setUrl(Config.API_URL + "Inventory/getImage/" + item_ID.item_ID);
    setitemName(item_ID.itemName);
  };

  const onSearch = (FilterText) => {
    console.log(FilterText);

    setdataset(
      InventoryState.stock.filter((item) =>
        item.itemName.toUpperCase().includes(FilterText.toUpperCase())
      )
    );
    //  console.log(cc);
  };

  return (
    <div>
      <div>
        <div className={classes.appBar2}>
          <div>
            {/* <div className="UpdatedTime"> {this.props.lastUpdatedOn} </div> */}
            Find :{" "}
            <input
              type="text"
              id="filled-basic"
              label="search"
              variant="filled"
              onChange={(event) => {
                onSearch(event.target.value);
              }}
              // value={this.state.searchedValue}
            />
            <FormControl sx={{ m: 1, minWidth: 120 }} size="small">
              <InputLabel id="demo-select-small-label">Route</InputLabel>
              <Select
                labelId="demo-select-small-label"
                id="demo-select-small"
                value={route}
                label="Route"
                onChange={handleChange}
              >
                {routes.map((item) => (
                  <MenuItem key={item} value={item}>
                    {item}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </div>
        </div>
        <Box component="main" sx={{ p: 3 }}>
          <div>
            {dataset.map((row) => (
              <div>
                <button onClick={() => showImage(row)}>image</button>
                <Item item={row} user_id={AuthState.user_id} />
              </div>
            ))}
          </div>
        </Box>
      </div>
      <Modal open={open} onClose={handleClose}>
        <div className={classes.itemModal}>
          <CloseIcon
            fontSize="70px"
            className={classes.CloseButton}
            onClick={handleClose}
          />
          <img src={url}></img>
          <div>{itemName}</div>
        </div>
      </Modal>
    </div>
  );
}

export default Inventory;
