# Intership Application Task (BookStore_App)

is made by Damjan Krstevski. 
___

##  Description of the Application 

#### This Application will serve as a platform for customers to browse and purchase books. It will also provide an administration interface for managing the inventory, authors, and customer orders. The application will help streamline the operations of the bookstore, making it easier to track sales, manage stock, and provide a user-friendly interface for customers to discover and purchase books.

<ins> BookStoreApp consists of six Class Libraries. That's are: </ins>

 - BookStoreApp.Domain
 - BookStoreApp.DataAccess
 - BookStoreApp.DTOs
 - BookStoreApp.Helpers
 - BookStoreApp.Mappers
 - BookStoreApp.Services

 ___

 ## BookStoreApp.Domain

We will start with Domain Models first. In the First Class Library we have two Folders. The first one is for Enums which are part of the Domain Models and the second one are basically the Models which we are working on. In our Application we have three Domain Models. <ins> That's are :  **Author**, **Book** *and* **Customer** </ins> and they are in a Relationship each other.

### Here are the relationships between the Book, Author, and Customer entities:

1. Book and Author Relationship:

One Author can write multiple Books, but each Book is written by only one Author. This creates a one-to-many relationship between Authors and Books.

```
  public class Author
   {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	   
	[Required]
	public string FirstName { get; set; } = string.Empty;

	[Required]
	public string LastName { get; set; } = string.Empty;
		
	public string? City { get; set; }

	public string? State { get; set; }


	public List<Book> Books = new List<Book>();
   }

```

```
    public class Book 
    {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	    
	[Required]
	public string? Title { get; set; }

	[Required]
	public int ISBN { get; set; }

	[Required]
	public Genre Genre { get; set; }

	[ForeignKey("Author")]
	public int AuthorId { get; set; }

	public Author? Author { get; set; }

	public List<BookCustomer> BookCustomers = new List<BookCustomer>();
   }

```

2. Customer and Book Relationship

Many customers can purchase multiple books, and each book can be purchased by multiple customers. This creates a many-to-many relationship between Customers and Books. Because here we have Many-to-Many Relationship we create a Junction Table which contains the Primary Key Columns of this two models.

```
    public class Book 
    {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	    
	[Required]
	public string? Title { get; set; }

	[Required]
	public int ISBN { get; set; }

	[Required]
	public Genre Genre { get; set; }

	[ForeignKey("Author")]
	public int AuthorId { get; set; }

	public Author? Author { get; set; }

	public List<BookCustomer> BookCustomers = new List<BookCustomer>();
   }

```

```
    public class Customer 
   {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	   
	[Required]
	public string FirstName { get; set; } = string.Empty;

	[Required]
	public string LastName { get; set; } = string.Empty;

	public string? Address { get; set; }

	public List<BookCustomer> BookCustomers = new List<BookCustomer>();
   }
```

## BookStoreApp.DataAccess

DataAccess plays a major rule and it is a crucial component for interacting with databases or other data sources. Data access refers to the process of retrieving, manipulating, and persisting data from various sources, such as databases, external services, or file systems. Also we have a Repositories which contain all CRUD Operations that we need to manipulate with our Database.

## BookStoreApp.DTOs

DTOs help us to seperate the internal data model of an application from the data that is exposed through the API. This separation allows us to tailor the data sent to and received from the API endpoints to the specific needs of the Client. For each Domain Model we additionally created DTOs where we will use them further in the Services and in the Controllers. 

## BookStoreApp.Helpers

Helper methods help us to organize our code better. In this Class Library I have registered my DbContext, Repositories and Services in order to inject them into the Program.cs where the main application resides.


## BookStoreApp.Mappers

Mappers allows us to make Data Transformation or to convert data from one to another format. That means that this transformation can include mapping database entities to DTOs, mapping request data to domain objects, or formatting data for presentation in responses.

## BookStoreApp.Services

In this Class Library we have the whole Business Logic of the Application. That means that they can provide a good way to organize and manage the functionality that the API offers to Clients.

## BookStore_App

Controllers play a fundamental rule in our Application and they are responsible for receiving HTTP Requests from Clients and at the same time they handle properly our Requests.







 


