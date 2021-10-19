class List {

    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(value) {
        this.list.push(value);
        this.list.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        if (index < 0 || index > this.list.length - 1) {
            throw new Error('Index out of range!')
        } else {
            this.list.splice(index, 1);
            this.list.sort((a, b) => a - b);
            this.size--;
        }

    }

    get(index) {
        return this.list[index];
    }

    size() {
        return `${Number(this.list.length)}`;
    }

}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
