function getPersons() {

    class Person {
        constructor(firstName, lastName, age, email) {
            this.firstName = firstName,
                this.lastName = lastName,
                this.age = age,
                this.email = email
        }

        toString() {
            return (`${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`);
        }
    }
    let result = [];

    const Anna = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
    result.push(Anna);

    const SoftUni = new Person('SoftUni');
    result.push(SoftUni);

    const Stephan = new Person('Stephan', 'Johnson', 25);
    result.push(Stephan);

    const Gabriel = new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com');
    result.push(Gabriel);

    return result;
}

console.log(getPersons());