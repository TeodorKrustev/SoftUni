import { lookupChar } from "./charLookUp.js";
import { expect } from "chai";

describe("lookupChar", () => {

    it("should return undefined when First parameter is from incorrect and second is with correct type", () => {
        //Arrange
        const incorrectFirstParam = 123;
        const correctSecondParam = "1";
        //Act
        const undefinedResult = lookupChar(incorrectFirstParam, correctSecondParam);
        //Assert
        expect(undefinedResult).to.be.undefined;
    })

    it("should return undefined when First parameter is from correct and second is with incorrect type", () => {
        //Arrange
        const correctFirstParam = "string";
        const incorrectSecondParam = 10.10;
        //Act
        const undefinedResult = lookupChar(correctFirstParam, incorrectSecondParam);
        //Assert
        expect(undefinedResult).to.be.undefined;
    })

    it("should return undefined when First parameter is from correct and second is with incorrect float type", () => {
        //Arrange
        const correctFirstParam = "string";
        const incorrectFloatNumberSecondParam = "1";
        //Act
        const undefinedResult = lookupChar(correctFirstParam, incorrectFloatNumberSecondParam);
        //Assert
        expect(undefinedResult).to.be.undefined;
    })

    it("should return Incorrect Index when First parameter is from correct and second is bigger than the string length", () => {
        //Arrange
        const correctFirstParam = "string";
        const biggerLengthSecondParam = 20;
        //Act
        const incorrectIndexResult = lookupChar(correctFirstParam, biggerLengthSecondParam);
        //Assert
        expect(incorrectIndexResult).to.be.equal("Incorrect index");
    })

    it("should return Incorrect Index when First parameter is from correct and second is lower than the string length", () => {
        //Arrange
        const correctFirstParam = "string";
        const biggerLengthSecondParam = -20;
        //Act
        const incorrectIndexResult = lookupChar(correctFirstParam, lowerLengthSecondParam);
        //Assert
        expect(incorrectIndexResult).to.be.equal("Incorrect index");
    })
})