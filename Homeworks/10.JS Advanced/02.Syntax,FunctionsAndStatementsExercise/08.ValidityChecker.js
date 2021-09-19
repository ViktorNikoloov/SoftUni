function validate(points) {
    let x1 = parseInt(points[0]);
    let y1 = parseInt(points[1]);
    let x2 = parseInt(points[2]);
    let y2 = parseInt(points[3]);

    let func = (x1,y1,x2,y2)=>{
        let height =x1 - x2;
        let width =  y1 - y2;
        let distance = Math.hypot(height,width);
        if (Number.isInteger(distance)) {
            return true;
        }
        return false;
    }


    console.log(`{${x1}, ${y1}} to {0, 0} is ${func(x1,y1,0,0)?'valid':'invalid'}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${func(x2,y2,0,0)?'valid':'invalid'}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${func(x1,y1,x2,y2)?'valid':'invalid'}`);
}

console.log(validate([3, 0, 0, 4]));
console.log(validate([2, 1, 1, 1]));