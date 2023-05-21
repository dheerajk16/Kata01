// validationUtils.js

export const validateForm = (formData, setErrors) => {
    const errors = {};
  
    if (formData.firstName.trim() === '') {
      errors.firstName = 'First name is required';
    }
  
    if (formData.lastName.trim() === '') {
      errors.lastName = 'Last name is required';
    }
  
    if (formData.yearOfJoin <= 1900) {
      errors.yearOfJoin = 'Valid Year of Join is required';
    }
  
    setErrors(errors);
    return Object.keys(errors).length === 0;
  };
  