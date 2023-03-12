using AutoMapper;
using OnlineBookStroe.Dtos;
using OnlineBookStroe.Model;

namespace OnlineBookStroe.Profiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<BookForCreateDto, Book>();

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName, source => source.MapFrom(
                   s => s.Author.AuthorName))
                .ForMember(dest => dest.CategoryName, source => source.MapFrom(
                   s => s.Category.CategoryName));
                



            CreateMap<Category, CategoryWithoutBook>();

            CreateMap<Category, CategoryWithBook>()
                .ForMember(dest => dest.books, source => source.MapFrom(
                   s => s.Books));

            CreateMap<Author, AuthorWithoutBook>();

            CreateMap<Author, AuthorWithBook>()
                .ForMember(dest => dest.books, source => source.MapFrom(
                   s => s.books));


            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.BookName, source => source.MapFrom(
                   s => s.Book.Name))
                .ForMember(dest => dest.BookPrice, source => source.MapFrom(
                   s => s.Book.Price))
                .ForMember(dest => dest.BookImagePath, source => source.MapFrom(
                   s => s.Book.ImagePath));
        }
    }
}