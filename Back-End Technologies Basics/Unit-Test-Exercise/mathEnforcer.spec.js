import { mathEnforcer } from "./mathEnforcer.js";
import { expect } from "chai";

describe("mathEnforcer", () => {
    describe("addFive", () => {
        it("should return undefined when pass string as input", () => {
            //Arrange
            const stringInput = "someString";
            //Act
            const undefinedResult = mathEnforcer.addFive(stringInput);
            //Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return undefined when pass undefined as input", () => {
            //Arrange
            const undefinedInput = undefined;
            //Act
            const undefinedResult = mathEnforcer.addFive(undefinedInput);
            //Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return undefined when pass number as string as input", () => {
            //Arrange
            const numberAsstringInput = "5";
            //Act
            const undefinedResult = mathEnforcer.addFive(numberAsstringInput);
            //Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return correct result when pass string with floating number as input assert with closeTo", () => {
            //Arrange
            const floatingNumberInput = 1.01;
            //Act
            const correctResult = mathEnforcer.addFive(floatingNumberInput);
            //Assert
            expect(correctResult).to.be.closeTo(6.01, 0.01);
        });

        it("should return correct result when pass string with floating number as input assert with equal", () => {
            //Arrange
            const floatingNumberInput = 1.01;
            //Act
            const correctResult = mathEnforcer.addFive(floatingNumberInput);
            //Assert
            expect(correctResult).to.be.equal(6.01);
        });

        it("should return correct result when pass floating number with a lot of digits as input assert with closeTo", () => {
            //Arrange
            const floatingNumberInput = 1.0000001;
            //Act
            const correctResult = mathEnforcer.addFive(floatingNumberInput);
            //Assert
            expect(correctResult).to.be.closeTo(6.01, 0.01);
        });

        it("should return correct result when pass number as input", () => {
            //Arrange
            const numberInput = 5;
            //Act
            const correctResult = mathEnforcer.addFive(numberInput);
            //Assert
            expect(correctResult).to.be.equal(10);
        });

        it("should return correct result when pass negative number as input", () => {
            //Arrange
            const negativeNumberInput = -15;
            //Act
            const correctResult = mathEnforcer.addFive(negativeNumberInput);
            //Assert
            expect(correctResult).to.be.equal(-10);
        });
    });

    describe("subtractTen", () => {
        it("should return undefined when pass string as input", () => {
            //Arrange
            const stringInput = "someString";
            //Act
            const undefinedResult = mathEnforcer.subtractTen(stringInput);
            //Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return undefined when pass undefined as input", () => {
            //Arrange
            const undefinedInput = undefined;
            //Act
            const undefinedResult = mathEnforcer.subtractTen(undefinedInput);
            //Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return undefined when pass number as string as input", () => {
            //Arrange
            const numberAsstringInput = "5";
            //Act
            const undefinedResult = mathEnforcer.subtractTen(numberAsstringInput);
            //Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return correct result when pass string with floating number as input assert with closeTo", () => {
            //Arrange
            const floatingNumberInput = 1.01;
            //Act
            const correctResult = mathEnforcer.subtractTen(floatingNumberInput);
            //Assert
            expect(correctResult).to.be.closeTo(8.99, 0.01);
        });

        it("should return correct result when pass string with floating number as input assert with equal", () => {
            //Arrange
            const floatingNumberInput = 1.01;
            //Act
            const correctResult = mathEnforcer.subtractTen(floatingNumberInput);
            //Assert
            expect(correctResult).to.be.equal(-8.99);
        });

        it("should return correct result when pass floating number with a lot of digits as input assert with closeTo", () => {
            //Arrange
            const floatingNumberInput = 1.0000001;
            //Act
            const correctResult = mathEnforcer.subtractTen(floatingNumberInput);
            //Assert
            expect(correctResult).to.be.closeTo(8.99, 0.01);
        });

        it("should return correct result when pass number as input", () => {
            //Arrange
            const numberInput = 5;
            //Act
            const correctResult = mathEnforcer.subtractTen(numberInput);
            //Assert
            expect(correctResult).to.be.equal(-5);
        });

        it("should return correct result when pass negative number as input", () => {
            //Arrange
            const negativeNumberInput = -15;
            //Act
            const correctResult = mathEnforcer.subtractTen(negativeNumberInput);
            //Assert
            expect(correctResult).to.be.equal(-25);
        });
    });

    describe("sum", () => {
        it("should return undefined when Param1: incorrect and Param2: correct", () => {
            //Arrange
            const incorrectFirstParam = "something";
            const correctSecondParam = 5;
            //Act
            const undefinedResult = mathEnforcer.sum(incorrectFirstParam, correctSecondParam);
            //Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return undefined when Param1: correct and Param2: incorrect", () => {
            //Arrange
            const correctFirstParam = 5;
            const incorrectSecondParam = "something";
            //Act
            const undefinedResult = mathEnforcer.sum(correctFirstParam, incorrectSecondParam);
            //Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return undefined when Param1: number as string and Param2: correct", () => {
            //Arrange
            const incorrectFirstParam = "5";
            const correctSecondParam = 6;
            //Act
            const undefinedResult = mathEnforcer.sum(incorrectFirstParam, correctSecondParam);
            //Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return correct result when Param1: correct and Param2: correct", () => {
            //Arrange
            const correctFirstParam = 5;
            const correctSecondParam = 7;
            //Act
            const correctResult = mathEnforcer.sum(correctFirstParam, correctSecondParam);
            //Assert
            expect(correctResult).to.be.equal(12);
        });

        it("should return correct result when Param1: negative number and Param2: negative number", () => {
            //Arrange
            const correctFirstParam = -5;
            const correctSecondParam = -4;
            //Act
            const correctResult = mathEnforcer.sum(correctFirstParam, correctSecondParam);
            //Assert
            expect(correctResult).to.be.equal(-9);
        });

        it("should return correct result when Param1: floating number and Param2: number with equal assertion", () => {
            //Arrange
            const floatingNumberFirstParam = 5.01;
            const correctSecondParam = 7;
            //Act
            const correctResult = mathEnforcer.sum(floatingNumberFirstParam, correctSecondParam);
            //Assert
            expect(correctResult).to.be.equal(12.01);
        });

        it("should return correct result when Param1: floating number and Param2: number with closeTo assertion", () => {
            //Arrange
            const floatingNumberFirstParam = 5.01;
            const correctSecondParam = 7;
            //Act
            const correctResult = mathEnforcer.sum(floatingNumberFirstParam, correctSecondParam);
            //Assert
            expect(correctResult).to.be.closeTo(12.01, 0.01);
        });

        it("should return undefined when Param1: correct and Param2: undefined", () => {
            //Arrange
            const correctFirstParam = 5;
            const undefinedSecondParam = undefined;
            //Act
            const undefinedResult = mathEnforcer.sum(correctFirstParam, undefinedSecondParam);
            //Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return undefined when Param1: undefined and Param2: correct", () => {
            //Arrange
            const undefinedFirstParam = undefined;
            const correctSecondParam = 7;
            //Act
            const undefinedResult = mathEnforcer.sum(undefinedFirstParam, correctSecondParam);
            //Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return undefined when Param1: floating number as string and Param2: negative number", () => {
            //Arrange
            const floatingNumberFirstParam = 0;
            const correctSecondParam = 0.1;
            //Act
            const correctResult = mathEnforcer.sum(floatingNumberFirstParam, correctSecondParam);
            //Assert
            expect(correctResult).to.be.closeTo(0.1, 0.01);
        });
    });
});
