function takePiecesOfPie(arr) {

    let result = [];
    for (let index = 1; index < arr.length; index +=2) {

        let currNumber =Number(arr[index]) * 2;
        result.push(currNumber);
    }

    result.reverse();
    return  result.join(' ');
}

console.log(takePiecesOfPie([10, 15, 20, 25]));
console.log(takePiecesOfPie([3, 0, 10, 4, 7, 3]));