function FruitCalculator(fruit, weightInGrams, price){

    let weightInKg = weightInGrams / 1000;
    let totalPrice = weightInKg * price;

    return (`I need $${totalPrice.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);

}

console.log(FruitCalculator('orange', 2500, 1.80));
console.log(FruitCalculator('apple', 1563, 2.35));