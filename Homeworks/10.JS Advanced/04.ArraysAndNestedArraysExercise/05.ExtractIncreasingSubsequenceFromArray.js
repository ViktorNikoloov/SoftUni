function extractIncreasingSubsequenceFromArray (arr) {

    let result = [];
    for (let index = 0; index < arr.length; index ++) {

        let currNUm = arr[index];
        if (currNUm >= result[result.length - 1] || result.length === 0) {
            result.push(currNUm);
        }
    }

    return result;
}

console.log(extractIncreasingSubsequenceFromArray([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(extractIncreasingSubsequenceFromArray([1, 2, 3, 4]));
console.log(extractIncreasingSubsequenceFromArray([20, 3, 2, 15, 6, 1]));