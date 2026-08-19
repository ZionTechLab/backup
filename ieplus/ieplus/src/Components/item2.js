import React from "react";
import classes from "./Auth.module.css";
import TextField from "@mui/material/TextField";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import { useFormik } from "formik";
import * as yup from "yup";
import { useDispatch, useSelector } from "react-redux";
import { loggin } from "../store";

const validationSchema = yup.object({
  email: yup
    .string("Enter your User ID")
    .min(5, "Enter a valid User ID")
    //  .email("Enter a valid User ID")
    .required("User ID is required"),
  password: yup
    .string("Enter your password")
    .min(4, "Password should be of minimum 4 characters length")
    .required("Password is required"),
});

const Login = (props) => {
  const dispatch = useDispatch();

  const authState = useSelector((state) => {
    return state.auth;
  });
  // React.useEffect(() => {
  //   console.log('Use Effect - login');
  //   console.log(authState.user_id)

  // },[authState.user_id]);

  const formik = useFormik({
    initialValues: {
      email2: "",
      email: "asasas",
      password: "",
    },
    validationSchema: validationSchema,
    onSubmit: (values) => {
      dispatch(
        loggin({
          user_id: values.email,
          password: values.password,
        })
      );

      //}
    },
  });

  const loginForm = (
    <form onSubmit={formik.handleSubmit}>
      <Box color="error.contrastText" p={1}>
        <TextField
          variant="filled"
          fullWidth
          id="email"
          name="email"
          defaultValue="Hello World"
          label="User ID"
          value={formik.values.email}
          onChange={formik.handleChange}
          error={formik.touched.email && Boolean(formik.errors.email)}
          helperText={formik.touched.email && formik.errors.email}
        />
      </Box>
      <Box color="error.contrastText" p={1}>
        <TextField
          fullWidth
          variant="filled"
          id="password"
          name="password"
          label="Password"
          type="password"
          value={formik.values.password}
          onChange={formik.handleChange}
          error={formik.touched.password && Boolean(formik.errors.password)}
          helperText={formik.touched.password && formik.errors.password}
        />
      </Box>
      {authState.err}
      <Box color="error.contrastText" p={1}>
        <Button color="primary" variant="contained" fullWidth type="submit">
          Sign in
        </Button>
      </Box>
    </form>
  );

  return (
    <div className={classes.container}>
      <div className={classes.top}>
        <img className={classes.Logo} alt="" src={"/image/ZionSFM_logo.png"} />
      </div>
      <div className={classes.Auth}>{loginForm}</div>
    </div>
  );
};

export default Login;
