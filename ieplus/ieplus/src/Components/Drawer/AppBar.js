import React from "react";
import classes from "./AppBar.module.css";
import Button from "@mui/material/Button";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";

const AppBar = (props) => {
  return (
    <div className={classes.appBar}>
      <IconButton
        edge="start"
        color="inherit"
        aria-label="menu"
        onClick={props.onClick(true)}
      >
        <MenuIcon />
      </IconButton>

      <Button color="inherit">{props.ActiveForm}</Button>

      <div className={classes.IconUser}>
        <IconButton
          edge="start"
          color="inherit"
          aria-label="Refresh"
        ></IconButton>
        <IconButton
          aria-label="account of current user"
          aria-controls="menu-appbar"
          aria-haspopup="true"
          edge="end"
          color="inherit"
        ></IconButton>
      </div>
    </div>
  );
};

export default AppBar;
