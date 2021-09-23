function listOfNames(arr) {

    let sortedArr = arr.sort((a,b) => a-b);
    let result = [];
    while (sortedArr.length > 0) {
        let smallNum = sortedArr.shift();
        let bigNum = sortedArr.pop();
        result.push(smallNum);
        result.push(bigNum);
    }

    return result;
}

console.log(listOfNames([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));