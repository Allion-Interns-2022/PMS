import Home from './Home';
import './App.css';
import { useState } from 'react';
import SignIn from './SignIn';
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter, Routes ,Route } from 'react-router-dom';
import AllPatients from './AllPatients';
import AddPatient from './AddPatient';
import Axios from "axios";


function App() {

  const [username, setUsername] = useState('')
  const [password, setPassword] = useState('')

  const submitUsername = () => {
    Axios.post("http://jsonplaceholder.typicode.com/users", {
      username: username, 
      password: password});
  }
  const [loggedIn, setLoggedIn] = useState(false);

  return (
    <BrowserRouter>
        <div className="contect">
          <Routes>
            
            <Route path="/" element={<SignIn/>} />
            <Route path="/home" element={<Home/>} />
            <Route path="/allpatients" element={<AllPatients/>} />
            <Route path="/addpatient" element={<AddPatient/>} />
          </Routes>
        </div>
    </BrowserRouter>
  );
}

export default App;
