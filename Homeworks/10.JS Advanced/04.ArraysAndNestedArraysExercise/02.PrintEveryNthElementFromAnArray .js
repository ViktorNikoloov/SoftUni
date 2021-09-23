function printEveryNthElementFromAnArray (arr, num) {

    let result = [];
    for (let index = 0; index < arr.length; index += num) {
        result.push(arr[index]);
    }
    return(result);
}

console.log(printEveryNthElementFromAnArray(['5', '20', '31', '4', '20'], 2));
console.log(printEveryNthElementFromAnArray(['dsa','asd', 'test', 'tset'], 2));
console.log(printEveryNthElementFromAnArray(['1', '2','3', '4', '5'], 6));