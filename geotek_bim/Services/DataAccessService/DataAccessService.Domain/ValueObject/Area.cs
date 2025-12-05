using NetTopologySuite.Geometries;
using System;

namespace Domain.ValueObjects
{
    public class Area
    {
        public MultiPolygon Value { get; }

        private Area() { }

        public Area(MultiPolygon value)
        {
            if (value == null || value.IsEmpty)
                throw new ArgumentException("Area cannot be null or empty", nameof(value));

            Value = value;
        }

        public double AreaSize => Value.Area;

        public bool Contains(Point point) => Value.Contains(point);
    }
}
