


//COSAS A HACER:
//
//0. HACER ENDPOINT API LISTA PERSONA CON NOMBRE DPTO.
//1. Los nombres de departamento
//2. Que el menu de actualizar y de insertar se latcheen al principio de la página
//3. Comentar y limpiar el código
//4. Manejar las fechas



//This function loads the list of people asynchronously, calling the API

async function showPersonList() {

    var personCollection;
    var departmentCollection;

    //Todo lo que necesite hacer con personCollection lo tengo que hacer aquí
    //No puedo devolver el valor
    getPersonCollection().then((personCollectionAsync) => {

        personCollection = personCollectionAsync;

        getDepartmentCollection().then((departmentCollectionAsync) => {

            departmentCollection = departmentCollectionAsync;


            rellenarTabla(personCollection, departmentCollection);

        });

    });

}

//Funcion auxiliar para transformar un array de departamentos en un array asociativo con la misma información


function transformarDepartamentos(departmentCollection) {

    var arrayDepartamentos = [];

    for (let department of departmentCollection) {
        arrayDepartamentos.DepartmentID = department.Name;
    }

    return arrayDepartamentos;
}



//This function generates the rows and fills them with each person's information, along with update and delete icons
//Los event listeners no están en un método de assignListeners porque se asignan a botones
//creados dinámicamente
    
async function rellenarTabla(personCollection, departmentArray) {

    var table = document.getElementById("listTable");
    var tbody = document.getElementsByTagName('tbody')[0];

    var id = 0;

    //Limpiamos la tabla por si ya está llena de previas iteraciones de esta función
    table.removeChild(tbody);


    //Por cada persona, creamos una nueva fila, 9 celdas, y las rellenamos con sus datos
    //y las últimas 2 celdas contendrán un botón de actualizar y otro de eliminar, respectivamente
    for (var person of personCollection) {

        //Estas variables NECESITAN ser declaradas con let para
        //que su scope sea de bloque. Problemático si no para pasarlas como parámetros
        //https://stackoverflow.com/questions/19586137/addeventlistener-using-for-loop-and-passing-values

        
        let personID = person.id;
        let personBlockScope = person;


        //Necesitamos una variable con scope de bloque
        //que almacene el valor de id en esta iteración.
        //Si usaramos la id normal tendríamos el último valor solamente para pasarlo como parámetros

        let idBlockScope = id;

        var newRow = table.insertRow(table.rows.length);

        //Le asignamos un id a cada fila, diferente en cada iteración
        newRow.id = "tr - " + id;

        //Aumentamos el contador para la proxima fila
        id++;

        for (var i = 0; i < 9; i++) {
            newRow.insertCell(i);
        }



        //Tengo que darle una id a cada botón y asignar aquí los event listeners que llamen
        //a una función y le pase por parámetros una persona

        newRow.cells[0].innerHTML = "<p>" + person.id + "</p>";

        newRow.cells[1].innerHTML = "<p>" + person.FirstName + "</p>";

        newRow.cells[2].innerHTML = "<p>" + person.LastName + "</p>";

        newRow.cells[3].innerHTML = "<p>" + person.Birthdate + "</p>";

        newRow.cells[4].innerHTML = "<p>" + person.PhoneNumber + "</p>";

        newRow.cells[5].innerHTML = "<p>" + person.Email + "</p>";

        newRow.cells[6].innerHTML = "<p>" + departmentArray[person.DepartmentID] + "</p>";

        //Añadimos al boton de actualizar del formulario la funcion a la que llamar, y le pasamos la fila actual
        //para poder alterarla visualmente.


        newRow.cells[7].innerHTML = "<input id=\"\" type=\"button\" value=\"Actualizame\"/>";

        //Le pasamos el id de la fila en la que mostrar el formulario y la persona cuya info. cargaremos en los input

        newRow.cells[7].addEventListener("click", function () { desplegarTodo(personBlockScope) });


        newRow.cells[8].innerHTML = "<input id=\"\" type=\"button\" value=\"Eliminame\"/>";
        newRow.cells[8].addEventListener("click", function () { confirmDelete(personID, ("tr - " + idBlockScope)) });

        

    }
}



//Wrapper alrededor de la función deletePerson de la API, para ponerle un alert
//y para eliminar la fila visualmente

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

