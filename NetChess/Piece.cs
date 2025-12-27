namespace NetChess;

public class Piece
{
    public (int x, int y) coordinates; // x, y
    
    public enum Type { Pawn, Bishop, Knight, Rook, Queen, King }
    public Type pieceType;
    public enum Color { White, Black }
    public Color pieceColor;
}