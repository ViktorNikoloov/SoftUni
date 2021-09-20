function SortArray(arr) {

    let result = [];
    for (let index = 0; index < arr.length; index++) {

        let currNumber = arr[index];
        if (currNumber < 0) {
            result.unshift(currNumber);
        } else {
            result.push(currNumber);
        }
    }

    for (const number of result) {
        console.log(number);
    }
}

SortArray([7, -2, 8, 9]);
SortArray([3, -2, 0, -1]);