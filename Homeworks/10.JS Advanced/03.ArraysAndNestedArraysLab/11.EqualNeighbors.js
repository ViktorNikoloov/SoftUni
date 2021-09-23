function equalNeighbors(matrix) {

    let matches = 0;
    let rowLength = matrix[0].length;
    for (let row = 0; row < rowLength; row++) {

        for (let col = 0; col < matrix.length; col++) {
            let currCol;
            let nextRow;
            let nextCol;
            
            if (col < rowLength) {
                currCol = (matrix[col][row]);
                 
            }
            if (row <= rowLength) {
                nextRow = (matrix[col][row + 1]);
            }
            if (col < matrix.length - 1) {
                nextCol = (matrix[col + 1][row]);
            }
            
            if (currCol === nextCol) {
                matches++;
            } else if (currCol === nextRow) {
                matches++;
            }

        }
    }
    return matches;
}

console.log(equalNeighbors(
    [['2', '2', '5', '7', '4'],
    ['4', '0', '5', '3', '4', '4'],
    ['2', '5', '5', '4', '2'],
    ['2', '5']]));

console.log(equalNeighbors(
    [['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]));

console.log(equalNeighbors(
    [['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]));