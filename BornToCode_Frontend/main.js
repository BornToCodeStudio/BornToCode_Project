let url = import.meta.env;
import {EditorView, basicSetup} from "codemirror";
import {html} from "@codemirror/lang-html";

url = window.location.origin;
console.log(import.meta.url);
console.log(url);

let editor = new EditorView({
    extensions: [basicSetup, html()],
    parent: document.querySelector("#textEditor"),
});

export async function getLastCode() {
    const response = await fetch(`${url}/Code/Get`);
    const data = await response.json();

    editor.dispatch({
        changes: {from: 0, to: editor.state.doc.toString().length, insert: data}
    });
}

export async function postNewCode() {
    let htmlEditorValue = editor.state.doc.toString();
    let json = JSON.stringify({html: htmlEditorValue});

    await fetch(`${url}/Code/Post`,
        {
            method: "POST",
            body: json,
            headers: {
                "Content-Type": "application/json",
            }
        });
}

export async function fetchWeatherFromServer() {
    const response = await fetch(`${url}/WeatherForecast`);
    const data = await response.json();

    var target = document.getElementById("result");
    target.textContent = "";
    data.forEach(function (element) {
        var node = document.createElement("li");
        var textNode = document.createTextNode(JSON.stringify(element));
        node.appendChild(textNode);
        target.appendChild(node);
    });
    console.log({forecasts: data, loading: false});
}

document.getElementById('getLastCode').addEventListener('click', getLastCode);
document.getElementById('postNewCode').addEventListener('click', postNewCode);
document.getElementById('fetchWeather').addEventListener('click', fetchWeatherFromServer);