const { isPalindrome } = require("./test_functions");

QUnit.module("testing isPalindrome function", () => {
    QUnit.test("Racecar parameter", function(assert){
        assert.ok(isPalindrome("racecar"), "Identifying 'racecar' as a palindrome")
    })
    QUnit.test("Palindrome sentence", function(assert){
        assert.ok(isPalindrome("racecar"), "Identifying 'A man, a plan, a canal, Panama!'. as a palindrome")
    })
    QUnit.test("Not a palindrome word", function(assert){
        assert.notOk(isPalindrome("hello"), "Identifying 'hello' as not a palindrome")
    })
    QUnit.test("Empty string", function(assert) {
        assert.notOk(isPalindrome(""), "Identifying empty string as not a palindrome");
    })
})