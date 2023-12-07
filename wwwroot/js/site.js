// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const myHeading = document.querySelector("h1");
myHeading.textContent = "Hello world!";

fetch('/Home/GetHomeStatus')
    .then(response => response.json())
    .then(data => {
        const statusElement = document.getElementById('status');
        statusElement.innerHTML = data.join('<br>');
    });