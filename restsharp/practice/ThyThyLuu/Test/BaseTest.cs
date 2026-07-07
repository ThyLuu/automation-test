using NUnit.Framework;

public class BaseTest
{
    protected UserService userService = null!;

    protected CreateUserRequest createUserData = null!;
    protected string token = null!;
    
    [SetUp]
    public void Setup()
    {
        ConfigurationUtils.ReadConfiguration("appsettings.json");
        token = ConfigurationUtils.GetString("Token");

        userService = new UserService();

        createUserData =
            JsonUtils.ReadJson<CreateUserRequest>(
                "TestData",
                "CreateUserData.json"
            );
    }
}