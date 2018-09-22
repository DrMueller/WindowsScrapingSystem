namespace Mmu.Wss.Application.Areas.Common.Models
{
    public static class Option
    {
        public static Option<T> CreateApplicible<T>(T optionValue)
        {
            return new Option<T>(true, optionValue);
        }

        public static Option<T> CreateNotApplicable<T>()
        {
            return new Option<T>(false, default(T));
        }
    }

    public sealed class Option<T>
    {
        public bool ApplyOption { get; }
        public T OptionValue { get; }

        internal Option(bool applyOption, T optionValue)
        {
            ApplyOption = applyOption;
            OptionValue = optionValue;
        }

        public bool CheckIfEquals(T otherValue)
        {
            if (!ApplyOption)
            {
                return true;
            }

            var result = Equals(otherValue, OptionValue);
            return result;
        }

        public static implicit operator Option<T>(T optionValue)
        {
            return ToOption(optionValue);
        }

        public static Option<TOpt> ToOption<TOpt>(TOpt optionValue)
        {
            return Option.CreateApplicible(optionValue);
        }
    }
}