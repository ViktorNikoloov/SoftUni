function SumOfTheFirstAndLastElements(arr){

let firstElement = Number(arr.shift());
let lastElement = Number(arr.pop());
let result = firstElement + lastElement;

return result;
}

console.log(SumOfTheFirstAndLastElements(['20', '30', '40']));
console.log(SumOfTheFirstAndLastElements(['5', '10']));