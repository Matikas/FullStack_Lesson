document.querySelector('#login').addEventListener('submit', (event) => {
    event.preventDefault();

    const loginRequest = {
        userName: event.target.name,
        password: event.target.password
      };

    fetch('https://localhost:7004/api/Auth/Login', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(loginRequest)
    });
});