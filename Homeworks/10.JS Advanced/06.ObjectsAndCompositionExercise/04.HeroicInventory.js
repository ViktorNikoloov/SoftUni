function heroicInventory(input) {
    const result = [];

    for (let element of input) {

        let allInfo = element.split(' / ');
        let name = allInfo[0];
        let level = allInfo[1];
        let items = allInfo[2] ? allInfo[2].split(', ') : [];

        let newHero = {
            name: name,
            level: Number(level),
            items: items,
        }
        result.push(newHero);
    }

    return JSON.stringify(result);
}

console.log(heroicInventory(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']));

console.log(heroicInventory(['Jake / 1000 / Gauss, HolidayGrenade']));