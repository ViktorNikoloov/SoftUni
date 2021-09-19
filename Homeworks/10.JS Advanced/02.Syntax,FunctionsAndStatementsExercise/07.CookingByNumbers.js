function cookingByNumbers(numberAsString, operator1, operator2, operator3, operator4, operator5) {

    let operators = [operator1, operator2, operator3, operator4, operator5];
    let result = Number(numberAsString);

    for (let index = 0; index < operators.length; index++) {
        let currOperator = operators[index];
        if (currOperator == 'chop') {
            result /= 2;
            console.log(result);
        } else if (currOperator == 'dice') {
            result = Math.sqrt(result);
            console.log(result);
        } else if (currOperator == 'spice') {
            result += 1;
            console.log(result);
        } else if (currOperator == 'bake') {
            result *= 3;
            console.log(result);
        } else if (currOperator == 'fillet') {
            result -= result * 0.2;
            console.log(result);
        }
    }
    
}

//cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');