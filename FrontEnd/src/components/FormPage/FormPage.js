// FormPage.js
import React, { useState } from 'react';
import { persistFormData, retrieveFormData } from '../../api/api';
import { validateForm } from '../../utils/validationUtils';
import './FormPage.css'; // Import the CSS file

const FormPage = () => {
    // const [formData, setFormData] = useState({
    //     firstName: '',
    //     lastName: '',
    //     dateOfBirth: ''
    //     });

  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [yearOfJoin, setYearOfJoin] = useState('');
  const [errors, setErrors] = useState({});
  const [message, setMessage] = useState('');

  const handleFirstNameChange = (event) => {
    setFirstName(event.target.value);
  };

  const handleLastNameChange = (event) => {
    setLastName(event.target.value);
  };

  const handleYearOfJoinChange = (event) => {
    setYearOfJoin(event.target.value);
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    const formData = { firstName, lastName, yearOfJoin };
    const isFormValid = validateForm(formData, setErrors);

    if (isFormValid) {
      persistFormData(formData)
        .then((response) => {
          console.log('Form data persisted:', response.data);
          setMessage('Data persisted successfully!');
          // Optionally, perform any additional actions or show success message to the user
        })
        .catch((error) => {
          console.error('Error during form submission:', error);
          // Handle the error or display an error message to the user
        });
    }
  };

  // Function to handle data retrieval
  const handleRetrieveData = () => {
    retrieveFormData()
      .then(data => {
        const { firstName, lastName, yearOfJoin } = data;
        const formData = { firstName, lastName, yearOfJoin };
        setFirstName(firstName);
        setLastName(lastName);
        setYearOfJoin(yearOfJoin);
        validateForm(formData, setErrors)
        setMessage('Data retrieved successfully!');
      })
      .catch(error => {
        console.log(error);
      });
  };

  const handleClearForm = () => {
    setFirstName('');
    setLastName('');
    setYearOfJoin('');
    setMessage('');
  };


  return (
    <div className="container">
        <form onSubmit={handleSubmit}>
        {/* Render the form inputs and error messages */}
        {errors.submitError && <span className="error">{errors.submitError}</span>}
        <div className="form-group">
            <label className="label">First Name:</label>
            <input type="text" value={firstName} onChange={handleFirstNameChange} className="input"/>
            {errors.firstName && <span className="error">{errors.firstName}</span>}
        </div>
        <div className="form-group">
            <label className="label">Last Name:</label>
            <input type="text" value={lastName} onChange={handleLastNameChange} className="input"/>
            {errors.lastName && <span className="error">{errors.lastName}</span>}
        </div>
        <div className="form-group">
            <label className="label">Year of Join:</label>
            <input type="number" value={yearOfJoin} onChange={handleYearOfJoinChange} className="input"/>
            {errors.yearOfJoin && <span className="error">{errors.yearOfJoin}</span>}
        </div>
        <div className="button-container">
            <button type="submit" className="button">Submit</button>
            <button type="button" onClick={handleRetrieveData} className="button">Retrieve Data</button>
            <button onClick={handleClearForm} className="button">Clear Form</button>
        </div>
        </form>

        {message && <p className="success-message">{message}</p>}
    </div>
  );
};

export default FormPage;
