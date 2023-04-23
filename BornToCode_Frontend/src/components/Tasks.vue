<template>
    <body>
    <main>
        <h1>Тут можно смотреть на коров и решать задачки</h1>
        <br>
        <img src="https://media.tenor.com/_gfqfXAP08IAAAAC/polish-cow-cow.gif">
        <br>
        <br>
        <button id="getTasks" @click="getTasks">Получить список задачек</button>
        <button id="postNewTask" @click="postNewTask">Создать новую задачку</button>
        <div id="jsonEditor" style="height: 400px; width: 800px"></div>
        <br>
        <br>
        <button id="getLastCode" @click="getLastCode">Получить последнее решение</button>
        <button id="postNewCode" @click="postNewCode">Отправить решение</button>
        <div id="htmlEditor" style="height: 400px; width: 800px"></div>
    </main>
    </body>
</template>

<script>
import {basicSetup, EditorView} from "codemirror";
import {json} from "@codemirror/lang-json";
import {html} from "@codemirror/lang-html";

let url = window.location.origin;

let jsonEditor = new EditorView({
    extensions: [basicSetup, json()],
    parent: document.querySelector("#jsonEditor"),
});

let htmlEditor = new EditorView({
    extensions: [basicSetup, html()],
    parent: document.querySelector("#htmlEditor"),
});

async function getTasks() {
    const response = await fetch(`${url}/Task/GetTasks`);
    const data = await response.text();

    jsonEditor.dispatch({
        changes: {from: 0, to: jsonEditor.state.doc.toString().length, insert: data}
    });
};

async function postNewTask() {
    let json = jsonEditor.state.doc.toString();

    await fetch(`${url}/Task/PostNewTask`,
        {
            method: "POST",
            body: json,
            headers: {
                "Content-Type": "application/json",
            }
        });
};

async function getLastCode() {
    const response = await fetch(`${url}/Code/Get`);
    const data = await response.json();

    htmlEditor.dispatch({
        changes: {from: 0, to: htmlEditor.state.doc.toString().length, insert: data}
    });
};

async function postNewCode() {
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
};

</script>