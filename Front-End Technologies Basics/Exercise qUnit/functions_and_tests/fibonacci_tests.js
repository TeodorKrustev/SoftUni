const { fibonacci } = require("./test_functions");

QUnit.module("fibonacci function tests", () => {
    QUnit.test("Zero as parameter", function(assert){
        assert.deepEqual(fibonacci(0), [], "Fibonacci sequence with 0 terms");
    })
    QUnit.test("One parameter", function(assert){
        assert.deepEqual(fibonacci(1), [0], "Fibonacci sequence with 1 terms");
    })
    QUnit.test("Five as parameter", function(assert){
        assert.deepEqual(fibonacci(5), [0, 1, 1, 2, 3], "Fibonacci sequence with 1 terms");
    })
    QUnit.test("Ten as parameter", function(assert) {
        assert.deepEqual(fibonacci(10), [0, 1, 1, 2, 3, 5, 8, 13, 21, 34], "Fibonacci sequence with 10 terms");
    })
})