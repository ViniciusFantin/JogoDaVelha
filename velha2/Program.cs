using System;

class Program
{
    static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    static char currentPlayer = 'X';
    static bool gameover = false;

    static void Main()
    {
        while (!gameover)
        {
            Console.Clear();
            DisplayBoard();
            MakeMove();
            CheckForWinner();
            SwitchPlayer();
        }

        Console.Clear();
        DisplayBoard();

        if (gameover)
        {
            if (currentPlayer == ' ')
                Console.WriteLine("O jogo empatou!");
            else
                Console.WriteLine("Jogador " + currentPlayer + " venceu!");
        }
    }

    static void DisplayBoard()
    {
        Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8]);
    }

    static void MakeMove()
    {
        bool validMove = false;

        while (!validMove)
        {
            Console.Write("Jogador " + currentPlayer + ", escolha uma posição (0-8): ");
            if (int.TryParse(Console.ReadLine(), out int position) && position >= 0 && position < 9 && board[position] == ' ')
            {
                board[position] = currentPlayer;
                validMove = true;
            }
            else
            {
                Console.WriteLine("Movimento inválido. Tente novamente.");
            }
        }
    }

    static void CheckForWinner()
    {
        if (
            (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer) ||
            (board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer) ||
            (board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer) ||
            (board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer) ||
            (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer) ||
            (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer) ||
            (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) ||
            (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer)
            )
        {
            gameover = true;
        }
        else if (!board.Contains(' '))
        {
            gameover = true;
            currentPlayer = ' ';
        }
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }
}