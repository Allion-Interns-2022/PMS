import Home from "./Home";
import "./App.css";
import { useState, useEffect } from "react";
import SignIn from "./SignIn";
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AllPatients from "./AllPatients.tsx";
import AddPatient from "./AddPatient";
import SignInTest from "./SignInTest";
import Axios from "axios";
import { useSelector } from "react-redux";
import { useAppSelector } from "./app/hooks.ts";

function App() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const isAuthenticated = useAppSelector((state) => state.user.isAuthenticated);
  const submitUsername = () => {
    Axios.post("http://jsonplaceholder.typicode.com/users", {
      username: username,
      password: password,
    });
  };
  // const [loggedIn, setLoggedIn] = useState(localStorage.getItem("isLoggedIn"));
  useEffect(() => {
    // if (localStorage.getItem("isAuthenticated") === "1") {
    //   isAuthenticated = true;
    // }
    // console.log(isAuthenticated);
  }, [isAuthenticated]);

  return (
    <BrowserRouter>
      <div className="contect">
        <Routes>
          {!isAuthenticated && <Route path="/" element={<SignIn />} />}
          {isAuthenticated && <Route path="/" element={<AllPatients />} />}
          <Route path="/home" element={<Home />} />
          <Route path="/allpatients" element={<AllPatients />} />
          <Route path="/addpatient" element={<AddPatient />} />
          <Route path="/signintest" element={<SignInTest />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
