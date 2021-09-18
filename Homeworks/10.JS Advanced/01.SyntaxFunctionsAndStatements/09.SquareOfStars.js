function SquareOfStars(number) {
    for (let index = 0; index < number; index++) {
        let result = [];

        for (let index = 0; index < number; index++) {
            result.push('*');
        }

        console.log(result.join(' '));
    }
}

SquareOfStars(2);