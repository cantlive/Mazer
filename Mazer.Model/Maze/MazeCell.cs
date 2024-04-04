using System;
using System.Collections.Generic;
using System.Linq;

namespace Mazer.Core.MazeModel
{
    public sealed class MazeCell
    {        
        private readonly Dictionary<BorderType, bool> _borders;
        private int _x;
        private int _y;
        private int _size;

        public MazeCell(int x, int y, int size)
        {
            _x = x;
            _y = y;
            _size = size;

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

        /// <summary>
        /// Get cell X position
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// </summary>
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(X));
                _x = value;
            }
        }

        /// <summary>
        /// Get cell Y position
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// </summary>
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Y));
                _y = value;
            }
        }

        /// <summary>
        /// Get cell size
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// </summary>
        public int Size 
        {
            get 
            {
                return _size;
            }
            set 
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Size));
                _size = value;
            }
        }

        public bool Visited { get; set; }
        public bool Left => _borders[BorderType.Left];
        public bool Top => _borders[BorderType.Top];
        public bool Right => _borders[BorderType.Right];
        public bool Bottom => _borders[BorderType.Bottom];

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