const { isEven } = require("./test_functions");

QUnit.module("isEven function test", () => {
 QUnit.test("Even number", function(assert){
    assert.ok(isEven(6), "Identifying even number: 2");
        assert.notOk(isEven(7), "Identifying odd number: 3");
        assert.ok(isEven(0), "Identifying even number: 0");
 })
 QUnit.test("Odd number", function(assert){
    assert.notOk(isEven(7), "Function returns false if given number is odd");
 })
 QUnit.test("Zero number", function(assert){
    assert.ok(isEven(0), "Function returns true if given number is zero");
 })
})