import React, { useState, useEffect } from "react";
import Grid from "@mui/material/Grid";
import classes from "./Customers.module.css";
import EditOutlinedIcon from "@mui/icons-material/EditOutlined";
import Pagination from "./Pagination";

const Customers = (props) => {
  // const [posts, setPosts] = useState([]);
  //const [loading, setLoading] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const [postsPerPage] = useState(10);

  const indexOfLastPost = currentPage * postsPerPage;
  const indexOfFirstPost = indexOfLastPost - postsPerPage;
  const currentPosts = props.Data.slice(indexOfFirstPost, indexOfLastPost);

  const paginate = (pageNumber) => setCurrentPage(pageNumber);

  return (
    <div>
      <Grid item xs={12}>
        {" "}
        {currentPosts.map((row1) => (
          <div className={classes.t1}>
            <Grid container>
              <Grid item xs={2}>
                <div className={classes.row11}> {row1.customer_ID} </div>{" "}
              </Grid>{" "}
              <Grid item xs={7}>
                <div className={classes.row11}> {row1.customerName} </div>{" "}
              </Grid>{" "}
              <Grid item xs={2}>
                <div className={classes.row11}> {row1.outstanding} </div>
              </Grid>{" "}
              <Grid item xs={1}>
                <div
                  onClick={() =>
                    props.onClick({
                      Customer_Code: row1.customer_ID,
                      customer_Name: row1.customerName,
                    })
                  }
                >
                  <EditOutlinedIcon />{" "}
                </div>
              </Grid>{" "}
            </Grid>
          </div>
        ))}{" "}
      </Grid>{" "}
      <Pagination
        postsPerPage={postsPerPage}
        totalPosts={props.Data.length}
        paginate={paginate}
      />{" "}
    </div>
  );
};
export default Customers;
