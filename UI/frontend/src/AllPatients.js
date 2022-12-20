
import React, { Component } from 'react';
import Table from 'react-bootstrap/Table';
import "bootstrap/dist/css/bootstrap.min.css";
import './AllPatients.css';
// import { useEffect, useState } from "react";
import Axios from "axios";
import Navbar from "./NavBar";
import { useSelector, useDispatch } from 'react-redux';
import { patientSlice } from './features/patient';
import patientReducer  from './features/patient';
import { useEffect, useState } from 'react';
import { allPatientsAsync } from './features/patient';
import { allPatients } from './features/patient';
//TODO 
// export default class AllPatients extends Component {
//     constructor(props) {
//         super(props);
//         this.state = {
//             patients: []
//         }
//     }

//     render() {
//         return (
//             <div>
//                 <table className="table table-striped">
//                     <thead>
//                         <tr>
//                             <th>#</th>
//                             <th>Name</th>
//                             <th>DOB</th>
//                             <th>WeightKG</th>
//                             <th>HeightCM</th>
//                             <th>Address</th>
//                             <th>Contact</th>
//                             <th>EmergencyContact</th>
//                             <th>Actions</th>
//                         </tr>
//                     </thead>
//                     <tbody>
//                         {
//                             patients.map(p =>
//                                 <tr key={p.Id}>
//                                     <td>{p.Name}</td>c
//                                     <td>{p.DOB}</td>
//                                     <td>{p.WeightKG}</td>
//                                     <td>{p.HeightCM}</td>
//                                     <td>{p.Address}</td>
//                                     <td>{p.Contact}</td>
//                                     <td>{p.EmergencyContact}</td>
//                                     <td>
//                                         <button type="button" className='btn btn-light mr-1'>
//                                             <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
//                                                 <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
//                                                 <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
//                                             </svg>
//                                         </button>
//                                         <button type="button" className='btn btn-light mr-1'>
//                                             <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
//                                                 <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
//                                                 <path fillRule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z" />
//                                             </svg>
//                                         </button>
//                                     </td>
//                                 </tr>
//                             )
//                         }
//                     </tbody>
//                 </table>

//             </div>
//         )
//     }
// }

const AllPatients = () => {
    

    
    const [patientsList, setPatientsList] = useState([]);

    // const url = "https://localhost:7197/api/patients";
    // useEffect(() => {

    //     fetch(url, {
    //         method: 'GET',
    //         headers: { "Content-Type": "application/json" },
    //         credentials: 'include'
    //     })
    //         .then(res => {
    //             return res.json();
    //         })
    //         .then(data => {
    //             setData(data)
    //         })

    // }, [url])
    const selectorData = useSelector((state)=> state.patient.value);
    const [data, setData] = useState([selectorData]);
    // console.log(selectorData);
    const dispatch = useDispatch();
    useEffect(() => {
        Axios.get("https://localhost:7197/api/patients")
            .then((response) => {
                dispatch(allPatients(response.data));
                // console.log(response.data);
                // console.log(selectorData);
                setPatientsList(response.data);
                setData(selectorData);
                console.log(data);
            })
    }
        , []
    )
    
    
    // const [patientList, setPatientList] = useState('');
    // const result = Object.values(patientList);
    
    // useEffect(() => {
    //     allPatientsAsync();
    //     setPatientList(selectorData);
    //     console.log(selectorData);
    // }, [selectorData])

    // useEffect(()=>{
    //     const patientsList = useSelector((state)=> state.patient.value);
    // }, [])
    

    return (
        <div>
            <Navbar />
            <Table striped bordered hover >
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Name</th>
                        <th>DOB</th>
                        <th>WeightKG</th>
                        <th>HeightCM</th>
                        <th>Address</th>
                        <th>Contact</th>
                        <th>EmergencyContact</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {/* {console.log(useSelector((state)=> state.patient.value))} */}
                    {patientsList?.map((p) =>
                        <tr key={p.id}>
                            <td>{p.id}</td>
                            <td>{p.name}</td>
                            <td>{p.dob}</td>
                            <td>{p.weightKG}</td>
                            <td>{p.heightCM}</td>
                            <td>{p.address}</td>
                            <td>{p.contact}</td>
                            <td>{p.emergencyContact}</td>
                            <td>
                                <button type="button" className='btn btn-light mr-1'>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                        <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                        <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                    </svg>
                                </button>
                                <button type="button" className='btn btn-light mr-1'>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash" viewBox="0 0 16 16">
                                        <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
                                        <path fillRule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z" />
                                    </svg>
                                </button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </Table>
        </div>
    );
};

export default AllPatients;