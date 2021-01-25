window.onload = initializeEvents;

function initializeEvents() {
    document.getElementById("btnEliminarPersona").addEventListener("click", borrarPersona, false);
}

function borrarPersona() {

    var llamada = new XMLHttpRequest();

    var idPersona = document.getElementById("nombrePersona").value;

    llamada.open("DELETE", "https://api-crud-sge.azurewebsites.net/api/Personas/" + idPersona);

    llamada.onreadystatechange = function () {

        if (llamada.readyState < 4) {

        } else if (llamada.readyState == 4 && llamada.status == 200) {

            document.getElementById("exito").innerHTML = llamada.responseText;
            alert("Exito!");

        }

    }

    llamada.send();

}