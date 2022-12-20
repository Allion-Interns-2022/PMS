import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import React, { useState, useEffect } from "react";
import Axios from "axios";
import Navbar from "./NavBar";
import { useDispatch, useSelector } from 'react-redux';

const AddPatient = () => {
    const [Id, setId] = useState("");
    const [Name, setName] = useState("");
    const [DOB, setDOB] = useState("");
    const [WeightKG, setWeightKG] = useState("");
    const [HeightCM, setHeightCM] = useState("");
    const [Address, setAddress] = useState("");
    const [Contact, setContact] = useState("");
    const [EmergencyContact, setEmergencyContact] = useState("");
    const { value } = useSelector((state)=>state.counter);
    const { id } = useSelector((state)=>state.id);
    const dispatch = useDispatch();

    const submitForm = (event) => {
        event.preventDefault();
        Axios.post("https://localhost:7197/api/patients"
            , {
                Name: Name
                , DOB: DOB
                , WeightKG: WeightKG
                , HeightCM: HeightCM
                , Address: Address
                , Contact: Contact
                , EmergencyContact: EmergencyContact
            })
            .then(() => {
                alert("Success!");
            });

    };

    return (
        <div>
            <Navbar />
            <Form>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Name</Form.Label>
                    <Form.Control type="text" placeholder="Name" onChange={e => setName(e.target.value)} />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>DOB</Form.Label>
                    <Form.Control type="date" placeholder="Date Of Birth" onChange={e => setDOB(e.target.value)} />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>WeightKG</Form.Label>
                    <Form.Control type="number" placeholder="WeightKG" onChange={e => setWeightKG(e.target.value)} />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>HeightCM</Form.Label>
                    <Form.Control type="number" placeholder="HeightCM" onChange={e => setHeightCM(e.target.value)} />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Address</Form.Label>
                    <Form.Control type="text" placeholder="Address" onChange={e => setAddress(e.target.value)} />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Contact</Form.Label>
                    <Form.Control type="text" placeholder="Contact" onChange={e => setContact(e.target.value)} />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>EmergencyContact</Form.Label>
                    <Form.Control type="text" placeholder="EmergencyContact" onChange={e => setEmergencyContact(e.target.value)} />
                </Form.Group>
                <Button onClick={submitForm} variant="primary" type="submit">
                    Submit
                </Button>
            </Form>
        </div>
    );
}

export default AddPatient;