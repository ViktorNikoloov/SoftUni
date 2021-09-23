function listOfNames(arr) {

    let result = arr.sort((a,b) => a.localeCompare(b));
    for (let index = 0; index < result.length; index ++) {
    console.log(`${index + 1}.${result[index]}`);

    }
}

listOfNames(["John", "Bob", "Christina", "Ema"]);