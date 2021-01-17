namespace BlazorApp.Data
{
    public interface IAuthorService
    {
        System.Collections.Generic.List<Data.Author> GetAuthors();
        Data.Author GetAuthorById(int authorId);

        System.DateTime GetCreationDate();

        string GetVersion();

        bool SaveAuthor(Data.Author author);

        int GetNewAuthorId();

        System.Threading.Tasks.Task<bool> SaveAuthorAsync(Data.Author author);

        System.Threading.Tasks.Task<bool> DeleteAuthorAsync(string authorId);

    }
}
