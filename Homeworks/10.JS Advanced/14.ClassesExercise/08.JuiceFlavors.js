function juiceFlavors(arr) {
    let juicesInfo = new Map();
    let juiceBottles = new Map();

    for (const juiceInfo of arr) {
        let splitedInfo = juiceInfo.split(' => ');
        let fruit = splitedInfo[0];
        let quantity = Number(splitedInfo[1]);

        if (!juicesInfo.has(fruit)) {
            juicesInfo.set(fruit, quantity);
        } else {
            juicesInfo.set(fruit, juicesInfo.get(fruit) + quantity);
        }

        while (juicesInfo.get(fruit) >= 1000) {
            if (!juiceBottles.has(fruit)) {
                juiceBottles.set(fruit, 1);
            } else {
                juiceBottles.set(fruit, juiceBottles.get(fruit) + 1);
            }

            juicesInfo.set(fruit, juicesInfo.get(fruit) - 1000);
        }
    }

    for (const [key, value] of juiceBottles) {
        console.log(`${key} => ${value}`)
    }
}

juiceFlavors(
    ['Orange => 2000',
        'Peach => 1432',
        'Banana => 450',
        'Peach => 600',
        'Strawberry => 549'
    ]
);

juiceFlavors(
    ['Kiwi => 234',
        'Pear => 2345',
        'Watermelon => 3456',
        'Kiwi => 4567',
        'Pear => 5678',
        'Watermelon => 6789'
    ]
);