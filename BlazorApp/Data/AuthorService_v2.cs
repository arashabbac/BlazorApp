//using System.Linq;

//namespace BlazorApp.Data
//{
//    public class AuthorService_v2 : object, IAuthorService
//    {
//        System.DateTime CreationDate { get; set; }
//        System.Collections.Generic.List<Author> Authors { get; set; }

//        public AuthorService_v2()
//        {
//            CreationDate = System.DateTime.Now;

//            Authors = new System.Collections.Generic.List<Author>();

//            Authors.Add(new Author("172-32-1176", "Johnson", "White", "408 496 7223", "Menlo Park"));
//            Authors.Add(new Author("213-46-8915", "Marjorie", "Green", "415 986 7020", "Oakland"));
//            Authors.Add(new Author("238-95-7766", "Cheryl", "Carson", "415 548 7723", "Berekley"));
//            Authors.Add(new Author("267-41-2394", "Michael", "O'Leary", "408 286 2428", "San Jose"));
//            Authors.Add(new Author("274-80-9391", "Dean", "Straight", "415 834 2919", "Oakland"));
//        }

//        public System.Collections.Generic.List<Author> GetAuthors()
//        {
//            return Authors;
//        }

//        public Author GetAuthorById(string authorId)
//        {
//            return Authors.Where(current => current.AuthorId == authorId).FirstOrDefault();
//        }

//        public System.DateTime GetCreationDate()
//        {
//            return CreationDate;
//        }

//        public string GetVersion()
//        {
//            return "v2";
//        }
//    }

//}
