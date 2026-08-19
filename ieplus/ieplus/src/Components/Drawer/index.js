import React from "react";
import { useState } from "react";
import Box from "@mui/material/Box";
import Drawer from "@mui/material/Drawer";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import { useDispatch, useSelector } from "react-redux";
import { setActiveForm } from "../../store";
import { MenuItems } from "../../Common/menu";
import AppBar from "./AppBar";

export default function TemporaryDrawer() {
  const dispatch = useDispatch();

  const authData = useSelector((state) => {
    return state.auth;
  });

  const [state, setState] = useState({ isOpen: false });

  const toggleDrawer = (open) => (event) => {
    if (
      event.type === "keydown" &&
      (event.key === "Tab" || event.key === "Shift")
    ) {
      return;
    }

    setState({ ...state, isOpen: open });
  };

  const PageSelected = (page) => (event) => {
    console.log(page);
    console.log("ado");
    dispatch(setActiveForm(page));
  };

  const list = () => (
    <Box
      sx={{ width: 250 }}
      role="presentation"
      // onClick={toggleDrawer(false)}
      // onKeyDown={toggleDrawer(false)}
    >
      <List>
        {MenuItems.map((item, index) => (
          <ListItem key={item[1]} disablePadding>
            <ListItemButton onClick={PageSelected(item[1])}>
              <ListItemIcon>{item[0]}</ListItemIcon>
              <ListItemText primary={item[1]} />
            </ListItemButton>
          </ListItem>
        ))}
      </List>
    </Box>
  );

  return (
    <div>
      <AppBar
        ActiveForm={authData.ActiveForm}
        onClick={(data) => toggleDrawer(data)}
      />

      <Drawer open={state.isOpen} onClose={toggleDrawer(false)}>
        {list()}
      </Drawer>
    </div>
  );
}
