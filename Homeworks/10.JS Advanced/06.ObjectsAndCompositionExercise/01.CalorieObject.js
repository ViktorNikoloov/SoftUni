function calorieObject(arr) {
    const result = {};
    let food;
    let calories;
    for (let i = 0; i < arr.length; i++) {

        if (i % 2 == 0) {
            food = arr[i];
        } else {
            calories = Number(arr[i]);
        }
        result[food] = calories;
    }
    return result;
}

console.log(calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));