class PersonDepartment {

    constructor(id, FirstName, LastName, Birthdate, PhoneNumber, Email, DepartmentID) {

        this.id = id;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Birthdate = Birthdate;
        this.PhoneNumber = PhoneNumber;
        this.Email = Email;
        this.DepartmentID = DepartmentID;
        //CONVERSI�N DE DEPARTMENT ID A NOMBRE DEPARTAMENTO USANDO UNA FUNCI�N QUE LO TRADUZCA
        //LLAMANDO A api/Departments/id te devuelve toda la info, y coges el nombre
    }

}