using Amazon.Lambda.Core;
using Epsagon.Dotnet.Lambda;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaEpsagonDemo
{
    public class AWSLambdaFunction : LambdaHandler<InputObject, bool>
    {
        public override Task<bool> HandlerFunction(InputObject inputObject, ILambdaContext context)
        {
            return Task.FromResult(IsEmailAddressValid(inputObject.EmailAddress));
        }
        private bool IsEmailAddressValid(string emailAddress)
        {
            string pattern = (@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return new Regex(pattern, RegexOptions.IgnoreCase).IsMatch(emailAddress);
        }
    }
    public class InputObject
    {
        public string EmailAddress { get; set; }
    }
}
