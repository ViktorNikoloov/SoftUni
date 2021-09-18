function circleArea(input){
let typeOfInput = typeof(input);
let result;

if(typeOfInput == 'number'){
result = Math.PI * Math.pow(input, 2);
return result.toFixed(2);
}

return (`We can not calculate the circle area, because we receive a ${typeOfInput}.`);

}

console.log(circleArea(6));