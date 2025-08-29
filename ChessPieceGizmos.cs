using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

public class ChessPieceGizmos : MonoBehaviour
{
    [ExecuteInEditMode]
    public enum ChessPiece
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    }

  /*  [System.Serializable]
    public struct ChessPieceData
    {
        public ChessPiece piece;
        public Texture2D icon;
    }
  */
    public ChessPiece piece;
    //public ChessPieceData pieceData;
    public float lookRadius = 0.5f;


    [SerializeField] private Texture2D pawnIcon;
    [SerializeField] private Texture2D rookIcon;
    [SerializeField] private Texture2D knightIcon;
    [SerializeField] private Texture2D bishopIcon;
    [SerializeField] private Texture2D queenIcon;
    [SerializeField] private Texture2D kingIcon;

    [SerializeField] bool black = true;

    void OnDrawGizmos()
    {
#if UNITY_EDITOR

      //  Gizmos.DrawIcon(transform.position, AssetDatabase.GetAssetPath(pieceData.icon), true);


        switch (piece)
        {

            case ChessPiece.Pawn:
                if(black)
                {
                    Gizmos.color = Color.black;
                }
                Gizmos.DrawIcon(transform.position, AssetDatabase.GetAssetPath(pawnIcon), true);
                break;
            case ChessPiece.Rook:
                Gizmos.DrawIcon(transform.position, AssetDatabase.GetAssetPath(rookIcon), true);
                break;
            case ChessPiece.Knight:
                Gizmos.DrawIcon(transform.position, AssetDatabase.GetAssetPath(knightIcon), true);
                break;
            case ChessPiece.Bishop:
                Gizmos.DrawIcon(transform.position, AssetDatabase.GetAssetPath(bishopIcon), true);
                break;
            case ChessPiece.Queen:
                Gizmos.DrawIcon(transform.position, AssetDatabase.GetAssetPath(queenIcon), true);
                break;
            case ChessPiece.King:
                Gizmos.DrawIcon(transform.position, AssetDatabase.GetAssetPath(kingIcon), true);
                break;
        }

#endif
    }

    void OnDrawGizmosSelected()
    {
#if UNITY_EDITOR
       /* Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position + Vector3.back * 0.01f, Vector3.forward, lookRadius);
       */
        CheckType(piece, this.gameObject);
        Gizmos.color = Color.blue;
#endif
    }

#if UNITY_EDITOR
    public void OnSceneGUI()
    {

    }
