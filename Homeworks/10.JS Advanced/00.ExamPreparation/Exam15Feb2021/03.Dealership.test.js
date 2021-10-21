const { expect } = require('chai');
const dealership = require('./03.Dealership');

describe("Test functionality of dealership", function() {
    describe("Test functionality of newCarCost", function() {

        it("Get discount if you return an old car from discountForOldCar list", function() {
            expect(dealership.newCarCost('Audi A4 B8', 30000)).to.be.equal(15000);
        });

        it("Return new car price without discount if the old car is not from discountForOldCar list", function() {
            expect(dealership.newCarCost('a', 30000)).to.be.equal(30000);
        });
     });

     describe("Test functionality of carEquipment", function() {

        it("Return the choosen functionality from the array", function() {
            expect(dealership.carEquipment(['a'], [0])).to.deep.equal(['a']);
        });

        it("Return the choosen functionality from the array", function() {
            expect(dealership.carEquipment(['a', 'b', 'c', 'd'], [0, 3])).to.deep.equal(['a', 'd']);
        });
     });

     describe("Test functionality of euroCategory", function() {

        it("Return message when euro category is under 4", function() {
            expect(dealership.euroCategory(3)).to.be.equal('Your euro category is low, so there is no discount from the final price!')
        });

        it("Return message with new discounted price when euro category is over 4", function() {
            expect(dealership.euroCategory(6)).to.be.equal(`We have added 5% discount to the final price: 14250.`)
        });

        it("Return message with new discounted price when euro category is exactly 4", function() {
            expect(dealership.euroCategory(4)).to.be.equal('We have added 5% discount to the final price: 14250.')
        });
     });

});
