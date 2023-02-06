
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioAutoglass.Infra.Data.Converters
{
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime)
        ) { }
    }

}
