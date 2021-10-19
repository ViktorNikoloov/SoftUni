class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;
        this.result = string;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength -= length;
        if (this.innerLength < 0) {
            this.innerLength = 0;
        }

    }

    toString() {
        this.result = this.innerString;
        this.result = this.result.slice(0, this.innerLength)
        if (this.innerString.length != this.result.length) {
            this.result += '...';
        }

        return `${this.result}`;
    }
}

let test = new Stringer("Tester", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
