function getBiggerHalf(arr) {

    let orderArray = arr.sort((a, b) => a - b);
    let half = Math.ceil(orderArray.length / 2);
    result = orderArray.slice(-half);


    return result;
}

console.log(getBiggerHalf([4, 7, 2, 5]));
console.log(getBiggerHalf([3, 19, 14, 7, 2, 19, 6]));