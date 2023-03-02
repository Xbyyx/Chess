using UnityEngine;
using System.Collections.Generic;

public enum ChessPieceType
{
    None = 0,
    Pawn = 1,
    Rook = 2,
    Knight = 3,
    Bishop = 4,
    Queen = 5,
    King = 6
}
public class ChessPiece : MonoBehaviour
{
    public ChessPieceType type;
    public int team;
    public int currentX;
    public int currentY;
    private Vector3 desiredPosition;
    private Vector3 desiredScale = new Vector3((float)1.5, (float)1.5, (float)1.5);

    private void Start()
    {
        if (team == 0 && team != 1 && type == ChessPieceType.Knight)
            transform.rotation = Quaternion.Euler(new Vector3(270, 180, 90));
        //transform.rotation = Quaternion.Euler((team == 0) ? Vector3.zero : new Vector3(0, 0, 0));
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10);
        transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * 10);
    }

    public virtual List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        return r;
    }

    public virtual SpecialMove GetSpecialMoves(ref ChessPiece[,] board, ref List<Vector2Int[]> moveList, ref List<Vector2Int> availableMoves)
    {
        return SpecialMove.None;
    }

    public  void SetPosition(Vector3 position, bool force = false)
    {
        if (this.type == ChessPieceType.Pawn)
            desiredPosition = position + new Vector3(0.0f, 1.3f, 0.0f);
        else 
            desiredPosition = position;

        if (force)
            transform.position = desiredPosition;
    }

    public virtual void SetScale(Vector3 scale, bool force = false)
    {
        if (this.type == ChessPieceType.Knight)
            desiredScale = scale - new Vector3(0.3f, 0.3f, 0.3f);
        
        if (this.type != ChessPieceType.Knight)
            desiredScale = scale;

        if (force)
            transform.localScale = desiredScale;
    }

}
