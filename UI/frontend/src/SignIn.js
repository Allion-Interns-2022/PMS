import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import "bootstrap/dist/css/bootstrap.min.css";
import "./SignIn.css";
import React from "react";
import "./index.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { userActions } from "./features/user";

const SignIn = (props) => {
  const dispatch = useDispatch();

  const [enteredUsername, setEnteredUsername] = useState("");
  const [enteredPassword, setEnteredPassword] = useState("");

  const usernameChangeHandler = (event) => {
    setEnteredUsername(event.target.value);
  };

  const passwordChangeHandler = (event) => {
    setEnteredPassword(event.target.value);
  };

  const submitHandler = (event) => {
    event.preventDefault();
    dispatch(userActions.login());
  };

  return (
    <div className="form-signin w-100 m-auto d-flex align-items-center">
      <Form
        onSubmit={submitHandler}
        style={{ width: "18rem" }}
        className="m-auto"
      >
        <h1 className="h3 mb-3 fw-normal">Please Sign In</h1>
        <Form.Group className="mb-3 w-10" controlId="formBasicUsername">
          {/* <Form.Label>Username</Form.Label> */}
          <Form.Control
            onChange={usernameChangeHandler}
            value={enteredUsername}
            className="mb-3 w-100"
            type="text"
            placeholder="Username"
            autoComplete="on"
          />
        </Form.Group>
        <Form.Group className="mb-3 w-100" controlId="formBasicPassword">
          {/* <Form.Label>Password</Form.Label> */}
          <Form.Control
            onChange={passwordChangeHandler}
            value={enteredPassword}
            className="form-control"
            type="password"
            placeholder="Password"
            autoComplete="on"
          />
        </Form.Group>
        <Button
          className="w-100 btn btn-lg btn-primary"
          variant="primary"
          type="submit"
        >
          Sign In
        </Button>
      </Form>
    </div>
  );
};

export default SignIn;
