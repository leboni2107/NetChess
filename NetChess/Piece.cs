namespace NetChess;

public class Piece
{
    public (int, int) coordinates; // x, y
    
    public enum Type { Pawn, Bishop, Knight, Rook, Queen, King }
    public Type pieceType;
}