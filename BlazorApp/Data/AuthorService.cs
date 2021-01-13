using System.Linq;

namespace BlazorApp.Data
{
    public class AuthorService : object , IAuthorService
    {
        System.DateTime CreationDate { get; set; }
        System.Collections.Generic.List<Author> Authors { get; set; }

        public AuthorService()
        {
            CreationDate = System.DateTime.Now;

            Authors = new System.Collections.Generic.List<Author>();

            //Authors.Add(new Author("172-32-1176", "Johnson", "White", "408 496 7223", "Menlo Park"));
            //Authors.Add(new Author("213-46-8915", "Marjorie", "Green", "415 986 7020", "Oakland"));
            //Authors.Add(new Author("238-95-7766", "Cheryl", "Carson", "415 548 7723", "Berekley"));
            //Authors.Add(new Author("267-41-2394", "Michael", "O'Leary", "408 286 2428", "San Jose"));
            //Authors.Add(new Author("274-80-9391", "Dean", "Straight", "415 834 2919", "Oakland"));

            Authors.Add(new Author(172321176, "Johnson", "White", "johnson.white@gmail.com" , 11000 , "408 496 7223", "Menlo Park"));
            Authors.Add(new Author(213468915, "Marjorie", "Green", "marjorie.green@gmail.com", 22000, "415 986 7020", "Oakland"));
            Authors.Add(new Author(238957766, "Cheryl", "Carson", "cheryl.carson@gmail.com", 39000 , "415 548 7723", "Berekley"));
            Authors.Add(new Author(267412394, "Michael", "O'Leary", "michael.oleary@gmail.com", 31000 ,  "408 286 2428", "San Jose"));
            Authors.Add(new Author(274809391, "Dean", "Straight", "dean.straight@gmail.com", 29000 , "415 834 2919", "Oakland"));
        }

        public System.Collections.Generic.List<Author> GetAuthors()
        {
            return Authors;
        }

        public Author GetAuthorById(int authorId)
        {
            return Authors.Where(current => current.AuthorId == authorId).FirstOrDefault();
        }

        public System.DateTime GetCreationDate()
        {
            return CreationDate;
        }


        public string GetVersion()
        {
            return "v1";
        }

        public async System.Threading.Tasks.Task<bool> SaveAuthorAsync(Data.Author author)
        {
            //author.AuthorId = GetNewAuthor();
            Authors.Add(author);
            return await System.Threading.Tasks.Task.FromResult(true);
        }

        public bool SaveAuthor(Data.Author author)
        {
            Authors.Add(author);
            return true;
        }

        public int GetNewAuthorId()
        {
            string id;
            int authorId;
            System.Random random = new System.Random();
            id = random.Next(100, 1000).ToString();
            id += random.Next(10, 100).ToString();
            id += random.Next(1000, 10000).ToString();

            authorId = System.Convert.ToInt32(id);

            return authorId;
        }

        public async System.Threading.Tasks.Task<bool> DeleteAuthorAsync(string authorId)
        {
            return await System.Threading.Tasks.Task.FromResult(true);
        }

    }

}
