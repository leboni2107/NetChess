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
        for (int i = 0; i < board.Length; i++)
        {
            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(board[i].coordinates.x, board[i].coordinates.y);
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
            Console.SetCursorPosition(10, 0);
        }
    }
    static void Main(string[] args)
    {
        bool end = false;
        string notation;
        (int x, int y) sub1, sub2;
        Piece[] board = InitializeBoard();

        while (!end)
        {
            DisplayBoard(board);

            Console.Write("Notation: ");
            notation = Console.ReadLine();

            sub1 = (int.Parse(notation.Substring(0, 1)), int.Parse(notation.Substring(1, 1)));
            sub2 = (int.Parse(notation.Substring(3, 1)), int.Parse(notation.Substring(4, 1)));
            
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i].coordinates == sub1)
                {
                    board[i].coordinates = sub2;
                    break;
                }
            }
        }
        
    }
}