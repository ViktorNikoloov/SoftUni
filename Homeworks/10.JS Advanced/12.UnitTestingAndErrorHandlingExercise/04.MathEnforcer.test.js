const { expect } = require('chai');
const mathEnforcer = require('./04.MathEnforcer');

describe('Check correct work of all functions', () => {

    describe('AddFive function', () => {

        it('Return the correct num +5', () => {
            expect(mathEnforcer.addFive(2)).to.be.equal(7);
        });

        it('Return the correct num +5, working with negative num', () => {
            expect(mathEnforcer.addFive(-10)).to.equal(-5);
        })

        it('Return the correct num +5', () => {
            expect(mathEnforcer.addFive(2.2)).to.be.equal(7.2);
        });

        it('Return undefined when paramether is not a num', () => {
            expect(mathEnforcer.addFive('a')).to.be.undefined;
        });

        it('Return undefined when paramether is num as string', () => {
            expect(mathEnforcer.addFive('2')).to.be.undefined;
        });

    });

    describe('SubtractTen function', () => {

        it('Return the correct num -10', () => {
            expect(mathEnforcer.subtractTen(20)).to.be.equal(10);
        });

        it('Return the correct num -10, working with negative num', () => {
            expect(mathEnforcer.subtractTen(-10)).to.equal(-20);
        })

        it('Return the correct num -10', () => {
            expect(mathEnforcer.subtractTen(22.2)).to.be.equal(12.2);
        });

        it('Return undefined when paramether is not a num', () => {
            expect(mathEnforcer.subtractTen('a')).to.be.undefined;
        });

        it('Return undefined when paramether is num as string', () => {
            expect(mathEnforcer.subtractTen('2')).to.be.undefined;
        });

    });

    describe('Sum function', () => {

        it('Return the sum of two num', () => {
            expect(mathEnforcer.sum(20, 10)).to.be.equal(30);
        });

        it('Return the sum of two num', () => {
            expect(mathEnforcer.sum(22.2, 7.8)).to.be.equal(30);
        });

        it('Return undefined when first paramether is not a num', () => {
            expect(mathEnforcer.sum('a', 2)).to.be.undefined;
        });

        it('Return undefined when second paramether is not a num', () => {
            expect(mathEnforcer.sum(2, 'a')).to.be.undefined;
        });

        it('Return undefined when first paramether is num as string', () => {
            expect(mathEnforcer.sum('2', 2)).to.be.undefined;
        });

        it('Return undefined when second paramether is num as string', () => {
            expect(mathEnforcer.sum(2, '2')).to.be.undefined;
        });

        it('Return undefined when both paramethers are num as string', () => {
            expect(mathEnforcer.sum('2', '2')).to.be.undefined;
        });

        it('Return undefined when both paramether are not a num', () => {
            expect(mathEnforcer.sum('a', 'a')).to.be.undefined;
        });

    });

});