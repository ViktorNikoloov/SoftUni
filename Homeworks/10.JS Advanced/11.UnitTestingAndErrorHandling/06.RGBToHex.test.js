const {expect} = require('chai');
const RGBtoHex = require('./06.RGBToHex');


describe('RGB number to Hex as string', () => {
    it('return undefined when number is < 0', () => {
        expect(RGBtoHex(-2, -3, -5)).to.be.undefined;
    });

    it('return undefined when number is > 255', () => {
        expect(RGBtoHex(256, 270, 310)).to.be.undefined;
    });

    it('return undefined when input is char', () => {
        expect(RGBtoHex('a', 'b', 'c')).to.be.undefined;
    });

    it('return undefined when input is not a number', () => {
        expect(RGBtoHex('1', '2', '3')).to.be.undefined;
    });

    it('return undefined when number is not integer', () => {
        expect(RGBtoHex(2.2)).to.be.undefined;
    });

    it('cover black to hex', () => {
        expect(RGBtoHex(0, 0, 0)).to.equal('#000000');
    });

    it('cover white to hex', () => {
        expect(RGBtoHex(255, 255, 255)).to.equal('#FFFFFF');
    });

    it('cover red to hex', () => {
        expect(RGBtoHex(255, 0, 0)).to.equal('#FF0000');
    });

    it('cover green to hex', () => {
        expect(RGBtoHex(0, 255, 0)).to.equal('#00FF00');
    });

    it('cover blue to hex', () => {
        expect(RGBtoHex(0, 0, 255)).to.equal('#0000FF');
    });

});