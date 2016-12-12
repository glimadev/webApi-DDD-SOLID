
namespace Api.Architecture.Domain.Entities.Messages
{
    public static class ValidationMessage
    {
        public static class Success
        {

        }

        public static class Validate
        {
            public const string FirstName = "Informe o primeiro nome";
            public const string LastName = "Informe o último nome";
        }
        public static class Length
        {
            public const string FirstName = "O primeiro nome deve ter entre {0} até {1} caracteres";
        }
    }
}
