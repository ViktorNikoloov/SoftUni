function sortAnArrayBy2Criteria(matrix) {
    let rows = [];
    let cols = [];
    for (let row = 0; row < matrix.length; row++) {
        let rowsSum = 0
        let colsSum = 0
        for (let col = 0; col < matrix.length; col++) {
            rowsSum += matrix[row][col];
            colsSum += matrix[col][row];
        }
        rows.push(rowsSum);
        cols.push(colsSum);
    }

    let isEqual = rows.concat(cols).every((el, i, arr) => el === arr[0]);

    return isEqual;
}

console.log(sortAnArrayBy2Criteria([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
));

console.log(sortAnArrayBy2Criteria([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
));

console.log(sortAnArrayBy2Criteria([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
));