
//Returns a Mision object array constructed from the JSON contained in the API's response

/*
 * Cabecera: async function getMisionList()
 *
 * Hace una llamada a la API para obtener un listado de misiones
 *
 * @return {Array<Object>}  misionCollection  El array que contiene el listado de misiones
 */

async function getMisionList() {

    return new Promise((resolve, reject) => {

        var request = new XMLHttpRequest();
        var misionCollection = null;
        request.open("GET", "http://localhost:50492/api/Misiones", true);

        request.onreadystatechange = function () {

            if (request.readyState == 4 && request.status == 200) {

                misionCollection = JSON.parse(request.response);

                resolve(misionCollection);

                //Codigo de estado 204: No content
            } else if (request.readyState == 4 && request.status == 204) {

                resolve(misionCollection);

            } else if (request.readyState == 4 && request.status != 200) {
                reject("Algo ha ido mal");
            }
        };

        request.send(null);
    });

}

/*
 * Cabecera: async function updateMision(mision)
 * 
 * Toma un objeto Mision como parámetro para actualizar, a través de una petición a la API, con el valor
 * de sus atributos.
 *
 * @param  {Object}   mision      El objeto que representa los nuevos datos de la mision a actualizar (ID incluida)
 * 
 * @return {Boolean}  successful  Indica si la API ha sido actualizada correctamente
 */

async function updateMision(mision) {

    return new Promise((resolve, reject) => {

        var successful = false;
        var request = new XMLHttpRequest();

        request.open("PUT", "http://localhost:50492/api/Misiones/" + mision.id, true);

        request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

        request.onreadystatechange = function () {

            if (request.readyState == 4 && request.status == 204) {
                successful = true;
                resolve(successful);
            } else if (request.readyState == 4 && request.status != 204) {
                reject("Algo ha ido mal");
            }
        };


        //Le pasamos al body el objeto JS de la mision transformado en JSON
        request.send(JSON.stringify(mision));


    });

}


async function getMisionById(id) {

    return new Promise((resolve, reject) => {

        var request = new XMLHttpRequest();
        var mision;

        request.open("GET", "http://localhost:50492/api/Misiones/" + id);

        request.onreadystatechange = function () {

            if (request.readyState == 4 && request.status == 200) {

                mision = JSON.parse(request.response);
                resolve(mision);

            } else if (request.readyState == 4 && request.status != 200) {
                reject("Algo ha ido mal");
            }

        };

        request.send(null);

    });

}