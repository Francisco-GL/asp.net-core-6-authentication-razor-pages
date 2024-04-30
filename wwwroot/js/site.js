// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const uri = 'http://localhost:4000/';
const EndPointAuth = uri + 'auth/';

async function test () {
    try {
        const response = await fetch(`${EndPointAuth}signUp`, {
            method: 'POST'
        });

        if (!response.ok) {
            throw new Error('Error en la solicitud');
        }

        const data = await response.json();
        const msg = document.getElementById("msg");
        msg.innerHTML = data.msg;
        console.log(data);
    } catch (error) {
        console.error('Ocurrió un error:', error.message);
    }

}