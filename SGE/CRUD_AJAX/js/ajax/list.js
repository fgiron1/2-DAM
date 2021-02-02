

//This function generates the rows and fills them with each person's information, along with update and delete icons
//Los event listeners no est�n en un m�todo de assignListeners porque se asignan a botones
//creados din�micamente

//This function loads the list of people, calling the API

function showPersonList() {

    var id = 0;
    var table = document.getElementById("listTable");
    var tbody = document.getElementsByTagName('tbody')[0];

    var personCollection = getPersonCollection();

    //Limpiamos la tabla por si ya est� llena de previas iteraciones de esta funci�n
    table.removeChild(tbody);

    //Por cada persona, creamos una nueva fila, 9 celdas, y las rellenamos con sus datos
    //y las �ltimas 2 celdas contendr�n un bot�n de actualizar y otro de eliminar, respectivamente
    for (var person of personCollection) {

        //Estas variables NECESITAN ser declaradas con let para
        //que su scope sea de bloque. Problem�tico si no para pasarlas como par�metros
        //https://stackoverflow.com/questions/19586137/addeventlistener-using-for-loop-and-passing-values

        
        let personID = person.id;
        let personBlockScope = person;


        //Necesitamos una variable con scope de bloque
        //que almacene el valor de id en esta iteraci�n.
        //Si usaramos la id normal tendr�amos el �ltimo valor solamente para pasarlo como par�metros

        let idBlockScope = id;

        var newRow = table.insertRow(table.rows.length);

        let newRowBlockScope = newRow;

        //Le asignamos un id a cada fila, diferente en cada iteraci�n
        newRow.id = "tr - " + id;

        //Aumentamos el contador para la proxima fila
        id++;

        for (var i = 0; i < 9; i++) {
            newRow.insertCell(i);
        }



        //Tengo que darle una id a cada bot�n y asignar aqu� los event listeners que llamen
        //a una funci�n y le pase por par�metros una persona

        newRow.cells[0].innerHTML = "<p>" + person.id + "</p>";

        newRow.cells[1].innerHTML = "<p>" + person.FirstName + "</p>";

        newRow.cells[2].innerHTML = "<p>" + person.LastName + "</p>";

        newRow.cells[3].innerHTML = "<p>" + person.Birthdate + "</p>";

        newRow.cells[4].innerHTML = "<p>" + person.PhoneNumber + "</p>";

        newRow.cells[5].innerHTML = "<p>" + person.Email + "</p>";

        newRow.cells[6].innerHTML = "<p>" + person.DepartmentID + "</p>";

        //A�adimos al boton de actualizar del formulario la funcion a la que llamar, y le pasamos la fila actual
        //para poder alterarla visualmente.


        newRow.cells[7].innerHTML = "<input id=\"\" type=\"button\" value=\"Actualizame\"/>";

        //Le pasamos el id de la fila en la que mostrar el formulario y la persona cuya info. cargaremos en los input

        newRow.cells[7].addEventListener("click", function () { desplegarTodo(personBlockScope) });


        newRow.cells[8].innerHTML = "<input id=\"\" type=\"button\" value=\"Eliminame\"/>";
        newRow.cells[8].addEventListener("click", function () { confirmDelete(personID, ("tr - " + idBlockScope)) });

        

    }
}

//Wrapper alrededor de la funci�n deletePerson de la API, para ponerle un alert
//y para eliminar la fila visualmente
function confirmDelete(id, rowID) {
    if (confirm("�Est� seguro de que desea borrar a la persona?") == true) {

        //Si la peticion fue exitosa en la API, se elimina visualmente
        if (deletePerson(id)) {
            document.getElementById(rowID).remove();
        }
    } 
}

//L�gica del bot�n de actualizar, asignada como callback para el boton del formulario
