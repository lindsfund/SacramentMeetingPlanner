// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addSpeaker() {
    fetch('@Url.Action("AddSpeakerInput", "Create")',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams(new FormData(document.querySelector('form'))),
        })
        .then(response => response.text())
        .then(result => {
            document.getElementById('speakerInputContainer').innerHTML = result;
        })
        .catch(error => console.error('ERROR:', error));
   // return alert("connected to JS");
}
