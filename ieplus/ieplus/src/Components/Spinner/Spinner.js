import React from 'react';
import classes from './Spinner.module.css';

const spinner = (props) => { 
    return (
      <div>
        <div className={classes.Loader}></div>
        Loading...
        </div>
  );}
export default spinner;