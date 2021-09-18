function getTheSumOfNumFromNToM(startNum, stopNum) {

    let startIndex = Number(startNum);
    let stopIndex = Number(stopNum);
    let result = 0;
    
    for (let index = startIndex; index <= stopIndex; index++) {
        result += index;
    }
    return result;
}

console.log(getTheSumOfNumFromNToM('-8', '20'));