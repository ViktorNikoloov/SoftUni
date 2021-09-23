function AddAndRemoveElements(arr) {

    let result = [];
    let number = 1;
    for (let index = 0; index < arr.length; index ++) {
        if (arr[index] == 'add') {
        result.push(number);
        } else{
            result.pop();
        }
        number++;
    }

    return result.length != 0 ? result.join("\n") : 'Empty';
}

console.log(AddAndRemoveElements(['add', 'add', 'add', 'add']));
console.log(AddAndRemoveElements(['add', 'add', 'remove', 'add', 'add']));
console.log(AddAndRemoveElements(['remove', 'remove', 'remove']));