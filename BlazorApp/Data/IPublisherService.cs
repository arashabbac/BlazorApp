namespace BlazorApp.Data
{
    interface IPublisherService
    {
        System.Collections.Generic.List<Data.Publisher> GetPublishers();
        Data.Publisher GetPublisherById(int pubId);
        bool SavePublisher(Data.Publisher publisher);
        void DeletePublisher(int pubId);
    }
}