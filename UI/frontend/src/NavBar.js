import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import "bootstrap/dist/css/bootstrap.min.css";
import { useNavigate } from "react-router-dom";
import SignIn from "./SignIn";
import { useState, useEffect } from "react";
import { userActions } from "./features/user";
import { useDispatch } from "react-redux";

const NavBar = () => {
  const navigate = useNavigate();
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const dispatch = useDispatch();
  const logoutHandler = () => {
    dispatch(userActions.logout());
    // navigate("/");
  };

  return (
    <Navbar bg="light" expand="lg">
      <Container>
        <Navbar.Brand onClick={() => navigate("/home")}>
          Patient Management System
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="#link">Medical Records</Nav.Link>
            <NavDropdown title="Patients" id="basic-nav-dropdown">
              <NavDropdown.Item onClick={() => navigate("/allpatients")}>
                All Patients
              </NavDropdown.Item>
              <NavDropdown.Item onClick={() => navigate("/addpatient")}>
                Add Patient
              </NavDropdown.Item>
              <NavDropdown.Item onClick={() => navigate("/searchpatient")}>
                Search
              </NavDropdown.Item>
            </NavDropdown>
            <Nav.Link onClick={logoutHandler}>Sign Out</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default NavBar;
