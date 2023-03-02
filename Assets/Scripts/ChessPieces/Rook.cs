using UnityEngine;
using System.Collections.Generic;

public class Rook : ChessPiece
{
    private Vector2Int direction;
    private int tmpX;
    private int tmpY;

    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        for (int i = 0; i < 4; i++)
        {
            tmpX = currentX;
            tmpY = currentY;
            switch (i)
            {
                case 0 :
                    direction = Vector2Int.left;
                    break;
                
                case 1 : 
                    direction = Vector2Int.right;
                    break;

                case 2 : 
                    direction = Vector2Int.up;
                    break;

                case 3 : 
                    direction = Vector2Int.down;
                    break;
                
                default : 
                    direction = Vector2Int.up;
                    break;
            }
            
            while ((tmpX + direction.x) > -1 && (tmpX + direction.x) < tileCountX 
                    && (tmpY + direction.y) > -1 && (tmpY + direction.y) < tileCountY 
                    && ( board[tmpX + direction.x, tmpY + direction.y] == null))
            {
                tmpX += direction.x;
                tmpY += direction.y;
                r.Add(new Vector2Int(tmpX, tmpY));
            }
            
            if ((tmpX + direction.x) > -1 && (tmpX + direction.x) < tileCountX 
                && (tmpY + direction.y) > -1 && (tmpY + direction.y) < tileCountY 
                && board[tmpX + direction.x, tmpY + direction.y] != null 
                && board[tmpX + direction.x, tmpY + direction.y].team != this.team)    
            {
                r.Add(new Vector2Int(tmpX + direction.x, tmpY + direction.y));
            }
        }

        return r;
    }
}