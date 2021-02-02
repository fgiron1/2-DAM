window.onload = assignEventListeners;

function assignEventListeners() {

    showPersonList();

    //INSERT CONTENT LISTENERS
    document.getElementById("btnInsertar").addEventListener("click", function () { btnInsertar(); });
    document.getElementById("btnDesplegarInsertar").addEventListener("click", function () { desplegarInsert() });

    //UPDATE CONTENT LISTENERS
    document.getElementById("btnActualizar").addEventListener("click", function () { btnActualizar(); });


}


function desplegarInsert() {

    var formularioInsertar = document.getElementById("formularioInsertar");

    //Tengo que añadirle al boton

    //Comprobamos si el formulario ya está desplegado o no

    if (formularioInsertar.classList.contains("hidden")) {

        //Desactivamos la clase visible
        formularioInsertar.classList.toggle("visible");

        //Activamos la clase hidden
        formularioInsertar.classList.toggle("hidden");

    } else {
        //Desactivamos clase visible
        formularioInsertar.classList.toggle("visible");

        //Activamos clase escondido
        formularioInsertar.classList.toggle("hidden");

    }
}

function btnInsertar() {

    //Le paso la fila, pero 

    //Construimos la persona y llamamos al método
    //que actualiza a la api

    //MANDAMOS 0 COMO ID AUNQUE NO HAGA FALTA
    //PORQUE NO PODEMOS TENER MULTIPLES CONSTRUCTORES
    //Ademas, en la api, aunque la envies, no la utiliza

    var personToInsert = new PersonDepartment(0, document.getElementById("insertFirstName").value, document.getElementById("insertLastName").value, document.getElementById("insertBirthdate").value, document.getElementById("insertPhoneNumber").value, document.getElementById("insertEmail").value, document.getElementById("insertDepartmentID").value);

    //Si se consigue actualizar, recargamos para que se refleje visualmente
    insertPerson().then((exitoso) => {
        if (exitoso) {
            showPersonList();
        }
    });

}
