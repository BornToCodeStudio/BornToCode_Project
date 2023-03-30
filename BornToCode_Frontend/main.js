export async function fetchWeatherFromServer() {
    const response = await fetch('https://borntocode-api.onrender.com/WeatherForecast');
    const data = await response.json();

    var target = document.getElementById("result");
    target.textContent = "";
    data.forEach(function(element) {
        var node = document.createElement("li");
        var textnode = document.createTextNode(JSON.stringify(element));
        node.appendChild(textnode);
        target.appendChild(node);
    });
    console.log({forecasts: data, loading: false});
}

document.getElementById('fetchWeather').addEventListener('click', fetchWeatherFromServer);