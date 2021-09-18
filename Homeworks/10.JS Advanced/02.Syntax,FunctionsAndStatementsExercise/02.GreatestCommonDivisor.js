function commonDevisor(firstNum, secondNum){

    while (secondNum != 0) {
        let temp = secondNum;
        secondNum = firstNum % secondNum;
        firstNum = temp;
    }
    return firstNum;

}

console.log(commonDevisor(15, 5));
console.log(commonDevisor(2154, 458));