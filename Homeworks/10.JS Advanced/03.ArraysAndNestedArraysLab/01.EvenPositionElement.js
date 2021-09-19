function printEvenPositionElement(input){
    let result = [];
    for (let index = 0; index < input.length; index+=2) {
        result.push(input[index]);
    }
    return result.join(' ');
}

console.log(printEvenPositionElement(['20', '30', '40', '50', '60']));