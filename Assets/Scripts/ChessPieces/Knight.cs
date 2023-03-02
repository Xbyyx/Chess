using UnityEngine;
using System.Collections.Generic;

public class Knight : ChessPiece
{
    private Vector2Int moveTwoOne = new Vector2Int(2, 1);
    private Vector2Int moveOneTwo = new Vector2Int(1, 2);
    private Vector2Int right = new Vector2Int(1, 1);
    private Vector2Int up = new Vector2Int(1, -1);
    private Vector2Int down = new Vector2Int(-1, -1);
    private Vector2Int left = new Vector2Int(-1, 1);
    private Vector2Int direction;

    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0 :
                    direction = left;
                    break;
                
                case 1 : 
                    direction = right;
                    break;

                case 2 : 
                    direction = up;
                    break;

                case 3 : 
                    direction = down;
                    break;
                
                default : 
                    direction = up;
                    break;
            }

            //Move two in front/back, one left/right
            if (currentX + 2 * direction.x > -1 && currentX + 2 * direction.x < tileCountX 
                && currentY + direction.y > -1 && currentY + direction.y < tileCountX
                && (board[currentX + 2 * direction.x, currentY + direction.y] == null 
                    || board[currentX + 2 * direction.x, currentY + direction.y].team != this.team))
                r.Add(new Vector2Int(currentX + 2 * direction.x, currentY + direction.y));

            //Move one in front/back, two left/right
            if (currentX + direction.x > -1 && currentX + direction.x < tileCountX 
                && currentY + 2 * direction.y > -1 && currentY + 2 * direction.y < tileCountX
                && (board[currentX + direction.x, currentY +2 *  direction.y] == null 
                    || board[currentX + direction.x, currentY + 2 * direction.y].team != this.team))
                r.Add(new Vector2Int(currentX + direction.x, currentY + 2 * direction.y));
        }

        return r;
    }
    
}
