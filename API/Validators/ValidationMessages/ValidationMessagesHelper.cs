using System.Collections.Generic;

namespace BookCatalogue.API.Validators.ValidationMessages
{
    public static class ValidationMessagesHelper
    {
        private static Dictionary<ValidationMessageType, string> validationMessages = new Dictionary<ValidationMessageType, string>(){
                                                    {ValidationMessageType.AuthorNameEmpty, "Please provide author name."},
                                                    {ValidationMessageType.AuthorNameInvalid, "Author name invalid. (max 200)."},
                                                    {ValidationMessageType.BookTitleMissing, "Please provide a title." },
                                                    {ValidationMessageType.BookTitleLengthInvalid, "Book title length invalid. (max 200)." },
                                                    {ValidationMessageType.ISBNEmpty, "Please provide ISBN." },
                                                    {ValidationMessageType.ISBNInvalid, "ISBN invalid. (max 13)." },
                                                    {ValidationMessageType.DateInvalid,"Please provide a valid date."},
                                                    {ValidationMessageType.AuthorsCountEmpty,"Please provide author/s."},

                                                    

                                                };

        public static string GetValidationMessage(this ValidationMessageType validationMessageType)
        {
            return validationMessages[validationMessageType];
        }
    }
}
