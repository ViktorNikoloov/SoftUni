function heroicInventory(input) {
    const result = [];

    // First decision
    // for (let element of input) {
    //     let allInfo = element.split(' / ');
    //     let name = allInfo[0];
    //     let level = allInfo[1];
    //     let items = allInfo[2] ? allInfo[2].split(', ') : [];

    //     let newHero = {
    //         name: name,
    //         level: Number(level),
    //         items: items,
    //     }

    //     result.push(newHero);
    // }

    // Second decision
    while (input.length) {
        let hero = input.shift();
        let [name, level, itemsString] = hero.split(' / ');
        level = Number(level);
        const items = itemsString ? itemsString.split(', ') : [];

        result.push({ name, level, items })
    }

    return JSON.stringify(result);
}

console.log(heroicInventory(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']));

console.log(heroicInventory(['Jake / 1000 / Gauss, HolidayGrenade']));