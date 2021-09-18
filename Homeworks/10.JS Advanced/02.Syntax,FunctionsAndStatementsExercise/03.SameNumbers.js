function commonDevisor(input) {

    let inputAsString = String(input);
    let isAllDigitsAreTheSame = true;
    let sum = 0;
    for (let index = 0; index < inputAsString.length; index++) {

        sum += Number(inputAsString[index]);
        if (inputAsString[0] != inputAsString[index]) {
            isAllDigitsAreTheSame = false;
        }
    }

    console.log(isAllDigitsAreTheSame);
    console.log(sum);
}
commonDevisor(2222222);
commonDevisor(1234);