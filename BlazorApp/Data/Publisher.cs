namespace BlazorApp.Data
{
    public class Publisher
    {
        public int Pub_Id { get; set; }
        public string Publisher_Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Publisher()
        {

        }

        public Publisher(int pub_id, string publisher_name, string city, string state, string country)
        {
            Pub_Id = pub_id;
            Publisher_Name = publisher_name;
            City = city;
            State = state;
            Country = country;
        }

    }
}
