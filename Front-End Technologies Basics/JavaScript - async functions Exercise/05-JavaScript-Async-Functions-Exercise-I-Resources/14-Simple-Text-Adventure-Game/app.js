function startAdventure()
{
    let command = "start";
    console.log("Welcome to the simple text adventure game!");
    while (true) {
        switch(command){
            case "start":
                // question: "You find yourself in a dark forest. You can go 'left' or 'right'."
                command = "left";
                break;
            case "left":
                // question: "You encounter a wild animal! You can 'fight' or 'run'."
                if(userInput == "fight"){
                    console.log("You bravely fight the animal and win!");
                } else if(userInput == "run") {
                    console.log("You run away safely.");
                }
                break;
                command = "right";
                break;
            case "right":
                // question: "You find a treasure chest! You can 'open' it or 'leave' it."
                if(userInput == "open")
                {
                    console.log("You open the chest and find a treasure! You win!");

                } else if(userInput == "leave")
                  {
                    console.log("You leave the chest and go back to the start.");
                  }
                  break;
            case "end":
                // question: End message: "Do you want to play again? (yes/no): "
                if(userInput == "yes")
                    {
                     console.log("start game again")
                    } else if(userInput == "no")
                        {
                            console.log("Thank you for playing!");
                        }
        }
    }
}