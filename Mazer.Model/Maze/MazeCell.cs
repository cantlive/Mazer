using System;
using System.Collections.Generic;
using System.Linq;

namespace Mazer.Core.MazeModel
{
    public sealed class MazeCell
    {
        private readonly Dictionary<BorderType, bool> _borders;

        public MazeCell(int x, int y, int size)
        {
            X = x;
            Y = y;
            Size = size;

            _borders = new Dictionary<BorderType, bool>()
            {
                { BorderType.Left, true },
                { BorderType.Top, true },
                { BorderType.Right, true },
                { BorderType.Bottom, true },
            };
        }

        public MazeCell(int x, int y, int size, Dictionary<BorderType, bool> borders) : this(x, y, size)
        {
            _borders = new Dictionary<BorderType, bool>(borders);
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public int Size { get; private set; }

        public bool Current { get; set; }

        public IEnumerable<BorderType> Borders => _borders.Where(x => x.Value).Select(x => x.Key);

        public static bool operator ==(MazeCell cell1, MazeCell cell2)
        {
            return (cell1.X == cell2.X && cell1.Y == cell2.Y);
        }

        public static bool operator !=(MazeCell cell1, MazeCell cell2)
        {
            return (cell1.X != cell2.X || cell1.Y != cell2.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is MazeCell cell &&
                   X == cell.X &&
                   Y == cell.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        /// <summary>
        /// Copy borders to cell
        /// </summary>
        /// <param name="cell">Cell</param>
        public void Copy(MazeCell cell)
        {
            cell.Current = Current;

            foreach (BorderType borderType in _borders.Keys)
                cell._borders[borderType] = _borders[borderType];
        }

        /// <summary>
        /// Add borders
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <param name="borders">Borders</param>
        public void AddBorders(params BorderType[] borders)
        {
            ChangeBordersState(state: true, borders);
        }

        /// <summary>
        /// Remove borders
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// </summary>
        /// <param name="borders">Borders</param>
        public void RemoveBorders(params BorderType[] borders)
        {
            ChangeBordersState(state: false, borders);
        }

        private void ChangeBordersState(bool state, params BorderType[] borders)
        {
            if (borders == null)
                throw new ArgumentNullException(nameof(borders));

            foreach (BorderType border in borders)
                _borders[border] = state;
        }
    }
}