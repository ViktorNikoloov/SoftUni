function lowerPricesInCities(arr){
    let result = {};

    arr.forEach(element => {
        let [town, product, price] = element.split(' | ');
    });

    
    
    // `${product} -> ${price} (${town})`
    return result;
}

console.log(lowerPricesInCities(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Sample Product | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
));