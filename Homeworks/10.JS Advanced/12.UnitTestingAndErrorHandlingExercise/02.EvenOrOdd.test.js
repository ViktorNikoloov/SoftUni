const { expect } = require('chai');
const isOddOrEven = require('./02.EvenOrOdd');

describe('Check is string, odd or even length', () => {
    
    describe('True path', () => {
        it('When input is with odd length return odd', () => {
            expect(isOddOrEven("Odd")).to.be.equal('odd');
        });

        it('When input is with even length return even', () => {
            expect(isOddOrEven("Even")).to.be.equal('even');
        });

    });
    
    describe('Wrong path', () => {

        it('When input is not a string return undefined', () => {
            expect(isOddOrEven(1)).to.be.undefined;
        });
    });
});