#endif
    void CheckType(ChessPiece _chessType, GameObject _chessPiece)
    {
        switch(_chessType)
        {
            case ChessPiece.Pawn:
                Vector3 _endPointPawn = _chessPiece.transform.position + (_chessPiece.transform.up * 2);
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_chessPiece.transform.position, _endPointPawn);
                break;
            case ChessPiece.Bishop:
                //Front Left line
                Vector3 _pos = _chessPiece.transform.position;
                Vector3 _pos2 = _chessPiece.transform.position + (_chessPiece.transform.up * 8) + (-_chessPiece.transform.right * 8);
                Vector3[] _pts = new Vector3[2]
                {
                    _pos,
                    _pos2
                };
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_pos, _pos2);
                //Front Right line
                Vector3 _pos3 = _chessPiece.transform.position;
                Vector3 _pos4 = _chessPiece.transform.position + (_chessPiece.transform.up * 8) + (_chessPiece.transform.right * 8);
                Vector3[] _pts2 = new Vector3[2]
                {
                    _pos3,
                    _pos4
                };
                Gizmos.DrawLine(_pos3, _pos4);
                Gizmos.color = Color.blue;
                //Back Left line
                Vector3 _pos5 = _chessPiece.transform.position;
                Vector3 _pos6 = _chessPiece.transform.position + (-_chessPiece.transform.up * 8) + (-_chessPiece.transform.right * 8);
                Vector3[] _pts3 = new Vector3[2]
                {
                    _pos5,
                    _pos6
                };
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_pos5, _pos6);
                //Back Right line
                Vector3 _pos7 = _chessPiece.transform.position;
                Vector3 _pos8 = _chessPiece.transform.position + (-_chessPiece.transform.up * 8) + (_chessPiece.transform.right * 8)    ;
                Vector3[] _pts4 = new Vector3[2]
                {
                    _pos7,
                    _pos8
                };
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_pos7, _pos8);
                break;
            case ChessPiece.Rook:
                //Front line
                Vector3 _posR1 = _chessPiece.transform.position;
                Vector3 _posR2 = _chessPiece.transform.position + (_chessPiece.transform.up * 8);
                Vector3[] _ptRs = new Vector3[2]
                {
                    _posR1,
                    _posR2
                };
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_posR1, _posR2);
                //Back line
                Vector3 _posR3 = _chessPiece.transform.position;
                Vector3 _posR4 = _chessPiece.transform.position + (-_chessPiece.transform.up * 8);
                Vector3[] _ptsR2 = new Vector3[2]
                {
                    _posR3,
                    _posR4
                };
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_posR3, _posR4);
                //Left line
                Vector3 _posR5 = _chessPiece.transform.position;
                Vector3 _posR6 = _chessPiece.transform.position + (-_chessPiece.transform.right * 8);
                Vector3[] _ptsR3 = new Vector3[2]
                {
                    _posR5,
                    _posR6
                };
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_posR5, _posR6);
                //Right line
                Vector3 _posR7 = _chessPiece.transform.position;
                Vector3 _posR8 = _chessPiece.transform.position + (_chessPiece.transform.right * 8);
                Vector3[] _ptsR4 = new Vector3[2]
                {
                    _posR7,
                    _posR8
                };
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_posR7, _posR8);
                break;
            case ChessPiece.Knight:
                Vector3[] _posK = new Vector3[8];
                //Points counter clockwise
                _posK[0] = _chessPiece.transform.position + (Vector3.up * 2) + (Vector3.left);
                _posK[1] = _chessPiece.transform.position + (Vector3.up) + (Vector3.left * 3);
                _posK[2] = _chessPiece.transform.position + (Vector3.down) + (Vector3.left * 3);
                _posK[3] = _chessPiece.transform.position + (Vector3.down * 2) + (Vector3.left);
                _posK[4] = _chessPiece.transform.position + (Vector3.down * 2) + (Vector3.right);
                _posK[5] = _chessPiece.transform.position + (Vector3.down) + (Vector3.right * 3);
                _posK[6] = _chessPiece.transform.position + (Vector3.up) + (Vector3.right * 3);
                _posK[7] = _chessPiece.transform.position + (Vector3.up * 2) + (Vector3.right);
                for(int i = 0; i < 8; i++)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawCube(_posK[i], Vector3.one);
                    
                }
                break;
            case ChessPiece.Queen:
                Vector3[] _posQ = new Vector3[8];
                //End positions counter clockwise
                _posQ[0] = _chessPiece.transform.position + (Vector3.up * 8);
                _posQ[1] = _chessPiece.transform.position + (Vector3.up * 8) + (Vector3.left * 8);
                _posQ[2] = _chessPiece.transform.position + (Vector3.left * 8);
                _posQ[3] = _chessPiece.transform.position + (Vector3.down * 8) + (Vector3.left * 8);
                _posQ[4] = _chessPiece.transform.position + (Vector3.down * 8);
                _posQ[5] = _chessPiece.transform.position + (Vector3.down * 8) + (Vector3.right * 8);
                _posQ[6] = _chessPiece.transform.position + (Vector3.right * 8);
                _posQ[7] = _chessPiece.transform.position + (Vector3.up * 8) + (Vector3.right * 8);
                for (int i = 0; i < 8; i++)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(_chessPiece.transform.position, _posQ[i]);
                }
                break;
            case ChessPiece.King:
                Vector3[] _posKing = new Vector3[8];
                //End positions counter clockwise
                _posKing[0] = _chessPiece.transform.position + (Vector3.up);
                _posKing[1] = _chessPiece.transform.position + (Vector3.up) + (Vector3.left);
                _posKing[2] = _chessPiece.transform.position + (Vector3.left);
                _posKing[3] = _chessPiece.transform.position + (Vector3.down) + (Vector3.left);
                _posKing[4] = _chessPiece.transform.position + (Vector3.down);
                _posKing[5] = _chessPiece.transform.position + (Vector3.down) + (Vector3.right);
                _posKing[6] = _chessPiece.transform.position + (Vector3.right);
                _posKing[7] = _chessPiece.transform.position + (Vector3.up) + (Vector3.right);
                Gizmos.color = Color.blue;
                for (int i = 0; i < 8; i++)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(_chessPiece.transform.position, _posKing[i]);
                    Gizmos.color = Color.blue;
                }
                break;
        }
    }
}


[CustomEditor(typeof(ChessPieceGizmos))]
public class ManageHandles: Editor
{
    
    void OnSceneGUI()
    {
        ChessPieceGizmos myObj = (ChessPieceGizmos)target;
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(myObj.transform.position + Vector3.back * 0.01f, Vector3.forward, myObj.lookRadius);
    }
}
