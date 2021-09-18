function aggregateElementss(numbers){

let sumOfElements = 0;
let inverseSumCalculation = 0;
let concatvalues = "";

for (let index = 0; index < numbers.length; index++) {
    let currNumber = numbers[index];
    sumOfElements+= currNumber;
    inverseSumCalculation += 1/currNumber;
    concatvalues += String(currNumber);
}
console.log(sumOfElements);
console.log(inverseSumCalculation);
console.log(concatvalues);
}

aggregateElementss([1, 2, 3]);
aggregateElementss([2, 4, 8, 16]);