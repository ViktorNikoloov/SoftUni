function carFactory(car) {
    const result = {};

    function createEngine(power) {
        if (power <= 90) {
            return { power: 90, volume: 1800 }

        } else if (power <= 120) {
            return { power: 120, volume: 2400 }
        } else {
            return { power: 200, volume: 3500 }
        }
    }

    let power = car.power;

    result.model = car.model;
    result.engine = createEngine(power)
    result.carriage = { type: car.carriage, color: car.color };
    result.wheels = new Array(4).fill(car.wheelsize % 2 == 0 ? car.wheelsize - 1 : car.wheelsize, 0, 4);

    return result;
}


console.log(carFactory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));

console.log(carFactory({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 }
));