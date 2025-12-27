namespace NetChess;

internal class Program
{ 
    static Piece[] InitializeBoard()
    {
        Piece[] board = new Piece[32];
        
        // White Pawns
        for (int i = 0; i < 8; i++)
        {
            board[i] = new Piece();
            board[i].coordinates = (i, 1);
            board[i].pieceType = Piece.Type.Pawn;
            board[i].pieceColor = Piece.Color.White;
        }
        
        // Black Pawns
        for (int i = 8; i < 16; i++)
        {
            board[i] = new Piece();
            board[i].coordinates = (i - 8, 6);
            board[i].pieceType = Piece.Type.Pawn;
            board[i].pieceColor = Piece.Color.Black;
        }
        
        // White Rooks
        board[16] = new Piece();
        board[16].coordinates = (0, 0);
        board[16].pieceType = Piece.Type.Rook;
        board[16].pieceColor = Piece.Color.White;
        
        board[17] = new Piece();
        board[17].coordinates = (7, 0);
        board[17].pieceType = Piece.Type.Rook;
        board[17].pieceColor = Piece.Color.White;
        
        // Black Rooks
        board[18] = new Piece();
        board[18].coordinates = (0, 7);
        board[18].pieceType = Piece.Type.Rook;
        board[18].pieceColor = Piece.Color.Black;
        
        board[19] = new Piece();
        board[19].coordinates = (7, 7);
        board[19].pieceType = Piece.Type.Rook;
        board[19].pieceColor = Piece.Color.Black;
        
        // White Knights
        board[20] = new Piece();
        board[20].coordinates = (1, 0);
        board[20].pieceType = Piece.Type.Knight;
        board[20].pieceColor = Piece.Color.White;
        
        board[21] = new Piece();
        board[21].coordinates = (6, 0);
        board[21].pieceType = Piece.Type.Knight;
        board[21].pieceColor = Piece.Color.White;
        
        // Black Knights
        board[22] = new Piece();
        board[22].coordinates = (1, 7);
        board[22].pieceType = Piece.Type.Knight;
        board[22].pieceColor = Piece.Color.Black;
        
        board[23] = new Piece();
        board[23].coordinates = (6, 7);
        board[23].pieceType = Piece.Type.Knight;
        board[23].pieceColor = Piece.Color.Black;
        
        // White Bishops
        board[24] = new Piece();
        board[24].coordinates = (2, 0);
        board[24].pieceType = Piece.Type.Bishop;
        board[24].pieceColor = Piece.Color.White;
        
        board[25] = new Piece();
        board[25].coordinates = (5, 0);
        board[25].pieceType = Piece.Type.Bishop;
        board[25].pieceColor = Piece.Color.White;
        
        // Black Bishops
        board[26] = new Piece();
        board[26].coordinates = (2, 7);
        board[26].pieceType = Piece.Type.Bishop;
        board[26].pieceColor = Piece.Color.Black;
        
        board[27] = new Piece();
        board[27].coordinates = (5, 7);
        board[27].pieceType = Piece.Type.Bishop;
        board[27].pieceColor = Piece.Color.Black;
        
        // White Queen
        board[28] = new Piece();
        board[28].coordinates = (3, 0);
        board[28].pieceType = Piece.Type.Queen;
        board[28].pieceColor = Piece.Color.White;
        
        // Black Queen
        board[29] = new Piece();
        board[29].coordinates = (3, 7);
        board[29].pieceType = Piece.Type.Queen;
        board[29].pieceColor = Piece.Color.Black;
        
        // White King
        board[30] = new Piece();
        board[30].coordinates = (4, 0);
        board[30].pieceType = Piece.Type.King;
        board[30].pieceColor = Piece.Color.White;
        
        // Black King
        board[31] = new Piece();
        board[31].coordinates = (4, 7);
        board[31].pieceType = Piece.Type.King;
        board[31].pieceColor = Piece.Color.Black;
        
        return board;
    }
    static void DisplayBoard(Piece[] board)
    {
        Console.Clear();
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i].eliminated)
                continue;
            
            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(board[i].coordinates.x*3+4, board[i].coordinates.y+2);
            string symbol = "";
            switch (board[i].pieceType)
            {
                case Piece.Type.Pawn:
                    symbol = "P";
                    break;
                case Piece.Type.Bishop:
                    symbol = "B";
                    break;
                case Piece.Type.Knight:
                    symbol = "N";
                    break;
                case Piece.Type.Rook:
                    symbol = "R";
                    break;
                case Piece.Type.Queen:
                    symbol = "Q";
                    break;
                case Piece.Type.King:
                    symbol = "K";
                    break;
            }

            if (board[i].pieceColor == Piece.Color.White)
            {
                Console.BackgroundColor = ConsoleColor.White; 
                Console.ForegroundColor = ConsoleColor.Black;
            }
            
            Console.Write(symbol);
        }
        
        Console.SetCursorPosition(2, 0);
        Console.Write("  A  B  C  D  E  F  G  H");
        
        Console.SetCursorPosition(2, 1);
        Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━┓");

        for (int i = 2; i <= 9; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write($"{i-1} ┃");
            
            Console.SetCursorPosition(27, i);
            Console.Write("┃");
        }
        
        Console.SetCursorPosition(2, 10);
        Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━┛");
    }
    static bool IsLegalMove(Piece piece, (int x, int y) deltas)
    {
        switch(piece.pieceType)
        {
            case Piece.Type.Pawn:
                if ((piece.pieceColor == Piece.Color.White && deltas == (0, 1)) || (piece.pieceColor == Piece.Color.Black && deltas == (0, -1)))
                    return true;
                break;
            case Piece.Type.Bishop:
                if (Math.Abs(deltas.x) == Math.Abs(deltas.y))
                    return true;
                break;
            case Piece.Type.Knight:
                if (deltas.x <= 1 && deltas.y <= 1  || (Math.Abs(deltas.x) == 1 && Math.Abs(deltas.y) == 2))
                    return true;
                break;
            case Piece.Type.Rook:
                if ((deltas.x > 0 && deltas.y == 0) || (deltas.x == 0 && deltas.y > 0))
                    return true;
                break;
        }

        return false;
    }
    
    static void Main(string[] args)
    {
        bool end = false;
        string notation;
        (int x, int y) sub1, sub2;
        Piece[] board = InitializeBoard();
        int turn = 0;

        while (!end)
        {
            DisplayBoard(board);
            
            Console.SetCursorPosition(30, 1);
            Console.WriteLine($"Turn: {(turn % 2 == 0 ? "White" : "Black")}");
            
            Console.SetCursorPosition(30, 2);
            Console.Write("Notation: ");
            notation = Console.ReadLine();
            if (notation.Length == 5)
            {
                sub1 = (int.Parse(notation.Substring(0, 1))-1, int.Parse(notation.Substring(1, 1))-1);
                sub2 = (int.Parse(notation.Substring(3, 1))-1, int.Parse(notation.Substring(4, 1))-1);
                
                for (int i = 0; i < board.Length; i++)
                {
                    if (board[i].coordinates == sub1 && IsLegalMove(board[i], (sub2.x-sub1.x, sub2.y-sub1.y)))
                    {
                        if(turn % 2 == 0 && board[i].pieceColor == Piece.Color.White)
                            board[i].coordinates = sub2;
                        else if(turn % 2 != 0 && board[i].pieceColor == Piece.Color.Black)
                            board[i].coordinates = sub2;
                        
                        turn++;
                        break;
                    }
                }
                
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (j == i)
                        continue;
                    if (board[i].coordinates == board[j].coordinates)
                    {
                        if (turn % 2 == 0)
                        {
                            // Eliminate Black
                            if (board[j].pieceColor == Piece.Color.Black)
                                board[j].eliminated = true;
                            else board[i].eliminated = true;
                        }
                        else
                        {
                            // Eliminate White
                            if (board[j].pieceColor == Piece.Color.White)
                                board[j].eliminated = true;
                            else board[i].eliminated = true;
                        }
                    }
                        
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i].pieceType == Piece.Type.King && board[i].eliminated)
                    end = true;
            }
        }
        
    }
}