window.onload = showPersonList;

function initializeEvents() {
    document.getElementById("btnPoblar").addEventListener("click", getPersonCollection);
}

//La id de la persona solicitada la obtenemos como propiedad de un campo de texto, no se la pasamos por parámetros
function getPerson() {

    var request = new XMLHttpRequest();

    request.onreadystatechange = function () {

    };

}

function showPersonList() {


    var table = document.getElementById("listTable");

    var request = new XMLHttpRequest();
    request.open("GET", "https://api-crud-sge.azurewebsites.net/api/Personas/");

    request.onreadystatechange = function () {

        if (request.readyState < 4) {

        } else if (request.readyState == 4 && request.status == 200) {

            //Parseamos el JSON que nos devuelve la llamada a la API
            var personCollection = JSON.parse(request.response);

            //Por cada persona, creamos una nueva fila, 9 celdas, y las rellenamos con sus datos
            //y las últimas 2 celdas contendrán un botón de actualizar y otro de eliminar, respectivamente
            for (var person of personCollection) {

                table.insertRow(table.rows.length);

                for (var i = 0; i < 9; i++) {     
                    table.rows[table.rows.length - 1].insertCell(i);
                }

                table.rows[table.rows.length - 1].cells[0].innerHTML = "<p>" + person.id + "</p>";
                table.rows[table.rows.length - 1].cells[1].innerHTML = "<p>" + person.FirstName + "</p>";
                table.rows[table.rows.length - 1].cells[2].innerHTML = "<p>" + person.LastName + "</p>";
                table.rows[table.rows.length - 1].cells[3].innerHTML = "<p>" + person.Birthdate + "</p>";
                table.rows[table.rows.length - 1].cells[4].innerHTML = "<p>" + person.PhoneNumber + "</p>";
                table.rows[table.rows.length - 1].cells[5].innerHTML = "<p>" + person.Email + "</p>";
                table.rows[table.rows.length - 1].cells[6].innerHTML = "<p>" + person.DepartmentID + "</p>";
                table.rows[table.rows.length - 1].cells[7].innerHTML =  "<input id=\"\" type=\"button\" value=\"Actualizame\" aas";
                table.rows[table.rows.length - 1].cells[8]
            }
        }
    };

    request.send();

}

function updatePerson() {

    var table = document.getElementById("listTable");

    var request = new XMLHttpRequest();

    //La id nos la tiene que pasar el enlace que clicamos
    request.open("PUT", "https://api-crud-sge.azurewebsites.net/api/Personas/");

    request.onreadystatechange = function () {

        if (request.readyState < 4) {

        } else if (request.readyState == 4 && request.status == 200) {

        }
    }
}

function deletePerson() {

    var request = new XMLHttpRequest();

    request.onreadystatechange = function () {

    };

}

function deletePersonCollection() {

    var request = new XMLHttpRequest();

    request.onreadystatechange = function () {

    };

}

function insertPerson() {

    var request = new XMLHttpRequest();

    request.onreadystatechange = function () {

    };

}