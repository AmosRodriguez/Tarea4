function Developer(name) {
    this.name = name
    this.type = "Desarollador"
}

function Desingner(name) {
    this.name = name
    this.type = "Desingner"
}

function Tester(name) {
    this.name = name
    this.type = "Tester"
}

function Employees() {
    this.create = (name, type) => {
        switch (type) {
            case 1:
                return new Developer(name)
            case 2:
                return new Tester(name)
            case 3:
                return new Desingner(name)
        }
    }
}

function mostrar() {
    console.log(this.name + " Es el " + this.type)
}

const employees = new Employees()
const employeesArg = []

employeesArg.push(Employees.create("Patrick", 1))
employeesArg.push(Employees.create("John", 2))
employeesArg.push(Employees.create("Jamie", 1))
employeesArg.push(Employees.create("Taylor", 3))
employeesArg.push(Employees.create("Tim", 2))
employeesArg.push(Employees.create("Tom", 3))

employees.forEach(emp => {
    mostrar.call(emp)
})