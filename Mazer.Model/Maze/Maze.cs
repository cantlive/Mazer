using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mazer.Core.MazeModel
{
    public sealed class Maze : IEnumerable<MazeCell>
    {
        private readonly MazeCell[,] _cells;
        private readonly Dictionary<MazeCellIndex, List<MazeCell>> _cellsNeighbours;

        public Maze(int width, int height, int rowsCount, int columnsCount)
        {
            Width = width;
            Height = height;
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;

            int cellWidth = width / columnsCount;
            int cellHeight = height / rowsCount;
            int cellSize = Math.Min(cellWidth, cellHeight);

            _cells = new MazeCell[rowsCount, columnsCount];
            _cellsNeighbours = new Dictionary<MazeCellIndex, List<MazeCell>>();

            InitCells(rowsCount, columnsCount, cellSize);
            FillCellsNeighbours();
        }

        public int Width { get; }
        public int Height { get; }
        public int RowsCount { get; }
        public int ColumnsCount { get; }

        public bool IsGenerated => _cells[0, 0].Borders.Count() < 4;

        /// <summary>
        /// Get <see cref="MazeCell"/> by row index and column index
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <param name="i">Row index</param>
        /// <param name="j">Column index</param>
        /// <returns><see cref="MazeCell"/></returns>
        public MazeCell this[int i, int j]
        {
            get
            {
                CheckBorders(i, j);
                return _cells[i, j];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Get all cells
        /// </summary>
        /// <returns>Enumerable of <see cref="MazeCell"/></returns>
        public IEnumerator<MazeCell> GetEnumerator()
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        /// <summary>
        /// Copy all cells from <paramref name="sourceMaze"/>
        /// </summary>
        /// <param name="sourceMaze">Source <see cref="Maze"/></param>
        public void CopyCells(Maze sourceMaze)
        {
            for (int i = 0; i < sourceMaze.RowsCount; i++)
            {
                for (int j = 0; j < sourceMaze.ColumnsCount; j++)
                {
                    sourceMaze[i, j].Copy(_cells[i, j]);
                }
            }
        }

        /// <summary>
        /// Get neighbours of <paramref name="cell"/>
        /// </summary>
        /// <param name="cell">Cell</param>
        /// <returns>List of neighbours</returns>
        public List<MazeCell> GetCellNeighbours(MazeCell cell)
        {
            MazeCellIndex index = GetCellIndex(cell);

            return GetCellNeighbours(index.X, index.Y);
        }

        /// <summary>
        /// Get neighbours of <see cref="MazeCell"/> by row index and column index
        /// </summary>
        /// <param name="cellX">Row index</param>
        /// <param name="cellY">Column index</param>
        /// <returns>List of neighbours</returns>
        public List<MazeCell> GetCellNeighbours(int cellX, int cellY)
        {
            return _cellsNeighbours[new MazeCellIndex(cellX, cellY)];
        }

        /// <summary>
        /// Remove borders between <paramref name="cell"/> and <paramref name="neighbourCell"/> if <paramref name="neighbourCell"/> is neighbour, else throw exception
        /// </summary>
        /// <exception cref="ArgumentException"></exception>>
        /// <param name="cell">Current cell</param>
        /// <param name="neighbourCell">Neighbour of <paramref name="cell"/></param>
        public void RemoveBordersBetweenNeighbours(MazeCell cell, MazeCell neighbourCell)
        {
            if (GetCellNeighbours(cell).Any(x => x == neighbourCell) == false)
                throw new ArgumentException($"Cell {neighbourCell} is not a neighbour of {cell}", nameof(neighbourCell));

            if (neighbourCell.X < cell.X)
            {
                cell.RemoveBorders(BorderType.Left);
                neighbourCell.RemoveBorders(BorderType.Right);
            }
            else if (neighbourCell.X > cell.X)
            {
                cell.RemoveBorders(BorderType.Right);
                neighbourCell.RemoveBorders(BorderType.Left);
            }

            if (neighbourCell.Y < cell.Y)
            {
                cell.RemoveBorders(BorderType.Top);
                neighbourCell.RemoveBorders(BorderType.Bottom);
            }
            else if (neighbourCell.Y > cell.Y)
            {
                cell.RemoveBorders(BorderType.Bottom);
                neighbourCell.RemoveBorders(BorderType.Top);
            }
        }

        private void CheckBorders(int i, int j)
        {
            if (i < 0 || i >= _cells.GetLength(0))
                throw new ArgumentOutOfRangeException($"{i} is out of range", nameof(i));

            if (j < 0 || j > _cells.GetLength(1))
                throw new ArgumentOutOfRangeException($"{j} is out of range", nameof(j));
        }

        private void InitCells(int rowCount, int columnCount, int cellSize)
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    _cells[i, j] = new MazeCell(j * cellSize, i * cellSize, cellSize);
                }
            }
        }

        private void FillCellsNeighbours()
        {
            _cellsNeighbours.Clear();

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    _cellsNeighbours.Add(new MazeCellIndex(i, j), GetCellNeighboursWithoutCash(i, j));
                }
            }
        }

        /// <summary>
        /// Get neighbours of <see cref="MazeCell"/> by row index and column index
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <param name="cellX">Row index</param>
        /// <param name="cellY">Column index</param>
        /// <returns>List of neighbours</returns>
        private List<MazeCell> GetCellNeighboursWithoutCash(int cellX, int cellY)
        {
            var result = new List<MazeCell>();

            int minX = Math.Max(cellX - 1, _cells.GetLowerBound(0));
            int maxX = Math.Min(cellX + 1, _cells.GetUpperBound(0));
            int minY = Math.Max(cellY - 1, _cells.GetLowerBound(1));
            int maxY = Math.Min(cellY + 1, _cells.GetUpperBound(1));

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if ((x == cellX || y == cellY) && _cells[x, y] != _cells[cellX, cellY])
                        result.Add(_cells[x, y]);
                }
            }

            return result;
        }

        private MazeCellIndex GetCellIndex(MazeCell cell)
        {
            return new MazeCellIndex(cell.Y / cell.Size, cell.X / cell.Size);
        }

        private struct MazeCellIndex : IEquatable<MazeCellIndex>
        {
            public int X { get; }
            public int Y { get; }

            public MazeCellIndex(int x, int y)
            {
                X = x;
                Y = y;
            }

            public bool Equals(MazeCellIndex other)
            {
                return (X == other.X) && (Y == other.Y);
            }

            public override bool Equals(object obj)
            {
                if (obj == null || obj is MazeCellIndex == false)
                    return false;

                return Equals((MazeCellIndex)obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }
    }
}