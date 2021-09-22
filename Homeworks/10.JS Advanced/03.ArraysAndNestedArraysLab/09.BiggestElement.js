function takeBiggestElement(matrix) {

    let maxValue = Number.MIN_VALUE;
    for (let row = 0; row <= matrix.length; row++) {

        for (let col = 0; col < matrix.length; col++) {

            let currValue = (matrix[col][row]);
            if (maxValue < currValue) {
                maxValue = currValue;
            }
        }
    }
    return maxValue;
}

console.log(takeBiggestElement(
    [[20, 50, 10],
    [8, 33, 145]]));

console.log(takeBiggestElement(
    [[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]));