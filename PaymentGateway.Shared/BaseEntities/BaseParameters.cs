using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Shared.BaseEntities
{
    public abstract class BaseParameters()
    {
        char _arrayDelimiter = ',';

        readonly char[] _invalidDelimiters = ['/', '\\', ' '];

        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 500;


        public List<string> SortFields { get; set; } = new();
        [Obsolete("For backwards compatibility.   Moving to SortFields", false)]
        public virtual List<string> Sorting { get; set; } = new();

        /// <summary>
        /// Each Sorting Column value is the name of the Column to sort on with a "-" when the sort order is descending
        /// </summary>
        [Obsolete("For backwards compatibility.   Moving to SortFields", false)]
        public virtual string SortingString
        {
            get => string.Join(ArrayDelimiter, Sorting);
            set => Sorting = string.IsNullOrEmpty(value) ? [] : value.Split(ArrayDelimiter).ToList();
        }

        public char ArrayDelimiter
        {
            get => _arrayDelimiter;
            set
            {
                if (_invalidDelimiters.Contains(value))
                {
                    throw new InvalidDataException($"{value} cannot be used as an array delimiter");
                }
                _arrayDelimiter = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new(50);
            if (PageIndex < 1) PageIndex = 1;
            if (PageSize < 5) PageSize = 5;
            else if (PageSize > 500) PageSize = 500;

            sb.Append($"{nameof(PageIndex)}={PageIndex}");
            if (PageSize != 500) sb.Append($"&{nameof(PageSize)}={PageSize}");
            if (ArrayDelimiter != ',') sb.Append($"&{nameof(ArrayDelimiter)}={Uri.EscapeDataString(ArrayDelimiter.ToString())}");
            if (Sorting?.Any() ?? false) { sb.Append($"&{nameof(Sorting)}={SortingString}"); }
            if (SortFields?.Any() ?? false) { sb.Append($"&{nameof(SortFields)}={string.Join(ArrayDelimiter, SortFields!)}"); }

            return sb.ToString();
        }
    }
}
