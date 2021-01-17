namespace BlazorApp.Data
{
    interface IPublisherService
    {
        System.Collections.Generic.List<Data.Publisher> GetPublishers();
        Data.Publisher GetPublisherById(string pubId);
        bool SavePublisher(Data.Publisher publisher);
        void DeletePublisher(string pubId);
    }
}