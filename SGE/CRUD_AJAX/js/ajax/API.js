//TODO: Controlar códigos de estado de error



//Takes a valid person ID as a parameter
//Returns a person object constructed from the JSON contained ni the API'S response

function getPerson(id) {

    var request = new XMLHttpRequest();
    var person;

    request.open("GET", "https://api-crud-sge.azurewebsites.net/api/Personas/" + id);

    request.onreadystatechange = function () {

        //TODO: Tengo que controlar el codigo de estado 204 No content
        if (request.readyState == 4 && request.status == 200) {
            person = JSON.parse(request.response);
        }

    };

    request.send();

    return person;

}

//Returns a person object array constructed from the JSON contained in the API's response
function getPersonCollection() {

    var request = new XMLHttpRequest();
    var personCollection;

    //La id nos la tiene que pasar el enlace que clicamos
    request.open("GET", "https://api-crud-sge.azurewebsites.net/api/Personas", false);

    request.onreadystatechange = function () {

        //TODO: Tengo que controlar el codigo de estado 204 No content
        if (request.readyState < 4) {

            //AQUI TENGO QUE PONER VISIBILITY DEL BODY HIDDEN PARA MIENTRAS TANTO.
            //EN SU LUGAR LO SUYO ES QUE TENGA TODO EN UN DIV Y LE PONGA LA VISIBILIITY A HIDDEN A ESE DIV
            //Y CREAR OTRO DIV CON LA ANIMACIÓN DE UN RELOJ O ALGO ASÍ

        } else if (request.readyState == 4 && request.status == 200) {

            personCollection = JSON.parse(request.response);

        }
    };

    request.send(null);

    return personCollection;

}


//Takes a person object as a parameter to update the API with its attributes
//Returns true on succesful result, otherwise returns false

function updatePerson(person) {

    var request = new XMLHttpRequest();
    var succesful = false;

    request.open("PUT", "https://api-crud-sge.azurewebsites.net/api/Personas/" + person.id);

    request.onreadystatechange = function () {

        //TODO: Tengo que controlar codigos de estado de error

        if (request.readyState == 4 && request.status == 200) {
            succesful = true;
        }
    };

    //Le pasamos al body el objeto JS de la persona transformado en JSON
    request.send(JSON.stringify(person));

    return succesful;
}

//Takes a valid id and deletes the API's record that matches ID
//Returns true on succesful result, otherwise returns false
function deletePerson(id) {

    var request = new XMLHttpRequest();
    var succesful = false;

    request.open("DELETE", "https://api-crud-sge.azurewebsites.net/api/Personas/" + id, false);

    request.onreadystatechange = function () {

        //TODO: Tengo que controlar codigos de estado de error

        if (request.readyState == 4 && request.status == 200) {
            succesful = true;
        }
    };

    request.send();

    return succesful;

}


//Takes a person object as a parameter to insert into the API
//Returns true on succesful result, otherwise returns false
function insertPerson(person) {

    var request = new XMLHttpRequest();
    var succesful = false;

    request.open("INSERT", "https://api-crud-sge.azurewebsites.net/api/Personas/");

    request.onreadystatechange = function () {

        if (request.readyState == 4 && request.status == 200) {
            succesful = true;
        }
    };

    request.send(JSON.stringify(person));

    return succesful;

}