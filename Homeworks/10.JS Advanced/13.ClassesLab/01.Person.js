class Person {
    constructor(firstName, lastName, age, email) {
        this.firstName = firstName,
        this.lastName = lastName,
        this.age = age,
        this.email = email
    }

    toString(){
        return (`${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`);
    }
}

const person = new Person('Viktor', 'Nikolov', 29, 'asd@asd.asd');
console.log(person.toString());