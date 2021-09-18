function timeToWalk(numberofSteps, footprintInMeters, speed){

    let length = numberofSteps * footprintInMeters;
    let totalRestsInMinutes = Math.floor(length / 500);
    let totalTime = length / speed / 1000 * 60;

    let totalTimeInSeconds = Math.ceil((totalRestsInMinutes + totalTime) * 60);

    let result = new Date(null, null, null, null, null, totalTimeInSeconds);

    return result.toTimeString().split(' ')[0];
}

console.log(timeToWalk(4000, 0.60, 5));
console.log(timeToWalk(2564, 0.70, 5.5));