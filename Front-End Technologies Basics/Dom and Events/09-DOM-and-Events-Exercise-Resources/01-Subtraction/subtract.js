function subtract() {
    let firstNumber = document.getElementById("firstNumber");
    let secondNumber = document.getElementById("secondNumber");
    let resultDiv = document.getElementById("result");

    let firstValue = Number(firstInput.value);
    let secondValue = Number(secondInput.value);
    
    let result = firsValue - secondValue;
    
    resultDiv.textContent = result;
} 