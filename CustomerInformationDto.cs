namespace AdminPanelProject
{
    public class CustomerInformationDto
    {
        public List<CustomerInformation> CustomerInformations { get; set; } = new List<CustomerInformation>();
        public int Pages { get; set; }
        public int CurrentPages { get; set; }
    }
}
