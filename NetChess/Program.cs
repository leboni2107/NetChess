namespace NetChess;

internal class Program
{
    static Piece[] InitializeBoard()
    {
        Piece[] board = new Piece[32];
        
        
        // Pawns

        for (int i = 0; i < 8; i++)
        {
            board[i] = new Piece();
            board[i].coordinates = (i, 0);
            board[i].pieceType = Piece.Type.Pawn;
            board[i].pieceColor = Piece.Color.White;
        }
        
        for (int i = 0; i < 8; i++)
        {
            board[i] = new Piece();
            board[i].coordinates = (i, 6);
            board[i].pieceType = Piece.Type.Pawn;
            board[i].pieceColor = Piece.Color.Black;
        }
        
        
        // Rooks
        board[16] = new Piece();
        board[16].coordinates = (0, 0);
        board[16].pieceType = Piece.Type.Rook;
        board[16].pieceColor = Piece.Color.White;
        
        board[17] = new Piece();
        board[17].coordinates = (0, 7);
        board[17].pieceType = Piece.Type.Rook;
        board[17].pieceColor = Piece.Color.White;
        
        board[18] = new Piece();
        board[18].coordinates = (7, 0);
        board[18].pieceType = Piece.Type.Rook;
        board[18].pieceColor = Piece.Color.Black;
        
        board[19] = new Piece();
        board[19].coordinates = (7, 7);
        board[19].pieceType = Piece.Type.Rook;
        board[19].pieceColor = Piece.Color.Black;
        
        
        // Knights
        board[20] = new Piece();
        board[20].coordinates = (0, 1);
        board[20].pieceType = Piece.Type.Knight;
        board[20].pieceColor = Piece.Color.White;
        
        board[21] = new Piece();
        board[21].coordinates = (0, 6);
        board[21].pieceType = Piece.Type.Knight;
        board[21].pieceColor = Piece.Color.White;
        
        board[22] = new Piece();
        board[22].coordinates = (1, 7);
        board[22].pieceType = Piece.Type.Knight;
        board[22].pieceColor = Piece.Color.Black;
        
        board[23] = new Piece();
        board[23].coordinates = (7, 7);
        board[23].pieceType = Piece.Type.Knight;
        board[23].pieceColor = Piece.Color.Black;
        
        // Bishops
        board[24] = new Piece();
        board[24].coordinates = (0, 2);
        board[24].pieceType = Piece.Type.Bishop;
        board[24].pieceColor = Piece.Color.White;
        
        board[25] = new Piece();
        board[25].coordinates = (0, 5);
        board[25].pieceType = Piece.Type.Bishop;
        board[25].pieceColor = Piece.Color.White;
        
        board[26] = new Piece();
        board[26].coordinates = (7, 2);
        board[26].pieceType = Piece.Type.Bishop;
        board[26].pieceColor = Piece.Color.Black;
        
        board[27] = new Piece();
        board[27].coordinates = (7, 5);
        board[27].pieceType = Piece.Type.Bishop;
        board[27].pieceColor = Piece.Color.Black;
        
        
        // Queens
        board[28] = new Piece();
        board[28].coordinates = (0, 3);
        board[28].pieceType = Piece.Type.Queen;
        board[28].pieceColor = Piece.Color.White;
        
        board[29] = new Piece();
        board[29].coordinates = (7, 3);
        board[29].pieceType = Piece.Type.Queen;
        board[29].pieceColor = Piece.Color.Black;
                
        
        // Kings
        board[30] = new Piece();
        board[30].coordinates = (0, 4);
        board[30].pieceType = Piece.Type.King;
        board[30].pieceColor = Piece.Color.White;
        
        board[31] = new Piece();
        board[31].coordinates = (7, 4);
        board[31].pieceType = Piece.Type.King;
        board[31].pieceColor = Piece.Color.Black;
        
        
        return board;
    }

    static void DisplayBoard(Piece[] board)
    {
        Console.Clear();
        for (int i = 0; i < board.Length; i++)
        {
            Console.SetCursorPosition(board[i].coordinates.Item1, board[i].coordinates.Item2);
            string symbol = "";
            switch (board[i].pieceType)
            {
                case Piece.Type.Pawn:
                    symbol = "p";
                    break;
                case Piece.Type.Bishop:
                    symbol = "b";
                    break;
                case Piece.Type.Knight:
                    symbol = "n";
                    break;
                case Piece.Type.Rook:
                    symbol = "r";
                    break;
                case Piece.Type.Queen:
                    symbol = "q";
                    break;
                case Piece.Type.King:
                    symbol = "k";
                    break;
            }

            if (board[i].pieceColor == Piece.Color.White)
            {
                symbol.ToUpper();
            }
            Console.Write(symbol);
        }
    }
    static void Main(string[] args)
    {
        Piece[] board = InitializeBoard();
        DisplayBoard(board);
        Console.ReadKey();
    }
}