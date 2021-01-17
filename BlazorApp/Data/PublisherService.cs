using System.Linq;

namespace BlazorApp.Data
{
    public class PublisherService : IPublisherService
    {
        public System.Collections.Generic.List<Data.Publisher> Publishers { get; set; }

        public PublisherService()
        {
            Publishers = new System.Collections.Generic.List<Data.Publisher>();

            Publishers.Add(new Data.Publisher("0736", "New Moon Books", "Boston", "MA", "USA"));
            Publishers.Add(new Data.Publisher("0877", "Binnet & Hardley", "Washington", "DC", "USA"));
            Publishers.Add(new Data.Publisher("1389", "Algodata Infosystems", "Berkeley", "CA", "USA"));
            Publishers.Add(new Data.Publisher("1622", "Five Lakes Publishing", "Chicago", "IL", "USA"));
            Publishers.Add(new Data.Publisher("1756", "Ramona Publishers", "Dallas", "TX", "USA"));
        }

        public System.Collections.Generic.List<Data.Publisher> GetPublishers()
        {
            return Publishers;
        }

        public Data.Publisher GetPublisherById(string pubId)
        {
            return Publishers.Where(pub => pub.Pub_Id == pubId).FirstOrDefault();
        }

        public bool SavePublisher(Data.Publisher publisher)
        {
            publisher.Pub_Id = GetNewId();
            Publishers.Add(publisher);
            return true;
        }

        private string GetNewId()
        {
            string id;
            System.Random random = new System.Random();
            id = random.Next(1000, 10000).ToString();

            return id;
        }

        public void DeletePublisher(string pubId)
        {
            throw new System.NotImplementedException();
        }
    }
}
