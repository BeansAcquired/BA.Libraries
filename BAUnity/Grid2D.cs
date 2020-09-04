using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BAUnity
{
    public class Grid2D : IEnumerable<Vector2>
    {
        #region Properties

        private List<Vector2> gridPoints = new List<Vector2>();

        public IEnumerator<Vector2> GetEnumerator() => gridPoints.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)gridPoints).GetEnumerator();

        // Rows
        public IEnumerable<Vector2> RowTop => gridPoints.Where(p => p.y == YMax);
        public IEnumerable<Vector2> RowBottom => gridPoints.Where(p => p.y == YMin);


        // Cols
        public IEnumerable<Vector2> ColumnLeft => gridPoints.Where(p => p.x == XMin);
        public IEnumerable<Vector2> ColumnRight => gridPoints.Where(p => p.x == XMax);

        // Y
        public float YMax => gridPoints.Select(p => p.y).Max();
        public float YMin => gridPoints.Select(p => p.y).Min();

        // X
        public float XMax => gridPoints.Select(p => p.x).Max();
        public float XMin => gridPoints.Select(p => p.x).Min();


        // Dimensions
        public float Width => Columns * CellWidth;
        public float Height => Rows * CellHeight;

        // Points
        public int Points => gridPoints.Count;
        public Vector2 TopLeft => gridPoints.Single(p => p.x == XMin && p.y == YMax);
        public Vector2 TopRight => gridPoints.Single(p => p.x == XMax && p.y == YMax);
        public Vector2 BottomRight => gridPoints.Single(p => p.x == XMax && p.y == YMin);
        public Vector2 BottomLeft => gridPoints.Single(p => p.x == XMin && p.y == YMin);
        public Vector2 TopLeftCorner => new Vector2(XMin - (CellWidth / 2), YMax + (CellHeight / 2));
        public Vector2 TopRightCorner => new Vector2(XMax + (CellWidth / 2), YMax + (CellHeight / 2));
        public Vector2 BottomRightCorner => new Vector2(XMax + (CellWidth / 2), YMin - (CellHeight / 2));
        public Vector2 BottomLeftCorner => new Vector2(XMin - (CellWidth / 2), YMin - (CellHeight / 2));

        // Cells
        public Vector2Int CellLayout { get; }
        public int Columns => CellLayout.x;
        public int Rows => CellLayout.y;
        public Vector2 CellSize { get; }
        public float CellWidth => CellSize.x;
        public float CellHeight => CellSize.y;
        public Vector2 CellSpacing { get; }
        public float ColumnSpacing => CellSpacing.x;
        public float RowSpacing => CellSpacing.y;

        //TODO: add Get Neighbors

        #endregion

        public Grid2D(Vector2Int layout, Vector2 cellSize, Vector2 cellSpacing)
        {

            CellLayout = layout; // Number of rows and columns
            CellSize = cellSize;
            CellSpacing = cellSpacing;

            PopulateGridPoints();
        }

        private void PopulateGridPoints()
        {
            float colOffset = (Width - CellWidth) / 2 + ColumnSpacing;
            float rowOffset = (Height - CellHeight) / 2 + RowSpacing;

            for (var i = 0; i < Rows * Columns; i++)
            {
                var col = i % Columns * (CellWidth + ColumnSpacing);
                var row = i / Columns * (CellHeight + RowSpacing);

                gridPoints.Add(new Vector2(col - colOffset, row - rowOffset));
            }
        }

        public IEnumerable<Vector2> Row(int index)
        {
            if (index < 0 || index >= Rows) return new List<Vector2>();

            return gridPoints
                .GroupBy(p => p.y)
                .OrderBy(p => p.Key)
                .ElementAt(index)
                .AsEnumerable();

        }

        public IEnumerable<Vector2> Column(int index)
        {
            if (index < 0 || index >= Columns) return new List<Vector2>();

            return gridPoints
                .GroupBy(p => p.x)
                .OrderBy(p => p.Key)
                .ElementAt(index)
                .AsEnumerable();

        }

    }

}



