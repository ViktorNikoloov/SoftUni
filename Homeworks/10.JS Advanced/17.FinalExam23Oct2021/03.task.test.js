const { expect } = require('chai');
const library = require('./03.task');

describe("Test library", function () {

    describe("Test calcPriceOfBook ", function () {
        it("incorrect input", function () {
            expect(() => library.calcPriceOfBook(2, 2)).to.throw('Invalid input');
        });

        it("incorrect input", function () {
            expect(() => library.calcPriceOfBook(2, 'a')).to.throw('Invalid input');
        });

        it("incorrect input", function () {
            expect(() => library.calcPriceOfBook('a', 2.2)).to.throw('Invalid input');
        });

        it("incorrect input", function () {
            expect(() => library.calcPriceOfBook(2, '2')).to.throw('Invalid input');
        });

        it("incorrect input", function () {
            expect(() => library.calcPriceOfBook(2, -1)).to.throw('Invalid input');
        });

        it("year bigger than 1980 return price", function () {
            expect(library.calcPriceOfBook('a', 1981)).to.equal('Price of a is 20.00');
        });

        it("year less than 1980 return price", function () {
            expect(library.calcPriceOfBook('a', 1979)).to.equal('Price of a is 10.00');
        });

        it("year equal to 1980 return price", function () {
            expect(library.calcPriceOfBook('a', 1980)).to.equal('Price of a is 10.00');
        });

    });

    describe("Test findBook", function () {
        it("arr of book is zero", function () {
            expect(() => library.findBook([], 'Troy')).to.throw('No books currently available');
        });

        it("when book is not in the arr", function () {
            expect(library.findBook(['a'], 'Troy')).to.equal('The book you are looking for is not here!');
        });

        it("When the book is in the arr", function () {
            expect(library.findBook(['Troy'], 'Troy')).to.equal('We found the book you want.');
        });

    });

    describe("АrrangeTheBooks ", function () {
        it("Number is not integer", function () {
            expect(() => library.arrangeTheBooks('2')).to.throw('Invalid input');
        });

        it("Number is not integer", function () {
            expect(() => library.arrangeTheBooks(2.2)).to.throw('Invalid input');
        });

        it("Number is negative integer", function () {
            expect(() => library.arrangeTheBooks(-2)).to.throw('Invalid input');
        });

        it("Number is negative not integer", function () {
            expect(() => library.arrangeTheBooks(-2.2)).to.throw('Invalid input');
        });

        it("When countBooks equal avaible space", function () {
            expect(library.arrangeTheBooks(40)).to.equal('Great job, the books are arranged.');
        });

        it("When countBooks is less than avaible space", function () {
            expect(library.arrangeTheBooks(39)).to.equal('Great job, the books are arranged.');
        });

        it("When countBooks is more than avaible space", function () {
            expect(library.arrangeTheBooks(41)).to.equal('Insufficient space, more shelves need to be purchased.');
        });

    });

});


