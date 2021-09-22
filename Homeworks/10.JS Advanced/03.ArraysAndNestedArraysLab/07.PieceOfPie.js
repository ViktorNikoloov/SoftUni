function takePiecesOfPie(arrayOfPieFlavors, startFlavor, endFlavor) {

    let result = [];
    let startIndex = arrayOfPieFlavors.indexOf(startFlavor);
    let endIndex = arrayOfPieFlavors.indexOf(endFlavor);
    for (let index = startIndex; index <= endIndex; index++) {

        let currFlavor = arrayOfPieFlavors[index];
        result.push(currFlavor);
    }

    return  result;
}

console.log(takePiecesOfPie(
    ['Pumpkin Pie', 'Key Lime Pie', 'Cherry Pie', 'Lemon Meringue Pie', 'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'
));

console.log(takePiecesOfPie([
    'Apple Crisp', 'Mississippi Mud Pie', 'Pot Pie', 'Steak and Cheese Pie', 'Butter Chicken Pie', 'Smoked Fish Pie'],
    'Pot Pie',
    'Smoked Fish Pie'
));