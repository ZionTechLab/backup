import "./App.css";
import Test from "./Components/item2";
import React, { useState, useEffect } from "react";
import Item from "./Components/Inventory";
import RouteWiseCustomers from "./Components/Customer/Customer2";
import Drawer from "./Components/Drawer";
import Admin from "./Components/Admin";
import Spinner from "./Components/Spinner/Spinner";
import { useDispatch, useSelector } from "react-redux";
import { setAuthStatus, init } from "./store";
// import classes from "./Components/Drawer/Drawer.module.css";

function App() {
  const dispatch = useDispatch();

  const authData = useSelector((state) => {
    return state.auth;
  });

  // const [count, setCount] = React.useState(1);
  // const [isInit, setStatus] = useState(false);

  useEffect(() => {
    console.log("Use effect - Auth data changed");

    if (authData.isAuthOK == true && authData.isInitOK == false) {
      //   console.log(authData);

      dispatch(
        init({
          user_id: authData.user_id,
        })
      );
    }
    // console.log(authData);
  }, [authData.isAuthOK, authData.isInitOK]);

  let contains = "";
  if (authData.isAuthOK == false) contains = <Test />;
  else if (authData.isAuthOK == true && authData.isInitOK == false)
    contains = <Spinner />;
  else if (authData.isAuthOK == true && authData.isInitOK == true) {
    contains = (
      <div className="aa">
        {/* //className={classes.Container} */}
        <Drawer />

        {(() => {
          switch (authData.ActiveForm) {
            case "Home":
              return "Welcome";
            case "Admin":
              return (
                <div>
                  {" "}
                  {localStorage.getItem("userType") == 1 ? (
                    <Admin />
                  ) : (
                    "No Access"
                  )}{" "}
                </div>
              );
            case "Inventory":
              return <Item />;
            case "Outstanding":
              return <RouteWiseCustomers />;
            default:
              return "404";
          }
        })()}
      </div>
    );
  }

  return <div>{contains}</div>;
}

export default App;
