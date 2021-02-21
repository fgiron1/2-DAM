
/*
 * Carga la lista de personas de forma as�ncrona, llamando a la API
 * y llama al m�todo rellenarTabla con la informaci�n obtenida, construyendo
 * visualmente la tabla
 */

async function showPersonList() {

    var departmentCollection;

    //Todo lo que necesite hacer con personCollection lo tengo que hacer aqu�
    //No puedo devolver el valor
    getPersonCollection().then((personCollectionAsync) => {

        //C�digo de estado 204: No content
        if (personCollectionAsync === null) {
            document.createElement(h1).innerHtml = "No content";
        } else {
            rellenarTabla(personCollectionAsync);
        }
        
    });

}



/*
 * Esta funci�n se encarga de generar las filas en la tabla y rellenarlas con la informaci�n de cada persona,
 * pasada por par�metros, adem�s de iconos para actualizar y eliminar
 * 
 * Los event listeners no est�n en el m�todo assignListeners (En insert.js) porque se asignan a botones
 * creados din�micamente

 *
 * @param  {Array<Object>} personCollection   Un array de objetos persona. Cada objeto representa a una persona, con toda su informaci�n relevante
 */
    
async function rellenarTabla(personCollection) {

    var table = document.getElementById("listTable");
    var tbody = document.getElementsByTagName('tbody')[0];

    //Limpiamos la tabla por si ya est� llena de previas iteraciones de esta funci�n
    table.removeChild(tbody);


    //Por cada persona, creamos una nueva fila, 9 celdas, y las rellenamos con sus datos.
    //Las primeras 7 celdas se destinan para los datos y las �ltimas 2 celdas contendr�n
    //un bot�n de actualizar y otro de eliminar, respectivamente

    var id = 0;
    for (var person of personCollection) {

        
        let personID = person.id;
        let personBlockScope = person;
        let idBlockScope = id;

        var newRow = table.insertRow(table.rows.length);

        //Le asignamos un id a la nueva fila, diferente en cada iteraci�n
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

        //A�adimos al boton de actualizar del formulario la funci�n a la que llamar

        newRow.cells[7].innerHTML = "<input id=\"\" type=\"button\" value=\"Actualizame\"/>";

        //Al hacer clic, le pasamos el objeto persona cuya informaci�n cargaremos en cada campo del formulario
        //para que el usuario edite

        newRow.cells[7].addEventListener("click", function () { desplegarTodo(personBlockScope) });



        //A�adimos al boton de eliminar del formulario la funcion a la que llamar

        newRow.cells[8].innerHTML = "<input id=\"\" type=\"button\" value=\"Eliminame\"/>";

        //Al hacer clic, Le pasamos el id de la persona para eliminarla de la API y el id de la fila
        //para eliminarla visualmente

        newRow.cells[8].addEventListener("click", function () { confirmDelete(personID, ("tr - " + idBlockScope)) });

        

    }
}


/*
 * Wrapper alrededor de la funci�n deletePerson de la API. Se encarga
 * de pedir confirmaci�n para eliminar a la persona, y refleja los cambios
 * visualmente, eliminando la fila en la tabla
 * 
 * @param  {Number} id     El valor del campo id de la persona a eliminar
 * @param  {String} rowID  El atributo id del nodo html de la fila a borrar
 */

function confirmDelete(id, rowID) {

    if (confirm("�Est� seguro de que desea borrar a la persona?") == true) {

        //Si la peticion fue exitosa en la API, se elimina visualmente

        deletePerson(id).then((exitoso) => {
            if (exitoso) {
                document.getElementById(rowID).remove();
            }
        });
    } 
}

