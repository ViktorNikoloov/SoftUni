const { expect } = require('chai');
const rgbToHexColor = require('./06.RGBToHex');


describe('RGB number to Hex as string', () => {

    describe('Undefined path', () => {

        it('return undefined when all number are < 0', () => {
            expect(rgbToHexColor(-2, -3, -5)).to.be.undefined;
        });

        it('return undefined when first num is < 0', () => {
            expect(rgbToHexColor(-2, 240, 230)).to.be.undefined;
        });

        it('return undefined when  third number is < 0', () => {
            expect(rgbToHexColor(230, 240, -5)).to.be.undefined;
        });

        it('return undefined when second number is < 0', () => {
            expect(rgbToHexColor(240, -1, 250)).to.be.undefined;
        });

        it('return undefined when number is > 255', () => {
            expect(rgbToHexColor(256, 270, 310)).to.be.undefined;
        });

        it('return undefined when input is char', () => {
            expect(rgbToHexColor('a', 'b', 'c')).to.be.undefined;
        });

        it('return undefined when input is not a number', () => {
            expect(rgbToHexColor('1', '2', '3')).to.be.undefined;
        });

        it('return undefined when number is not integer', () => {
            expect(rgbToHexColor(2.2)).to.be.undefined;
        });

        it('return undefined when parameter count in not corrent', () => {
            expect(rgbToHexColor(255)).to.be.undefined;
        });

    });

    describe('Right path', () => {

        it('cover black to hex', () => {
            expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
        });

        it('cover white to hex', () => {
            expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
        });

        it('cover red to hex', () => {
            expect(rgbToHexColor(255, 0, 0)).to.equal('#FF0000');
        });

        it('cover green to hex', () => {
            expect(rgbToHexColor(0, 255, 0)).to.equal('#00FF00');
        });

        it('cover blue to hex', () => {
            expect(rgbToHexColor(0, 0, 255)).to.equal('#0000FF');
        });

    });

});