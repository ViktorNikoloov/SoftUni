function rotateArray (arr, numberOfRotations) {

    let result = arr;
    for (let index = 0; index < numberOfRotations; index ++) {
        let latstNum = arr.pop();
        result.unshift(latstNum);
    }

    return result.join(' ');
}

console.log(rotateArray(['1', '2', '3', '4'], 2));
console.log(rotateArray(['Banana', 'Orange', 'Coconut', 'Apple'], 15));