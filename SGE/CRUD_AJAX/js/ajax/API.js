//TODO: Controlar códigos de estado de error



//Takes a valid person ID as a parameter
//Returns a person object constructed from the JSON contained ni the API'S response

async function getPerson(id) {

    return new Promise((resolve, reject) => {

        var request = new XMLHttpRequest();
        var person;

        request.open("GET", "https://api-crud-sge.azurewebsites.net/api/Personas/" + id);

        request.onreadystatechange = function () {

            //TODO: Tengo que controlar el codigo de estado 204 No content
            //Y los errores con reject aquí y en el metodo que lo llama con .catch(), al igual que con .then()

            if (request.readyState == 4 && request.status == 200) {
                person = JSON.parse(request.response);
                resolve(person);
            }

        };

        request.send(null);

    });

   

}

//Returns a person object array constructed from the JSON contained in the API's response
async function getPersonCollection() {

    return new Promise((resolve, reject) => {

        var request = new XMLHttpRequest();
        var personCollection;

        //La id nos la tiene que pasar el enlace que clicamos
        request.open("GET", "https://api-crud-sge.azurewebsites.net/api/Personas", true);

        request.onreadystatechange = function () {

            //TODO: Tengo que controlar el codigo de estado 204 No content
            if (request.readyState < 4) {

                //AQUI TENGO QUE PONER VISIBILITY DEL BODY HIDDEN PARA MIENTRAS TANTO.
                //EN SU LUGAR LO SUYO ES QUE TENGA TODO EN UN DIV Y LE PONGA LA VISIBILIITY A HIDDEN A ESE DIV
                //Y CREAR OTRO DIV CON LA ANIMACIÓN DE UN RELOJ O ALGO ASÍ

            } else if (request.readyState == 4 && request.status == 200) {

                personCollection = JSON.parse(request.response);

                resolve(personCollection);
            }
        };

        request.send(null);
    });

}


//Takes a person object as a parameter to update the API with its attributes
//Returns true on succesful result, otherwise returns false

async function updatePerson(person) {

    return new Promise((resolve, reject) => {

        var succesful = false;
        var request = new XMLHttpRequest();

        request.open("PUT", "https://api-crud-sge.azurewebsites.net/api/Personas/" + person.id, true);

        request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

        request.onreadystatechange = function () {

            //TODO: Tengo que controlar codigos de estado de error

            if (request.readyState == 4 && request.status == 204) {
                succesful = true;
                resolve(succesful);
            }
        };


        //Le pasamos al body el objeto JS de la persona transformado en JSON
        request.send(JSON.stringify(person));


    });

   

    return succesful;
}

//Takes a valid id and deletes the API's record that matches ID
//Returns true on succesful result, otherwise returns false
async function deletePerson(id) {

    return new Promise((resolve, reject) => {

        var request = new XMLHttpRequest();
        var succesful = false;

        request.open("DELETE", "https://api-crud-sge.azurewebsites.net/api/Personas/" + id, true);

        request.onreadystatechange = function () {

            //TODO: Tengo que controlar codigos de estado de error
            //Código de estado 204 -> No content. Todo fue bien
            if (request.readyState == 4 && request.status == 204) {
                succesful = true;
                resolve(succesful);
            }
        };

        request.send();

    });

    

}


//Takes a person object as a parameter to insert into the API
//Returns true on succesful result, otherwise returns false
async function insertPerson(person) {

    return new Promise((resolve, reject) => {

        var request = new XMLHttpRequest();
        var succesful = false;

        request.open("POST", "https://api-crud-sge.azurewebsites.net/api/Personas/", true);

        request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

        request.onreadystatechange = function () {

            //POST message returns no content (204) if everything went okay
            if (request.readyState == 4 && request.status == 204) {
                succesful = true;
                resolve(succesful);
            }
        };

        request.send(JSON.stringify(person));

    });

}

async function getDepartmentCollection() {

    return new Promise((resolve, reject) => {

        var succesful;
        var request = new XMLHttpRequest();

        request.open("GET", "https://api-crud-sge.azurewebsites.net/api/Departments/", true);

        request.onreadystatechange = function () {

            //TODO: Tengo que controlar el codigo de estado 204 No content
            if (request.readyState < 4) {

            } else if (request.readyState == 4 && request.status == 200) {

                departmentCollection = JSON.parse(request.response);
                succesful = true;
                resolve(departmentCollection, succesful);
            }
        };

        request.send(null);

    });

}