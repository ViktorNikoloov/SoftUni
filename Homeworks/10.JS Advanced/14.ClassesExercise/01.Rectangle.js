class Rectangle {
    constructor(width, height, color) {
        this.width = width,
            this.height = height,
            this.color = color
    }

    // set color(value){
    //     this._color=value;
    // }

    // get color() {
    //     return this._color.substr(0,1).toUpperCase() + this._color.slice(1);
    // }

    calcArea() {
        return this.width * this.height;
    }


}

let rect = new Rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());