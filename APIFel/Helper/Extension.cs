using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace APIFel.Helper
{
    public static class Extensions
    {
        /// <summary>
        /// Remove accents of an string
        /// </summary>
        /// <param name="text">String representing the text to normalize</param>
        /// <returns>Normalized text</returns>
        public static string NormalizeSpecialCharacters(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            //text = string.Concat(Regex.Replace(text, @"[ñ]", m=>text.Normalize(NormalizationForm.FormD)));
            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }
    }
}