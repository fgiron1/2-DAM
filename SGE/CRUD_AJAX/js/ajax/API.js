
//Returns a person object array constructed from the JSON contained in the API's response

/*
 * Cabecera: async function getPersonCollection(person)
 *
 * Hace una llamada a la API para obtener un listado de personas relacionadas
 * con el nombre de departamento al que pertenecen y lo devuelve.
 *
 * @return {Array<Object>}  personCollection  El array que contiene el listado de personas con nombre de departamento
 */

async function getPersonCollection() {

    return new Promise((resolve, reject) => {

        var request = new XMLHttpRequest();
        var personCollection = null;

        request.open("GET", "https://api-crud-sge.azurewebsites.net/api/PersonasDepartmentName", true);

        request.onreadystatechange = function () {

            if (request.readyState == 4 && request.status == 200) {

                personCollection = JSON.parse(request.response);

                resolve(personCollection);

                //Codigo de estado 204: No content
            } else if (request.readyState == 4 && request.status == 204) {

                resolve(personCollection);

            } else if (request.readyState == 4 && request.status != 200) {
                reject("Algo ha ido mal");
            }
        };

        request.send(null);
    });

}

/*
 * Cabecera: async function updatePerson(person)
 * 
 * Toma un objeto persona como parámetro para actualizar, a través de una petición a la API, con el valor
 * de sus atributos.
 *
 * @param  {Object}   Person     El objeto que representa los nuevos datos de la persona a actualizar (ID incluida)
 * 
 * @return {Boolean}  succesful  Indica si la API ha sido actualizada correctamente
 */

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
            } else if (request.readyState == 4 && request.status != 204) {
                reject("Algo ha ido mal");
            }
        };


        //Le pasamos al body el objeto JS de la persona transformado en JSON
        request.send(JSON.stringify(person));


    });

}

//Takes a valid id and deletes the API's record that matches ID
//Returns true on succesful result, otherwise returns false

/*
 * Cabecera: async function deletePerson(id)
 *
 * Toma una id de persona y envia una peticion a la API para eliminar a la persona
 * cuya ID coincida en la base de datos
 *
 * @param  {Number}   id     La id de la persona a eliminar
 *
 * @return {Boolean}  succesful  Indica si la API ha sido actualizada correctamente
 */
async function deletePerson(id) {

    return new Promise((resolve, reject) => {

        var request = new XMLHttpRequest();
        var succesful = false;

        request.open("DELETE", "https://api-crud-sge.azurewebsites.net/api/Personas/" + id, true);

        request.onreadystatechange = function () {

            //Código de estado 204 -> No content. Todo fue bien
            if (request.readyState == 4 && request.status == 204) {
                succesful = true;
                resolve(succesful);
            } else if (request.readyState == 4 && request.status != 204) {
                reject("Algo ha ido mal");
            }
        };

        request.send();

    });

    

}


/*
 * Cabecera: async function insertPerson(person)
 *
 * Toma un objeto persona como parámetro para insertar, haciéndole una petición a la API, con el valor
 * de sus atributos. La ID no está incluida, es autogenerada en la bbdd
 *
 * @param  {Object}   Person     El objeto que representa los nuevos datos de la persona a insertar
 * 
 * @return {Boolean}  succesful  Indica si la API ha sido actualizada correctamente
 */

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
            } else if (request.readyState == 4 && request.status != 204) {
                reject("Algo ha ido mal");
            }
        };

        request.send(JSON.stringify(person));

    });

}


//Función no utilizada para este caso de uso
/*
 * async function getPerson(id) {

    return new Promise((resolve, reject) => {

        var request = new XMLHttpRequest();
        var person;

        request.open("GET", "https://api-crud-sge.azurewebsites.net/api/PersonasDepartmentName/" + id);

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
 *
 *
 *
 */