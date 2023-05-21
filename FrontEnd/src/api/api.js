// api.js
import axios from 'axios';

const API_BASE_URL = process.env.REACT_APP_API_BASE_URL;

export const persistFormData = (data) => {
    return axios.post(`${API_BASE_URL}/formData`, data) // Update with your specific API endpoint for saving form data
        .then(response => response.data)
        .catch(error => {
        console.log(error);
        throw error;
        });
};

export const retrieveFormData = () => {
    return axios.get(`${API_BASE_URL}/formData`) // Update with your specific API endpoint for retrieving form data
        .then(response => response.data)
        .catch(error => {
        console.log(error);
        throw error;
        });
};