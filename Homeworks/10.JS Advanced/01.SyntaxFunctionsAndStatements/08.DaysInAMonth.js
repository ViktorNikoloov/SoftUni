function DaysInAMonth(month, year){

let result = new Date(year, month, 0).getDate();
return result;

}

console.log(DaysInAMonth(1, 2012));