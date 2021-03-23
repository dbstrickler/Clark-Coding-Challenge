// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function submitProfile() {
    $.ajax({
        url: 'SubmitProfile',
        type: "POST",
        dataType: "JSON",
        data: {
            firstName: firstName,
            lastName: lastName,
            email: email
        }
        success: function (text) {
            if (text == "Valid") {
                window.location.href = baseurl + 'Contacts/ConfirmationPage';
            }
            else {
                alert(text);
            }
        }
    });
}