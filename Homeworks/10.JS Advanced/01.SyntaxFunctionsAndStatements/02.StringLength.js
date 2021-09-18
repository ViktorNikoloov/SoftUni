function averageStringLength(first, second, third){
let lengthOfTheStrings = first.length + second.length + third.length;
let avgOfTheStrings = Math.floor(lengthOfTheStrings / 3);

console.log(lengthOfTheStrings);
console.log(avgOfTheStrings);
}

averageStringLength('chocolate', 'ice cream', 'cake');
averageStringLength('pasta', '5', '22.3');