(function(){const r=document.createElement("link").relList;if(r&&r.supports&&r.supports("modulepreload"))return;for(const e of document.querySelectorAll('link[rel="modulepreload"]'))n(e);new MutationObserver(e=>{for(const t of e)if(t.type==="childList")for(const s of t.addedNodes)s.tagName==="LINK"&&s.rel==="modulepreload"&&n(s)}).observe(document,{childList:!0,subtree:!0});function o(e){const t={};return e.integrity&&(t.integrity=e.integrity),e.referrerPolicy&&(t.referrerPolicy=e.referrerPolicy),e.crossOrigin==="use-credentials"?t.credentials="include":e.crossOrigin==="anonymous"?t.credentials="omit":t.credentials="same-origin",t}function n(e){if(e.ep)return;e.ep=!0;const t=o(e);fetch(e.href,t)}})();async function i(){const r=await(await fetch("https://localhost:7182/WeatherForecast")).json();var o=document.getElementById("result");o.textContent="",r.forEach(function(n){var e=document.createElement("li"),t=document.createTextNode(JSON.stringify(n));e.appendChild(t),o.appendChild(e)}),console.log({forecasts:r,loading:!1})}document.getElementById("fetchWeather").addEventListener("click",i);
