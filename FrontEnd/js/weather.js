const token = sessionStorage.getItem('token');

if (!token) {
    alert('please login in order to see weather forecast');
    document.location.href = '/index.html';
}
else {
    fetch('https://localhost:7004/WeatherForecast', {
        method: 'GET',
        headers: {
            'Authorization': `Bearer ${token}`
        }
    })
    .then((response) => response.json())
    .then((response) => {
        const container = document.querySelector('#weather-container');

        for(let i = 0; i<response.length; i++) {
            const weatherParagraph = document.createElement('p');
            weatherParagraph.innerHTML = `<b>${response[i].date}</b> temperature: <b>${response[i].temperatureC} C</b>, weather will be <b>${response[i].summary}</b>`;
            container.append(weatherParagraph);
        }
    })
    .catch((error) => alert(error));
}