class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(username, salary, position, department) {
        if (!username || !position || !department || !salary || salary < 0) {
            throw new Error('Invalid input!');
        }
        let newEmployee = {
            username: username,
            salary: Number(salary),
            position: position
        }

        if (!this.departments[department]) {
            this.departments[department] = [];
        }
        this.departments[department].push(newEmployee);
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartment = '';
        let avgSalary = 0;

        Object.entries(this.departments).forEach(([key, value]) => {
            let currSalary = 0;
            value.forEach(s => {
                currSalary += s.salary;
            })

            currSalary = currSalary / value.length;
            if (currSalary > avgSalary) {
                bestDepartment = key;
                avgSalary = currSalary;
            }
        })

        if (bestDepartment != null) {
            let result = `Best Department is: ${bestDepartment}\nAverage salary: ${avgSalary.toFixed(2)}\n`;

            Object.values(this.departments[bestDepartment]).sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username))
                .forEach(emp => {
                    let employee = `${emp.username} ${emp.salary} ${emp.position}\n`;
                    result += employee;
                });;

            return result.trim();
        }

    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
