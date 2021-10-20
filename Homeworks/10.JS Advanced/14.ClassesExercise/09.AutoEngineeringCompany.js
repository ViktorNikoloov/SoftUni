function autoEngineeringCompany(arr) {
    let producedCars = new Map();

    for (const car of arr) {
        let [brand, model, produced] = car.split(' | ');
        let producedAsNum = Number(produced);
        if (!producedCars.has(brand)) {
            producedCars.set(brand, []);
            producedCars.get(brand).push({ model, producedAsNum });

        } else if (producedCars.get(brand).some(x => x.model == model)) {
            producedCars.get(brand).find(x => x.model == model).producedAsNum += producedAsNum;
        } else {
            producedCars.get(brand).push({ model, producedAsNum });
        }
    }

    for (const [key, models] of producedCars) {

        console.log(key);
        for (const modelInfo of models) {
            console.log(`###${modelInfo.model} -> ${modelInfo.producedAsNum}`)
        }
    }
}

autoEngineeringCompany(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']

);