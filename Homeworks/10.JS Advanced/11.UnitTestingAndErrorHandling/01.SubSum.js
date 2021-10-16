function sumARangeOfNumericElements(arr, startIndex, endIndex) {
    let startIndexAsNum = Number(startIndex);
    let endtIndexAsNum = Number(endIndex);

    let sum = 0;
    if (!Array.isArray(arr)) {
        return NaN;
    } if (startIndexAsNum < 0) {
        startIndexAsNum = 0;
    } if (endtIndexAsNum > arr.length - 1) {
        endtIndexAsNum = arr.length - 1;
    }

    for (let index = startIndexAsNum; index <= endtIndexAsNum; index++) {
        sum += Number(arr[index]);

    }

    return sum;
}

console.log(sumARangeOfNumericElements([10, 20, 30, 40, 50, 60], 3, 300));
console.log(sumARangeOfNumericElements([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(sumARangeOfNumericElements([10, 'twenty', 30, 40], 0, 2));
console.log(sumARangeOfNumericElements([], 1, 2));
console.log(sumARangeOfNumericElements('text', 0, 2));
