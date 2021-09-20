function getSmallestTwoNumbers(arr) {

    let input = arr;
    let result = [];

    for (let index = 0; index < 2; index++) {
        let smallestNum = Math.min(...arr);
        let numberIndex = input.indexOf(smallestNum);

        result.push(input[numberIndex]);
        input.splice(numberIndex, 1);
    }

    return result.join(' ');
}

console.log(getSmallestTwoNumbers([30, 15, 50, 5]));
console.log(getSmallestTwoNumbers([3, 0, 10, 4, 7, 3]));