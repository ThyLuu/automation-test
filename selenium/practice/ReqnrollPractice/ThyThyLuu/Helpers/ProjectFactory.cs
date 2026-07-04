public static class ProjectFactory
{
    public static ProjectInformation Create(
        Dictionary<string, string> data)
    {
        return new ProjectInformation
        {
            ProjectName = data["ProjectName"],
            ProjectType = data["ProjectType"],
            ProjectStatus = data["ProjectStatus"],
            StartDate = data["StartDate"],
            EndDate = data["EndDate"],
            Size = data["Size"],
            Location = data["Location"],
            ProjectManager = data["ProjectManager"],
            DeliveryManager = data["DeliveryManager"],
            EngagementManager = data["EngagementManager"],
            ShortDescription = data["ShortDescription"],
            LongDescription = data["LongDescription"],
            Technologies = data["Technologies"],
            ClientName = data["ClientName"],
            ClientIndustry = data["ClientIndustry"],
            ClientDescription = data["ClientDescription"]
        };
    }
}