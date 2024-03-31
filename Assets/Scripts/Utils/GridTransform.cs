using UnityEngine;

namespace Utils
{
    [ExecuteAlways]
    public class GridTransform : MonoBehaviour
    {
        [SerializeField] private Vector2 _cellSize = Vector2.one;
        [SerializeField] private Vector2Int _gridSize = Vector2Int.one;
        [SerializeField] private Alignment _alignment = Alignment.Center;

        [SerializeField] private bool _isAlwaysUpdate = true;

        private const float CENTER_OFFSET = 2f;
        private const int CHILD_SUBTRAHENDTION = 1;
        
        private enum Alignment
        {
            Left,
            Center,
            Right
        }

        private void Update()
        {
            if (!_isAlwaysUpdate)
            {
                return;
            }

            GenerateGrid();
        }

        public void GenerateGrid()
        {
            Vector2 startPosition = GetPositionByAligment();

            for (int i = 0; i < _gridSize.x; i++)
            {
                for (int j = 0; j < _gridSize.y; j++)
                {
                    int index = i * _gridSize.y + j;
                    if (index < transform.childCount)
                    {
                        transform.GetChild(index).localPosition = startPosition + new Vector2(j * _cellSize.x, i * -_cellSize.y);
                    }
                }
            }
        }

        private Vector2 GetPositionByAligment()
        {
            float gridWidth = (_gridSize.y - 1) * _cellSize.x;
            float gridHeight = (_gridSize.x - 1) * _cellSize.y;
            
            switch (_alignment)
            {
                case Alignment.Left:
                    return Vector2.zero;
                case Alignment.Center:
                    return new Vector2(-gridWidth / CENTER_OFFSET, gridHeight / CENTER_OFFSET);
                case Alignment.Right:
                    return new Vector2(-gridWidth, gridHeight);
                default:
                    return Vector2.zero;
            }
        }
    }
}