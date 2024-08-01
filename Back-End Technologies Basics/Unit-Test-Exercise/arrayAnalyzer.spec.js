import { analyzeArray } from "./arrayAnalyzer.js"
import { expect } from "chai"

describe ("analyzeArray", ()=>{
    it("should return undefined when pass non-array as input", () => {
        //Arrange
        const nonArrayInput = "someString";
        //Act
        const undefinedResult = analyzeArray(nonArrayInput);
        //Assert
        expect(undefinedResult).to.be.undefined
    })
    
    it("should return undefined when pass empty array as input", () => {
        //Arrange
        const emptyArrayInput = [];
        //Act
        const undefinedResult = analyzeArray(emptyArrayInput);
        //Assert
        expect(undefinedResult).to.be.undefined
    })
    
    it("should return correct value when pass array with different numbers as input", () => {
        //Arrange
        const differentNumbersArrayInput = [1, 2, 3, 4];
        //Act
        const correctResult = analyzeArray(numbersArrayInput);
        //Assert
        expect(correctResult).to.deep.equal({min: 1, max: 4, length: 4});
    })

    it("should return correct value when pass array with single element as input", () => {
        //Arrange
        const singleElementArrayInput = [3];
        //Act
        const correctResult = analyzeArray(singleElementArrayInput);
        //Assert
        expect(correctResult).to.deep.equal({min: 3, max: 3, length: 1});
    })

    it("should return correct value when pass array with same elements as input", () => {
        //Arrange
        const sameElementsArrayInput = [3, 3, 3];
        //Act
        const correctResult = analyzeArray(sameElementsArrayInput);
        //Assert
        expect(correctResult).to.deep.equal({min: 3, max: 3, length: 3});
    })

})