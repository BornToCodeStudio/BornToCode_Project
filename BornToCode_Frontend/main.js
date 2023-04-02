export async function fetchWeatherFromServer() {
    const response = await fetch('http://localhost:8000/WeatherForecast');
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