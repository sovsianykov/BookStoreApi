using System;
using MyWebApi.Application;
using MyWebApi.Application.Models;
namespace MyWebApi.Application
{
	public interface IBookStorage
	{
		List<BookDto> Books { get;}
	}
}

public class BookStorage : IBookStorage
{
    public  List<BookDto> Books => new List<BookDto>
        {
            new BookDto(1,"Title1","Lorem Author"),
            new BookDto(2,"Title2","Lorem Author"),
            new BookDto(3,"Title3","Lorem Author"),
            new BookDto(4,"Title4","Lorem Author"),
            new BookDto(5,"Title5","Lorem Author"),
            new BookDto(6,"Title6","Lorem Author"),
        };

}
