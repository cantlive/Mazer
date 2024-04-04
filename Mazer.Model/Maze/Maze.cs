using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mazer.Core.MazeModel
{
    public sealed class Maze : IEnumerable<MazeCell>
    {
        private int _width, _height, _rowsCount, _columnsCount;
        private MazeCell[,] _initialCells;
        private MazeCell[,] _cells;
        private Dictionary<MazeCellIndex, List<MazeCell>> _cellsNeighbours;

        public Maze(int width, int height, int rowsCount, int columnsCount)
        {
            Width = width;
            Height = height;
            InitCells(rowsCount, columnsCount);
        }

        #region Properties

        public bool IsGenerated => _cells[0, 0].Borders.Count() < 4;

        /// <summary>
        /// Number of rows in maze
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// </summary>
        public int RowsCount
        {
            get { return _rowsCount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(RowsCount));

                _rowsCount = value;
            }
        }

        /// <summary>
        /// Number of columns in maze
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// </summary>
        public int ColumnsCount
        {
            get { return _columnsCount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(ColumnsCount));

                _columnsCount = value;
            }
        }

        /// <summary>
        /// Maze width
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// </summary>
        private int Width 
        {   
            get { return _width; } 
            set 
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Width));

                _width = value;
            }
        }

        /// <summary>
        /// Maze height
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// </summary>
        private int Height
        {
            get { return _height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Height));

                _height = value;
            }
        }

        #endregion Properties

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
        /// Set number of rows and columns of maze
        /// </summary>
        /// <param name="rowsCount">Number of rows</param>
        /// <param name="columnsCount">Number of columns</param>
        public void SetMazeSize(int rowsCount, int columnsCount) 
        {
            InitCells(rowsCount, columnsCount);
        }

        /// <summary>
        /// Set size of cells
        /// </summary>
        /// <param name="width">Maze width</param>
        /// <param name="height">Maze height</param>
        public void SetCellsSize(int width, int height) 
        {
            Width = width;
            Height = height;

            int cellSize = GetCellSize();
            SetCellsSize(cellSize);
        }

        /// <summary>
        /// Set all cells with all borders
        /// </summary>
        public void Reset() 
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    _initialCells[i, j].Copy(_cells[i, j]);
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
        /// Get index of <paramref name="cell"/>
        /// </summary>
        /// <param name="cell">Cell</param>
        /// <returns>Index of <paramref name="cell"/></returns>
        public MazeCellIndex GetCellIndex(MazeCell cell)
        {
            return new MazeCellIndex(cell.Y / cell.Size, cell.X / cell.Size);
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

        private void InitCells(int rowsCount, int columnsCount)
        {
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;
            int cellSize = GetCellSize();

            _initialCells = new MazeCell[rowsCount, columnsCount];
            _cells = new MazeCell[rowsCount, columnsCount];
            _cellsNeighbours = new Dictionary<MazeCellIndex, List<MazeCell>>();

            InitCells(rowsCount, columnsCount, cellSize);
            FillCellsNeighbours();
        }

        private int GetCellSize() 
        {
            int cellWidth = Width / ColumnsCount;
            int cellHeight = Height / RowsCount;
            return Math.Min(cellWidth, cellHeight);
        }

        private void InitCells(int rowsCount, int columnsCount, int cellSize)
        {
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    _initialCells[i, j] = new MazeCell(j * cellSize, i * cellSize, cellSize);
                    _cells[i, j] = new MazeCell(j * cellSize, i * cellSize, cellSize);
                }
            }
        }

        private void SetCellsSize(int cellSize) 
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    _initialCells[i, j].Size = _cells[i, j].Size = cellSize;
                    _initialCells[i, j].X = _cells[i, j].X = j * cellSize;
                    _initialCells[i, j].Y = _cells[i, j].Y = i * cellSize;
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

        private void CheckBorders(int i, int j)
        {
            if (i < 0 || i >= _cells.GetLength(0))
                throw new ArgumentOutOfRangeException($"{i} is out of range", nameof(i));

            if (j < 0 || j > _cells.GetLength(1))
                throw new ArgumentOutOfRangeException($"{j} is out of range", nameof(j));
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

        public struct MazeCellIndex : IEquatable<MazeCellIndex>
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