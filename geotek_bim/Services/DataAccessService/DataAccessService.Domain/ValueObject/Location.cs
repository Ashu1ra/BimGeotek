using NetTopologySuite.Geometries;

namespace Domain.ValueObjects
{
    public class Location
    {
        public Point Value { get; private set; }

        private Location() { }

        public Location(Point value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.X < -180 || value.X > 180) throw new ArgumentOutOfRangeException(nameof(value), "Longitude out of range");
            if (value.Y < -90 || value.Y > 90) throw new ArgumentOutOfRangeException(nameof(value), "Latitude out of range");

            Value = value;
        }

        public double Latitude => Value.Y;
        public double Longitude => Value.X;
        public double Altitude => Value.Z;

        public bool IsInside(MultiPolygon region) => region.Contains(Value);
    }
}
