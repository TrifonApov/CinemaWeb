function setRoleValue(userId, inputId) {
    var dropdown = document.getElementById('roleDropdown-' + userId);
    var input = document.getElementById(inputId + '-' + userId);
    input.value = dropdown.value;
}

function confirmDeleteUser(event, form) {
    event.preventDefault();

    Swal.fire({
        title: 'Delete user?',
        text: 'This action cannot be undone.',
        icon: 'warning',
        background: '#212529',
        color: '#f8f9fa',
        iconColor: '#ffc107',
        showCancelButton: true,
        confirmButtonText: 'Delete',
        cancelButtonText: 'Cancel',
        confirmButtonColor: '#dc3545',
        cancelButtonColor: '#6c757d',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            form.submit();
        }
    });
}
