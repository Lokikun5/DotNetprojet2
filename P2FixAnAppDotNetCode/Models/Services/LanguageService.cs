using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services method to manage the application language
    /// </summary>
    public class LanguageService : ILanguageService
    {
        /// <summary>
        /// Set the UI language
        /// </summary>
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        /// <summary>
        /// Set the culture
        /// </summary>
        public string SetCulture(string language)
        {
            // FIX: Default culture is English.
            // Default culture is English.
            string culture = "en-GB";

            // Convert the selected language name into
            // the culture code used by ASP.NET Core.
            switch (language)
            {
                case "French":
                    culture = "fr-FR";
                    break;

                case "Spanish":
                    culture = "es-ES";
                    break;

                case "English":
                default:
                    culture = "en-GB";
                    break;
            }

            return culture;

            if (string.IsNullOrWhiteSpace(language))
            {
                return "en";
            }

            string key = language.Trim().ToLowerInvariant();

            // Accept common variants like "French", "fr", "fr-FR", etc.
            if (key.StartsWith("fr") || key == "french")
            {
                return "fr";
            }

            // Accept common variants like "Spanish", "es", "es-ES", etc.
            if (key.StartsWith("es") || key == "spanish")
            {
                return "es";
            }

            // Default to English for any unknown value
            return "en";
        }

        /// <summary>
        /// Update the culture cookie
        /// </summary>
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}
