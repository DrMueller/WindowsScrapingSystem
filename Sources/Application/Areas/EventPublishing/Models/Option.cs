namespace Mmu.Wss.Application.Areas.EventPublishing.Models
{
    public class Option
    {
        public Option(bool applyOption, bool optionValue)
        {
            ApplyOption = applyOption;
            OptionValue = optionValue;
        }

        public bool ApplyOption { get; }
        public bool OptionValue { get; }

        public static Option CreateApplicible(bool optionValue)
        {
            return new Option(true, optionValue);
        }

        public static Option CreateNotApplicable()
        {
            return new Option(false, false);
        }
    }
}