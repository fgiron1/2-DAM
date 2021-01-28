window.onload = initializeEvents;

function initializeEvents() {
    document.getElementById("btnEliminarPersona").addEventListener("click", borrarPersona, false);
}


/*
 * Prototipo: 
 * 
 * 
 */

function borrarPersona() {

    var llamada = new XMLHttpRequest();

    var idPersona = document.getElementById("nombrePersona").value;

    llamada.open("DELETE", "https://api-crud-sge.azurewebsites.net/api/Personas/" + idPersona);

    llamada.onreadystatechange = function () {

        if (llamada.readyState < 4) {

            //Código de estado para el eliminar es 204 (No content) porque no
            //he programado nada 
        } else if (llamada.readyState == 4 && llamada.status == 204) {
            //No hay responseText porque no lo he programado yo lol
            document.getElementById("exito").innerHTML = "Eliminada satisfactoriamente";

        } else if (llamada.readyState == 4 && llamada.status == 404) {
            document.getElementById("exito").innerHTML = "Persona no encontrada";
        }

    }

    llamada.send();

}