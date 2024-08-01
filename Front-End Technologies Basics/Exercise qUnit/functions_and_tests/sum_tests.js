const { sum } = require("./test_functions");

QUnit.module('sum function test', () => {
    QUnit.test("Adding two positive numbers", function(assert){
        assert.equal(sum(3, 3), 6, "Adding two positive numbers");
    })
    QUnit.test("Adding positive and negative numbers", function(assert){
        assert.equal(sum(6, -3), 3, "Adding positive and negative numbers");
    })
    QUnit.test("Adding two negative numbers", function(assert){
        assert.equal(sum(-3, -3), -6, "Adding two negative numbers");
    })
    QUnit.test("Adding floating point numbers", function(assert){
        assert.equal(Math.floor(sum(0.1, 0.3) * 10), 4, "Adding floating point numbers");
    })     
})