function cityRecords(townsArray) {
    let towns = {};


    for (let townAsString of townsArray) {
        let input = townAsString.split(' <-> ');
        let name = input[0];
        let population = Number(input[1]);

        if (towns[name] == undefined) {
            towns[name] = population;
        } else {
            towns[name] += population;
        }
    }

    for (let name in towns) {
        console.log(`${name} : ${towns[name]}`)
    }
}


cityRecords(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);

cityRecords(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']);