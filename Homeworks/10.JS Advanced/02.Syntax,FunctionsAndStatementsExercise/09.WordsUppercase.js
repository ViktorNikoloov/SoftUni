function getUppercaseWords(input){

    let allWords = input.toUpperCase().match(/\w+/gim);
    return allWords.join(', ');
}


console.log(getUppercaseWords('Hi, how are you?'));
console.log(getUppercaseWords('hello'));
console.log(getUppercaseWords('Functions in JS can be nested, i.e. hold other functions'));