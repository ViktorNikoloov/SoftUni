function calculator(firstNum, SecondNum, operant){
    let result;
    if(operant == '+'){
        result = firstNum + SecondNum;
    } else if(operant == '-'){
        result = firstNum - SecondNum;
    } else if(operant == '*'){
        result = firstNum * SecondNum;
    } else if(operant == '/'){
        result = firstNum / SecondNum;
    } else if(operant == '%'){
        result = firstNum % SecondNum;
    } else if(operant == '**'){
        result = firstNum ** SecondNum;
    } else{
        result = 'The operator is not valid';
    }

    return result;
}

console.log(calculator(5, 6, '+'));
console.log(calculator(3, 5.5, '*'));