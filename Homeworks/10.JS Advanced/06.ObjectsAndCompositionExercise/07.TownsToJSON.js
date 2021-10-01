function townsToJSON(input) {
    let result = [];
    for (let i = 1; i < input.length; i++) {
        let [town, latitude, longitute] = input[i].split(['|']).slice(1, input[i].length - 1);
        latitude = Number(latitude).toFixed(2);
        longitute = Number(longitute).toFixed(2);
        
        let currTown = {
            Town: town.trim(),
            Latitude: Number(latitude),
            Longitude: Number(longitute)
        }
        result.push(currTown)

    }

    return JSON.stringify(result);
}

console.log(townsToJSON(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));