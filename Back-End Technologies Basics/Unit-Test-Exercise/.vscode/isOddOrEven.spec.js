import { isOddOrEven } from "./isOddOrEven.js"
import { expect } from 'chai'

describe("isOddOrEven", () => {

    it("should return undefined when pass non string value as input", () => {
        
        //Arrange
        const inputValueNumber = 15;
        const inputValueUndefined = undefined;
        const inputValueNull = null;
        const inputValueFloatNumber = 10.10;
        //Act
        const resultNumber = isOddOrEven(inputValueNumber);
        const resultUndefined = isOddOrEven(inputValueUndefined);
        const resultNull = isOddOrEven(inputValueNull);
        const resultFloatNumber = isOddOrEven(inputValueFloatNumber);
        //Assert
        expect (resultNumber).to.be.undefined;
        expect (resultUndefined).to.be.undefined;
        expect (resultNull).to.be.undefined;
        expect (resultFloatNumber).to.be.undefined;
    })

    it ("should return even when the input string lenght is even", () => {
        //Arrange
        const evenStringLength = "1234";
        //Act
        const resultEvenStringLength = isOddOrEven(evenStringLength);
        //Assert
        expect (resultEvenStringLength).to.be.equal('even');
    })

    it ("should return odd when the input string length is odd", () => {
        //Arrange
        const oddStringLength = "123";
        //Act
        const resultOddStringLength = isOddOrEven(oddStringLength)
        //Assert
        expect (resultOddStringLength).to.be.equal('odd');
    })
    it ("it should return even when the input string legth is 0", () => {
        //Arrange
        const zeroStringLength = "123";
        //Act
        const resultZeroStringLength = isOddOrEven(zeroStringLength)
        //Assert
        expect (resultZeroStringLength).to.be.equal('even');
    })
})