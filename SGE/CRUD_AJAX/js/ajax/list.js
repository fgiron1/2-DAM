
/*
 * Carga la lista de personas de forma asíncrona, llamando a la API
 * y llama al método rellenarTabla con la información obtenida, construyendo
 * visualmente la tabla
 */

async function showPersonList() {

    var departmentCollection;

    //Todo lo que necesite hacer con personCollection lo tengo que hacer aquí
    //No puedo devolver el valor
    getPersonCollection().then((personCollectionAsync) => {

        //Código de estado 204: No content
        if (personCollectionAsync === null) {
            document.createElement(h1).innerHtml = "No content";
        } else {
            rellenarTabla(personCollectionAsync);
        }
        
    });

}



/*
 * Esta función se encarga de generar las filas en la tabla y rellenarlas con la información de cada persona,
 * pasada por parámetros, además de iconos para actualizar y eliminar
 * 
 * Los event listeners no están en el método assignListeners (En insert.js) porque se asignan a botones
 * creados dinámicamente

 *
 * @param  {Array<Object>} personCollection   Un array de objetos persona. Cada objeto representa a una persona, con toda su información relevante
 */
    
async function rellenarTabla(personCollection) {

    var table = document.getElementById("listTable");
    var tbody = document.getElementsByTagName('tbody')[0];

    //Limpiamos la tabla por si ya está llena de previas iteraciones de esta función
    table.removeChild(tbody);


    //Por cada persona, creamos una nueva fila, 9 celdas, y las rellenamos con sus datos.
    //Las primeras 7 celdas se destinan para los datos y las últimas 2 celdas contendrán
    //un botón de actualizar y otro de eliminar, respectivamente

    var id = 0;
    for (var person of personCollection) {

        
        let personID = person.id;
        let personBlockScope = person;
        let idBlockScope = id;

        var newRow = table.insertRow(table.rows.length);

        //Le asignamos un id a la nueva fila, diferente en cada iteración
        newRow.id = "tr - " + id;

        //Aumentamos el contador para la proxima fila
        id++;

        //Insertamos 9 celdas en la nueva fila
        for (var i = 0; i < 9; i++) {
            newRow.insertCell(i);
        }

        newRow.cells[0].classList.add("negro");

        //Rellenamos las celdas

        newRow.cells[1].innerHTML = "<p>" + person.FirstName + "</p>";

        newRow.cells[2].innerHTML = "<p>" + person.LastName + "</p>";

        newRow.cells[3].innerHTML = "<p>" + person.Birthdate.substring(0,9) + "</p>";

        newRow.cells[4].innerHTML = "<p>" + person.PhoneNumber + "</p>";

        newRow.cells[5].innerHTML = "<p>" + person.Email + "</p>";

        newRow.cells[6].innerHTML = "<p>" + person.departmentName + "</p>";

        //Añadimos al boton de actualizar del formulario la función a la que llamar

        newRow.cells[7].innerHTML = "<input id=\"\" type=\"button\" value=\"Actualizame\"/>";

        //Al hacer clic, le pasamos el objeto persona cuya información cargaremos en cada campo del formulario
        //para que el usuario edite

        newRow.cells[7].addEventListener("click", function () { desplegarTodo(personBlockScope) });



        //Añadimos al boton de eliminar del formulario la funcion a la que llamar

        newRow.cells[8].innerHTML = "<input id=\"\" type=\"button\" value=\"Eliminame\"/>";

        //Al hacer clic, Le pasamos el id de la persona para eliminarla de la API y el id de la fila
        //para eliminarla visualmente

        newRow.cells[8].addEventListener("click", function () { confirmDelete(personID, ("tr - " + idBlockScope)) });

        

    }
}


/*
 * Wrapper alrededor de la función deletePerson de la API. Se encarga
 * de pedir confirmación para eliminar a la persona, y refleja los cambios
 * visualmente, eliminando la fila en la tabla
 * 
 * @param  {Number} id     El valor del campo id de la persona a eliminar
 * @param  {String} rowID  El atributo id del nodo html de la fila a borrar
 */

function confirmDelete(id, rowID) {

    if (confirm("¿Está seguro de que desea borrar a la persona?") == true) {

        //Si la peticion fue exitosa en la API, se elimina visualmente

        deletePerson(id).then((exitoso) => {
            if (exitoso) {
                document.getElementById(rowID).remove();
            }
        });
    } 
}

