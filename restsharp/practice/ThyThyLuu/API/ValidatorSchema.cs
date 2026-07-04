using FluentAssertions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

public static class ValidatorSchema
{
    public static void ValidateSchema(string responseContent, string schemaFileName)
    {
        string schemaJson = JsonUtils.ReadJsonFile(
                "Schema",
                schemaFileName);

        JSchema schema = JSchema.Parse(schemaJson);

        JToken json = JToken.Parse(responseContent);

        bool isValid = json.IsValid(
            schema,
            out IList<string> errorMessages);

        isValid.Should().BeTrue(
            string.Join(Environment.NewLine, errorMessages));
    }
}