window.onload = initializeEvents;

function initializeEvents() {
    document.getElementById("btnTraerPersona").addEventListener("click", solicitudAPI, false);
}

function solicitudAPI() {

    var llamada = new XMLHttpRequest();

    llamada.open("GET", "https://api-crud-sge.azurewebsites.net/api/Personas/5");

    llamada.onreadystatechange = function () {
        if (this.readyState < 4) {

            //0: Estado inicial del objeto, antes de realizar operaci�n alguna sobre �l.
            //1: El m�todo open() ha sido llamado de forma correcta.
            //2: Se ha producido el env�o de la informaci�n.
            //3: Han sido recibidas todas las cabeceras http.
            //4: La transferencia de datos se ha completado.

        } else if (this.readyState == 4 && this.status == 200) {

            var datosPersona = JSON.parse(llamada.responseText);
            document.getElementById("destinoPersona").innerHTML =
                "id: " + datosPersona.id + "<br/>" +
                "DepartmentID: " + datosPersona.DepartmentID + "<br/>" +
                "Email: " + datosPersona.Email + "<br/>" +
                "FirstName: " + datosPersona.FirstName + "<br/>" +
                "LastName: " + datosPersona.LastName + "<br/>" +
                "Birthdate: " + datosPersona.Birthdate + "<br/>"
                "PhoneNumber: " + datosPersona.PhoneNumber;
        }
    };

    llamada.send();

}