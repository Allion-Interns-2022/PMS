import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import "bootstrap/dist/css/bootstrap.min.css";
import './SignIn.css';
import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import "bootstrap/dist/css/bootstrap.min.css";
import Axios from "axios";
import { useNavigate } from "react-router-dom";

// const submitReview = () => {
//     Axios.post("https://localhost:7197/api/users", {
//       username: username, 
//       password: password});
//   }

const SignIn = () => {
    const navigate = useNavigate();
    return (
        <div className="form-signin w-100 m-auto d-flex align-items-center">

            <Form style={{ width: '18rem' }} className="m-auto">
                <h1 class="h3 mb-3 fw-normal">Please Sign In</h1>
                <Form.Group className="mb-3 w-10" controlId="formBasicUsername">
                    {/* <Form.Label>Username</Form.Label> */}
                    <Form.Control className='mb-3 w-100' type="username" placeholder="Username" />
                </Form.Group>
                <Form.Group className="mb-3 w-100" controlId="formBasicPassword">
                    {/* <Form.Label>Password</Form.Label> */}
                    <Form.Control className='form-control' type="password" placeholder="Password" />
                </Form.Group>
                <Button onClick={() => navigate("/allpatients")} className="w-100 btn btn-lg btn-primary" variant="primary" type="submit">
                    Sign In
                </Button>
            </Form>
        </div>
    );
}

export default SignIn;