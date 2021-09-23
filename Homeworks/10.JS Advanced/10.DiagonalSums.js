function takeDiagonalSymsOfArr(matrix) {

    let result = [];
    let leftDiagonal = 0;
    let rightDiagonal = 0;
    for (let index = 0; index <= matrix.length - 1; index++) {

            leftDiagonal += matrix[index][index];
            rightDiagonal += matrix[index][(matrix.length - 1 - index)];
    }
    result.push(leftDiagonal);
    result.push(rightDiagonal);

    return result.join(' ');
}

console.log(takeDiagonalSymsOfArr(
    [[20, 40],
    [10, 60]]));

console.log(takeDiagonalSymsOfArr(
    [[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]));