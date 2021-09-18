function getPreviousDay(year, month, day) {

    let date = new Date(year + '-' + month + '-' + day);
    date.setDate(day - 1);

    return(`${date.getFullYear()}-${(Number(date.getMonth()) + 1)}-${date.getDate()}`);
}

consoloe.log(getPreviousDay(2016, 9, 30));
consoloe.log(getPreviousDay(2016, 10, 1));