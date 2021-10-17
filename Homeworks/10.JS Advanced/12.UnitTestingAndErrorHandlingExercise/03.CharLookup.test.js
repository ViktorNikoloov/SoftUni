const { expect } = require('chai');
const lookupChar = require('./03.CharLookup');

describe('Give the correct index of the string', () => {

    describe('Undefined path', () => {

        it('Return undefined when first paramether is not a string', () => {
            expect(lookupChar(2, 2)).to.be.undefined;
        });
        
        it('Return undefined when second paramether is decimal num', () => {
            expect(lookupChar('text', 3.3)).to.be.undefined
        })

        it('Return undefined when second paramether is not a num', () => {
            expect(lookupChar('abcd', 'a')).to.be.undefined;
        });

        it('Return undefined when second paramether is num as string', () => {
            expect(lookupChar('abcd', '2')).to.be.undefined;
        });

        it('Return undefined when second paramether is negative num', () => {
            expect(lookupChar('abcd', -1)).to.be.equal('Incorrect index');
        });

        it('Return undefined when second paramether is equal to string length', () => {
            expect(lookupChar('abcd', 4)).to.be.equal('Incorrect index');
        });

        it('Return undefined when second paramether is bigger then string length', () => {
            expect(lookupChar('abcd', 6)).to.be.equal('Incorrect index');
        });
    });

    describe('Right path', () => {

        it('Return index 3 of the string abcde', () => {
            expect(lookupChar('abcde', 2)).to.equal('c');
        });
        
    });

});