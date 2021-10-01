function store(input) {
    let dictionary = {};

    while (input.length) {
        let [productName, productPrice] = input.shift().split(' : ');
        const firstLetter = productName[0];

        if (!dictionary[firstLetter]) {
            dictionary[firstLetter] = [];
        }

        dictionary[firstLetter].push({ productName, price: Number(productPrice) });
        dictionary[firstLetter].sort((a, b) => (a.productName).localeCompare(b.productName));
    }

    let result = [];
    // for (const letter in dictionary) {
    //     let values = dictionary[letter].map(entry => `  ${entry.productName}: ${entry.price}`);

    //     let string = `${letter}\n${values.join('\n')}`;
    //     result.push(string);
    // }

    Object.entries(dictionary).sort((a, b) => a[0].localeCompare(b[0]))
        .forEach(entry => {
            let values = entry[1]
                .sort((a, b) => (a.productName).localeCompare(b.productName))
                .map(product => `  ${product.productName}: ${product.price}`)
                .join('\n');

            let string = `${entry[0]}\n${values}`;
            result.push(string);
        })

    return result.join('\n');
}

console.log(store(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
));