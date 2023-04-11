let url = import.meta.env;
import {EditorView, basicSetup} from "codemirror";
import {json} from "@codemirror/lang-json";
import {html} from "@codemirror/lang-html";

url = window.location.origin;
console.log(import.meta.url);
console.log(url);

let jsonEditor = new EditorView({
    extensions: [basicSetup, json()],
    parent: document.querySelector("#jsonEditor"),
});

let htmlEditor = new EditorView({
    extensions: [basicSetup, html()],
    parent: document.querySelector("#htmlEditor"),
});

export async function getTasks() {
    const response = await fetch(`${url}/Task/GetTasks`);
    const data = await response.text();

    jsonEditor.dispatch({
        changes: {from: 0, to: jsonEditor.state.doc.toString().length, insert: data}
    });
}

export async function postNewTask() {
    let jsonEditorValue = jsonEditor.state.doc.toString();
    let json = jsonEditorValue;

    await fetch(`${url}/Task/PostNewTask`,
        {
            method: "POST",
            body: json,
            headers: {
                "Content-Type": "application/json",
            }
        });
}

export async function getLastCode() {
    const response = await fetch(`${url}/Code/Get`);
    const data = await response.json();

    htmlEditor.dispatch({
        changes: {from: 0, to: htmlEditor.state.doc.toString().length, insert: data}
    });
}

export async function postNewCode() {
    let htmlEditorValue = htmlEditor.state.doc.toString();
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

document.getElementById('getTasks').addEventListener('click', getTasks);
document.getElementById('postNewTask').addEventListener('click', postNewTask);
document.getElementById('getLastCode').addEventListener('click', getLastCode);
document.getElementById('postNewCode').addEventListener('click', postNewCode);
document.getElementById('fetchWeather').addEventListener('click', fetchWeatherFromServer);