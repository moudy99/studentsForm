document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("addStudentForm");
    const nameInput = document.getElementById("Name");
    const dobInput = document.getElementById("DateOfBirth");
    const emailInput = document.getElementById("Email");
    const subjectCheckboxes = document.querySelectorAll('input[name="SubjectIds"]');

    const nameErrorMessage = document.getElementById("nameError");
    const dobErrorMessage = document.getElementById("dobError");
    const emailErrorMessage = document.getElementById("emailError");
    const subjectErrorMessage = document.getElementById("subjectError");
    const submitButton = form.querySelector(".submit-btn");

    submitButton.disabled = true;

    function validateForm() {
        let isFormValid = true;

        nameErrorMessage.textContent = "";
        dobErrorMessage.textContent = "";
        emailErrorMessage.textContent = "";
        subjectErrorMessage.textContent = "";

        const nameValue = nameInput.value.trim();
        const namePattern = /^[A-Za-z ]+$/;
        if (!namePattern.test(nameValue)) {
            nameErrorMessage.textContent = "Name cannot have numbers or special characters.";
            isFormValid = false;
        }

        const dobValue = new Date(dobInput.value);
        const today = new Date();
        const age = today.getFullYear() - dobValue.getFullYear();
        if (age < 15) {
            dobErrorMessage.textContent = "Student must be older than 15 years.";
            isFormValid = false;
        }

        const emailValue = emailInput.value.trim();
        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailPattern.test(emailValue)) {
            emailErrorMessage.textContent = "Please enter a valid email address.";
            isFormValid = false;
        }

        const selectedSubjects = Array.from(subjectCheckboxes).filter(input => input.checked);
        if (selectedSubjects.length !== 2) {
            subjectErrorMessage.textContent = "Please select exactly 2 subjects.";
            isFormValid = false;
        }

        submitButton.disabled = !isFormValid;
    }

    nameInput.addEventListener("focusout", validateForm);
    dobInput.addEventListener("focusout", validateForm);
    emailInput.addEventListener("focusout", validateForm);
    subjectCheckboxes.forEach(checkbox => {
        checkbox.addEventListener("focusout", validateForm);
    });

    form.addEventListener("submit", async function (event) {
        event.preventDefault();

        validateForm();

        if (!submitButton.disabled) {
            try {
                const formData = new FormData(form);
                const response = await fetch(form.action, {
                    method: 'POST',
                    body: formData,
                    headers: {
                        'X-Requested-With': 'XMLHttpRequest'
                    }
                });

                if (response.ok) {
                    const result = await response.text();
                    Swal.fire({
                        title: "Success!",
                        text: "Student has been added successfully.",
                        icon: "success",
                        confirmButtonText: "OK"
                    }).then(() => {
                        form.reset(); 
                    });
                } else {
                    Swal.fire({
                        title: "Error!",
                        text: "Failed to add student.",
                        icon: "error",
                        confirmButtonText: "OK"
                    });
                }
            } catch (error) {
                Swal.fire({
                    title: "Error!",
                    text: "Something went wrong. Please try again later.",
                    icon: "error",
                    confirmButtonText: "OK"
                });
            }
        }
    });
});
