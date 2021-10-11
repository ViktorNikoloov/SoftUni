const { expect } = require('chai');
const isSymmetric = require('./05.CheckForSymmetry');

describe('is array symmetric', () => {
    it('return true for valid symmetric input', () => {
        expect(isSymmetric([1, 1])).to.true;
    });

    it('return false for valid non-symmetric input', () => {
        expect(isSymmetric([1, 2])).to.be.false;
    });

    it('returns false for invalid argument', () => {
        expect(isSymmetric(['a'])).to.be.false;
    });

    it('returns false for mixed arguments', () => {
        expect(isSymmetric(['1', 1])).to.be.false;
    });

    it('returns true for multiple arguments', () => {
        expect(isSymmetric([1, 1, 1])).to.true;
    });

    it('returns true for valid symmetric string array', () => {
        expect(isSymmetric(['a', 'a'])).to.true;
    });

    it('returns false for non-simetric string array', () => {
        expect(isSymmetric(['a', 'b'])).to.be.false;
    });

    it('returns false for non-array', () => {
        expect(isSymmetric(1)).to.be.false;
    });
});