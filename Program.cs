using tictactoe;
// Create an instance of the supporting class in our driver class
SupportClass sc = new SupportClass();

// Initialize some variables
char[,] gameBoard = new char[3,3];
string player1 = "";
string player2 = "";
bool playGame = true;
int playerTurn = 1;
int setUp = 49;
bool wantToPlay = false;

// set up initial gameboard with blank spaces
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        gameBoard[i,j] = (char)setUp;
        setUp++;
    }
}


// Welcome user to game
Console.WriteLine("Welcome to Tic Tac Toe!");
Console.WriteLine("Please enter player 1's name:");
player1 = Console.ReadLine();
Console.WriteLine("Please enter player 2's name:");
player2 = Console.ReadLine();

// Print the blank board
// sc.PrintBoard(gameBoard);

// Enter game loop
do
{
    //for (int i = 0; i < 3; i++)
    //{
    //for (int j = 0; j < 3; j++)
    //{
    //  Console.Write(gameBoard[i, j]);
    //}
    //  Console.WriteLine("");
    //}
    SupportClass.PrintBoard(gameBoard);
    bool correctInput = false;

    // int userInput = 0;
    string userString = "";
    int[] matrixSpot = new int[2];
    // test
    string turnPlayer = "";
    char symbol = ' ';

    do
    {
        int turn = playerTurn % 2;
        if (turn == 1) { turnPlayer = player1; symbol = char.Parse("X"); }
        else { turnPlayer = player2; symbol = char.Parse("O"); }
        Console.WriteLine(turnPlayer + ", select a number to place your sign");

        // get user input and convert it to ascii
        userString = Console.ReadLine();
        int userInput = userString[0];

        if ((userInput > 57 || userInput < 49) || (userString.Length > 1))
        {
            Console.WriteLine("Invalid input; please try again.");
        }
        else if ((userInput - 48) > 6)
        {
            matrixSpot = [2, userInput - 55];
            correctInput = true;
        }
        else if ((userInput - 48) > 3)
        {
            matrixSpot = [1, userInput - 52];
            correctInput = true;
        }
        else
        {
            matrixSpot = [0, userInput - 49];
            correctInput = true;
        }

        //if (gameBoard[matrixSpot[0], matrixSpot[1]] == char.Parse("-") && correctInput)
        if (gameBoard[matrixSpot[0], matrixSpot[1]] < 58 && correctInput)
        {
            // update spot
            gameBoard[matrixSpot[0], matrixSpot[1]] = symbol;
        }
        else if (correctInput)
        {
            Console.WriteLine("That spot is already taken. Please choose another spot.");
            correctInput = false;
        }

    } while (!correctInput);


    // increment player turn
    playerTurn++;

    //check for winner
    if (SupportClass.CheckForWinner(gameBoard, turnPlayer))
    {
        SupportClass.PrintBoard(gameBoard);
        playGame = false;
    }
} while (playGame);

static bool OneStringEntry(string userString)
{
    return userString.Length ==1 && char.IsDigit(userString[0]);
}

static bool Number(string userString)
{
    return int.TryParse(userString, out _);
}