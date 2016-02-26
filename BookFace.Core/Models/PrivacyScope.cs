namespace BookFace.Core.Models
{
    public class PrivacyScope
    {
        static PrivacyScope()
        {
            Public = new PrivacyScope();
        }

        public static PrivacyScope Public { get; private set; }

        public static PrivacyScope Friends { get; private set; }
    }
}