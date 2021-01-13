namespace BlazorApp.Data
{
    interface IPublisherService
    {
        System.Collections.Generic.List<Publisher> GetPublishers();
        Publisher GetPublisherById(string pubId);
        bool SavePublisher(Publisher publisher);
        void DeletePublisher(string pubId);
    }
}