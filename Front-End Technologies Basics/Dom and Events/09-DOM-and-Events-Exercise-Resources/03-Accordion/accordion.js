function toggle() {
    let button = document.getElementsByClassName("button")[0];
    let textDiv = document.getElementById("extra");

    if(displayStyle == "More"){
        textDiv.style.display = "block";
        button.textContent = "Less";
    }
    else {
        textDiv.style.display = "none";
        button.textContent = "More";
    }
}