document.querySelector('#login').addEventListener('submit', (event) => {
    event.preventDefault();

    const loginRequest = {
        userName: event.target.name.value,
        password: event.target.password.value
      };

    fetch('https://localhost:7004/api/Auth/Login', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(loginRequest)
    })
    .then(response => response.json())
    .then(result => {
        if(result.errorMessage) {
            alert(result.errorMessage);
            return;
        } else {
            sessionStorage.setItem('token', result.token);
            document.location.href = '/weather.html';
        }
    })
    .catch((error) => alert(error));
});