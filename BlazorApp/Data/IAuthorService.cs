namespace BlazorApp.Data
{
    public interface IAuthorService
    {
        System.Collections.Generic.List<Author> GetAuthors();
        Author GetAuthorById(int authorId);

        System.DateTime GetCreationDate();

        string GetVersion();

        bool SaveAuthor(Data.Author author);

        int GetNewAuthorId();

        System.Threading.Tasks.Task<bool> SaveAuthorAsync(Author author);

        System.Threading.Tasks.Task<bool> DeleteAuthorAsync(string authorId);

    }
}
