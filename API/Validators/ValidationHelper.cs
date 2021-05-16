using System;

namespace BookCatalogue.API.Validators
{
    public static class ValidationHelper
    {
        public static bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
